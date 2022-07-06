using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Net;

namespace YourTube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Youtube Url")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete("loader.bat");
            }
            catch
            {
                
            }
            tx_cmdstring.Text = "";
            tx_cmdstring.Text += " ";
            tx_cmdstring.Text += textBox1.Text;
           
        
            if (comboBox1.Text == "Playlist Yes")
            {
                tx_cmdstring.Text += " --yes-playlist";
              

            }
            else
            {
                tx_cmdstring.Text += " --no-playlist";
            }
            if (comboBox2.Text == "MP3")
            {
                tx_cmdstring.Text += " --audio-format mp3 -x";
               

            }
            else
            {
                tx_cmdstring.Text += " -S res,ext:mp4:m4a --recode mp4";
                if (comboBox4.Text.Contains("144"))
                {
                    tx_cmdstring.Text += " -f ";
                    tx_cmdstring.Text += comboBox4.Text;
                }
                else if (comboBox4.Text.Contains("240"))
                {
                    tx_cmdstring.Text += " -f ";
                    tx_cmdstring.Text += comboBox4.Text;
                }
                else if (comboBox4.Text.Contains("360"))
                {
                    tx_cmdstring.Text += " -f ";
                    tx_cmdstring.Text += comboBox4.Text;
                }
                else if (comboBox4.Text.Contains("480"))
                {
                    tx_cmdstring.Text += " -f ";
                    tx_cmdstring.Text += comboBox4.Text;
                }
                else if (comboBox4.Text.Contains("720"))
                {
                    tx_cmdstring.Text += " -f ";
                    tx_cmdstring.Text += comboBox4.Text;
                }
                else if (comboBox4.Text.Contains("Best 4k / 1080"))
                {

                }

            }
           

            if (comboBox3.Text == "ID")
            {
                tx_cmdstring.Text += " -o %(id)s.%(ext)s";
            }
            else if (comboBox3.Text == "Title")
            {
                tx_cmdstring.Text += " -o %(title)s.%(ext)s";
            }
            else if (comboBox3.Text == "Title + ID")
            {
                tx_cmdstring.Text += " -o %(title)s.%(ext)s.%(id)s";
            }
            if(comboBox5.Text == "Add Thumbnail")
            {
                tx_cmdstring.Text += " --embed-thumbnail";
            }else if (comboBox5.Text == "Add Metadata")
            {
                tx_cmdstring.Text += " --embed-metadata";
                tx_cmdstring.Text += " --xattrs";
            }
            else if (comboBox5.Text == "Add Metadata + Thumbnail")
            {
                tx_cmdstring.Text += " --embed-thumbnail";
                tx_cmdstring.Text += " --embed-metadata";
                tx_cmdstring.Text += " --xattrs";
            }

            tx_cmdstring.Text += " --geo-bypass";
            textBox2.Text = tx_cmdstring.Text;

            string strCmdText;
            strCmdText = tx_cmdstring.Text;
                 System.Diagnostics.Process.Start("yt-dlp.exe", strCmdText);
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button1, "Download file or playlist");
            toolTip1.SetToolTip(this.textBox2, "yt-dlp.exe string");
            toolTip1.SetToolTip(this.textBox1, "Video or playlist url");
            toolTip1.SetToolTip(this.comboBox1, "Playlist Yes/No");
            toolTip1.SetToolTip(this.comboBox2, "Format MP3/MP4");
            toolTip1.SetToolTip(this.comboBox3, "Name format ID/Title/Title + ID");
            toolTip1.SetToolTip(this.comboBox4, "Video quality 144/240/360/480/720/Best 4k / 1080");
            toolTip1.SetToolTip(this.comboBox5, "Add Metadata");
            toolTip1.SetToolTip(this.pictureBox1, "Copy yt-dlp.exe string");
            toolTip1.SetToolTip(this.pictureBox2, "Click me ^.^");
            toolTip1.SetToolTip(this.button2, "Move all *.mp4/*.mp3 files to the files folder");
            toolTip1.SetToolTip(this.button3, "Download ffmpeg.exe and yt-dlp.exe (you need this)");
            tx_cmdstring.Visible = false;
            try
            {
                Directory.CreateDirectory("files");
            }
            catch
            {

            }
            tx_cmdstring.Text = "";
            label1.Text = "";
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "MP3")
            {

                comboBox4.Hide();

            }
            else
            {

                comboBox4.Show();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "MP3")
            {

                comboBox4.Hide();

            }
            else
            {

                comboBox4.Show();
            }
        }

        private void tx_cmdstring_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tx_cmdstring.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string paths = System.Reflection.Assembly.GetExecutingAssembly().Location;
            

            label1.Text = paths;
            label1.Text = label1.Text.Replace("YourTube.exe", "");
            //label1.Text = label1.Text.Replace("\\", "/");
            string filepath = label1.Text;
            DirectoryInfo d = new DirectoryInfo(filepath);

            foreach (var file in d.GetFiles("*.mp3"))
            {
                try
                {
                    Directory.Move(file.FullName, filepath + "\\files\\" + file.Name);
                }
                catch { 
                }
            
            }

            foreach (var file in d.GetFiles("*.mp4"))
            {
                try
                {
                    Directory.Move(file.FullName, filepath + "\\files\\" + file.Name);
                }
                catch
                {
                }

            }

            foreach (var file in d.GetFiles("*.webm"))
            {
                try
                {
                    Directory.Move(file.FullName, filepath + "\\files\\" + file.Name);
                }
                catch
                {
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete("ffmpeg.exe");
                File.Delete("yt-dlp.exe");
            }
            catch { 
            
            }
            try
            {
                MessageBox.Show("Download size => 115 MB");
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://xamplex.de/data/ffmpeg.exe", "ffmpeg.exe");
                    client.DownloadFile("https://xamplex.de/data/yt-dlp.exe", "yt-dlp.exe");
                }
                MessageBox.Show("Downloaded");
            }
            catch
            {
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(textBox2.Text);
            }
            catch
            {

            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/7qE4rTv9fq");
        }
    }
}
