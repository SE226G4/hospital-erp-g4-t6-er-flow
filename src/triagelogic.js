export const classifyPatientTriage = (isConscious, pulseRate, isBedAvailable) => {
    // 1. معالجة الحالة الحرجة (فصل الشرط لتقليل التعقيد)
    const isCritical = !isConscious || pulseRate < 40 ||  pulseRate > 130;
    
    if (isCritical) {
        return isBedAvailable ? "توجيه فوري للسرير" : "تنبيه طوارئ للطاقم";
    }

    // 2. معالجة الحالة المتوسطة
    if (pulseRate >= 100 && pulseRate <= 130) {
        return "إضافة لقائمة الانتظار المتوسطة";
    }

    // 3. الحالة الافتراضية (البسيطة)
    return "تصنيف كحالة بسيطة";
};
//Refactor