using System.Collections.Generic;

namespace BedLibrary
{
    public class BedSystem
    {
        public class HospitalBed
        {
            public int BedId { get; set; }
            public string Department { get; set; }
            public bool IsAvailable { get; set; }  
            public int EquipmentLevel { get; set; } 
        }

        /// <summary>
        /// التابع بعد الـ Refactoring (التعقيد السيكلوماتيكي CC أصبح 3 بدلاً من 4)
        /// </summary>
        public HospitalBed FindSuitableBedFast(List<HospitalBed> sortedBeds, int requiredEquipment)
        {
            int low = 0;
            int high = sortedBeds.Count - 1;
            HospitalBed optimalBed = null;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                HospitalBed midBed = sortedBeds[mid];

                // شرط واحد مدمج وذكي للبحث السريع
                if (midBed.EquipmentLevel >= requiredEquipment && midBed.IsAvailable)
                {
                    optimalBed = midBed; 
                    high = mid - 1;     // تقليص النطاق للبحث عن الأنسب تماماً تلافياً لهدر الأسرة عالية الكفاءة
                }
                else
                {
                    // دمج الحالات: لو التجهيز أقل، أو التجهيز كافٍ لكن السرير مشغول
                    // في الحالتين نتحرك للأعلى لأن المصفوفة مرتبة تصاعدياً
                    low = mid + 1; 
                }
            }

            return optimalBed; 
        }
    }
}
