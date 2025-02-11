﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployee(CreateEmployeeDto employeeDto)
        {
            string query = "Insert Into Employee (Name, Title, Mail, PhoneNumber, ImageUrl, Status) " +
                            "values (@name,@title,@mail,@phoneNumber,@imageUrl,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", employeeDto.Name);
            parameters.Add("@title", employeeDto.Title);
            parameters.Add("@mail", employeeDto.Mail);
            parameters.Add("@phoneNumber", employeeDto.PhoneNumber);
            parameters.Add("@imageUrl", employeeDto.ImageUrl);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteEmployee(int id)
        {
            string query = "Delete From Employee Where EmployeeId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * From Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdEmployeeDto> GetEmployee(int id)
        {
            string query = "Select * From Employee Where EmployeeId=@EmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "Update Employee Set Name = @Name, Title = @title, Mail = @mail,  PhoneNumber = @phoneNumber, ImageUrl = @imageUrl, Status = @status Where EmployeeId = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@name", updateEmployeeDto.Name);
            parameters.Add("@title", updateEmployeeDto.Title);
            parameters.Add("@mail", updateEmployeeDto.Mail);
            parameters.Add("@phoneNumber", updateEmployeeDto.PhoneNumber);
            parameters.Add("@imageUrl", updateEmployeeDto.ImageUrl);
            parameters.Add("@status", true);
            parameters.Add("@Id", updateEmployeeDto.EmployeeId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
