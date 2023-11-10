using Domain.Common;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Account;

public partial class Account
{
    private const int CIFRE_PHONE_NUMBER = 9;

    public static Result<Account> New(string username,string password,int numberPhone,string email)
    {
        if (!(
                AccountUsernameIsValid(username) &&
                AccountPasswordIsValid(password) &&
                AccountPhoneNumberIsValid(numberPhone)&&
                AccountEmailIsValid(email))
           )return Result.Fail("Parametri non validi per la creazione dell'account");

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
    public bool AddCard(Card card)
    {
        if(!CardIsValid(card))return false;

        Cards.Add(card);
        return true;
    }
    public bool UpdateUsername (string username)
    {
        if (!AccountUsernameIsValid(username)) return false;

        Username = username;
        return true;
    }
    public bool UpdatePassword(string password)
    {
        if(!AccountPasswordIsValid(password)) return false;

        Password = password;
        return true;
    }
    public bool UpdateEmail(string email)
    {
        if(!AccountEmailIsValid(email)) return false;

        Email = email;
        return true;
    }
    public bool UpdatePhone(int number)
    {
        if (!AccountPhoneNumberIsValid(number)) return false;

        Phone = number;
        return true;
    }
    public bool UpdateAddress(Address address)
    {
        if (!AccountAddressIsValid(address)) return false;

        Address = address;
        return true;
    }
}