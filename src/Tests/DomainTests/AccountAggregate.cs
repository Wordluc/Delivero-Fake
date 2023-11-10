using Domain.Account;
using Domain.Common;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainTests;

public class AccountRoot
{
    [Fact]
    public void CreateAccount_WithIncorrectUsername_GetNull () {
        var account = Account.New("" , "ddddde", 123456789,"viaio@gmail.com").IsFailed;
            
        account.Should().BeTrue();
        
    }
    [Fact]
    public void CreateAccount_WithIncorrectEmail_GetNull()
    {
        var account = Account.New("", "ddddde", 123456789, "viuai").IsFailed;
            
        account.Should().BeTrue();

    }
    [Fact]
    public void CreateAccount_WithCorrectValue_GetAccount()
    {
        var account = Account.New("wordluc", "ddDA21d$^e", 123456789, "viuai@gmail.com").IsSuccess;

        account.Should().BeTrue();

    }
    [Fact]
    public void SetAddress_WithCorrectValue()
    {
        var account = Account.New("wordluc", "ddDA21d$^e", 123456789, "viuai@gmail.com").Value;

        var address = Address.New("mussomeli", "Via bla bla", 55);
        account.UpdateAddress(address.Value);

        account.Address.Should().Be(address.Value);
    }
    [Fact]
    public void AddCard_WithCorrectIban()
    {
        var account = Account.New("wordluc", "ddDA21d$^e", 123456789, "viuai@gmail.com").Value;

        account.AddCard(new Card("luca", "IT22123", new DateOnly())).Should().BeTrue();
    }
    [Fact]
    public void AddCard_WithInCorrectIban()
    {
        var account = Account.New("wordluc", "ddDA21d$^e", 123456789, "viuai@gmail.com").Value;

        account.AddCard(new Card("luca", "", new DateOnly())).Should().BeFalse();
    }
}