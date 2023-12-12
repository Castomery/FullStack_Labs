import { useEffect, useState } from "react";

export default function Home() {
  const [weather, setWeather] = useState(null);

  useEffect(() => {
    const coords = "latitude=52.52&longitude=13.41";
    const getWeather = async () => {
      const response = await fetch(
        `https://api.open-meteo.com/v1/forecast?${coords}&current=temperature_2m,windspeed_10m&hourly=temperature_2m,relativehumidity_2m,windspeed_10m`
      );
      const data = await response.json();
      setWeather(data);
    };
    getWeather();
  }, []);

  return (
    <>
      <div>
        <h1>Current Weather</h1>
        {!!weather && <div>{weather.current.temperature_2m} C</div>}
      </div>
    </>
  );
}
