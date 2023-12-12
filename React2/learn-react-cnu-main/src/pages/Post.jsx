import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

export default function Post() {
  const [post, setPost] = useState({});
  const { id } = useParams();

  useEffect(() => {
    fetch("https://jsonplaceholder.typicode.com/posts/" + id)
      .then((response) => response.json())
      .then((json) => setPost(json));
  }, []);

  return <div>{post.title}</div>;
}
