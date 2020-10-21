using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _2020_2_20demo1.Models;
using System.Web.Http.Cors;

namespace webAPI.Controllers
{
  //  [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"select CustomerId, Name, Address from dbo.Customer";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OnBroadingApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Customer cu)
        {
            try
            {

                DataTable table = new DataTable();

                string query = @"
                        insert into dbo.Customer values('" + cu.Name + "', '" + cu.Address + "'" + @")
                        ";

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OnBroadingApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Add Successfully";
            }
            catch (Exception)
            {
                return "Fail to add";
            }
        }
        public string Put(Customer cu)
        {
            try
            {

                DataTable table = new DataTable();

                string query = @"
                                  update dbo.Customer set Name = '" + cu.Name + @"'
                                 , Address = '" + cu.Address + @"'
                                   where CustomerId =" + cu.CustomerId + @"

                               ";

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OnBroadingApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Add Successfully";
            }
            catch (Exception)
            {
                return "Fail to add";
            }
        }

        public string Delete(int id)
        {
            try
            {

                DataTable table = new DataTable();

                string query = @"
                        
                delete from dbo.Customer where CustomerId = " + id;
                


                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OnBroadingApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted";
            }
            catch (Exception)
            {
                return "Fail to delete";
            }

        }

    }
}
