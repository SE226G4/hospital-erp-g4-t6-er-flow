using Xunit;
using EmergencyFlow;

namespace EmergencyFlow.Tests
{
    public class TriageManagerTests
    {
        [Fact]
        public void ClassifyPatientTriage_Unconscious_ReturnsCritical()
        {
            // Arrange
            var manager = new TriageManager();
            bool isConscious = false;
            int pulseRate = 75;

            // Act
            string result = manager.ClassifyPatientTriage(isConscious, pulseRate);

            // Assert
            Assert.Equal("Critical", result);
        }

        [Fact]
        public void ClassifyPatientTriage_PulseMedium_ReturnsMedium()
        {
            // Arrange
            var manager = new TriageManager();
            bool isConscious = true;
            int pulseRate = 110;

            // Act
            string result = manager.ClassifyPatientTriage(isConscious, pulseRate);

            // Assert
            Assert.Equal("Medium", result);
        }

        [Fact]
        public void ClassifyPatientTriage_NormalCase_ReturnsLow()
        {
            // Arrange
            var manager = new TriageManager();
            bool isConscious = true;
            int pulseRate = 75;

            // Act
            string result = manager.ClassifyPatientTriage(isConscious, pulseRate);

            // Assert
            Assert.Equal("Low", result);
        }

        [Fact]
        public void CheckBedAvailability_CriticalAndAvailable_DirectToBed()
        {
            // Arrange
            var manager = new TriageManager();
            string triageLevel = "Critical";
            bool isBedAvailable = true;

            // Act
            string result = manager.CheckBedAvailability(triageLevel, isBedAvailable);

            // Assert
            Assert.Equal("Direct to Available Bed Immediately", result);
        }

        [Fact]
        public void CheckBedAvailability_CriticalAndNoBed_AlertIssued()
        {
            // Arrange
            var manager = new TriageManager();
            string triageLevel = "Critical";
            bool isBedAvailable = false;

            // Act
            string result = manager.CheckBedAvailability(triageLevel, isBedAvailable);

            // Assert
            Assert.Equal("ALERT: No Bed Available! Issue Emergency Notification", result);
        }
    }
}