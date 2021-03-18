using ExamADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamADO.NET.Data
{
    public class ReceptionDataAccess : DbDataAccess<Reception>
    {
        public override void Delete(Reception reception)
        {
            var deleteSqlScript = "Delete from Receptions where Id = @Id";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = deleteSqlScript;
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public override void Insert(Reception reception)
        {
            var insertSqlScript = "insert into Patients (Id, Begin,End, IsUse ) values (@Id, @Begin, @End,@IsUse)";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = insertSqlScript;
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public override ICollection<Reception> Select(Reception reception)
        {
            var selectSqlScript = "select * from Receptions";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = selectSqlScript;
            var dataReader = command.ExecuteReader();

            var receptions = new List<Reception>();
            while (dataReader.Read())
            {
                receptions.Add(new Reception
                {
                    Id = Guid.Parse(dataReader["Id"].ToString()),
                    Begin = DateTime.Parse(dataReader["Begin"].ToString()),
                    End = DateTime.Parse(dataReader["End"].ToString())
                    
                });
            }
            dataReader.Close();
            command.Dispose();

            return receptions;
        }

        public override void Update(Reception entity)
        {

            var updateSqlScript = "update Players set Begin = @Begin, End = @End, IsUse = @IsUse  where Id = @Id";
            var command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandText = updateSqlScript;
            command.ExecuteNonQuery();
            command.Dispose();
        }
    }
}
