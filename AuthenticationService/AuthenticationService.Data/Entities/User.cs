using System;

namespace AuthenticationService.Data.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}

