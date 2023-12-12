import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Home from "./pages/Home";
import Posts from "./pages/Posts";
import ContactUs from "./pages/ContactUs";
import Main from "./layouts/Main";
import Post from "./pages/Post";
import { useDarkTheme } from "./hooks/useDarkTheme";
import useDocumentTitle from"./hooks/useDocumentTitle"
const router = createBrowserRouter([
  {
    path: "/",
    element: <Main />,
    children: [
      {
        path: "/",
        element: <Home />,
      },
      {
        path: "/posts",
        element: <Posts />,
      },
      {
        path: "/posts/:id",
        element: <Post />,
      },
      {
        path: "/contact-us",
        element: <ContactUs />,
      },
    ],
  },
]);

function App() {
  useDarkTheme();
  useDocumentTitle("My new title");
  return (
    <div className="min-h-screen bg-slate-100 text-gray-800 dark:bg-slate-800 dark:text-orange-300">
      <RouterProvider router={router} />
    </div>
  );
}

export default App;
