using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PythonPlot
{
    public partial class mainForm : Form
    {

        private Stream pStream;

        public mainForm()
        {
            InitializeComponent();

            //Set Window Title
            this.Text = "Python Plot";

            //Open Pipe to Python Script
            pStream = Console.OpenStandardInput();
            
            //Link pictureBox with python stream
            this.plot_pictureBox.Image = new Bitmap(pStream);
            this.plot_pictureBox.Refresh();

            pStream = Console.OpenStandardOutput();
            pStream.WriteByte(0);
            pStream.Flush();
        }

        /// <summary>
        /// Displays the coordinates of the pictureBox upon mouse movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plot_pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point mouseCoordinates = this.plot_pictureBox.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            this.toolStripStatusLabel.Text = mouseCoordinates.ToString();
        }

        private void mainForm_Activated(object sender, EventArgs e)
        {
            //Refresh the plot
            //this.plot_pictureBox.Load();
            //this.plot_pictureBox.Refresh();
            this.toolStripStatusLabel.Text = "Activated";
        }
    }
}
