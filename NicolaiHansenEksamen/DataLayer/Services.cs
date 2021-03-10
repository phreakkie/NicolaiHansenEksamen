using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NicolaiHansenEksamen.DataLayer
{
    class Services
    {
        public bool getName(string name)
        {

            try
            {
            var json = new WebClient().DownloadString($"https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{name}?api_key=RGAPI-09cb83ff-5e01-41dd-900f-bd8699bad895");
                Entities names = JsonConvert.DeserializeObject<Entities>(json);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
