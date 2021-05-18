using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Configuration;

namespace SongSite
{
    public class SongDAO
    {
        private DataClasses1DataContext db = new DataClasses1DataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);

        public List<Song> SelectAll()
        {
            db.ObjectTrackingEnabled = false;
            return db.Songs.ToList();
        }

        public Song SelectById(int id)
        {
            return db.Songs.SingleOrDefault(s => s.Id == id);
        }

        public List<Song> SelectByKeyword(String keyword)
        {
            return db.Songs.Where(s => s.Title.Contains(keyword)).ToList();
        }

        public bool Insert(Song song)
        {
            try
            {
                db.Songs.InsertOnSubmit(song);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Update(Song song)
        {
            Song dbSong = db.Songs.SingleOrDefault(s => s.Id == song.Id);

            if (dbSong != null)
            {
                try
                {
                    dbSong.Title = song.Title;
                    dbSong.Singer = song.Singer;
                    dbSong.Genre = song.Genre;
                    dbSong.Album = song.Album;
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }

        public bool Delete(int id)
        {
            Song dbSong = db.Songs.SingleOrDefault(s => s.Id == id);

            if (dbSong != null)
            {
                try
                {
                    db.Songs.DeleteOnSubmit(dbSong);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }
    }
}