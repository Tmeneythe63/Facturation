using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Facturation
{
    public class DAL_Article
    {
        public static int insert(Article A)
        {
            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();
            string requete;
            SqlCeCommand cmd;
            if (A.Promo == 1)
            {
                requete = "Insert into Article(Reference,Designation,Quantite,Promo,DateFinPromo,Prix,deleted) values(?,?,?,?,?,?,'false')";
                cmd = new SqlCeCommand(requete, cnn);

                cmd.Parameters.AddWithValue("Reference", A.Reference);
                cmd.Parameters.AddWithValue("Designation", A.Designation);
                cmd.Parameters.AddWithValue("Quantite", A.Quantite);
                cmd.Parameters.AddWithValue("Promo", A.Promo);
                cmd.Parameters.AddWithValue("DateFinPromo", A.DateFinPromo);
                cmd.Parameters.AddWithValue("Prix", A.Prix);
            }
            else
            {
                requete = "Insert into Article(Reference,Designation,Quantite,Promo,Prix,deleted) values(?,?,?,?,?,'false')";
                 cmd = new SqlCeCommand(requete, cnn);

                cmd.Parameters.AddWithValue("Reference", A.Reference);
                cmd.Parameters.AddWithValue("Designation", A.Designation);
                cmd.Parameters.AddWithValue("Quantite", A.Quantite);
                cmd.Parameters.AddWithValue("Promo", A.Promo);
                cmd.Parameters.AddWithValue("Prix", A.Prix);
            }
            
           

            int i = cmd.ExecuteNonQuery();
            cnn.Close();

            return i;
        }

        public static int getIdArticleByReference(string reference)
        {
          
            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string cm = "select Id from Article where Reference='" + reference + "'";
            SqlCeCommand cmd = new SqlCeCommand(cm, cnn);
            int idArticle;

            if (cmd.ExecuteScalar()!=null)
                 idArticle = (int)cmd.ExecuteScalar();
            else
                 idArticle = -1;

            cnn.Close();
            return idArticle;
        }

        public static int getNbrArticle()
        {

            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string cm = "select count(*) from Article  where deleted='false'";
            SqlCeCommand cmd = new SqlCeCommand(cm, cnn);
            int i = (int)cmd.ExecuteScalar();

            cnn.Close();
            return i;

        }
       
        public static int getPromoArticleByReference(string reference)
        {

            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string cm = "select Promo from Article where Reference='" + reference + "' and Promo=1" ;
            SqlCeCommand cmd = new SqlCeCommand(cm, cnn);
            int PromoArticle;

            if (cmd.ExecuteScalar() != null)
            {
                PromoArticle = 1;
            }    
            else
                PromoArticle = 0;

            cnn.Close();
            return PromoArticle;
        }

        public static float getPrixArticleByReference(string reference)
        {

            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string cm = "select Prix from Article where Reference='" + reference + "'";
            SqlCeCommand cmd = new SqlCeCommand(cm, cnn);
            float PrixArticle;

            if (cmd.ExecuteScalar() != null)
            {
                 PrixArticle = float.Parse(cmd.ExecuteScalar().ToString());
            }
            else
                PrixArticle = -1;

            cnn.Close();
            return PrixArticle;
        }
        public static int getQteArticleByReference(string reference)
        {

            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string cm = "select Quantite from Article where Reference='" + reference + "'";
            SqlCeCommand cmd = new SqlCeCommand(cm, cnn);
            int Quantite;

            if (cmd.ExecuteScalar() != null)
            {
                Quantite = Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            else
                Quantite = -1;

            cnn.Close();
            return Quantite;
        }
        

        public static DataTable SelectAll()
        {
            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();
       
            string requete = "select Reference,Designation,Quantite,Promo,DateFinPromo,Prix from Article where deleted='false'";
            SqlCeCommand cmd = new SqlCeCommand(requete, cnn);

            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt); 


            cnn.Close();
            return dt;
        }


        public static ArrayList SelectAllReferences()
        {

            ArrayList listDesReferences = new ArrayList();


            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string requete = "select Reference,Designation,Quantite,Promo,DateFinPromo,Prix from Article  where deleted='false'";
            SqlCeCommand cmd = new SqlCeCommand(requete, cnn);

            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);


            foreach (DataRow row in dt.Rows)
            {
                listDesReferences.Add(row["Reference"]);
               
            }

            cnn.Close();
            return listDesReferences;
        }

        public static DataTable SelectAllByAnyValue(string value)
        {
            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();
            string requete;
         
            requete = "select Reference,Designation,Quantite,Promo,DateFinPromo,Prix from Article where  (Reference LIKE '%" + value + "%' or Designation LIKE '%" + value + "%') and deleted='false' ";

            SqlCeCommand cmd = new SqlCeCommand(requete, cnn);

            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);


            if (value.All(char.IsDigit) && dt.Rows.Count== 0)
            {
                requete = "select Reference,Designation,Quantite,Promo,DateFinPromo,Prix from Article where Quantite='" + Int32.Parse(value) + "' and  deleted='false' ";

                 cmd = new SqlCeCommand(requete, cnn);

                 da = new SqlCeDataAdapter(cmd);

                 dt = new DataTable();
                da.Fill(dt);
            }


           /* float f;
            if(value.IndexOf(",")>0 && value.IndexOf(".") > 0 && float.TryParse(value, out f) && dt.Rows.Count == 0)
            {
               
               requete = "select Reference,Designation,Quantite,Promo,DateFinPromo,Prix from Article where Prix between " + (f - 0.3) + " and   " +  (f + 0.3) + "";

                cmd = new SqlCeCommand(requete, cnn);

                da = new SqlCeDataAdapter(cmd);

                dt = new DataTable();
                da.Fill(dt);
            }
            */


            cnn.Close();
            return dt;
        }

        public static int Delete(string reference)
        {
            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();


            string cm = "update Article set deleted='true' where Reference='" + reference + "'";

            SqlCeCommand cmd = new SqlCeCommand(cm, cnn);
            int i = cmd.ExecuteNonQuery();
            cnn.Close();
            return i;
        }

        

        public static bool NotExistArticle(string reference)
        {

            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            bool notExist;

            string cm = "select Reference from Article where Reference='" + reference + "' ";
            SqlCeCommand cmd = new SqlCeCommand(cm, cnn);
           
            if (cmd.ExecuteScalar() == null)
            {
                notExist= true;
            }
            else
                notExist= false;

            cnn.Close();

            return notExist;

        }

        public static int Update(Article e)
        {

            SqlCeConnection connection = Connection.getConnection();
            connection.Open();
            string requete;
            SqlCeCommand cmd;
            SqlCeParameter pr;
            int i;


            if (e.Promo == 1)
            {
                requete = "update Article set Designation=?,Quantite=?,Promo=?,DateFinPromo=?,Prix=? where Reference=?";
                pr = new SqlCeParameter();
                cmd = new SqlCeCommand(requete, connection);

                cmd.Parameters.AddWithValue("Designation", e.Designation);
                cmd.Parameters.AddWithValue("Quantite", e.Quantite);
                cmd.Parameters.AddWithValue("Promo", e.Promo);
                cmd.Parameters.AddWithValue("DateFinPromo", e.DateFinPromo);
                cmd.Parameters.AddWithValue("Prix", e.Prix);
                cmd.Parameters.AddWithValue("Reference", e.Reference);
                i = cmd.ExecuteNonQuery();
            }
            else
            {
                requete = "update Article set Designation=?,Quantite=?,Promo=?,DateFinPromo=null,Prix=? where Reference=?";
                pr = new SqlCeParameter();
                cmd = new SqlCeCommand(requete, connection);

                cmd.Parameters.AddWithValue("Designation", e.Designation);
                cmd.Parameters.AddWithValue("Quantite", e.Quantite);
                cmd.Parameters.AddWithValue("Promo", e.Promo);
                cmd.Parameters.AddWithValue("Prix", e.Prix);
                cmd.Parameters.AddWithValue("Reference", e.Reference);
                i = cmd.ExecuteNonQuery();
            }
            
            connection.Close();
            return i;
        }

        public static int UpdateQuantiteArticle(int IdArticle, int QuantiteDemander)
        {

            SqlCeConnection connection = Connection.getConnection();
            connection.Open();
            string requete;
            SqlCeCommand cmd;
            int i;


            
                requete = "update Article set Quantite=Quantite-? where Id=?";
            
                cmd = new SqlCeCommand(requete, connection);

             
                cmd.Parameters.AddWithValue("Quantite", QuantiteDemander);
                cmd.Parameters.AddWithValue("Id", IdArticle);
                i = cmd.ExecuteNonQuery();
          

            connection.Close();
            return i;
        }
        public static string getdesignationByReference(string reference)
        {

            SqlCeConnection cnn = Connection.getConnection();
            cnn.Open();

            string cm = "select Designation from Article where Reference='" + reference + "'  and deleted='false'";
            SqlCeCommand cmd = new SqlCeCommand(cm, cnn);
            string Designation;

            if (cmd.ExecuteScalar() != null)
            {
                Designation = cmd.ExecuteScalar().ToString();
            }
            else
                Designation = "";

            cnn.Close();
            return Designation;
        }


    }
}
