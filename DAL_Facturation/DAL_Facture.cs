using System.Data;
using System.Data.SqlServerCe;
using System.Linq;

namespace DAL_Facturation
{
   public class DAL_Facture
    {
        public static int insert(Facture F)
        {
            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string requete = "Insert into Facture(Reference,Date,Total,Client) values(?,?,?,?)";
            SqlCeCommand cmd = new SqlCeCommand(requete, cnn);

            cmd.Parameters.AddWithValue("Reference", F.Reference);
            cmd.Parameters.AddWithValue("Date", F.Date);
            cmd.Parameters.AddWithValue("Total", F.Total);
            cmd.Parameters.AddWithValue("Client", F.Client);



            int i = cmd.ExecuteNonQuery();
            cnn.Close();

            return i;
        }
        public static float getTotalFactureByReference(string reference)
        {

            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string cm = "select Total from Facture where Reference='" + reference + "'";
            SqlCeCommand cmd = new SqlCeCommand(cm, cnn);
            float TotalFacture;

            if (cmd.ExecuteScalar() != null)
                TotalFacture =( float)cmd.ExecuteScalar();
            else
                TotalFacture = -1;

            cnn.Close();
            return TotalFacture;
        }
        public static int getNbrFacture()
        {

            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string cm = "select count(*) from Facture;";
            SqlCeCommand cmd = new SqlCeCommand(cm, cnn);
            int i = (int)cmd.ExecuteScalar();

            cnn.Close();
            return i;

        }
        public static DataTable SelectAll()
        {
            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string requete = "select Reference,Date,Total,Client from Facture;";
            SqlCeCommand cmd = new SqlCeCommand(requete, cnn);

            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);


            cnn.Close();
            return dt;
        }
        public static int Delete(string reference)
        {
            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string cm = "delete from Facture where Reference='" + reference + "'";
            SqlCeCommand cmd = new SqlCeCommand(cm, cnn);
            int i = cmd.ExecuteNonQuery();
            cnn.Close();
            return i;
        }

        public static DataTable SelectAllByAnyValue(string value)
        {
            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();
            string requete;

            requete = "select Reference,Date,Total,Client from Facture where  Reference='" + value + "' or Client='" +value +"' ";

            SqlCeCommand cmd = new SqlCeCommand(requete, cnn);

            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);








            cnn.Close();
            return dt;
        }
        public static int Update(Facture e)
        {

                SqlCeConnection connection = Connection.getConnection();
                connection.Open();

                string requete= "update Facture set Date=?,Total=?,Client=? where Reference=?";

                
                SqlCeCommand cmd = new SqlCeCommand(requete, connection);

                
               
                cmd.Parameters.AddWithValue("Date",e.Date);
                cmd.Parameters.AddWithValue("Total", e.Total);
            cmd.Parameters.AddWithValue("Client", e.Client);
            cmd.Parameters.AddWithValue("Reference", e.Reference);
               

            int i = cmd.ExecuteNonQuery();
                connection.Close();


           
            return i;
        }
        //UpdateTotalFacture
        public static int UpdateTotalFacture(int IdFacture, float Montant)
        {

            SqlCeConnection connection = Connection.getConnection();
            connection.Open();

            string requete = "update Facture set Total=Total + ? where Id=?";


            SqlCeCommand cmd = new SqlCeCommand(requete, connection);



          

            cmd.Parameters.AddWithValue("Total", Montant);
            cmd.Parameters.AddWithValue("Id", IdFacture);



            int i = cmd.ExecuteNonQuery();
            connection.Close();



            return i;
        }
        public static int getIdFactureByReference(string reference)
        {

            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string cm = "select Id from Facture where Reference='" + reference + "'";
            SqlCeCommand cmd = new SqlCeCommand(cm, cnn);
            int idArticle;

            if (cmd.ExecuteScalar() != null)
                idArticle = (int)cmd.ExecuteScalar();
            else
                idArticle = -1;

            cnn.Close();
            return idArticle;
        }
    }

}

    

