using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ImdbDemo
{


    public partial class IMDBForm : Form
    {

        
        public IMDBForm()
        {
            InitializeComponent();
        }

        private void IMDBForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 
            // 'database1DataSet.Table' table. You can move, or remove it, as needed.
            //this.tableTableAdapter.Fill(this.database1DataSet.Table);
            this.txtSearch.Focus();
            this.AcceptButton = btnGetInfo;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://www.omdbapi.com/?t=" + txtSearch.Text.Trim() + "&apikey=fc42c2f";
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                ImdbEntity jsonArray = JsonConvert.DeserializeObject<ImdbEntity>(json);
                
                
                if (jsonArray.Response == "True")
                {
                    lblActor.Text = jsonArray.Actors;
                    lblDirector.Text = jsonArray.Director;
                    lblImdbRating.Text = jsonArray.imdbRating;
                    lblGenre.Text = jsonArray.Genre;
                    lblYear.Text = jsonArray.Year;
                    lblPlot.Text = jsonArray.Plot;
                    lblRating.Text = jsonArray.Rated;
                    lblAwards.Text = jsonArray.Awards;
                    lblRuntime.Text = jsonArray.Runtime;
                    picMoviePoster.ImageLocation = jsonArray.Poster;

                }
                else
                {
                    MessageBox.Show("Movie not Found!!!");
                }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 jsonArray = new AboutBox1();
            jsonArray.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            this.Dispose();
        }
    }
}
