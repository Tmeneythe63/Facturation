using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Facturation
{
   public class LigneFacture
    {
        public int IdFacture;
        public int IdArticle;
        public float Montant;
        public int QuantiteDemander;

        public LigneFacture()
        {

        }
        public LigneFacture(int IdFacture, int IdArticle, float Montant, int QuantiteDemander)
        {
            this.IdFacture = IdFacture;
            this.IdArticle = IdArticle;
            this.Montant = Montant;
            this.QuantiteDemander = QuantiteDemander;
        }

    }
}
