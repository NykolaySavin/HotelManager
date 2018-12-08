
using HotelManager.Model.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.Autorization
{
    public interface IAuthenticationService
    {
        Employee AuthenticateUser(string username, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        
        private static List<InternalUserData> _users {
            get
            {
                using (HotelContext context = new HotelContext())
                {
                    return context.Users.ToList();
                }
                   
            }
        }
        public Employee AuthenticateUser(string username, string clearTextPassword)
        {
            InternalUserData userData = _users.FirstOrDefault(u => u.Username.Equals(username)
                && u.HashedPassword.Equals(CalculateHash(clearTextPassword, u.Username)));
            if (userData == null)
                throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");
            Employee e;
            using (HotelContext context = new HotelContext())
                {

                List<Employee> employees = context.Employees.ToList();
                e = employees.Find(x => x.Username == userData.Username);
            }
            return e;
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
