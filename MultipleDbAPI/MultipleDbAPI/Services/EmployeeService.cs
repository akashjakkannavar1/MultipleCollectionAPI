using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MultipleDbAPI.Models;

namespace MultipleDbAPI.Services
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employee;
        private readonly IMongoCollection<Department> _department;
        public EmployeeService(IMultipleDbAPIDatabaseSettings setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var database = client.GetDatabase(setting.DatabaseName);
            _employee = database.GetCollection<Employee>(setting.employeeCollectionName);
            _department = database.GetCollection<Department>(setting.departmentCollectionName);
        }

        public Employee Insert(Employee emp)
        {
            _employee.InsertOne(emp);
            return emp;
        }

        public List<Employee> InsertMany(List<Employee> emp)
        {
            _employee.InsertMany(emp);
            return emp;
        }

        public List<Employee> GetEmployees()
        {
            var departments = _employee.Find(s => true).ToList();
            return departments;
        }

        //public Department Getdetails(string name)
        //{
        //    var details = _employee.Find(s => s.name == name).FirstOrDefault();
        //    var dept = _department.Find(s => s._id == details.department_id).FirstOrDefault();
        //    return dept;
        //}

        //public List<Department> GetMultiDetails(List<string> names)
        //{
        //    List<Department> deptList = new List<Department>();
        //    foreach (var n in names)
        //    {
        //        var details = _employee.Find(s => s.name == n).FirstOrDefault();
        //        var dept = _department.Find(s => s._id == details.department_id).FirstOrDefault();
        //        deptList.Add(dept);
        //    }
        //    return deptList;
        //}

        //public Object getdeptAggregate(string name)
        //{
        //    var depts = _employee.Aggregate()
        //        .Match(p => p.name == name)
        //        .Lookup(
        //        foreignCollection: _department,
        //        localField: e => e._id,
        //        foreignField: f => f.department_id,
        //        @as: (deptdetails dd)=>dd._employee
        //        );

        //    return depts;
        //}

        //public List<deptdetails> getdeptAggregate(string name)
        //{
        //    var depts=from p in _employee.AsQueryable()
        //              where p.name==name
        //              join d in _department.AsQueryable() on p.department_id equals d._id into deptdetails
        //              select new {p.name,_employee=deptdetails._employee}
        //              into p
        //              orderby
        //}

        public List<Employee> getempList(string deptname)
        {
            List<Employee> emp = new List<Employee>();
            var dept = _department.Find(s => s.department_name == deptname).FirstOrDefault();
            foreach (var e in _employee.AsQueryable())
            {
                if (e.department_id == dept._id)
                {
                    emp.Add(e);
                }
            }
            return emp;
        }

        //public List<deptdetails> getdeptAggregate(string id)
        //{
        //    var query = from d in _department.AsQueryable()
        //                join e in _employee.AsQueryable() on d._id equals id into DeptDetails
        //                select new deptdetails
        //                {
        //                    name = d.department_name,
        //                    location = d.location
        //                };
        //    var dlist = query.ToList();
        //    return dlist;
        //}  
        public Employee GetEmpById(int id)
        {
            var emp = _employee.Find(s => s._id == id).FirstOrDefault();
            return emp;
        }


        public Employee UpdEmployee(Employee emp)
        {
            var employee = _employee.FindOneAndReplace(s => s._id == emp._id, emp);
            return employee;
        }
    }
}