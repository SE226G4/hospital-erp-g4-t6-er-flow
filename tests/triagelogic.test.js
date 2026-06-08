const { classifyPatientTriage } = require("../src/triagelogic.js");

//import { classifyPatientTriage } from '../src/triagelogic.js';
module.exports={classifyPatientTriage};

describe('classifyPatientTriage', () => {
    
    // اختبار المسار 1 و 2 (الحالة الحرجة مع توفر سرير)
    test('يجب توجيه فوري للسرير إذا كان فاقد للوعي والسرير متاح', () => {
        expect(classifyPatientTriage(false, 80, true)).toBe("توجيه فوري للسرير");
    });

    // اختبار المسار 1 و 2 (الحالة الحرجة بدون سرير)
    test('يجب إرسال تنبيه طوارئ إذا كان النبض خارج النطاق ولا يوجد سرير', () => {
        expect(classifyPatientTriage(true, 150, false)).toBe("تنبيه طوارئ للطاقم");
    });

    // اختبار المسار 3 (الحالة المتوسطة)
    test('يجب تصنيف الحالة كمتوسطة إذا كان النبض بين 100 و 130', () => {
        expect(classifyPatientTriage(true, 110, true)).toBe("إضافة لقائمة الانتظار المتوسطة");
    });

    // اختبار المسار 4 (الحالة البسيطة)
    test('يجب تصنيف الحالة كبسيطة في المسار الافتراضي', () => {
        expect(classifyPatientTriage(true, 70, true)).toBe("تصنيف كحالة بسيطة");
    });
});