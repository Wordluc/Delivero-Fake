using Domain.Account;
using Domain.Common;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainTests
{
    public class AccountRoot
    {
        [Fact]
        public void CreateAccount_WithIncorrectUsername_GetNull () {
            var account = Account.New("" , "ddddde", 123456789,"viaio@gmail.com");
            account.Should().BeNull();
        
        }
        [Fact]
        public void CreateAccount_WithIncorrectEmail_GetNull()
        {
            var account = Account.New("", "ddddde", 123456789, "viuai");
            account.Should().BeNull();

        }
        [Fact]
        public void CreateAccount_WithCorrectValue_GetAccount()
        {
            var account = Account.New("wordluc", "ddddde", 123456789, "viuai@gmail.com");
            account.Should().NotBeNull();

        }
        [Fact]
        public void SetAddress_WithWrongValue_GetFalse()
        {
            var account = Account.New("wordluc", "ddddde", 123456789, "viuai@gmail.com");
            account.Should().NotBeNull();
            account!.SetAddress("c",-10).Should().BeFalse();

        }
        [Fact]
        public void SetAddress_WithCorrectValue()
        {
            var account = Account.New("wordluc", "ddddde", 123456789, "viuai@gmail.com");
            account.Should().NotBeNull();
            account!.SetAddress("via cewiju", 10);
            account.Address.Should().Be(new Address("via cewiju", 10));
        }
    }
}
