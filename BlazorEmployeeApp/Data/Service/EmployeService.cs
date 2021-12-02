using BlazorEmployeeApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployeeApp.Data.Service
{
    public class EmployeService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;      
        }
        public List<Employee> getEmloyeeList()
        {
            var emplist = _dbContext.Employees.ToList();
            return emplist;
        }

        //Insert Employee
        public async Task<bool> InsertEmployeeAsync(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        

        // GetEmployee by Id
        public async Task<Employee> GetEmployeeAsync(int Id)
        {
            Employee employee = await _dbContext.Employees.FirstOrDefaultAsync(c => c.EmployeeId.Equals(Id));
            return employee;
        }
       

        //UpdateEmployee
        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        
    }
}
