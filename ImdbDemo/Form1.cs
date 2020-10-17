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
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                ImdbEntity obj = new ImdbEntity();
                obj = oJS.Deserialize<ImdbEntity>(json);
                if (obj.Response == "True")
                {
                    lblActor.Text = obj.Actors;
                    lblDirector.Text = obj.Director;
                    lblImdbRating.Text = obj.imdbRating;
                    lblGenre.Text = obj.Genre;
                    lblYear.Text = obj.Year;
                    lblPlot.Text = obj.Plot;
                    lblRating.Text = obj.Rated;
                    lblAwards.Text = obj.Awards;
                    lblRuntime.Text = obj.Runtime;
                    picMoviePoster.ImageLocation = obj.Poster;

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
            AboutBox1 obj = new AboutBox1();
            obj.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            this.Dispose();
        }
    }
}
