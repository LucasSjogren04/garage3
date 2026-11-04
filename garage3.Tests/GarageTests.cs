using garage3;
using garage3.Interfaces;
using garage3.Vehicles;

namespace garage3.Tests
{
    public class GarageTests
    {
        [Fact]
        public void Constructor_CapacityGiven_CapacityIsSet()
        {
            // Arrange
            int capacity = 5;

            // Act
            Garage<IVehicle> garage = new Garage<IVehicle>(capacity);

            // Assert
            Assert.Equal(5, garage.GetCapacity());
        }

        [Fact]
        public void Constructor_ZeroCapacity_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int capacity = 0;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Garage<IVehicle>(capacity));
        }

        [Fact]
        public void CountVehicles_NewGarage_ReturnsZero()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);

            // Act
            int count = garage.CountVehicles();

            // Assert
            Assert.Equal(0, count);
        }

        [Fact]
        public void CountVehicles_TwoVehiclesParked_ReturnsTwo()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            garage.Park(new Car("ABC123", "Red", 4, "Gasoline"));
            garage.Park(new Bus("BUS123", "Yellow", 6, 50));

            // Act
            int count = garage.CountVehicles();

            // Assert
            Assert.Equal(2, count);
        }

        [Fact]
        public void IsFull_SpotsLeft_ReturnsFalse()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(2);
            garage.Park(new Car("ABC123", "Red", 4, "Gasoline"));

            // Act
            bool isFull = garage.IsFull();

            // Assert
            Assert.False(isFull);
        }

        [Fact]
        public void IsFull_AllSpotsTaken_ReturnsTrue()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(1);
            garage.Park(new Car("ABC123", "Red", 4, "Gasoline"));

            // Act
            bool isFull = garage.IsFull();

            // Assert
            Assert.True(isFull);
        }

        [Fact]
        public void Park_EmptyGarage_ReturnsTrueAndVehicleIsParked()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            Car car = new Car("ABC123", "Red", 4, "Gasoline");

            // Act
            bool parked = garage.Park(car);

            // Assert
            Assert.True(parked);
            Assert.Same(car, garage.FindVehicle("ABC123"));
        }

        [Fact]
        public void Park_FullGarage_ReturnsFalse()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(1);
            garage.Park(new Car("ABC123", "Red", 4, "Gasoline"));

            // Act
            bool parked = garage.Park(new Car("XYZ789", "Blue", 4, "Diesel"));

            // Assert
            Assert.False(parked);
            Assert.Equal(1, garage.CountVehicles());
        }

        [Fact]
        public void Park_SamePlateAlreadyParked_ReturnsFalse()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            garage.Park(new Car("ABC123", "Red", 4, "Gasoline"));

            // Act
            bool parked = garage.Park(new Motorcycle("ABC123", "Black", 2, 600));

            // Assert
            Assert.False(parked);
            Assert.Equal(1, garage.CountVehicles());
        }

        [Fact]
        public void Park_SamePlateInLowerCase_ReturnsFalse()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            garage.Park(new Car("ABC123", "Red", 4, "Gasoline"));

            // Act
            bool parked = garage.Park(new Car("abc123", "Blue", 4, "Diesel"));

            // Assert
            Assert.False(parked);
        }

        [Fact]
        public void Remove_ParkedVehicle_ReturnsTrueAndVehicleIsGone()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            garage.Park(new Car("ABC123", "Red", 4, "Gasoline"));

            // Act
            bool removed = garage.Remove("ABC123");

            // Assert
            Assert.True(removed);
            Assert.Null(garage.FindVehicle("ABC123"));
            Assert.Equal(0, garage.CountVehicles());
        }

        [Fact]
        public void Remove_PlateNotParked_ReturnsFalse()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            garage.Park(new Car("ABC123", "Red", 4, "Gasoline"));

            // Act
            bool removed = garage.Remove("XYZ789");

            // Assert
            Assert.False(removed);
            Assert.Equal(1, garage.CountVehicles());
        }

        [Fact]
        public void Remove_PlateInMixedCase_ReturnsTrue()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            garage.Park(new Car("ABC123", "Red", 4, "Gasoline"));

            // Act
            bool removed = garage.Remove("AbC123");

            // Assert
            Assert.True(removed);
        }

        [Theory]
        [InlineData("ABC123")]
        [InlineData("Abc123")]
        [InlineData("AbC123")]
        [InlineData("abc123")]
        public void FindVehicle_AnyLetterCase_ReturnsVehicle(string searchPlate)
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            Car car = new Car("ABC123", "Red", 4, "Gasoline");
            garage.Park(car);

            // Act
            IVehicle? found = garage.FindVehicle(searchPlate);

            // Assert
            Assert.Same(car, found);
        }

        [Fact]
        public void FindVehicle_PlateNotParked_ReturnsNull()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            garage.Park(new Car("ABC123", "Red", 4, "Gasoline"));

            // Act
            IVehicle? found = garage.FindVehicle("XYZ789");

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void GetEnumerator_TwoVehiclesParked_ForeachReturnsBoth()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);
            Car car = new Car("ABC123", "Red", 4, "Gasoline");
            Boat boat = new Boat("SEA555", "Blue", 0, 8);
            garage.Park(car);
            garage.Park(boat);

            // Act
            List<IVehicle> result = new List<IVehicle>();
            foreach (IVehicle vehicle in garage)
            {
                result.Add(vehicle);
            }

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(car, result);
            Assert.Contains(boat, result);
        }

        [Fact]
        public void GetEnumerator_EmptyGarage_ForeachReturnsNothing()
        {
            // Arrange
            Garage<IVehicle> garage = new Garage<IVehicle>(3);

            // Act
            int count = 0;
            foreach (IVehicle vehicle in garage)
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }

        [Fact]
        public void Park_GarageOfCars_OnlyAcceptsCars()
        {
            // Arrange
            Garage<Car> garage = new Garage<Car>(2);

            // Act
            bool parked = garage.Park(new Car("ABC123", "Red", 4, "Gasoline"));

            // Assert
            Assert.True(parked);
            Assert.IsType<Car>(garage.FindVehicle("ABC123"));
        }
    }
}
