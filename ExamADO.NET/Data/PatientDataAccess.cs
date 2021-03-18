using ExamADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamADO.NET.Data
{
    public class PatientDataAccess : DbDataAccess<Patient>
    {
        public override void Delete(Patient patient)
        {
            var deleteSqlScript = "Delete from Patients where Id = @Id";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = deleteSqlScript;
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public override void Insert(Patient patient)
        {
            var insertSqlScript = "insert into Patients (Id, FullName, Phone, Address ) values (@Id, @FullName, @Phone,Address)";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = insertSqlScript;
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public override ICollection<Patient> Select(Patient patient)
        {
            var selectSqlScript = "select * from Patients";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = selectSqlScript;
            var dataReader = command.ExecuteReader();

            var patients = new List<Patient>();
            while (dataReader.Read())
            {
                patients.Add(new Patient
                {
                    Id = Guid.Parse(dataReader["Id"].ToString()),
                    FullName = dataReader["FullName"].ToString(),
                    Phone = dataReader["Phone"].ToString(),
                    Address = dataReader["Address"].ToString()
                    

                });
            }
            dataReader.Close();
            command.Dispose();

            return patients;
        }

        public override void Update(Patient entity)
        {
            var updateSqlScript = "update Players set FullName = @FullName, Phone = @Phone, Address = @Address where Id = @Id";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = updateSqlScript;
            command.ExecuteNonQuery();
            command.Dispose();
        }
    }
}
