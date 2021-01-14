using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region ADDITIONAL NAMESPACES
using ChinookSystem.ENTITIES;
using ChinookSystem.DAL;
using ChinookSystem.VIEWMODELS;
using System.ComponentModel; //is for ODS
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        //due to the fact that the entities are internal, you CANNOT use the entity class as a return data type.
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<ArtistAlbums> Albums_GetArtistAlbums()
        {
            using(var context = new ChinookSystemContext())
            {
               //LINQ to Entity

                IEnumerable<ArtistAlbums> results = from x in context.ALBUMs
                                                    select new ArtistAlbums
                                                    {
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistName = x.ARTIST.Name
                                                    };
                return results.ToList();
            }
        }

        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbums> Albums_GetAlbumsForArtist(int artistid)
        {
            using (var context = new ChinookSystemContext())
            {
                //LINQ to Entity

                IEnumerable<ArtistAlbums> results = from x in context.ALBUMs
                                                    where x.ArtistID == artistid
                                                    select new ArtistAlbums
                                                    {
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistName = x.ARTIST.Name,
                                                        ArtistID = x.ArtistID
                                                    };
                return results.ToList();
            }
        }

    }
}
