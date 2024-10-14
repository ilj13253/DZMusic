using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SoundWave.Model
{
    public class AlbumFilterModel
    {
        public required decimal? MinPrice { get; set; }
        public required decimal? MaxPrice { get; set; }
        public required string SearchTerm { get; set; }
    }
}
