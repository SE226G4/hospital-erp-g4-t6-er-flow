using System;

namespace HospitalERP.Emergency
{
    public class EmergencyFlowManager
    {
        public string TriagePatient(int heartRate, int systolicBP, bool isConscious, bool hasSevereBleeding)
        {
            string priority = "Stable";

            if (!isConscious || hasSevereBleeding)
            {
                priority = "Critical (Level 1)";
            }
            else
            {
                if (heartRate > 120 || heartRate < 50)
                {
                    if (systolicBP < 90)
                    {
                        priority = "Urgent (Level 2)";
                    }
                    else
                    {
                        priority = "Delayed (Level 3)";
                    }
                }
                else
                {
                    if (systolicBP > 160)
                    {
                        priority = "Delayed (Level 3)";
                    }
                    else
                    {
                        priority = "Standard (Level 4)";
                    }
                }
            }

            return priority;
        }
    }
}