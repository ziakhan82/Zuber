using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zuber.Models;

namespace Zuber.Services.EFServices
{
    public class SingletonUser
    {
        public ZuberUser User { get; set; }
        public bool SignedIn
        {
            get
            {
                if (User == null) return false;
                else return true;
            }
        }
        public bool IsDriver
        {
            get { return User.Driver; }
            //set { User.Driver = value; }
        }

        public SingletonUser()
        {

        }

        public void Login(ZuberUser user)
        {
            User = user;
        }
        public void Logout()
        {
            User = null;
        }
    }
}
