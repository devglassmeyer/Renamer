using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renamer
{
    internal class songdata
    {
        private bool _renamed = false;
        public string songfile { get; set; }
        public string songfile_renamed { get; set; }
        public bool IsRenamed { get { return _renamed; } set { _renamed = value; } }
        public songdata(string song_file, string song_file_renamed)
        {
            this.songfile = song_file;
            this.songfile_renamed = song_file_renamed;
        }
    }
    internal class albumdata
    {
        private List<songdata> _songdata;

        public string album_path { get; set; }
        public string artist_name { get; set; }
        public List<songdata> songdatas { get; set; }

        public void add_song(songdata songdata) 
        { 
            if (songdata != null)
            {
                var cur_obj = _songdata.Find(x => x.songfile == songdata.songfile);
                if (cur_obj == null)
                {
                    _songdata.Add(songdata);
                }
                else
                {
                    cur_obj.songfile_renamed = songdata.songfile_renamed;
                    cur_obj.IsRenamed = songdata.IsRenamed;
                }
            }
        }
        public albumdata(string album_path_name, string artist_name_string)
        {
            this.album_path = album_path_name;
            this.artist_name = artist_name_string;
            _songdata = new List<songdata>();
        }
    }
}
