using System;
using System.Security;

namespace EmergencyFlow
{
    public enum TriageLevel
    {
        Low,
        Medium,
        Critical
    }
    public class TriageManager
    {
        public TriageLevel ClassifyPatientTriage(bool isConscious, int pulseRate)
        {
            if (!isConscious || IsPulseCritical(pulseRate)) 
                return  TriageLevel.Critical ;
           
            if (IsPluseMedium(pulseRate)) 
                return TriageLevel.Medium  ;

            return TriageLevel.Low ;

        }

        private static bool IsPulseCritical(int pulseRate) => pulseRate < 40 || pulseRate > 130; 
        private static bool IsPluseMedium(int pulseRate) => pulseRate >= 100 && pulseRate <= 130;

        public string CheckBedAvailability(TriageLevel triageLevel, bool isBedAvailable)
        {
            switch (triageLevel)
            {
                case TriageLevel.Critical:
                    return isBedAvailable 
                       ? "Direct to Available Bed Immediately" 
                       : "ALERT: No Bed Available! Issue Emergency Notification";

                case TriageLevel.Medium:
                    if (!isBedAvailable)
                        return "Place Patient in ER Waiting Queue";
                    return "Standard ER Process";
                        
                default:
                    return "Standard ER Process";
            
            }      
            
        }
    }
}