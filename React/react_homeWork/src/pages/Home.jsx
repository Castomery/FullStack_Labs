import React, { useState } from 'react';
export default function Home() {
    const [formData, setFormData] = useState({
        name: '',
        message: '',
    });

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value,
        });
    };

    const handleFormSubmit = (e) => {
        e.preventDefault();
        console.log('Введені дані:', formData);
    };

    return (

        <div className='flex h-screen bg-orange-300'>
        <form onSubmit={handleFormSubmit} className='flex flex-col m-auto p-4 border-2 border-black'>
          <label className='mb-4 font-bold'>
            Ім'я:
            <input
              type="text"
              name="name"
              value={formData.name}
              onChange={handleInputChange}
              className=' w-60 flex gap-4 p-2 border-2'
            />
          </label>
  
          <label className='mb-4 font-bold'>
            Повідомлення:
            <textarea
              name="message"
              value={formData.message}
              onChange={handleInputChange}
              className='w-60 flex p-2 border-2'
            />
          </label>
  
          <button type="submit" className='p-2 bg-blue-500 text-white'>
            Відправити
          </button>
        </form>
      </div>
    );
}
