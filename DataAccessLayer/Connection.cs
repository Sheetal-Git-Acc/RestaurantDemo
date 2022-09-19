using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace DataAccessLayer
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public interface IDatabaseHandler
    {
        IDbConnection CreateConnection();
        void CloseConnection(IDbConnection connection);
        IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection);
        IDataAdapter CreateAdapter(IDbCommand command);
        IDbDataParameter CreateParameter(IDbCommand command);
    }
    public class Connection
    {
        //string srtpath = "C:\\Users\\DELL\\source\\repos\\Restaurant\\RestaurantFinalApp\\";
        //SqlConnection restcn;

        //public DataSet GetAllRestaurant()
        //{


        // var configuation = GetConfiguration();
        //  SqlConnection scon = new SqlConnection(configuation.GetSection("Data").GetSection("ConnectionStrings").Value);
        //scon.Open();
        // SqlCommand cmd = new SqlCommand("USP_GetAllRestaurants", scon);
        //  SqlDataAdapter sda = new SqlDataAdapter();
        //  cmd.CommandType = CommandType.StoredProcedure;
        //  DataSet ds = new DataSet();
        //  sda.SelectCommand = cmd;
        //  sda.Fill(ds);

        //cmd.ExecuteNonQuery();

        //  scon.Close();
        // }

        //public void insertres()
        // {
        // var configuation = GetConfiguration();
        // SqlConnection scon = new SqlConnection(configuation.GetSection("Data").GetSection("ConnectionStrings").Value);
        //  scon.Open();
        //  SqlCommand cmd = new SqlCommand();
        //  cmd.CommandText = "USP_RestaurantOps";
        //  cmd.CommandType = CommandType.StoredProcedure;
        // cmd.Parameters.Add();
        // cmd.Parameters.Add();

        //  cmd.ExecuteNonQuery();
        //  scon.Close();


        //}
        public string CS = "";
        public string strConn()
        {
            CS = System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            return CS;
        }
        public IConfigurationRoot GetConfiguration()
        {
            // var builder = "";
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
       
    }
    }





       

        //string strconnection = "Data Source=DESKTOP-0G71S4M;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


    


