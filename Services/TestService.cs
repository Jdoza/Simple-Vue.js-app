
using StartEx.Domain;
using StartEx.Models.Request;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StartEx.Services
{
    public class TestService : ITestService
    {
        public List<jobs> GetAllJobs()
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StarterConnection"].ConnectionString))
            {
                con.Open(); // opens connection
                var cmd = con.CreateCommand();
               // SqlCommand cmd = con.CreateCommand(); // new command
                cmd.CommandText = "dbo.GetAllInfo";
                cmd.CommandType = CommandType.StoredProcedure;

                using(var reader = cmd.ExecuteReader())
                {
                    var results = new List<jobs>();

                    while (reader.Read())
                    {
                        results.Add(new jobs
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            Company = (string)reader["Company"],
                            Salary = (string)reader["Salary"],
                            Location = (string)reader["Location"],
                            ContactInfo = (string)reader["ContactInfo"]
                        });
                    }
                    return results;
                }
            }
        }

        public int Insert (addJob model)
        {
           using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StarterConnection"].ConnectionString ))
            {
                con.Open(); // opens connection
                var cmd = con.CreateCommand();
                // SqlCommand cmd = con.CreateCommand(); // new command
                cmd.CommandText = "dbo.AddJob";
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Company", model.Company);
                cmd.Parameters.AddWithValue("@Salary", model.Salary);
                cmd.Parameters.AddWithValue("@Location", model.Location);
                cmd.Parameters.AddWithValue("@ContactInfo", model.ContactInfo);

                SqlParameter idParam = new SqlParameter("@Id", SqlDbType.Int);
                idParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(idParam);

                cmd.ExecuteNonQuery();

                return (int)idParam.Value;   
            }

        }

        public void Delete(int Id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StarterConnection"].ConnectionString))
            {
                con.Open(); // opens connection
                var cmd = con.CreateCommand();
                // SqlCommand cmd = con.CreateCommand(); // new command
                cmd.CommandText = "dbo.DeleteJob";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();

            }
        }

        public void Update (updateJob model )
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StarterConnection"].ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "dbo.UpdateJob";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Company", model.Company);
                cmd.Parameters.AddWithValue("@Salary", model.Salary);
                cmd.Parameters.AddWithValue("@Location", model.Location);
                cmd.Parameters.AddWithValue("@ContactInfo", model.ContactInfo);

                cmd.ExecuteNonQuery();
            }
        }
    }
}