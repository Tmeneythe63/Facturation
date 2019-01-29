using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Facturation
{
  public  class DAL_LigneFacture
    {
        public static int insert(LigneFacture L)
        {
            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string requete = "Insert into LigneFacture(IdFacture,IdArticle,Montant,QuantiteDemander) values(?,?,?,?)";
            SqlCeCommand cmd = new SqlCeCommand(requete, cnn);

            cmd.Parameters.AddWithValue("Reference", L.IdFacture);
            cmd.Parameters.AddWithValue("Designation", L.IdArticle);
            cmd.Parameters.AddWithValue("Montant",L.Montant );
            cmd.Parameters.AddWithValue("QuantiteDemander", L.QuantiteDemander);

            int i = cmd.ExecuteNonQuery();
            cnn.Close();

            return i;
        }
        public static int getNbrLigneFacture()
        {

            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string cm = "select count(*) from LigneFacture;";
            SqlCeCommand cmd = new SqlCeCommand(cm, cnn);
            int i = (int)cmd.ExecuteScalar();

            cnn.Close();
            return i;

        }

        public static DataTable SelectAll(int IdFacture)
        {
            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string requete = "select Article.Designation AS Designation ,QuantiteDemander AS Quantite ,Article.Prix AS Prix ,Montant from LigneFacture,Facture,Article  where Article.Id=IdArticle and Facture.Id=IdFacture and Facture.Id=" + IdFacture + "";
            SqlCeCommand cmd = new SqlCeCommand(requete, cnn);

            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);


            cnn.Close();
            return dt;
        }
    }
}
