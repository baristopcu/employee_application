using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EmployeeService.API.Models.RequestModels
{
    public class InsertEmployeeRequestModel
    {
        [JsonProperty("name")]
        [Required]
        [StringLength(250, ErrorMessage = "Max character limit is 250")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        [Required]
        [StringLength(250, ErrorMessage = "Max character limit is 250")]
        public string Surname { get; set; }


        [JsonProperty("gender")]
        [Required]
        public int? Gender { get; set; }


        [JsonProperty("birthdate")]
        [Required]
        public DateTime? BirthDate { get; set; }
    }
}

