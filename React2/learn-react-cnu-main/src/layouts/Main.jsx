import { Outlet } from "react-router-dom";
import Header from "../components/Header";

export default function Main() {
  return (
    <div>
      <Header />
      <div className="max-w-screen-lg mx-auto mt-4">
        <Outlet />
      </div>
    </div>
  );
}
