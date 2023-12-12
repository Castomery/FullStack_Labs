import { useEffect, useState } from "react";
import useDebounce from "../hooks/useDebounce";

const DebouncedInput = () => {
  const [inputValue, setInputValue] = useState("");

  const handleChange = (e) => {
    setInputValue(e.target.value);
  };

  //Uncomment this code to see how it works. The only thing you need to create is useDebounce hook
  const debouncedValue = useDebounce(inputValue, 2000);

  useEffect(() => {
    console.log(
      "Just for checking. This console must runs after 2 seconds of inactivity"
    );
  }, [debouncedValue]);

  return (
    <>
      <h1 className="text-3xl font-bold">Debounced Input</h1>
      <input
        value={inputValue}
        onChange={handleChange}
        className="p-4 rounded-lg border border-red-300 focus:outline-red-500"
      />
      <h3>
        Debounced means that value should update only after the delay - 2s in
        our case, but you can set any
      </h3>
    </>
  );
};

export default DebouncedInput;
