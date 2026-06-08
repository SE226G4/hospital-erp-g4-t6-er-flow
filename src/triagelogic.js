/**
 * هذا التابع يقوم بتصنيف الحالة بناءً على المعايير المذكورة في نص الموديل 6
 * التعقيد الحلقي (CC) لهذه الدالة هو 4 (3 نقاط قرار + 1)
 */
module.exports={classifyPatientTriage};
//export const classifyPatientTriage = (isConscious, pulseRate, isBedAvailable) => {
    // مسار 1: الحالة الحرجة (إذا كان فاقد للوعي أو النبض خارج النطاق)
    if (!isConscious || pulseRate < 40 || pulseRate > 130) {
        // مسار 2: هل يوجد سرير؟
        if (isBedAvailable) {
            return "توجيه فوري للسرير";
        } else {
            return "تنبيه طوارئ للطاقم";
        }
    } 
    // مسار 3: الحالة المتوسطة
    else if (pulseRate >= 100 && pulseRate <= 130) {
        return "إضافة لقائمة الانتظار المتوسطة";
    } 
    // مسار 4: الحالة البسيطة
    else {
        return "تصنيف كحالة بسيطة";
    }
;