using Domain.Common;


#pragma warning disable CS8618
namespace Domain.Account
{
    public partial class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public Address Address { get; set; }
        private Account() { }
    }
}
