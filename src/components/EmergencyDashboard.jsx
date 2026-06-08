import React, { useState } from 'react';
// استيراد الدالة من ملفها الجديد
import { classifyPatientTriage } from '../path/to/triagelogic'; 

const EmergencyDashboard = () => {
  // إضافة State للمدخلات الجديدة المطلوبة للدالة
  const [isConscious, setIsConscious] = useState(true);
  const [pulseRate, setPulseRate] = useState(80);
  const [notes, setNotes] = useState('');
  
  const totalBeds = 30;
  const occupiedBeds = 22;
  const availableBeds = totalBeds - occupiedBeds;
  const isBedAvailable = availableBeds > 0;

  // استدعاء الدالة بناءً على الحالات الحالية
  const triageResult = classifyPatientTriage(isConscious, pulseRate, isBedAvailable);

  return (
    <div className="p-6 max-w-lg mx-auto bg-gray-50 rounded-xl shadow-lg">
      <div className="bg-red-700 p-6 rounded-t-xl text-white mb-4">
        <h2 className="text-xl font-bold mb-4">نظام التصنيف الطبي</h2>
        
        {/* مدخلات جديدة لاستخدام الدالة */}
        <div className="mb-4">
          <label>معدل النبض: </label>
          <input 
            type="number"
            className="text-black p-1 w-20 rounded"
            value={pulseRate}
            onChange={(e) => setPulseRate(Number(e.target.value))}
          />
        </div>
        
        <button 
          onClick={() => setIsConscious(!isConscious)}
          className={`p-2 rounded ${isConscious ? 'bg-green-500' : 'bg-gray-500'}`}
        >
          {isConscious ? 'واعي' : 'فاقد للوعي'}
        </button>
      </div>
      
      {/* عرض النتيجة */}
      <div className="bg-white p-4 rounded-b-xl border">
        <h3 className="font-bold text-lg mb-2">نتيجة التصنيف:</h3>
        <p className="text-blue-700 font-bold p-3 bg-blue-50 rounded">
          {triageResult}
        </p>
      </div>
    </div>
  );
};

export default EmergencyDashboard;