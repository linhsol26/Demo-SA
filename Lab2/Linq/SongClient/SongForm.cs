using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongClient
{
    public partial class SongForm : Form
    {
        public SongForm()
        {
            InitializeComponent();
        }
        private void SongForm_Load(object sender, EventArgs e)
        {
            List<Song> songs = new SongBUS().GetAll();
            gridSong.DataSource = songs;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // search btn
            String keyword = textKeyword.Text.Trim();
            List<Song> songs = new SongBUS().Search(keyword);
            gridSong.DataSource = songs;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Song newSong = new Song()
            {
                Id = 0,
                Title = txtTitle.Text.Trim(),
                Singer = txtSinger.Text.Trim(),
                Album = txtAlbum.Text.Trim(),
                Genre = txtGenre.Text.Trim(),
            };

            bool result = new SongBUS().AddNew(newSong);
            if (result)
            {
                List<Song> songs = new SongBUS().GetAll();
                gridSong.DataSource = songs;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Song newSong = new Song()
            {
                Id = int.Parse(txtId.Text.Trim()),
                Title = txtTitle.Text.Trim(),
                Singer = txtSinger.Text.Trim(),
                Album = txtAlbum.Text.Trim(),
                Genre = txtGenre.Text.Trim(),
            };

            bool result = new SongBUS().Update(newSong);
            if (result)
            {
                List<Song> songs = new SongBUS().GetAll();
                gridSong.DataSource = songs;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int id = int.Parse(txtId.Text.Trim());

                bool result = new SongBUS().Delete(id);
                if (result)
                {
                    List<Song> songs = new SongBUS().GetAll();
                    gridSong.DataSource = songs;
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }



        private void gridSong_SelectionChanged(object sender, EventArgs e)
        {
            if (gridSong.SelectedRows.Count > 0)
            {
                int id = int.Parse(gridSong.SelectedRows[0].Cells["Id"].Value.ToString());
                Song song = new SongBUS().GetDetails(id);
                if (song != null)
                {
                    txtId.Text = song.Id.ToString();
                    txtTitle.Text = song.Title;
                    txtSinger.Text = song.Singer;
                    txtAlbum.Text = song.Album;
                    txtGenre.Text = song.Genre;
                }
            }
        }
    }
}
