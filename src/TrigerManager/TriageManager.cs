using System;

namespace EmergencyFlow
{
    public class TriageManager
    {
        public string ClassifyPatientTriage(bool isConscious, int pulseRate)
        {
            if (!isConscious || pulseRate < 40 || pulseRate > 130)
            {
                return "Critical";
            }
            else if (pulseRate >= 100 && pulseRate <= 130)
            {
                return "Medium";
            }
            else
            {
                return "Low";
            }
        }

        public string CheckBedAvailability(string triageLevel, bool isBedAvailable)
        {
            if (triageLevel == "Critical" && isBedAvailable)
            {
                return "Direct to Available Bed Immediately";
            }
            else if (triageLevel == "Critical" && !isBedAvailable)
            {
                return "ALERT: No Bed Available! Issue Emergency Notification";
            }
            else if (triageLevel == "Medium" && !isBedAvailable)
            {
                return "Place Patient in ER Waiting Queue";
            }
            else
            {
                return "Standard ER Process";
            }
        }
    }
}