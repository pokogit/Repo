using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyEinladungen.Models;

namespace PartyEinladungen.Models
{
    // Hier wurde static verwendet, um Daten von verschiedenen Stellen aus
    // zu speichern und zu lesen
    public static class Repository
    {
        public static List<GuestResponse> responses = new List<GuestResponse>();

        public static IEnumerable<GuestResponse> Responses // Es würde aber List<...> gehen.
        {
            get
            {
                return responses;
            }
        }

        public static void AddResponse(GuestResponse response)
        {
            responses.Add(response);
        }
    }
}
