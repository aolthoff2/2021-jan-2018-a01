using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region ADDITIONAL NAMESPACES
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace ChinookSystem.ENTITIES
{
    [Table("Tracks")]
    internal class TRACK
    {
        
        private string _Composer;
        [Key]
        public int TrackID { get; set; }

        [Required(ErrorMessage = "Track Name is required.")]
        [StringLength(200, ErrorMessage = "Track Name is limited to 200 characters.")]
        public string Name { get; set; }

        public int? AlbumID { get; set; }
        

        [Required(ErrorMessage = "Media Type ID is required.")]
        public int MediaTypeID { get; set; }

        public int? GenreID { get; set; }

        [StringLength(220,ErrorMessage ="Composer is limited to 220 characters.")]
        public string Composer
        {
            get { return _Composer; }
            set { _Composer = string.IsNullOrEmpty(value) ? null : value; }
        }

        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

        public decimal UnitPrice { get; set; }



        //NAGIVATIONAL PROPERTIES
        public virtual ALBUM ALBUM { get; set; }
        public virtual GENRE GENRE { get; set; }
        public virtual MEDIATYPE MEDIATYPE { get; set; }

        


    }
}
