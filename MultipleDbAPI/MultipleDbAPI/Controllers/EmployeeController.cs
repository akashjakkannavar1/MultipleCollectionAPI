using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultipleDbAPI.Models;
using MultipleDbAPI.Services;

namespace MultipleDbAPI.Controllers
{
    [Route("api/multipleDbApi/employee")]
    [ApiController]
    public class EmployeeController:ControllerBase
    {
        public EmployeeController(EmployeeService departmentService)
        {
            EmployeeService = departmentService ?? throw new ArgumentNullException(nameof(EmployeeService));
        }
        public EmployeeService EmployeeService { get; }

        //[HttpGet]
        //public ActionResult display()
        //{
        //    return Ok(EmployeeService.show());
        //}

        [HttpPost]
        public ActionResult InsertEmployee([FromBody] Employee emp)
        {
            try
            {
                var employee = EmployeeService.Insert(emp);
                return Ok(emp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            

        }
        [HttpPost]
        [Route("insertMany")]
        public ActionResult InsertManyEmployees([FromBody] List<Employee> emp)
        {
            try
            {
                var employee = EmployeeService.InsertMany(emp);
                return Ok(emp);
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
                var departments = EmployeeService.GetEmployees();
                return Ok(departments);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("getbyId/{id}")]

        public ActionResult GetById(int id)
        {
            try
            {
                var emp = EmployeeService.GetEmpById(id);
                return Ok(emp);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        //[HttpGet]
        //[Route("{name}")]
        //public ActionResult GetDeptDetails(string name)
        //{
        //    try
        //    {
        //        var dept = EmployeeService.Getdetails(name);
        //        return Ok(dept);
        //    }
        //    catch (Exception e)
        //    {
        //        return NotFound(e.Message);
        //    }
        //}

        //[HttpPost]
        //[Route("api/multipleDbApi/employeelist")]
        //public ActionResult GetMultipleDeotDetails([FromBody]List<string> names)
        //{
        //    try
        //    {
        //        var alldetails = EmployeeService.GetMultiDetails(names);
        //        return Ok(alldetails);
        //    }
        //    catch (Exception e)
        //    {
        //        return NotFound(e.Message);
        //    }
        //}

        //[HttpGet]
        //[Route("getDeptDetails/{name}")]
        //public ActionResult GetDeptDetailsAggregate([FromRoute] string name)
        //{
            
        //        var depts = EmployeeService.getdeptAggregate(name);
        //        return Ok(depts);
            
        //}

        [HttpGet]
        [Route("getEmployeeDetails/{deptname}")]
        public ActionResult GetEmployeesWithDeptName([FromRoute] string deptname)
        {
            try
            {
                var emp = EmployeeService.getempList(deptname);
                return Ok(emp);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpPut]
        [Route("updateEmployee")]

        public ActionResult UpdateEmployee([FromBody] Employee emp)
        {
            try
            {
                var employee = EmployeeService.GetEmpById(emp._id);
                if(employee!=null)
                {
                    EmployeeService.UpdEmployee(emp);
                }
                return Ok(emp);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}



//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using WebApi.Services;
//using WebApi.Entities;

//namespace SampleJWTAPI.Controllers
//{
//    [Authorize]
//    [ApiController]
//    [Route("[controller]")]
//    public class UsersController : ControllerBase
//    {
//        private IUserService _userService;

//        public UsersController(IUserService userService)
//        {
//            _userService = userService;
//        }

//        [AllowAnonymous]
//        [HttpPost("authenticate")]
//        public IActionResult Authenticate([FromBody]User userParam)
//        {
//            var user = _userService.Authenticate(userParam.Username, userParam.Password);

//            if (user == null)
//                return BadRequest(new { message = "Username or password is incorrect" });

//            return Ok(user);
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var users = _userService.GetAll();
//            return Ok(users);
//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SampleJWTAPI.Entities
//{
//    public class User
//    {
//        public string Id { get; set; }
//        public string Name { get; set; }
//        public string Password { get; set; }
//        public string token { get; set; }
//    }
//}
