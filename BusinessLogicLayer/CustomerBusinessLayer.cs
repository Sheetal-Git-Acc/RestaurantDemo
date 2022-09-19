using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CustomerBusinessLayer
    {

        public IEnumerable<Customer> Customers
        {
            get 
            
            {

                DataAccessLayer.Connection cn = new DataAccessLayer.Connection();

                string CS = cn.strConn();
                List<Customer> customers = new List<Customer>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("USP_GetAllCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                        customer.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                        customer.CustomerName = dr["CustomerName"].ToString();
                        customer.Mobileno = dr["MobileNo"].ToString();
                        customers.Add(customer);
                    }
                }

                return customers;

            }

        }
        //To insert Cusine 
        public void AddCustomer(Customer customer)
        {
            DataAccessLayer.Connection cn = new DataAccessLayer.Connection();
            //var configuation = cn.GetConfiguration();
            //  string CS = configuation.GetSection("Data").GetSection("ConnectionStrings").Value;
            //string CSadd = cn.strConn();
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_CustomerOps", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@RestaurantID", customer.RestaurantID);
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@MobileNo", customer.Mobileno);
                cmd.Parameters.AddWithValue("@OperationType", "Insert");

                cmd.ExecuteNonQuery();
            }
        }

    }
}
