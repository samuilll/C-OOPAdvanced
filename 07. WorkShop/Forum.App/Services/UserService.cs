using Forum.App.Contracts;
using Forum.Data;
using Forum.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.Services
{
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
            User user = this.forumData.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("Cannot get the username!");
            }

            return user;
        }

        public string GetUserName(int userId)
        {
            User user = this.forumData.Users.FirstOrDefault(u => u.Id == userId);

            if (user==null)
            {
                throw new ArgumentException("Cannot get the username!");
            }

            return user.Username;
        }

        public bool TryLogInUser(string username, string password)
        {
            bool invalidUsername = string.IsNullOrWhiteSpace(username);
            bool invalidPassword = string.IsNullOrWhiteSpace(password);

            if (invalidUsername||invalidPassword)
            {
                return false;
            }

            User user = this.forumData.Users.FirstOrDefault(u=>u.Username==username&&u.Password==password);

            if (user==null)
            {
                return false;
            }

            session.Reset();
            session.LogIn(user);

            return true;
        }

        public bool TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrEmpty(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrEmpty(password) && password.Length > 3;

            if (!validUsername||!validPassword)
            {
                throw new ArgumentException("Username and password must be more than 3 symbols!"); 
            }

            bool userAlreadyExist = this.forumData.Users.Any(u => u.Username == username);

            if (userAlreadyExist)
            {
                throw new Exception("Username taken!");
            }

            int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;

            User user = new User(userId,username,password);

            forumData.Users.Add(user);
            forumData.SaveChanges();

            this.TryLogInUser(username, password);

            return true;
        }
    }
}
