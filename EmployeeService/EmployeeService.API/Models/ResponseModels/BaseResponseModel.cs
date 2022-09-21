using System;
using Newtonsoft.Json;

namespace EmployeeService.API.Models.ResponseModels
{
    public class BaseResponseModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

    }
}

