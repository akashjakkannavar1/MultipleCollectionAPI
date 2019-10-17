using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultipleDbAPI.Models;
using MultipleDbAPI.Services;

namespace MultipleDbAPI.Controllers
{
    [Route("api/multipleDbApi/employeeDetails")]
    [ApiController]
    public class EmployeeDetailsController:ControllerBase 
    {
        public EmployeeDetailsController(EmployeeDetailsService employeeDetailsService)
        {
            EmployeeDetailsService = employeeDetailsService ?? throw new ArgumentNullException(nameof(EmployeeDetailsService));
        }
        public EmployeeDetailsService EmployeeDetailsService { get; }
        //[HttpGet]
        //[Route("/{deptid}")]
        //public ActionResult GetEmployeesWithDeptName([FromRoute] string deptid)
        //{
        //    try
        //    {
        //        var emp = EmployeeDetailsService.getempList(deptid);
        //        return Ok(emp);
        //    }
        //    catch (Exception e)
        //    {
        //        return NotFound(e.Message);
        //    }

        //}
    }
     
}
