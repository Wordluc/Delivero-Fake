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

        public bool SetUsername (string username)
        {
            if (!AccountUsernameIsValid(username)) return false;

            Username = username;
            return true;
        }
        public bool SetPassword(string password)
        {
           if(!AccountPasswordIsValid(password)) return false;  

            Password = password;
            return true;
        }
        private bool SetEmail(string email)
        {
            if(!AccountEmailIsValid(email)) return false;

            Email = email;
            return true;
        }
        public bool SetPhone(int number)
        {
            if (!AccountPhoneNumberIsValid(number)) return false;

            Phone = number;
            return true;
        }
        public bool SetAddress(Address address)
        {
            if (!AccountAddressIsValid(address)) return false;

            Address = address;
            return true;
        }
    }
}
