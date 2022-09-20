using System;
namespace AuthenticationService.API.Models.RequestModels
{
    public class AuthenticateRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

