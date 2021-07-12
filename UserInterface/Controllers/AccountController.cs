using Business.Account;
using Business.Account.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Business.Account.Entities;
using Core.Common;

namespace UserInterface.Controllers
{
    [Route("api/[controller]")]
    public class AccountController
    {
        private User userClass = new User("", "", "");
        public void User(string email, string password, string username)
        {
            userClass = new User(email, password, username);
        }

        [HttpPost]
        [Route("Login")]
        public BaseReturn<ELogin> Login([FromBody] ELogin user)
        {
            return userClass.Login(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public BaseReturn<EUser> Registration([FromBody] EUser user)
        {
            return userClass.Registration(user);
        }

    }
}