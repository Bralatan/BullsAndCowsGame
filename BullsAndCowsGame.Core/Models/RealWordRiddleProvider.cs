using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BullsAndCowsGame.Core.Models.Interfaces;

namespace BullsAndCowsGame.Core.Models
{
    public class RealWordRiddleProvider: IRiddleProvider
    {
        private readonly string _connectionString;

        public RealWordRiddleProvider(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public string GenerateRiddle()
        {
            string randomWord = "";
            string query = "SELECT TOP 1 wordForRiddle FROM Riddle ORDER BY NEWID();";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            randomWord = reader["wordForRiddle"].ToString();
                        }
                    }
                }
            }

            return randomWord;
        }
    }
}
