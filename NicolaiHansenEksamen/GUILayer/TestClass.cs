using System;
using System.Collections.Generic;
using System.Text;
using NicolaiHansenEksamen.DataLayer;

namespace NicolaiHansenEksamen.GUILayer
{
    public class TestClass
    {

        DatabaseHandler database = new DatabaseHandler();
        public void testMetode(string name, string smnName, string rank, int phnNmb, string turnType) //Kræver specifikke parametre for at sende data til databasen. 
        {
            try
            {
                database.insertPlayerData(name, smnName, rank, phnNmb, turnType);
            }
            catch
            {

            }
        }
    }
}
