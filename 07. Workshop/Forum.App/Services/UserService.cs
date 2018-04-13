using static Forum.App.Controllers.SignUpController;
using System.Linq;
using System.Collections.Generic;

namespace Forum.App.Services
{
    public static class UserService
    {
        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            var validUserName = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            var validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;
            if (!validUserName || !validPassword)
            {
                return SignUpStatus.DetailsError;
            }

            var forumData = new ForumData();

            var userAlreadyExists = forumData.Users.Any(u => u.Username == username);

            if (!userAlreadyExists)
            {
                var id = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
                var user = new User(id, username, password, new List<int>());

                forumData.Users.Add(user);
                forumData.SaveChanges();

                return SignUpStatus.Success;
            }
            return SignUpStatus.UsernameTakenError;  
        }

        public static bool TryLogInUser(string username, string password)
        {
            var validUserName = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            var validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;
            if (!validUserName || !validPassword)
            {
                return false;
            }

            var forumData = new ForumData();

            var userExists = forumData.Users.Any(u => u.Username == username && u.Password == password);
            return userExists;
        }

        public static User GetUser(int id)
        {
            var forumData = new ForumData();
            var user = forumData.Users.Find(u => u.Id == id);
            return user;
        }

        public static User GetUser(string username, ForumData forumData)
        {
            var user = forumData.Users.Find(u => u.Username == username);
            return user;
        }
    }
}
