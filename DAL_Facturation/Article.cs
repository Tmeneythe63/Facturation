using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Facturation
{
    public class Article
    {
        public string Reference;
        public string Designation;
        public int Quantite;
        public int Promo;
        public DateTime DateFinPromo;
        public float Prix;


        public Article()
        {

        }

        public Article(string Reference, string Designation, int Quantite, int Promo, DateTime DateFinPromo,  float Prix)
        {
            this.Reference = Reference;
            this.Designation = Designation;
            this.Quantite = Quantite;
            this.Promo = Promo;
            this.DateFinPromo = DateFinPromo;
            this.Prix = Prix;

        }

    }
}
