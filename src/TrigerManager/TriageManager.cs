using System;
using System.Security;

namespace EmergencyFlow
{
    public class TriageManager
    {
        public string ClassifyPatientTriage(bool isConscious, int pulseRate)
        {
            if (!isConscious || IsPulseCritical(pulseRate)) return  "Critical" ;
           
            if (IsPluseMedium(pulseRate)) return "Medium" ;

            else return "Low";

        }

        private static bool IsPulseCritical(int pulseRate) => pulseRate < 40 || pulseRate > 130; 
        private static bool IsPluseMedium(int pulseRate) => pulseRate >= 100 && pulseRate <= 130;

        public string CheckBedAvailability(string triageLevel, bool isBedAvailable)
        {
            if (triageLevel == "Critical")
            
                return isBedAvailable 
                       ? "Direct to Available Bed Immediately" 
                       : "ALERT: No Bed Available! Issue Emergency Notification";
        
            else if (triageLevel == "Medium" && !isBedAvailable)
            
                return "Place Patient in ER Waiting Queue";
            
            else
            
                return "Standard ER Process";
            
        }
    }
}