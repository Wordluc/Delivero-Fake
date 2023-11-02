using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Domain.Common.Address;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Account
{
    public partial class Account
    {
        public static bool AccountNameIsValid(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            if (name.Length < 3 || name.Length > 10) return false;

            return true;
        }
        public static bool AccountUsernameIsValid(string username)
        {
          
            if (string.IsNullOrEmpty(username)) return false;
            if (username.Length is < 3 or > 20) return false;

            return true;
        }
        public static bool AccountPasswordIsValid(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;
            if (password.Length is < 5 or > 20) return false;

            return true;
        }
        public static bool AccountEmailIsValid(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            if (email.Length is < 5 or > 20) return false;
            if (!email.Contains("@")) return false;
            if (!(email.Contains(".it") || email.Contains(".com"))) return false;
            
            return true;
        }
        public static bool AccountPhoneNumberIsValid(int number)
        {
            if ((number + "").Length != CifrePhoneNumber) return false;

            return true;
        }
        public static bool AccountAddressIsValid(Address address)
        {
            if (string.IsNullOrEmpty(address.Via)) return false;
            if (address.Via.Length is < 2 or > 20) return false;

            if (string.IsNullOrEmpty(address.City)) return false;
            if (address.City.Length is < 2 or > 30) return false;

            if (address.AddressNumber <= 0) return false;

            return true;
        }
    }
}
