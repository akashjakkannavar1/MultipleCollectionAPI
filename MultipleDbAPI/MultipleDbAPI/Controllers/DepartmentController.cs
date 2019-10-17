using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultipleDbAPI.Services;
using MultipleDbAPI.Models;

namespace MultipleDbAPI.Controllers
{
    [Route("api/multipleDbApi/department")]
    [ApiController]
    public class DepartmentController: ControllerBase
    {
        public DepartmentController(DepartmentService departmentService)
        {
            DepartmentService = departmentService ?? throw new ArgumentNullException(nameof(DepartmentService)); 
        }
        public DepartmentService DepartmentService { get; }

        [HttpPost]
        public ActionResult InsertDepartment(Department dept)
        {
            try
            {
                var department = DepartmentService.Insert(dept);
                    return Ok(dept);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult Getall()
        {
            try
            {
                var departments = DepartmentService.GetDepartments();
                return Ok(departments);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("{empid}")]
        public ActionResult GetEmpDetails(string empid)
        {
            try
            {
                var employees = DepartmentService.GetEmployees(empid);
                return Ok(employees);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }
    }
}
