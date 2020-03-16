using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using _2020_2_20demo1.Models;

namespace webAPI.Controllers
{
    public class StoreController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"select StoreId, Name, Address from dbo.Store";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OnBroadingApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Store sto)
        {
            try
            {

                DataTable table = new DataTable();

                string query = @"
                        insert into dbo.Store values('" + sto.Name + "', '" + sto.Address + "'" + @")
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

        public string Put(Store sto)
        {
            try
            {

                DataTable table = new DataTable();

                string query = @"
                        update dbo.Store set Name = '" + sto.Name + @"'
                                ,Address = '" + sto.Address + @"'
                            where StoreId =" + sto.StoreId+ @"
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
                        
                delete from dbo.Store where StoreId = " + id;



                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OnBroadingApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully";
            }
            catch (Exception)
            {
                return "Fail to delete";
            }

        }
    }
}
