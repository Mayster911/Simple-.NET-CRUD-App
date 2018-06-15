using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekt.Models;
using Projekt.DAL;
using Projekt.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace Projekt.BL
{
    public class UserBL
    {
        public List<User> GetUsers(string username)
        {
            UserDAL db = new UserDAL();
            return db.UserDB.Where(x => x.userName == username).ToList(); // pobranie wszystkich użytkowników
        }

        public bool isValidUser(string userName, string password)
        {
            List<User> list = this.GetUsers(userName);
            string hashpw = CalculateMD5Hash(password);
            foreach (var user in list)
            {
                if (userName == user.userName && hashpw == user.pwHash)
                    return true;
            }
            return false;
        }

        public bool isUniqueName(string userName)
        {
            List<User> list = this.GetUsers(userName);
            foreach (var user in list)
            {
                if (userName == user.userName)
                    return false;
            }
            return true;
        }

        public void AddUser(User u)
        {
            UserDAL db = new UserDAL();
            u.pwHash = CalculateMD5Hash(u.pwHash);
            db.UserDB.Add(u);
            db.SaveChanges();
        }

        public void AddUser(RegisterVM vm)
        {
            User u = new User();
            u.userName = vm.UserName;
            u.pwHash = CalculateMD5Hash(vm.Password);

            UserDAL db = new UserDAL();
            db.UserDB.Add(u);
            db.SaveChanges();
        }

        public int GetLoggedUserID(string loggeduser)
        {
            int id = -1;
            List<User> list = this.GetUsers(loggeduser);
            foreach (var item in list)
            {
                if (item.userName == loggeduser)
                {
                    id = item.ID;
                    break;
                }
            }
            return id;
        }

        private string CalculateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

    }
}