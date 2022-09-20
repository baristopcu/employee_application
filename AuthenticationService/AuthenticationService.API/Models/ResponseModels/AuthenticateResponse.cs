using System;
namespace AuthenticationService.API.Models.ResponseModels
{
    public class AuthenticateResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
    }
}

