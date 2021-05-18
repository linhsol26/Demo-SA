using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SongSite
{
    public partial class SongForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<Song> songs = new SongBUS().GetAll();
                gvSongs.DataSource = songs;
                gvSongs.DataBind();
            }
        }

        protected void gvSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = gvSongs.SelectedRow.Cells[1].Text.Trim();
            txtTitle.Text = gvSongs.SelectedRow.Cells[2].Text.Trim();
            txtSinger.Text = gvSongs.SelectedRow.Cells[3].Text.Trim();            txtSinger.Text = gvSongs.SelectedRow.Cells[2].Text.Trim();
            txtGenre.Text = gvSongs.SelectedRow.Cells[4].Text.Trim();
            txtAlbum.Text = gvSongs.SelectedRow.Cells[5].Text.Trim();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtKeyword.Text.Trim();
            List<Song> songs = new SongBUS().Search(keyword);
            gvSongs.DataSource = songs;
            gvSongs.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Song newSong = new Song()
            {
                Title = txtTitle.Text.Trim(),
                Singer = txtSinger.Text.Trim(),
                Genre = txtGenre.Text.Trim(),
                Album = txtAlbum.Text.Trim()
            };
            bool result = new SongBUS().AddNew(newSong);
            if (result)
            {
                List<Song> songs = new SongBUS().GetAll();
                gvSongs.DataSource = songs;
                gvSongs.DataBind();
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Song newSong = new Song()
            {
                Id = int.Parse(txtID.Text.Trim()),
                Title = txtTitle.Text.Trim(),
                Singer = txtSinger.Text.Trim(),
                Genre = txtGenre.Text.Trim(),
                Album = txtAlbum.Text.Trim()
            };
            bool result = new SongBUS().Update(newSong);
            if (result)
            {
                List<Song> songs = new SongBUS().GetAll();
                gvSongs.DataSource = songs;
                gvSongs.DataBind();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int code = int.Parse(txtID.Text.Trim());
            bool result = new SongBUS().Delete(code);
            if (result)
            {
                List<Song> songs = new SongBUS().GetAll();
                gvSongs.DataSource = songs;
                gvSongs.DataBind();
            }
        }
    }
}