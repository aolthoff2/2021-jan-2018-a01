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

        #region QUERIES


        //due to the fact that the entities are internal, you CANNOT use the entity class as a return data type.
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<ArtistAlbums> Albums_GetArtistAlbums()
        {
            using(var context = new ChinookSystemContext())
            {
               //LINQ to Entity

                IEnumerable<ArtistAlbums> results = from x in context.Albums
                                                    select new ArtistAlbums
                                                    {
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistName = x.Artist.Name
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

                IEnumerable<ArtistAlbums> results = from x in context.Albums
                                                    where x.ArtistId == artistid
                                                    select new ArtistAlbums
                                                    {
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistName = x.Artist.Name,
                                                        ArtistID = x.ArtistId
                                                    };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<AlbumItem> Albums_List()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<AlbumItem> results = from x in context.Albums
                                                    select new AlbumItem
                                                    {
                                                        AlbumId = x.AlbumId,
                                                        Title = x.Title,
                                                        ArtistId = x.ArtistId,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ReleaseLabel = x.ReleaseLabel
                                                    };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AlbumItem Albums_FindById(int albumid)
        {
            using (var context = new ChinookSystemContext())
            {
                AlbumItem results = (from x in context.Albums
                                     where x.AlbumId == albumid
                                     select new AlbumItem
                                     {
                                         AlbumId = x.AlbumId,
                                         Title = x.Title,
                                         ArtistId = x.ArtistId,
                                         ReleaseYear = x.ReleaseYear,
                                         ReleaseLabel = x.ReleaseLabel
                                     }).FirstOrDefault();
                return results;
            }
        }
        #endregion

        #region ADD, UPDATE, DELETE

        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public int Albums_Add(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                //we need to move the data from the the viewmodel class into an entity instance BEFORE staging
                Album entityItem = new Album
                {
                    //the pkey of the albums table is an identity() pkey
                    //therefore you do not need to supply the albumid value
                    Title = item.Title,
                    ArtistId = item.ArtistId,
                    ReleaseYear = item.ReleaseYear,
                    ReleaseLabel = item.ReleaseLabel
                };

                //staging
                context.Albums.Add(entityItem);
                //commit
                context.SaveChanges();
                //since i have an int as the return data type, i will return new identity value
                return entityItem.AlbumId;
            }
        }


        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Albums_Update(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                //we need to move the data from the the viewmodel class into an entity instance BEFORE staging
                Album entityItem = new Album
                {
                    //on updates, you NEED to supply the table's pkey value
                    AlbumId = item.AlbumId,
                    Title = item.Title,
                    ArtistId = item.ArtistId,
                    ReleaseYear = item.ReleaseYear,
                    ReleaseLabel = item.ReleaseLabel
                };

                //staging is to local memory 
                context.Entry(entityItem).State = System.Data.Entity.EntityState.Modified;
                //commit is the action of sending your request to the database for action
                context.SaveChanges();
                
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Albums_Delete(AlbumItem item)
        {
            //this method will call the actual delete method and pass it
            // the only needed piece of data: pkey
            Albums_Delete(item.AlbumId);
        }

        public void Albums_Delete(int albumid)
        {
            using(var context = new ChinookSystemContext())
            {
                var exists = context.Albums.Find(albumid);
                context.Albums.Remove(exists);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
