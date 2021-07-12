using Business.Account.Entities;
using System;
using System.Collections.Generic;
using Core.Common;

namespace Business.Account.Implementation
{
    public class User : EUser
    {
        List<EUser> userList { get; set; }
        int UserId = 0;
        public User(string email, string password, string username)
        {
            email = EmailId;
            password = Password;
            username = UserName;
        }
        public BaseReturn<ELogin> Login(ELogin user)
        {
            var userData = new BaseReturn<ELogin>();
            userList = new List<EUser>();
            try
            {
                userList.ForEach(item =>
                {
                    if (item.UserName == user.EmailId && item.Password == user.Password)
                    {
                        userData.Message = "Login successfull";
                        userData.Success = true;
                    }
                    else
                    {
                        userData.Message = "User does not exists";
                        userData.Success = false;
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Login Error:", ex);
            }
            return userData;
        }

        public BaseReturn<EUser> Registration(EUser user)
        {
            var userData = new BaseReturn<EUser>();
            userList = new List<EUser>();
            try
            {
                // userList.ForEach(usr =>
                // {
                if (!userList.Contains(user))
                {
                    userList.Add(new EUser
                    {
                        // UserId = UserId + 1,
                        UserName = user.UserName,
                        EmailId = user.EmailId,
                        Password = user.Password,
                        // CreatedDate = DateTime.Now
                    });

                    userData.Data = user;
                    userData.Message = "User registration successfull";
                    userData.Success = true;
                }
                else
                {
                    userData.Message = "User already exists";
                    userData.Success = false;
                }
                // });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Registration Error:", ex);
            }
            return userData;
        }
    }
}