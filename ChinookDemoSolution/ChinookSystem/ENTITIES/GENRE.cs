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
    [Table("Genres")]
    internal class GENRE
    {
        private string _Name;
        [Key]
        public int GenreID { get; set; }

        [StringLength(120,ErrorMessage ="Genre Name is limited to 120 characters.")]
        public string Name
        {
            get { return _Name; }
            set { _Name = string.IsNullOrEmpty(value) ? null : value; }
        }

        //NAVIGATIONAL PROPERTIES

        public virtual ICollection<TRACK> TRACKs { get; set; }
    }
}
