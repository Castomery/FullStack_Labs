/* eslint-disable react/prop-types */
import { Link } from "react-router-dom";

export default function PostCard({ post }) {
  return (
    <Link
      to={`/posts/${post.id}`}
      className="border w-80 bg-slate-400 p-3 rounded-xl"
    >
      <h1>{post.title}</h1>
    </Link>
  );
}
