using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using MultipleDbAPI.Models;

namespace MultipleDbAPI.Services
{
    public class DepartmentService
    {
        private readonly IMongoCollection<Employee> _employee;
        private readonly IMongoCollection<Department> _department;
        public DepartmentService(IMultipleDbAPIDatabaseSettings setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var database = client.GetDatabase(setting.DatabaseName);
            _department = database.GetCollection<Department>(setting.departmentCollectionName);
            _employee = database.GetCollection<Employee>(setting.employeeCollectionName);
        }

        public Department Insert(Department dept)
        {
            _department.InsertOne(dept);
            return dept;
        }

        public List<Department> GetDepartments()
        {
            var departments = _department.Find(s => true).ToList();
            return departments;
        }

        public List<Employee> GetEmployees(string id)
        {
            var dept = _department.Find(s => s._id == id).FirstOrDefault();
            var employees = _employee.Find<Employee>(s => s.department_id == dept._id).ToList();
            return employees;
        }
    }
}
