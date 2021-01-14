
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region ADDITIONAL NAMESPACES
using ChinookSystem.BLL;
using ChinookSystem.VIEWMODELS;
#endregion

namespace WebApp.SamplePages
{
    public partial class SearchByDDL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //this is the FIRST TIME
                LoadArtistList();
            }
        }

        protected void LoadArtistList()
        {
            ArtistController sysmgr = new ArtistController();
            List<SelectionList> info = sysmgr.Artists_DDLList();

            //let's assume the data collection needs to be sorted
            info.Sort((x,y) => x.DisplayField.CompareTo(y.DisplayField));

            //setup the ddl
            ArtistList.DataSource = info;
            ArtistList.DataTextField = nameof(SelectionList.DisplayField);
            ArtistList.DataValueField = nameof(SelectionList.ValueField);
            ArtistList.DataBind();

            //setup of a prompt line
            ArtistList.Items.Insert(0, new ListItem("SELECT...", "0"));
        }

        protected void SearchAlbums_Click(object sender, EventArgs e)
        {
            if (ArtistList.SelectedIndex == 0)
            {
                //am i on the first physical line (prompt line) of the DDL
                MessageLabel.Text = "SELECT AN ARTIST FOR THE SEARCH";
                ArtistAlbumList.DataSource = null;
                ArtistAlbumList.DataBind();

            }
            else
            {
                AlbumController sysmgr = new AlbumController();
                List<ChinookSystem.VIEWMODELS.ArtistAlbums> info = sysmgr.Albums_GetAlbumsForArtist(int.Parse(ArtistList.SelectedValue));
                ArtistAlbumList.DataSource = info;
                ArtistAlbumList.DataBind();
            }
        }
    }
}