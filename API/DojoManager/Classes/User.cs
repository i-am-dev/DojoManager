using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DojoManager.Models;
using DojoManager.Data;
using Microsoft.Extensions.Options;

namespace DojoManager.Classes
{
    public class UserEngine
    {

        private string GetSalt()
        {
            byte[] bytes = new byte[128 / 8];
            using (var keyGenerator = RandomNumberGenerator.Create())
            {
                keyGenerator.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }


        private string SHA256Hash(string plainText, string salt)
        {
            string hashed = "";
            
            using(var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainText + salt));
                hashed = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            return hashed;
        }

        public User CreateUser(User model)
        {

            

            // hash the password
            model.Salt = GetSalt();
            model.Password = SHA256Hash(model.Password, model.Salt);

            // save the record
            try
            {
                DBManager db = new DBManager();

                model = db.UserSaveNewUser(model);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            // clear password and salt before returning:
            model.Salt = "";
            model.Password = "";
            return model;
        }

        public User GetUserDetailsFromEmail(User model)
        {
            // get the record
            try{
                DBManager db = new DBManager();

                model = db.GetUserDetailsFromEmail(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // clear password and salt before returning:
            model.Salt = "";
            model.Password = "";
            return model;
        }

        public bool DoesUserExist(User model)
        {
            bool result = false;
            try
            {
                DBManager db = new DBManager();

                result = db.DoesUserExist(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // clear password and salt before returning:
            model.Salt = "";
            model.Password = "";
            return result;
        }

        public bool ValidUserAndPassword(string email, string password)
        {
            bool result = false;
            try
            {
                DBManager db = new DBManager();



                result = db.ValidUserAndPassword(email, SHA256Hash(password,ReturnSaltForUserEmail(email)));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private string ReturnSaltForUserEmail(string email)
        {
            string salt = "";
            try
            {
                DBManager db = new DBManager();

                salt = db.ReturnSaltForUserEmail(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return salt;
        }
    }
}
