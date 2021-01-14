using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region ADDITIONAL NAMESPACES
using ChinookSystem.ENTITIES; //for the internal entites
using ChinookSystem.DAL; //for the context class
using ChinookSystem.VIEWMODELS; //for the public data classes for transporting data from the library to the web app
using System.ComponentModel; //is for ODS
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class ArtistController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<SelectionList> Artists_DDLList()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<SelectionList> results = from x in context.ARTISTs
                                                     orderby x.Name
                                                select new SelectionList
                                                {
                                                    ValueField = x.ArtistID,
                                                    DisplayField = x.Name
                                                };
                return results.ToList();
            }
        }
    }
}
