using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLayer;
using System.Data.SqlClient;
using System.Data;



namespace RestaurantDemo.Controllers
{
    public class ValuesController1 : ApiController
    {
        CuisineBusinessLayer  cbl = new CuisineBusinessLayer();
       List<Cuisine> cuisines = new List<Cuisine>();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        [ActionName("GetCuisineByID")]

        public  Cuisine Get(int id)
        {

            //return listEmp.First(e => e.ID == id);  
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ToString();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = System.Data.CommandType.Text;
            sqlCmd.CommandText = "Select * from Cuisine where CuisineID =" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Cuisine cuisine = null;
            while (reader.Read())
            {
                cuisine = new Cuisine();
                cuisine.CuisineID = Convert.ToInt32(reader.GetValue(0));
                cuisine.RestaurantID = Convert.ToInt32(reader.GetValue(1));
                cuisine.CuisineName = reader.GetValue(2).ToString();
               // emp.Name = reader.GetValue(1).ToString();
                //emp.ManagerId = Convert.ToInt32(reader.GetValue(2));
            }
            myConnection.Close();
            return cuisine;
         
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
              
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}