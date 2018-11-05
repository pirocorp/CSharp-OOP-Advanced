namespace Forum.App.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data;
    using DataModels;

    public class UserService : IUserService
    {
        private ForumData forumData;
        private ISession session;

        public UserService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public string GetUserName(int userId)
        {
            throw new NotImplementedException();
        }

        public bool TryLogInUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool TrySignUpUser(string username, string password)
        {
            var validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            var validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validUsername || !validPassword)
            {
                throw new ArgumentException($"Username and Password must be longer than 3 symbols!");
            }

            var userAlreadyExists = this.forumData.Users.Any(u => u.Username == username);

            if (userAlreadyExists)
            {
                throw new InvalidOperationException("Username taken!");
            }

            var userId = this.forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
            var user = new User(userId, username, password);

            this.forumData.Users.Add(user);
            this.forumData.SaveChanges();

            this.TryLogInUser(username, password);

            return true;
        }
    }
}