using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region ADDITIONAL NAMESPACES
using System.Data.Entity;
using ChinookSystem.ENTITIES;
#endregion

namespace ChinookSystem.DAL
{
    internal class ChinookSystemContext:DbContext
    {
        public ChinookSystemContext() : base("name=ChinookDB")
        {

        }

        public DbSet<ARTIST> ARTISTs { get; set; }
        public DbSet<ALBUM> ALBUMs { get; set; }
        public DbSet<GENRE> GENREs { get; set; }
        public DbSet<MEDIATYPE> MEDIATYPEs { get; set; }
        public DbSet<TRACK> TRACKs { get; set; }
    }
}
