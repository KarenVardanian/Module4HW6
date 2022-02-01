using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW6.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
         public DateTimeOffset ReleasedDate { get; set; }
         public List<SongArtist> SongArtists { get; set; } = new List<SongArtist>();
     
    }
}
