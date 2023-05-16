using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegisterClients.Classes;
using System.Data.SqlClient;

namespace RegisterClients.Pages.Clients
{
    public class editclientModel : PageModel
    {
        public ClientInfo ClientInformation_ = new ClientInfo();
        public String Error_ = "";
        public String Succeedprocess = "";
        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {
                String ConnectionString = "Data Source=DESKTOP-C52125S;Initial Catalog=registerclients;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    String sql = "Select * from clients WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id",id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                             if(reader.Read())
                            {
                                //Creating an instance of the class ClientInfo
                                ClientInfo ci = new ClientInfo();
                                ci.id = "" + reader.GetInt32(0);
                                ci.name = reader.GetString(1);
                                ci.email = reader.GetString(2);
                                ci.Phone = reader.GetString(3);
                                ci.address = reader.GetString(4);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error_ = ex.Message;
            }
        }
        public void OnPost()
        {
            ClientInformation_.id = Request.Form["id"];
            ClientInformation_.name = Request.Form["name"];
            ClientInformation_.email = Request.Form["email"];
            ClientInformation_.Phone = Request.Form["phone"];
            ClientInformation_.address = Request.Form["address"];

            if (ClientInformation_.id.Length == 0 || ClientInformation_.name.Length == 0 || ClientInformation_.email.Length == 0 || 
                ClientInformation_.Phone.Length == 0 || ClientInformation_.address.Length == 0)
            {
                Error_ = "All of the fields are required for the registration";
                return;
            }

            try
            {
                String ConnectionString = "Data Source=DESKTOP-C52125S;Initial Catalog=registerclients;Integrated Security=True";
                using (SqlConnection conexion = new SqlConnection(ConnectionString))
                {
                    conexion.Open();
                    String sql_update = "UPDATE clients " + "SET name=@name, email=@email, phone=@phone, address=@address WHERE id=@id";

                    using (SqlCommand comando = new SqlCommand(sql_update, conexion))
                    {
                        comando.Parameters.AddWithValue("@name", ClientInformation_.name);
                        comando.Parameters.AddWithValue("@email", ClientInformation_.email);
                        comando.Parameters.AddWithValue("@phone", ClientInformation_.Phone);
                        comando.Parameters.AddWithValue("@address", ClientInformation_.address);
                        comando.Parameters.AddWithValue("@id", ClientInformation_.id);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Error_ = ex.Message;
            }
            Response.Redirect("/Clients/Index");
        }
    }
}
