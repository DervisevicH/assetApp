using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetTracker_API.ViewModel;
using AssetTracket_Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetTracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private AssetsTrackerContext _db;
        public EmployeeController(AssetsTrackerContext db) { _db = db; }

        [HttpGet("GetAllEmployees")]
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _db.Employee.ToListAsync();
        }
        [HttpGet("GetEmployeesDropDown")]
        public async Task<List<EmployeeVM>> GetEmployeesDropDown()
        {
            var employee=await _db.Employee.ToListAsync();
            List<EmployeeVM> employeeVMs = new List<EmployeeVM>();
            foreach (var item in employee)
            {
                EmployeeVM employeeVM = new EmployeeVM
                {
                    EmployeeId = item.EmployeeId,
                    Employee = item.FirstName + " " + item.LastName
                };
                employeeVMs.Add(employeeVM);
            }
           
            return employeeVMs;          
        }
        [HttpPost]
        public async Task<Employee> AddEmployee(Employee employee)
        {
            await _db.Employee.AddAsync(employee);
            
            _db.SaveChanges();

            return await _db.Employee.FindAsync(employee.EmployeeId);
        }
    }
}