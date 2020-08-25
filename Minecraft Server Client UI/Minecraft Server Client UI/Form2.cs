using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;


namespace Minecraft_Server_Client_UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            ClientInfo client;
            InitializeComponent();
            var name = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            this.progressBar1.Value = 0;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
            this.progressBar1.Step = 1;

           
                progressBar1.PerformStep();
            
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LimeGreen, e.ClipRectangle);
        }
        private void Form2_Load(object sender, EventArgs e){}

        void CheckForUpdates()
        {

        }

        
    }
}
