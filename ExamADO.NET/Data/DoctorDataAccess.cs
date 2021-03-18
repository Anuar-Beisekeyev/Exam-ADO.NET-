using ExamADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ExamADO.NET.Data
{
    public class DoctorDataAccess : DbDataAccess<Doctor>
    {
        
        public override void Delete(Doctor doctor)
        {
            
            var deleteSqlScript = "Delete from Doctors where Id = @Id";
            var idParameter = new SqlParameter("@Id",doctor.Id);
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = deleteSqlScript;
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public override void Insert(Doctor doctor)
        {
            var insertSqlScript = "insert into Players (Id, FullName, Position ) values (@Id, @FullName, @Position)";                      
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = insertSqlScript;
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public override ICollection<Doctor> Select(Doctor doctor)
        {
            var selectSqlScript = "select * from Doctors";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = selectSqlScript;
            var dataReader = command.ExecuteReader();

            var doctors = new List<Doctor>();
            while (dataReader.Read())
            {
                doctors.Add(new Doctor
                {
                    Id = Guid.Parse(dataReader["Id"].ToString()),
                    FullName = dataReader["Name"].ToString(),
                    Position = dataReader["Position"].ToString()                   

                });
            }
            dataReader.Close();
            command.Dispose();

            return doctors;
        }

        public override void Update(Doctor doctor)
        {
            var updateSqlScript = "update Players set FullName = @FullName, Position = @Position  where Id = @Id";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = updateSqlScript;
            command.ExecuteNonQuery();
            command.Dispose();
        }
    }
}
