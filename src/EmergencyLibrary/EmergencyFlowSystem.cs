using System;

namespace EmergencyLibrary
{
    public class EmergencyFlowSystem
    {
        // =========================================================================
        // 1. التابع الأساسي (قبل التطوير) - قيمة التعقيد الحسابي CC = 6
        // =========================================================================
        public string ProcessEmergencyRouting(int triageLevel, bool isBedAvailable, int responseTimeMinutes, bool isChronic)
        {
            string decisionResult = "";

            if (triageLevel == 3 && isBedAvailable)
            {
                decisionResult = "توجيه فوري إلى السرير المتاح في قسم الطوارئ.";
            }
            else
            {
                if (triageLevel == 3 && !isBedAvailable)
                {
                    if (responseTimeMinutes > 15 || isChronic)
                    {
                        decisionResult = "تنبيه خطر: إخلاء سرير مريض مستقر فوراً ونقل الحالة الحرجة إليه.";
                    }
                    else
                    {
                        decisionResult = "إصدار تنبيه عاجل للإدارة الطبية لتأمين سرير إضافي خلال 5 دقائق.";
                    }
                }
                else
                {
                    if (triageLevel == 2)
                    {
                        if (isBedAvailable)
                        {
                            decisionResult = "نقل المريض إلى أسرة الملاحظة المؤقتة.";
                        }
                        else
                        {
                            decisionResult = "وضع المريض في قائمة الانتظار مع إعادة الفحص كل 15 دقيقة.";
                        }
                    }
                    else
                    {
                        decisionResult = "توجيه المريض إلى العيادات الخارجية التابعة للطوارئ.";
                    }
                }
            }

            return decisionResult;
        }

        // =========================================================================
        // 2. التابع المطور (بعد الـ Refactoring) - قيمة التعقيد الحسابي CC = 4
        // تم الاعتماد على أسلوب (Early Return) للتخلص من تداخل الشروط العميقة العشوائي
        // =========================================================================
        public string ProcessEmergencyRoutingRefactored(int triageLevel, bool isBedAvailable, int responseTimeMinutes, bool isChronic)
        {
            // أ. معالجة الحالات الحرجة جداً مع توفر سرير
            if (triageLevel == 3 && isBedAvailable)
            {
                return "توجيه فوري إلى السرير المتاح في قسم الطوارئ.";
            }

            // ب. معالجة الحالات الحرجة جداً عند عدم توفر سرير
            if (triageLevel == 3 && !isBedAvailable)
            {
                if (responseTimeMinutes > 15 || isChronic)
                {
                    return "تنبيه خطر: إخلاء سرير مريض مستقر فوراً ونقل الحالة الحرجة إليه.";
                }
                
                return "إصدار تنبيه عاجل للإدارة الطبية لتأمين سرير إضافي خلال 5 دقائق.";
            }

            // ج. معالجة الحالات المتوسطة الخطورة (Triage Level = 2)
            if (triageLevel == 2)
            {
                return isBedAvailable ? "نقل المريض إلى أسرة الملاحظة المؤقتة." 
                                    : "وضع المريض في قائمة الانتظار مع إعادة الفحص كل 15 دقيقة.";
            }

            // د. معالجة الحالات البسيطة أو الباردة (تلقائياً)
            return "توجيه المريض إلى العيادات الخارجية التابعة للطوارئ.";
        }
    }
}