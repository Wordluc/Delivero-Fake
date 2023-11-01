using Domain.Common;


#pragma warning disable CS8618
namespace Domain.Account
{
    public partial class Account
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public int Phone { get; private set; }
        public Address Address { get; private set; }
        private Account() { }
    }
}
