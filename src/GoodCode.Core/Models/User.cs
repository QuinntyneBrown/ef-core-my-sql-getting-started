using System;

namespace GoodCode.Core.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
