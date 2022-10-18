using KumpelApp.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace KumpelApp.Api
{
    public class KumpelService
    {
        private List<Kumpel> KumpelListe;
        public KumpelService()
        {
            KumpelListe = new List<Kumpel>
            {
                new Kumpel
                {
                    Id = 1,
                    Spitzname = "Max",
                    Telefonnummer= "01234567890"
                },

                new Kumpel
                {
                    Id = 2,
                    Spitzname = "Moritz",
                    Telefonnummer = "110"
                },

                new Kumpel
                {
                    Id = 3,
                    Spitzname = "Marie",
                    Telefonnummer = "112"
                }

                
            };
        }

        public List<Kumpel> GetKumpels()
        {
            
            return KumpelListe;
        }


        
    }
}
