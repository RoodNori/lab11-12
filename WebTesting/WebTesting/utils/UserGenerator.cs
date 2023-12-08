using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting
{
    internal class UserGenerator
    {
        public static User GetRestrictedUserByLogin()
        {
            DateTime Date = new DateTime(2000, 1, 1);

            return new User("авбгде", "абвгде1!", Date, "rzvjglt376@1secmail.ru");
        }
        public static User GetRestrictedUserByPassword()
        {
            DateTime Date = new DateTime(2000, 1, 1);

            return new User("abcdefgfuaym", "абвгде", Date, "rzvjglt376@1secmail.ru");
        }
        public static User GetRestrictedUserByBirthday()
        {
            DateTime Date = DateTime.Now;

            return new User("abcdefgfuaym", "абвгде1!", Date, "rzvjglt376@1secmail.ru");
        }
        public static User GetUserLower13()
        {
            return new User("fuhcfhjcf", "абвгде1!");
        }
        public static User GetUserHigher13()
        {
            return new User("fhjxyhfnb", "абвгде1!");
        }
    }
}
