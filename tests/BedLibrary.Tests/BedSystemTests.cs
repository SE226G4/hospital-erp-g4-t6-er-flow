using Xunit;
using BedLibrary;
using System.Collections.Generic;

namespace BedLibrary.Tests
{
    public class BedSystemTests
    {
        // الحالة الأولى: العثور على سرير مطابق ومتاح تماماً
        [Fact]
        public void FindSuitableBedFast_ExactMatchAvailable_ReturnsCorrectBed()
        {
            // 1. Arrange (تهيئة المعطيات)
            var bedSystem = new BedSystem();
            var sortedBeds = new List<BedSystem.HospitalBed>
            {
                new BedSystem.HospitalBed { BedId = 1, Department = "ER", EquipmentLevel = 1, IsAvailable = true },
                new BedSystem.HospitalBed { BedId = 2, Department = "ICU", EquipmentLevel = 2, IsAvailable = true },
                new BedSystem.HospitalBed { BedId = 3, Department = "ICU", EquipmentLevel = 3, IsAvailable = true }
            };
            int requiredEquipment = 2;

            // 2. Act (تنفيذ الوظيفة)
            var result = bedSystem.FindSuitableBedFast(sortedBeds, requiredEquipment);

            // 3. Assert (التحقق من صحة النتيجة)
            Assert.NotNull(result);
            Assert.Equal(2, result.BedId);
            Assert.Equal(2, result.EquipmentLevel);
        }

        // الحالة الثانية: السرير المطابق مشغول، فيأخذ التجهيز الأعلى المتاح
        [Fact]
        public void FindSuitableBedFast_HigherMatchAvailable_ReturnsCorrectBed()
        {
            // 1. Arrange
            var bedSystem = new BedSystem();
            var sortedBeds = new List<BedSystem.HospitalBed>
            {
                new BedSystem.HospitalBed { BedId = 1, Department = "ER", EquipmentLevel = 1, IsAvailable = true },
                new BedSystem.HospitalBed { BedId = 2, Department = "ICU", EquipmentLevel = 2, IsAvailable = false }, // غير متاح
                new BedSystem.HospitalBed { BedId = 3, Department = "ICU", EquipmentLevel = 3, IsAvailable = true }  // متاح وأعلى كفاءة
            };
            int requiredEquipment = 2;

            // 2. Act
            var result = bedSystem.FindSuitableBedFast(sortedBeds, requiredEquipment);

            // 3. Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.BedId); 
        }

        // الحالة الثالثة: عدم وجود سرير يلبي أو يتجاوز مستوى التجهيز المطلوب
        [Fact]
        public void FindSuitableBedFast_NoSufficientEquipment_ReturnsNull()
        {
            // 1. Arrange
            var bedSystem = new BedSystem();
            var sortedBeds = new List<BedSystem.HospitalBed>
            {
                new BedSystem.HospitalBed { BedId = 1, Department = "ER", EquipmentLevel = 1, IsAvailable = true },
                new BedSystem.HospitalBed { BedId = 2, Department = "ER", EquipmentLevel = 2, IsAvailable = true }
            };
            int requiredEquipment = 3; 

            // 2. Act
            var result = bedSystem.FindSuitableBedFast(sortedBeds, requiredEquipment);

            // 3. Assert
            Assert.Null(result);
        }
    }
}
