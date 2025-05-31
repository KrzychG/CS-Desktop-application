using Npgsql;
using System;
using System.Collections.Generic;

namespace SystemZarzadzaniaUrzadzeniami.Service
{
    public class DatabaseService
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=urzadzenia;Username=postgres;Password=password";

        public string ConnectionString => connectionString;

        // -- EMPLOYEES --

        public List<Employee> GetEmployees()
        {
            var list = new List<Employee>();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id, firstname, lastname, department FROM employee ORDER BY id", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Department = reader.GetString(3)
                        });
                    }
                }
            }
            return list;
        }

        public void AddEmployee(Employee employee)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO employee (firstname, lastname, department) VALUES (@firstname, @lastname, @department) RETURNING id", conn))
                {
                    cmd.Parameters.AddWithValue("firstname", employee.FirstName);
                    cmd.Parameters.AddWithValue("lastname", employee.LastName);
                    cmd.Parameters.AddWithValue("department", employee.Department);
                    employee.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE employee SET firstname = @firstname, lastname = @lastname, department = @department WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", employee.Id);
                    cmd.Parameters.AddWithValue("firstname", employee.FirstName);
                    cmd.Parameters.AddWithValue("lastname", employee.LastName);
                    cmd.Parameters.AddWithValue("department", employee.Department);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM employee WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", employeeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // -- DEVICES --

        public List<Device> GetDevices()
        {
            var list = new List<Device>();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id, name, serialnumber, purchasedate, employeeid FROM device ORDER BY id", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Device
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            SerialNumber = reader.GetString(2),
                            PurchaseDate = reader.GetDateTime(3),
                            EmployeeId = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                        });
                    }
                }
            }
            return list;
        }

        public void AddDevice(Device device)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO device (name, serialnumber, purchasedate, employeeid) VALUES (@name, @serialnumber, @purchasedate, @employeeid) RETURNING id", conn))
                {
                    cmd.Parameters.AddWithValue("name", device.Name);
                    cmd.Parameters.AddWithValue("serialnumber", device.SerialNumber);
                    cmd.Parameters.AddWithValue("purchasedate", device.PurchaseDate);
                    cmd.Parameters.AddWithValue("employeeid", device.EmployeeId.HasValue ? (object)device.EmployeeId.Value : DBNull.Value);
                    device.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void UpdateDevice(Device device)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE device SET name = @name, serialnumber = @serialnumber, purchasedate = @purchasedate, employeeid = @employeeid WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", device.Id);
                    cmd.Parameters.AddWithValue("name", device.Name);
                    cmd.Parameters.AddWithValue("serialnumber", device.SerialNumber);
                    cmd.Parameters.AddWithValue("purchasedate", device.PurchaseDate);
                    cmd.Parameters.AddWithValue("employeeid", device.EmployeeId.HasValue ? (object)device.EmployeeId.Value : DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteDevice(int deviceId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM device WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", deviceId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Device> GetDevicesByEmployeeId(int employeeId)
        {
            var list = new List<Device>();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id, name, serialnumber, purchasedate, employeeid FROM device WHERE employeeid = @employeeid", conn))
                {
                    cmd.Parameters.AddWithValue("employeeid", employeeId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Device
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                SerialNumber = reader.GetString(2),
                                PurchaseDate = reader.GetDateTime(3),
                                EmployeeId = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
