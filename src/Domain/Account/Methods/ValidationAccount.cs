using Domain.Common;
using FluentResults;
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
        private static Regex RegexRunnerEmail=new(RegexEmail);

        private static string RegexPassword = @"^(?=.*[A-Z]{2})(?=.*[$\^\.]{2})(?=.*[0-9]{2}).{8,20}$";
        private static Regex RegexRunnerPassword = new(RegexPassword);

        //  private static string RegexIban = @"^\b[A-Z]{2}[0-9]{2}(?:[ ]?[0-9]{4}){4}(?!(?:[ ]?[0-9]){3})(?:[ ]?[0-9]{1,2})?\b$";
        private static string RegexIban = @"^[A-Z]{2}[0-9]{5}$";
        private static Regex RegexRunnerIban = new(RegexIban);
   
        public static Result AccountUsernameIsValid(string username)
        {
          
            var result = Result.Ok();
            if (string.IsNullOrEmpty(username) || username.Length is < 3 or > 20) 
                result.WithError("username non valido");

            return result;
        }
        public static Result AccountPasswordIsValid(string password)
        {
            if(RegexRunnerPassword.Match(password).Success)return Result.Ok();
            return Result.Fail("Password account non valida");
        }
        public static Result AccountEmailIsValid(string email)
        {
            if (RegexRunnerEmail.Match(email).Success) return Result.Ok();
            return Result.Fail("Email account non valida");
        }
        public static Result AccountPhoneNumberIsValid(int number)
        {
    
            if (Regex.IsMatch(number.ToString(),$"^[0-9]{{{CifrePhoneNumber}}}$")) return Result.Ok();
            return Result.Fail("Numero di telefono non valido");
        }
        public static Result AccountAddressIsValid(Address address)
        {
            var result=Result.Ok();
            if (string.IsNullOrEmpty(address.Via) ||
                address.Via.Length is < 2 or > 20)result.WithError("Via non valida");

            if (string.IsNullOrEmpty(address.City) &&
                address.City.Length is < 2 or > 30) result.WithError("Città non valida");

            if (address.AddressNumber <= 0) result.WithError("Numero civico non valido");

            return result;
        }
        private Result CardIsValid(Card card)
        {
            var result = Result.Ok();
            if (card.OwnerName.Length is < 2 or > 20) result.WithError("Proprietario/a carta non valido");
            if (!RegexRunnerIban.Match(card.Iban).Success) result.WithError("Iban non valido");
            return result;
        }
    }
}
