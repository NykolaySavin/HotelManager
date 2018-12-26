using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model
{
    public class InternalUserData : Base
    {
        public InternalUserData(string username, string email, string Password, string role)
        {
            Username = username;
            Email = email;
            HashedPassword = CalculateHash(Password,username);
            Role = role;
        }
        public InternalUserData()
        {

        }
        public string Username
        {
            get;
            set;
        }
        public Employee Employee
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }

        public string HashedPassword
        {
            get;
            set;
        }

        public string Role
        {
            get;
            set;
        }
        private static string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }
    }
}
