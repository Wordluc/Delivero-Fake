﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Domain.Common.Address;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Account
{

    public partial class Account
    {
        private static string RegexEmail = @"^[a-zA-Z]\w+([\.\-]\w+)*@\w+([\.\-][\w])*\.(com|it|org)$";
        private static Regex RegexRunnerEmail=new Regex(RegexEmail);

        private static string RegexPassword = @"^(?=.*[A-Z]{2})(?=.*[$\^\.]{2})(?=.*[0-9]{2}).{8,20}$";
        private static Regex RegexRunnerPassword = new Regex(RegexPassword);
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
            return RegexRunnerPassword.Match(password).Success;
        }
        public static bool AccountEmailIsValid(string email)
        {
            return RegexRunnerEmail.Match(email).Success;
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
        private bool CardIsValid(Card card)
        {
            if (string.IsNullOrEmpty(card.Iban)) return false;
            if (card.Iban.Length >= 27) return false;
            if (card.OwnerName.Length is < 2 or > 20) return false;

            return true;
        }
    }
}
