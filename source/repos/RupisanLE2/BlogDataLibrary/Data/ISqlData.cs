using BlogDataLibrary.Models;

namespace BlogDataLibrary.Data
{
    public interface ISqlData
    {
        void AddPost(PostModel post);
        UserModel Authenticate(string username, string password);
        void CreatePost(PostModel post);
        void CreateUser(UserModel user);
        List<ListPostModel> GetAllPosts();
        List<UserModel> GetAllUsers();
        PostModel GetPost(int id);
        UserModel GetUser(string userName, string password);
        List<ListPostModel> ListPosts();
        void Register(string username, string firstName, string lastName, string password);
        ListPostModel ShowPostDetails(int id);
    }
}