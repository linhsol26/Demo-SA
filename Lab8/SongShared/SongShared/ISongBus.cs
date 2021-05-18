using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongShared
{
    interface ISongBus
    {
        List<Song> GetAll();
        Song GetDetails(int code);
        List<Song> Search(string keyword);
        bool AddNew(Song newSong);
        bool Update(Song newSong);
        bool Delete(int code);
    }
}
