using Xunit;
using EmergencyLibrary;

namespace EmergencyLibrary.Tests
{
    public class EmergencyRoutingTests
    {
        private readonly EmergencyFlowSystem _flowSystem = new EmergencyFlowSystem();

        [Fact]
        public void Test_CriticalPatient_With_AvailableBed()
        {
            string result = _flowSystem.ProcessEmergencyRouting(3, true, 5, false);
            Assert.Equal("توجيه فوري إلى السرير المتاح في قسم الطوارئ.", result);
        }

        [Fact]
        public void Test_CriticalPatient_NoBed_ChronicDisease()
        {
            string result = _flowSystem.ProcessEmergencyRouting(3, false, 5, true);
            Assert.Equal("تنبيه خطر: إخلاء سرير مريض مستقر فوراً ونقل الحالة الحرجة إليه.", result);
        }

        [Fact]
        public void Test_RoutinePatient()
        {
            string result = _flowSystem.ProcessEmergencyRouting(1, false, 5, false);
            Assert.Equal("توجيه المريض إلى العيادات الخارجية التابعة للطوارئ.", result);
        }
    }
}