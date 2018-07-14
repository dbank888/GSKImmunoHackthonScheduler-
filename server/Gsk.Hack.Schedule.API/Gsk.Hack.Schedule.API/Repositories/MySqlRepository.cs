using Gsk.Hack.Schedule.API.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Repositories
{
    public class MySqlRepository : IDisposable
    {
        private const string ConnectionString =
            "Server=gskdbserverimnno.mysql.database.azure.com; Port=3306; Database=vaccine; Uid=gskadmin@gskdbserverimnno; Pwd=ImmunoH@CK1;";
        private 
        MySqlConnection conn = new MySqlConnection(ConnectionString);

        public MySqlRepository()
        {
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<Recommendation> GetVaccines(string name)
        {
            List<Recommendation> recommendations = new List<Recommendation>();

            string sql = "SELECT p.full_name, v.vaccine_name, v.recommendation_text FROM public.patients p JOIN public.demos d ON (p.current_age_bin = d.age_bin) AND (p.sex = d.sex) AND (p.is_known_pregnant = d.is_pregnant) JOIN public.vaccine_recommendations v ON (d.demo_id = v.demo_id) WHERE family_id = (SELECT family_id FROM public.patients WHERE full_name = @Name) AND is_vaccine_hesitant = 0;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Name", name);

        
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Recommendation recommendation = new Recommendation();
                recommendation.FullName = rdr[0].ToString();
                recommendation.VacineName = rdr[1].ToString();
                recommendation.RecommendationText = rdr[2].ToString();

                recommendations.Add(recommendation);
            }

            rdr.Close();

            return recommendations;
        }

        public int GetNumberOfRoomsAvailable()
        {
            int numberOfRooms = 0;

            string sql = "SELECT COUNT(*) as num_rooms_available FROM public.schedule WHERE timestamp = '2018-08-06Z09:00:00' AND is_available";
            //string sql = "SELECT * FROM TEST WHERE Name='@Name'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            //cmd.Parameters.AddWithValue("@Name", name);


            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Int32.TryParse(rdr[0].ToString(), out numberOfRooms);
            }
            
            rdr.Close();

            return numberOfRooms;
            
        }
    }
}