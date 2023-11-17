using Domain.Common;
using FluentResults;
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

        public static Result<Account> New(string username,string password,int numberPhone,string email)
        {
            var result = AccountUsernameIsValid(username).And(
                  AccountPasswordIsValid(password)).And(
                  AccountPhoneNumberIsValid(numberPhone).And(
                  AccountEmailIsValid(email)));
                
            if (result.IsFailed) return result;

            var newAccount = new Account()
            {
                Username = username,
                Password = password,
                Phone = numberPhone,
                Email = email,
                Cards = new()
            };

            return Result.Ok(newAccount);
        }
        public Result AddCard(Card card)
        {
            var result=CardIsValid(card);
            if (result.IsFailed) return result;

            Cards.Add(card);
            return Result.Ok();
        }
        public Result UpdateUsername (string username)
        {
            var result = AccountUsernameIsValid(username);
            if (result.IsFailed) return result;
            Username = username;
            return Result.Ok();
        }
        public Result UpdatePassword(string password)
        {
            var result = AccountPasswordIsValid(password);
           if (result.IsFailed) return result;

            Password = password;
            return Result.Ok();
        }
        public Result UpdateEmail(string email)
        {
            var result = AccountEmailIsValid(email);
            if (result.IsFailed) return result;

            Email = email;
            return Result.Ok();
        }
        public Result UpdatePhone(int number)
        {
            var result = AccountPhoneNumberIsValid(number);
            if(result.IsFailed) return result;

            Phone = number;
            return Result.Ok();
        }
        public Result UpdateAddress(Address address)
        {
            var result = AccountAddressIsValid(address);
            if (result.IsFailed) return result;
            Address = address;
            return Result.Ok();
        }
    }
}
