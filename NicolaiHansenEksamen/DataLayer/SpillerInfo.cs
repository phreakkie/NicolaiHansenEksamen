using System;
using System.Collections.Generic;
using System.Text;

namespace NicolaiHansenEksamen.DataLayer
{
    class SpillerInfo
    {
        int id;         //Atributter/Fields
        string name;
        string summonerName;
        string rank;
        int phoneNumber;
        string tournamentType;

        public SpillerInfo(int id, string name, string summonerName, string rank, int phoneNumber, string tournamentType) //Constructor
        {
            this.id = id;
            this.name = name;
            this.summonerName = summonerName;
            this.rank = rank;
            this.phoneNumber = phoneNumber;
            this.tournamentType = tournamentType;
        }

        public int Id { get => id; set => id = value; }    //Property
        public string Name { get => name; set => name = value; }
        public string SummonerName { get => summonerName; set => summonerName = value; }
        public string Rank { get => rank; set => rank = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string TournamentType { get => tournamentType; set => tournamentType = value; }
    }
}
