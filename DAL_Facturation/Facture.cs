using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Facturation
{
   public class Facture
    {
        public string Reference;
        public DateTime Date;
        public float Total;
        public string Client;

        public Facture()
        {

        }
        public Facture (string Reference, DateTime Date, float Total,string Client)
        {
            this.Reference = Reference;
            this.Date = Date;
            this.Total = Total;
            this.Client = Client;
        }

    }
}
