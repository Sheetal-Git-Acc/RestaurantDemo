using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration ;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CuisineBusinessLayer
    {
       
        public IEnumerable<Cuisine> Cuisines
        {
            
            get
            {

                DataAccessLayer.Connection cn = new DataAccessLayer.Connection();
             //   string test = cn.strConn();
                // var configuation = cn.GetConfiguration();
                // string CS = configuation.GetSection("Data").GetSection("ConnectionStrings").Value;
                // string CS = System.Configuration.ConfigurationSettings["DBCS"].ConnectionString;
               //string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ToString();
               string  CS = cn.strConn();

        List<Cuisine> cuisines = new List<Cuisine>();

                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("USP_GetAllCuisine", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Cuisine cuisine = new Cuisine();
                        cuisine.CuisineID = Convert.ToInt32(dr["CuisineID"]);
                        cuisine.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                        cuisine.CuisineName = dr["CuisineName"].ToString();
                        cuisines.Add(cuisine);
                    }
                }
                return cuisines;

            }

        }
        //To insert Cusine 
        public void AddCuisine(Cuisine cuisine)
        {
            DataAccessLayer.Connection cn = new DataAccessLayer.Connection();
            //var configuation = cn.GetConfiguration();
            //  string CS = configuation.GetSection("Data").GetSection("ConnectionStrings").Value;
            //string CSadd = cn.strConn();
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_CuisineOps", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CuisineID", cuisine.CuisineID);
                cmd.Parameters.AddWithValue("@RestaurantID", cuisine.RestaurantID);
                cmd.Parameters.AddWithValue("@CuisineName", cuisine.CuisineName);
                cmd.Parameters.AddWithValue("@OperationType", "Insert");

                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateCuisine(Cuisine cuisine)
        {
            DataAccessLayer.Connection cn = new DataAccessLayer.Connection();
            //var configuation = cn.GetConfiguration();
            // string CS = configuation.GetSection("Data").GetSection("ConnectionStrings").Value;
            string CS = cn.strConn();
           // string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ToString();

            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_CuisineOps", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CuisineID", cuisine.CuisineID);
                cmd.Parameters.AddWithValue("@RestaurantID", cuisine.RestaurantID);
                cmd.Parameters.AddWithValue("@CuisineName", cuisine.CuisineName);
                cmd.Parameters.AddWithValue("@OperationType", "Update");

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCuisine(Cuisine cuisine)
        {

            DataAccessLayer.Connection cn = new DataAccessLayer.Connection();
            // var configuation = cn.GetConfiguration();
            // string CS = configuation.GetSection("Data").GetSection("ConnectionStrings").Value;
            //  string CS = cn.strConn();
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_CuisineOps", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CuisineID", cuisine.CuisineID);
            //    cmd.Parameters.AddWithValue("@RestaurantID", cuisine.RestaurantID);
            //    cmd.Parameters.AddWithValue("@CuisineName", cuisine.CuisineName);
                cmd.Parameters.AddWithValue("@OperationType", "Delete");
                cmd.ExecuteNonQuery();
            }
        }



    }
}
