using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting
{
    internal class User
    {
        private string Login;
        private string Password;
        private DateTime Birthday;
        private string Email;

        public User(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
        }
        public User(string Login, string Password, DateTime Date, string Email)
        {
            this.Login = Login;
            this.Password = Password;
            Birthday = Date;
            this.Email = Email;
        }
        public string GetLogin()
        {
            return this.Login;
        }
        public string GetPassword()
        {
            return this.Password;
        }
        public DateTime GetBirthday()
        {
            return this.Birthday;
        }
        public string GetEmail()
        {
            return this.Email;
        }
    }
}
