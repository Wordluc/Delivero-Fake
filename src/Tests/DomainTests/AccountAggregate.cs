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
            var account = Account.New("wordluc", "ddddde", 123456789, "viuai@gmail.com").IsSuccess;
           
            account.Should().BeTrue();

        }
        [Fact]
        public void SetAddress_WithWrongValue_GetFalse()
        {
            var account = Account.New("wordluc", "ddddde", 123456789, "viuai@gmail.com").Value;

            account.UpdateAddress(new("mussomeli", "c",-10)).Should().BeFalse();

        }
        [Fact]
        public void SetAddress_WithCorrectValue()
        {
            var account = Account.New("wordluc", "ddddde", 123456789, "viuai@gmail.com").Value;

            account.UpdateAddress(new("mussomeli", "via cewiju", 10));

            account.Address.Should().Be(new Address("mussomeli", "via cewiju", 10));
        }
    }
}
