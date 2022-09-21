using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EmployeeService.API.Models.RequestModels
{
    public class UpdateEmployeeRequestModel
    {
        [JsonProperty("employeeId")]
        [Required]
        public int EmployeeId { get; set; }

        [JsonProperty("name")]
        [StringLength(250, ErrorMessage = "Max character limit is 250")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        [StringLength(250, ErrorMessage = "Max character limit is 250")]
        public string Surname { get; set; }


        [JsonProperty("gender")]
        public int Gender { get; set; }


        [JsonProperty("birthdate")]
        public DateTime BirthDate { get; set; }
    }
}

