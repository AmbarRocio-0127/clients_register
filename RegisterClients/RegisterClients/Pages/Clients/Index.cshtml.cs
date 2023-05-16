using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegisterClients.Classes;
using System.Data.SqlClient;

namespace RegisterClients.Pages.Clients
{
    public class IndexModel : PageModel
    {
        ///Creating the lis of Clients information
        public List<ClientInfo> ListaClientes = new List<ClientInfo>();
        public void OnGet()
        {
            //creating the exception to catch errors and we will conect the database
            try
            {
            //adding the connection sting to stablish the connection with the database
                String ConnectionString = "Data Source=DESKTOP-C52125S;Initial Catalog=registerclients;Integrated Security=True";
                
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    String sql = "Select * from Clients";
                    using(SqlCommand command = new SqlCommand(sql, connection))
                    {
                    using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Creating an instance of the class ClientInfo
                                ClientInfo ci = new ClientInfo();
                                ci.id = "" + reader.GetInt32(0);
                                ci.name = reader.GetString(1);
                                ci.email = reader.GetString(2);
                                ci.Phone = reader.GetString(3);
                                ci.address = reader.GetString(4);

                                //Adding the information of the clients in the list
                                ListaClientes.Add(ci);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Adding message in case of the error
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
