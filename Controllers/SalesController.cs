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
    public class SalesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"select ID, convert(varchar(10),DateSold,120) 
                            as DateSold , StoreId, CustomerId, 
                            ProductId from dbo.Sales";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OnBroadingApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Sales Sale)
        {
           
            try
            {

                DataTable table = new DataTable();
                string query = @"
                        insert into dbo.Sales(DateSold, StoreId, CustomerId, ProductId) values('" + Sale.DateSold + @"', " + Sale.StoreId + @", " + Sale.CustomerId + @", " + Sale.ProductId + @")
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

        public string Put(Sales sale)
        {
            try
            {

                DataTable table = new DataTable();


                string query = @"
                                  update dbo.Sales set DateSold = '" + sale.DateSold + @"'
                                 , StoreId = '" + sale.StoreId + @"', CustomerId = '" + sale.CustomerId + @"',
                                    ProductId = '" + sale.ProductId + @"'
                                   where ID =" + sale.Id + @"

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
                        
                delete from dbo.Sales where ID = " + id;



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
