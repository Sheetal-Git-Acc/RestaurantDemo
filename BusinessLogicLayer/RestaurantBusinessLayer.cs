using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class RestaurantBusinessLayer
    {
        public IEnumerable<Restaurant> restaurants
        {

            get
            {

                DataAccessLayer.Connection cn = new DataAccessLayer.Connection();
         
                string CS = cn.strConn();

                List<Restaurant> restaurants = new List<Restaurant>();

                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("USP_GetAllRestaurant", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Restaurant restaurant = new Restaurant();
                        restaurant.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                        restaurant.RestaurantName = dr["RestaurantName"].ToString();
                        restaurant.Address = dr["Address"].ToString();
                        restaurant.MobileNo = dr["MobileNo"].ToString();

                        restaurants.Add(restaurant);
                    }
                }
                return restaurants;

            }
        }
        public void AddRestaurant(Restaurant restaurant)
        {
            DataAccessLayer.Connection cn = new DataAccessLayer.Connection();
            //var configuation = cn.GetConfiguration();
            //  string CS = configuation.GetSection("Data").GetSection("ConnectionStrings").Value;
            //string CSadd = cn.strConn();
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_RestaurantOps", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@RestaurantID", restaurant.RestaurantID);
                cmd.Parameters.AddWithValue("@RestaurantName", restaurant.RestaurantName);
                cmd.Parameters.AddWithValue("@Address", restaurant.Address);
                cmd.Parameters.AddWithValue("@MobileNo", restaurant.MobileNo);
                cmd.Parameters.AddWithValue("@OperationType", "Insert");

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            DataAccessLayer.Connection cn = new DataAccessLayer.Connection();
           
            string CS = cn.strConn();
            

            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_RestaurantOps", con);
                cmd.CommandType = CommandType.StoredProcedure;
             
                cmd.Parameters.AddWithValue("@RestaurantID", restaurant.RestaurantID);
                cmd.Parameters.AddWithValue("@RestaurantName", restaurant.RestaurantName);
                cmd.Parameters.AddWithValue("@Address", restaurant.Address);
                cmd.Parameters.AddWithValue("@MobileNo", restaurant.MobileNo);
                cmd.Parameters.AddWithValue("@OperationType", "Update");

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {

            DataAccessLayer.Connection cn = new DataAccessLayer.Connection();

            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_RestaurantOps", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RestaurantID", restaurant.RestaurantID);
           
                cmd.Parameters.AddWithValue("@OperationType", "Delete");
                cmd.ExecuteNonQuery();
            }
        }
    }
}
