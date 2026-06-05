using Xunit;
using HospitalERP.Emergency;

namespace HospitalERP.Tests
{
    public class EmergencyFlowManagerTests
    {
        private readonly EmergencyFlowManager _manager;

        public EmergencyFlowManagerTests()
        {
            _manager = new EmergencyFlowManager();
        }

        [Theory]
        [InlineData(75, 120, false, false, "Critical (Level 1)")]
        [InlineData(130, 80, true, false, "Urgent (Level 2)")]
        [InlineData(130, 110, true, false, "Delayed (Level 3)")]
        [InlineData(80, 170, true, false, "Delayed (Level 3)")]
        [InlineData(80, 120, true, false, "Standard (Level 4)")]
        public void TriagePatient_ShouldReturnExpectedPriority(int heartRate, int systolicBP, bool isConscious, bool hasSevereBleeding, string expectedPriority)
        {
            string actualPriority = _manager.TriagePatient(heartRate, systolicBP, isConscious, hasSevereBleeding);
            Assert.Equal(expectedPriority, actualPriority);
        }
    }
}