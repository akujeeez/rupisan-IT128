using BlogDataLibrary.Database;
using BlogDataLibrary.Models;

namespace BlogDataLibrary.Data
{
    public class SqlData
    {
        private ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public List<UserModel> GetAllUsers()
        {
            string sql = "SELECT * FROM dbo.Users";
            return _db.LoadData<UserModel, dynamic>(sql, new { }, connectionStringName, false);
        }

        public UserModel GetUser(string userName, string password)
        {
            string sql = "SELECT * FROM dbo.Users WHERE UserName = @UserName AND Password = @Password";
            return _db.LoadData<UserModel, dynamic>(sql, new { UserName = userName, Password = password }, connectionStringName, false).FirstOrDefault();
        }

        public void CreateUser(UserModel user)
        {
            string sql = "INSERT INTO dbo.Users (UserName, FirstName, LastName, Password) VALUES (@UserName, @FirstName, @LastName, @Password)";
            _db.SaveData(sql, user, connectionStringName, false);
        }

        public List<ListPostModel> GetAllPosts()
        {
            string sql = "SELECT p.Id, p.Title, p.Body, p.DateCreated, u.UserName, u.FirstName, u.LastName FROM dbo.Posts p INNER JOIN dbo.Users u ON p.UserId = u.Id";
            return _db.LoadData<ListPostModel, dynamic>(sql, new { }, connectionStringName, false);
        }

        public PostModel GetPost(int id)
        {
            string sql = "SELECT * FROM dbo.Posts WHERE Id = @Id";
            return _db.LoadData<PostModel, dynamic>(sql, new { Id = id }, connectionStringName, false).FirstOrDefault();
        }

        public void CreatePost(PostModel post)
        {
            string sql = "INSERT INTO dbo.Posts (UserId, Title, Body, DateCreated) VALUES (@UserId, @Title, @Body, @DateCreated)";
            _db.SaveData(sql, post, connectionStringName, false);
        }
    }
}