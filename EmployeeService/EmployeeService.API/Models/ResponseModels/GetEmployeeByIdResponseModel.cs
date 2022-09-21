using System;
using EmployeeService.Data.DTOs;

namespace EmployeeService.API.Models.ResponseModels
{
    public class GetEmployeeByIdResponseModel : BaseResponseModel
    {
        public GetEmployeeByIdResponseModel()
        {
        }

        public EmployeeDTO Employee { get; set; }
    }
}

