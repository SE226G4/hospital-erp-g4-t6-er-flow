using System;

namespace HospitalERP.Emergency
{
    public class EmergencyFlowManager
    {
        public string TriagePatient(int heartRate, int systolicBP, bool isConscious, bool hasSevereBleeding)
        {
            if (!isConscious || hasSevereBleeding)
            {
                return "Critical (Level 1)";
            }

            return EvaluateVitalSigns(heartRate, systolicBP);
        }

        private string EvaluateVitalSigns(int heartRate, int systolicBP)
        {
            if (heartRate > 120 || heartRate < 50)
            {
                return (systolicBP < 90) ? "Urgent (Level 2)" : "Delayed (Level 3)";
            }

            return (systolicBP > 160) ? "Delayed (Level 3)" : "Standard (Level 4)";
        }
    }
}