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
    [Table("Artists")]
    internal class ARTIST
    {
        private string _Name;
        [Key]
        public int ArtistID { get; set; }

        //[Required(ErrorMessage = "Artist Name is required.")]
        [StringLength(120, ErrorMessage = "Artist Name is limited to 120 characters.")]
        public string Name
        {
            get { return _Name; }
            set { _Name = string.IsNullOrEmpty(value) ? null : value; }
        }


        //NAVIGATIONAL PROPERTIES
        //ONE TO MANY RELATIONSHIP!
        //Create the many relationship in this entity.

        //Artist has a collection of Albums; an Album belongs to an Artist

        public virtual ICollection<ALBUM> ALBUMs { get; set; }


    }
}
