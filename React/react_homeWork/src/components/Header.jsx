import React, { useState, useEffect, createContext, useContext } from 'react';

export default function Header() {

    const [userData, setUserData] = useState({});

    useEffect(() => {

      const fetchUserData = async () => {
          const response = await fetch('https://api.github.com/users/Castomery');
          const data = await response.json();
          setUserData({ name: data.name, photo: data.avatar_url });
      };
  
      fetchUserData();
    }, []);

    return (
        <div>
            <nav className='flex bg-orange-200 item-center p-4 gap-4'>
                <div className='flex gap-4'>
                    <img className='h-12 w-12 rounded-full items-center' src={!!userData && userData.photo} alt='' />
                    <span className='text-3xl'>{!!userData && userData.name}</span>
                </div>
            </nav>
        </div>
    )
}