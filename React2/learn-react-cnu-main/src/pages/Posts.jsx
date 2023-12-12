import PostCard from "../components/PostCard";
import useFetch from "../hooks/useFetch";

export default function Posts() {
  const {
    data: posts,
    loading,
    error,
  } = useFetch("https://jsonplaceholder.typicode.com/posts");

  return (
    <div>
      <h1>posts</h1>
      <div className="flex flex-wrap gap-4">
        {loading ? (
          <span>Loading....</span>
        ) : error ? (
          <span>Oops, some error: {error}</span>
        ) : (
          Array.isArray(posts) &&
          posts.map((post) => <PostCard post={post} key={post.id} />)
        )}
      </div>
    </div>
  );
}
