using _2020_2_20demo1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webAPI.Controllers
{
    public class ProductController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"select ProductId, Name, Price from dbo.Product";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OnBroadingApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Product pro)
        {
            try
            {

                DataTable table = new DataTable();

                string query = @"
                        insert into dbo.Product(Name,Price) values('" + pro.Name + "', '" + pro.Price + "'" + @")
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
        public string Put(Product pro)
        {
            try
            {

                DataTable table = new DataTable();

                string query = @"
                                  update dbo.Product set Name = '" + pro.Name + @"'
                                 , Price = '" + pro.Price + @"'
                                   where ProductId =" + pro.ProductId + @"

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
                        
                delete from dbo.Product where ProductId = " + id;



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
