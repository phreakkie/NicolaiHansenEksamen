using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using NicolaiHansenEksamen.DataLayer;

namespace NicolaiHansenEksamen.DataLayer
{
    class DatabaseHandler
    {
        //Streng som forbinder til SQL serveren
        private string connectionString = "Data Source=CV-BB-7503;Initial Catalog=RPGWPFSpil;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private DataSet Execute(string query) //Privat metode af sikkerhedsmæssige årsager. Indkapsler Execute så man ikke kan ændre på hvad der bliver sendt til databasen
        {
            DataSet resultSet = new DataSet();
            try //starten på en Try/Catch
            {

                //Microsoft klasser som bliver brugt til at forbinde til SQL databasen
                using (SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, new SqlConnection(connectionString))))

                {
                    // Open conn, execute query, close conn, wrap result in DataSet: adapter.Fill(resultSet);
                    adapter.Fill(resultSet);
                }
            }
            catch (Exception ex) //Catch delen af en Try/Catch, som udskriver en Exception message hvis Try delen fejler.
            {
                MessageBox.Show("Exception Message: " + ex.Message);
            }
            return resultSet;

        }

        public void insertPlayerData(string name, string smnName,string rank, int phnNmb, string turnType) //Kræver specifikke parametre for at sende data til databasen. 
        {
            Execute($"INSERT INTO Spillere (Name, SummonerName, Rank, PhoneNmb, TurnamentType) " +
                $"VALUES ('{name}', '{smnName}', '{rank}', {phnNmb}, '{turnType}');");
        }

        public SpillerInfo getPlayerData(string smnrName)
        {
            //string query = "SELECT * from dbo.Spillere WHERE SummonerName = " + smnrName;
            DataTable dataTable = new DataTable(); //oprætter et dalatable
            using (var con = new SqlConnection("Data Source=CV-BB-7503;Initial Catalog=RPGWPFSpil;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
            SqlCommand sql = new SqlCommand("SELECT * FROM dbo.Spillere WHERE SummonerName=@smnrName", con);
                sql.Parameters.AddWithValue("@smnrName", smnrName); 
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql);//oprætter en SqlDataAdapter
                da.Fill(dataTable); //fylder data fra det valgte row ind i et datatable

                //DataSet playerInfo = Execute("");
                //DataTable playerTable = playerInfo.Tables[0];

                if (dataTable.Rows.Count == 0)  //Hvis der ikke er nogen rows i datatable får man besked om at spilleren ikke kan findes.
                {
                    MessageBox.Show("Spilleren findes ikke\nTjek om navnet er stavet rigtigt");

                    SpillerInfo tomInfo = new SpillerInfo(0,"","","",0,""); 
                    return tomInfo; //returnerer en "tom" SpillerInfo.
                }
                else
                {
                SpillerInfo spillerInfo = new SpillerInfo((int)dataTable.Rows[0]["ID"], (string)dataTable.Rows[0]["Name"], (string)dataTable.Rows[0]["SummonerName"], (string)dataTable.Rows[0]["Rank"], (int)dataTable.Rows[0]["PhoneNmb"], (string)dataTable.Rows[0]["TurnamentType"]);
                return spillerInfo;
                }
            }
        }
    }
}
