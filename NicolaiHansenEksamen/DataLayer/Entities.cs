using System;
using System.Collections.Generic;
using System.Text;

namespace NicolaiHansenEksamen.DataLayer
{
    class Entities
    {
        string accountId;
        int profileIconId;
        long revisionDate;
        string name;
        string id;
        string puuid;
        long summonerLevel;





    public string AccountId { get => accountId; set => accountId = value; }
        public int ProfileIconId { get => profileIconId; set => profileIconId = value; }
        public long RevisionDate { get => revisionDate; set => revisionDate = value; }
        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public string Puuid { get => puuid; set => puuid = value; }
        public long SummonerLevel { get => summonerLevel; set => summonerLevel = value; }

        public static explicit operator string(Entities v)
        {
            throw new NotImplementedException();
        }
    }
}
