import Header from "../components/Header";
import { Outlet } from "react-router-dom";


export default function Main() {
    return (
        <div className="h-full">
            <Header />
            <Outlet />
        </div>
    )
}
