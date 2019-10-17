using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MultipleDbAPI.Models;


namespace MultipleDbAPI.Services
{
    public class EmployeeDetailsService
    {
        private readonly IMongoCollection<Employee> _employee;
        private readonly IMongoCollection<Department> _department;
        public EmployeeDetailsService(IMultipleDbAPIDatabaseSettings setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var database = client.GetDatabase(setting.DatabaseName);
            _department = database.GetCollection<Department>(setting.departmentCollectionName);
            _employee = database.GetCollection<Employee>(setting.employeeCollectionName);
        }

        //public List<string> getempList(string deptid)
        //{
        //    List<string> emp = new List<string>();
        //    foreach (var e in _employee.AsQueryable())
        //    {
        //        if (e.department_id == deptid)
        //        {
        //            emp.Add(e.name);
        //        }
        //    }
        //    return emp;
        //}
    }
}
