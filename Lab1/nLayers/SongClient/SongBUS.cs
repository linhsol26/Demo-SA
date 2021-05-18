using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongClient
{
    class SongBUS
    {
        public List<Song> GetAll()
        {
            List<Song> songs = new SongDAO().SelectAll();
            return songs;
        }

        public Song GetDetails(int id)
        {
            Song song = new SongDAO().SelectById(id);
            return song;
        }

        public List<Song> Search(String keyword)
        {
            List<Song> songs = new SongDAO().SelectByKeyword(keyword);
            return songs;
        }

        public bool AddNew(Song newSong)
        {
            return new SongDAO().Insert(newSong);
        }

        public bool Update(Song newSong)
        {
            return new SongDAO().Update(newSong);
        }

        public bool Delete(int id)
        {
            return new SongDAO().Delete(id);
        }
    }
}
