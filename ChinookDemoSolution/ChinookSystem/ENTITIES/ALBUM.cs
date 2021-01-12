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
    [Table("Albums")]
    internal class ALBUM
    {
        private string _ReleaseLabel;
        private int _ReleaseYear;
        [Key]
        public int AlbumID { get; set; }

        [Required(ErrorMessage = "Album Title is required.")]
        [StringLength(160, ErrorMessage = "Album Title is limited to 160 characters.")]
        public string Title { get; set; }

        //[Required(ErrorMessage = "Artist ID is required.")]
        public int ArtistID { get; set; }


        public int ReleaseYear
        {
            get { return _ReleaseYear; }
            set
            {
                if (_ReleaseYear < 1950 || _ReleaseYear > DateTime.Today.Year)
                {
                    throw new Exception("Album Release Year is before 1950, or a year in the future.");
                }
                else
                {
                    _ReleaseYear = value;
                }
            }
        }


        [StringLength(50, ErrorMessage = "Album Release Label is limited to 50 characters.")]
        public string ReleaseLabel
        {
            get { return _ReleaseLabel; }
            set { _ReleaseLabel = string.IsNullOrEmpty(value) ? null : value; }
        }


        //You can still use your [NotMapped] annotations.

        //Navigational Properties
        //classinstancename.propertyname.fieldpropertyname

        //MANY TO ONE RELATIONSHIP!
        //Create the 1 end of the relationship in this entity.

        public virtual ARTIST ARTIST { get; set; }

       
        public virtual ICollection<TRACK> TRACKs { get; set; }

    }
}
