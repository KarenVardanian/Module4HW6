using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW6.Entities
{
    public class Ganre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Song> Songs { get; set; }=new List<Song>();
        
    }
}
