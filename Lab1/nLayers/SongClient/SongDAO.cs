using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace SongClient
{
    class SongDAO
    {
        public List<Song> SelectAll()
        {
            List<Song> songs = new List<Song>();
            String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM Song";
            SqlCommand com = new SqlCommand(strCom, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                Song song = new Song()
                {
                    Id = (int)dr["Id"],
                    Singer = (String)dr["Singer"],
                    Title = (String)dr["Title"],
                    Album = (String)dr["Album"],
                    Genre = (String)dr["Genre"]
                };
                songs.Add(song);
            }
            return songs;
        }

        public Song SelectById(int id)
        {
            String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM Song WHERE Id = @Id";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Id", id));
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                Song song = new Song()
                {
                    Id = (int)dr["Id"],
                    Singer = (String)dr["Singer"],
                    Title = (String)dr["Title"],
                    Album = (String)dr["Album"],
                    Genre = (String)dr["Genre"]
                };
                return song;
            }
            return null;
        }

        public List<Song> SelectByKeyword(String keyword)
        {
            List<Song> songs = new List<Song>();
            String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM Song WHERE Title LIKE @Keyword or Singer LIKE @Keyword";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Keyword", "%" + keyword + "%"));
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                Song song = new Song()
                {
                    Id = (int)dr["Id"],
                    Singer = (String)dr["Singer"],
                    Title = (String)dr["Title"],
                    Album = (String)dr["Album"],
                    Genre = (String)dr["Genre"]
                };
                songs.Add(song);
            }
            return songs;
        }

        public bool Insert(Song newSong)
        {
            String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "INSERT INTO Song VALUES(@Title, @Singer, @Album, @Genre)";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Title", newSong.Title));
            com.Parameters.Add(new SqlParameter("@Singer", newSong.Singer));
            com.Parameters.Add(new SqlParameter("@Album", newSong.Album));
            com.Parameters.Add(new SqlParameter("@Genre", newSong.Genre));
            try
            {
                return com.ExecuteNonQuery() > 0;
            } catch
            {
                return false;
            }
        }

        public bool Update(Song newSong)
        {
            String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "UPDATE Song SET Title=@Title, Singer=@Singer, Album=@Album, Genre=@Genre WHERE Id=@Id";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Id", newSong.Id));
            com.Parameters.Add(new SqlParameter("@Title", newSong.Title));
            com.Parameters.Add(new SqlParameter("@Singer", newSong.Singer));
            com.Parameters.Add(new SqlParameter("@Album", newSong.Album));
            com.Parameters.Add(new SqlParameter("@Genre", newSong.Genre));
            try
            {
                return com.ExecuteNonQuery() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "DELETE FROM Song WHERE Id=@Id";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Id", id));
            try
            {
                return com.ExecuteNonQuery() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
