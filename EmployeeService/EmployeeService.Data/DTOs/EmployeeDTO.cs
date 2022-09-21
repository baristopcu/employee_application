using System;
namespace EmployeeService.Data.DTOs
{
    public class EmployeeDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? CreatedOnUtc { get; set; }
    }
}

