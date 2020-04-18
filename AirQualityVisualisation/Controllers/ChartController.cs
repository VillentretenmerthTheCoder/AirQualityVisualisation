using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirQualityVisualisation.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AirData_F2019"];

            using (SqlConnection connection = new SqlConnection(connectionString.ToString()))
            {
                List<KeyValuePair<string, float>> data = new List<KeyValuePair<string, float>>();
                SqlCommand command = new SqlCommand("SELECT StofNavn, RaaResultat FROM Final_View", connection);
                //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        data.Add(new KeyValuePair<string, float>(
                            reader["StofNavn"].ToString(), 
                            float.Parse(reader["RaaResultat"].ToString())));
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    //ViewBag.Data = name;

                    reader.Close();
                }
                var elements = data.Select(x => x.Key).Distinct();
                var nameArray = new List<string>();
                var dataArray = new List<float>();
                foreach (var el in elements)
                {
                    // Exclude a few since charts don't support log scale
                    if (el == "Gasformigt elemtar kviksølv") continue;
                    if (el == "Nedbør") continue;
                    var elementData = data.Where(e => e.Key == el).Select(y => y.Value).Average();
                    nameArray.Add(el);
                    dataArray.Add(elementData);
                }
                ViewBag.DataX = nameArray;
                ViewBag.DataY = dataArray;
            }
            return View();
        }
    }
}