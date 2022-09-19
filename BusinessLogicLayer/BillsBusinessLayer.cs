using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using DataAccessLayer;

namespace BusinessLogicLayer
{
   public  class BillsBusinessLayer
    {
        public IEnumerable<Bills> Bills
        {

            get
            {

                DataAccessLayer.Connection cn = new DataAccessLayer.Connection();
                //   string test = cn.strConn();
                // var configuation = cn.GetConfiguration();
                // string CS = configuation.GetSection("Data").GetSection("ConnectionStrings").Value;
                // string CS = System.Configuration.ConfigurationSettings["DBCS"].ConnectionString;
                //string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ToString();
                string CS = cn.strConn();

                List<Bills> bills = new List<Bills>();

                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("USP_GetAllBills", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Bills bill = new Bills();
                        // cuisine.CuisineID = Convert.ToInt32(dr["CuisineID"]);
                        // cuisine.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                        //  cuisine.CuisineName = dr["CuisineName"].ToString();
                         bills.Add(bill);
                    }
                }
                return bills;

            }


        }


        }
    }
