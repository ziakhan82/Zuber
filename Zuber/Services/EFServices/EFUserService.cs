using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Zuber.Models;
using Zuber.Services.Interfaces;

namespace Zuber.Services.EFServices
{
    public class EFUserService:IUserService
    {
        ZuberDBContext service;
        public EFUserService(ZuberDBContext s)
        {
            service = s;
        }
        public void AddZuberUser(ZuberUser user)
        {
            user.Password = PasswordHash(user.Email, user.Password);
            service.Users.Add(user);
            service.SaveChanges();
        }

        public void DeleteZuberUser(string email)
        {
            service.Users.Remove(GetZuberUser(email));
            service.SaveChanges();
        }
        public void UpdateZuberUser(ZuberUser user)
        {
            service.Users.Update(user);
            service.SaveChanges();
        }

        public void GiveUserDot(ZuberUser user, int id)
        {
            user.DotId = id;
            service.Users.Update(user);
            service.SaveChanges();
        }

        public List<ZuberUser> GetAllUsers()
        {
            return service.Users.ToList<ZuberUser>();
        }

        public ZuberUser GetZuberUser(string email)
        {
            return service.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public ZuberUser GetZuberUserById(int id)
        {
            return service.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public static string PasswordHash(string userEmail, string password)
        {
            PasswordHasher<string> pw = new PasswordHasher<string>();
            string passwordHashed = pw.HashPassword(userEmail, password);
            return passwordHashed;
        }
        
        public static bool CheckHashedPassword(string email, string dbPassword, string password)
        {
            PasswordHasher<string> pw = new PasswordHasher<string>();
            var verificationResult = pw.VerifyHashedPassword(email, dbPassword, password);
            if (verificationResult == PasswordVerificationResult.Success)
            {
                return true;
            }
            return false;
        }
    }
}
