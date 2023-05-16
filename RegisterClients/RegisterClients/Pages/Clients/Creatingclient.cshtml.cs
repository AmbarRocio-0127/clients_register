using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using RegisterClients.Classes;
using System.Data.SqlClient;

namespace RegisterClients.Pages.Clients
{
    public class CreatingclientModel : PageModel
    {
        //Creating the variables useful
        public ClientInfo ClientInformation = new ClientInfo();
        public String Error_ = "";
        public String Succeedprocess = "";
        public void OnGet()
        {
        }
        //creating the post method 
        public void OnPost() {
            ClientInformation.name = Request.Form["name"];
            ClientInformation.email = Request.Form["email"];
            ClientInformation.Phone = Request.Form["phone"];
            ClientInformation.address = Request.Form["address"];

            if (ClientInformation.name.Length == 0 || ClientInformation.email.Length == 0 || ClientInformation.Phone.Length == 0 || ClientInformation.address.Length == 0)
            {
                Error_ = "All of the fields are required for the registration";
                return;
            }
            //Saving the Data into the database*
            try
            {
                String Connectionstring = "Data Source=DESKTOP-C52125S;Initial Catalog=registerclients;Integrated Security=True";

                using (SqlConnection conexion = new SqlConnection(Connectionstring))
                {
                    conexion.Open();
                    string Insertsql = "INSERT INTO clients " +
                        "(name, email, phone, address)" +
                        "VALUES(@name, @email, @phone, @address);";

                    using (SqlCommand comand = new SqlCommand(Insertsql, conexion))
                    {
                        comand.Parameters.AddWithValue("@name", ClientInformation.name);
                        comand.Parameters.AddWithValue("@email", ClientInformation.email);
                        comand.Parameters.AddWithValue("@phone", ClientInformation.Phone);
                        comand.Parameters.AddWithValue("@address", ClientInformation.address);
                        comand.ExecuteNonQuery();
                    }
                }

            }catch (Exception ex) { 
            Error_ = ex.Message;
            return;
            }   

            ClientInformation.name = ""; ClientInformation.email = ""; ClientInformation.Phone = ""; ClientInformation.address = "";
            Succeedprocess = "Information added successfully";

            Response.Redirect("/Clients/Index");
        }
    }
}
