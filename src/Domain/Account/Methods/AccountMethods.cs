using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Account
{
    public partial class Account
    {
        private const int CifrePhoneNumber = 9;

        public static Account? New(string username,string password,int numberPhone,string email)
        {
            var newAccount=new Account();

            if (!(
                    newAccount.SetEmail(email) &&
                    newAccount.SetPassword(password) &&
                    newAccount.SetPhone(numberPhone) &&
                    newAccount.SetUsername(username))
                )return null;

            return newAccount;
        }
        private bool SetName(string name) {
            if (string.IsNullOrEmpty(name)) return false;
            if (name.Length < 3 || name.Length > 10) return false;

            Name = name;
            return true;
        }

        public bool SetUsername (string username)
        {
            if (string.IsNullOrEmpty(username)) return false;
            if (username.Length < 3 || username.Length > 20) return false;

            Username = username;
            return true;
        }
        public bool SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;
            if (password.Length < 5 || password.Length > 20) return false;

            Password = password;
            return true;
        }
        private bool SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            if (email.Length < 5 || email.Length > 20) return false;
            if(!email.Contains("@")) return false;
            if (!(email.Contains(".it") || email.Contains(".com"))) return false;

            Email = email;
            return true;
        }
        public bool SetPhone(int number)
        {
            if ((number+"").Length!=CifrePhoneNumber) return false;

            Phone = number;
            return true;
        }
        public bool SetAddress(string city,string via,int number)
        {
            if (string.IsNullOrEmpty(via)) return false;
            if (via.Length < 2 || via.Length > 20) return false;
            if(number <= 0)return false;

            Address = new(city,via, number);
            return true;
        }
    }
}
