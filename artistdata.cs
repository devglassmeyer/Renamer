using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renamer
{
    internal class artistdata
    {
        private List<albumdata> _albumdata;
        public string name { get; set; }
        public string artist_path { get; set; }

        public void AddAlbum(albumdata adata)
        {
            if (adata != null)
            {
                var cur_obj = _albumdata.Find(x => x.album_path == adata.album_path);
                if (cur_obj == null)
                {
                    _albumdata.Add(adata);
                }
            }
        }

        public bool AlbumExists(string album_path)
        {
            var cur_obj = _albumdata.Find(x => x.album_path == album_path);
            return cur_obj != null;
        }

        public bool AlbumExists(albumdata ad)
        {
            return AlbumExists(ad.album_path);
        }

        public artistdata(string name_of_artist, string path_for_artist)
        {
            this.name = name_of_artist;
            this.artist_path = path_for_artist;
            _albumdata = new List<albumdata>();
        }
    }
}
