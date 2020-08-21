using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Server_Client_UI
{
    // Property Of Dynatec Computing 
    // Copyrighted, please do not distribute. 
    // Description: Main UI 
    public partial class Form1 : Form
    {

        bool disable = false;
        bool clicked = false;
        bool clicked_0 = false;
        bool clicked_1 = false;
        bool clicked_2 = false; 
        public Form1()
        {
            InitializeComponent();
        }
        #region Create
        private void label4_MouseMove(object sender, MouseEventArgs e) // Create
        {
            this.Create.BackColor = System.Drawing.Color.Gray; 
        }
        private void label4_MouseLeave(object sender, EventArgs e)
        {
            this.Create.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
        }       
        // click event
        private void label4_Click(object sender, EventArgs e) // Create
        {
            this.Home_0.BackColor = System.Drawing.Color.Gray;
            this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            
            // make all panels visibility false besides the relevant ones
            this.panel2.Visible = true;
            this.panel1.Visible = true;
        }
        #endregion
        #region Delete
        private void Delete_MouseMove(object sender, MouseEventArgs e) // Create
        {
            this.Delete.BackColor = System.Drawing.Color.Gray;
        }
        private void Delete_MouseLeave(object sender, EventArgs e)
        {
            this.Delete.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
        }
        // click event
        private void Delete_Click(object sender, EventArgs e)
        {
            this.Home_0.BackColor = System.Drawing.Color.Gray;
            this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.panel2.Visible = false;
            this.panel1.Visible = true;
            // make all panels visibility false besides the relevant ones
        }
        #endregion
        #region Change
        private void Change_MouseMove(object sender, MouseEventArgs e) // Create
        {
            this.Change.BackColor = System.Drawing.Color.Gray;           
        }
        private void Change_MouseLeave(object sender, EventArgs e)
        {
            this.Change.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
        }
        // click event
        private void Change_Click(object sender, EventArgs e)
        {
            this.Home_0.BackColor = System.Drawing.Color.Gray;
            this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.panel2.Visible = false;
            this.panel1.Visible = true; 
            // make all panels visibility false besides the relevant ones

        }
        #endregion
        #region ChangeServer
        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            this.label5.BackColor = System.Drawing.Color.Gray; 
        }
        private void label5_MouseLeave(object sender, EventArgs e)
        {
            if (clicked_2)
            {
                this.label5.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                this.label5.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            }
            clicked_2 = false; 
        }
        private void label5_Click(object sender, EventArgs e)
        {                                  
           if (this.Change.Visible)
            this.Change.Visible = false;
           if (this.Delete.Visible)
            this.Delete.Visible = false;
           if (this.Create.Visible)
            this.Create.Visible = false;
            if (!this.Forge.Visible)
             this.Forge.Visible = true;
            if (!this.Vanilla.Visible)
             this.Vanilla.Visible = true;
            if (!this.Spigot.Visible)
                this.Spigot.Visible = true;
            // vice versa
        if (disable)
            {
                if (!this.Change.Visible)
                    this.Change.Visible = true;
                if (!this.Delete.Visible)
                    this.Delete.Visible = true;
                if (!this.Create.Visible)
                    this.Create.Visible = true;
                if (this.Forge.Visible)
                    this.Forge.Visible = false;
                if (this.Vanilla.Visible)
                    this.Vanilla.Visible = false;
                if (this.Spigot.Visible)
                    this.Spigot.Visible = false;
            }
            disable = !disable;
            clicked_2 = !clicked_2; 
        }
        #endregion
        #region Forge 
        private void Forge_Click(object sender, EventArgs e)
        {
            this.Home_0.BackColor = System.Drawing.Color.Gray;
            this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.panel2.Visible = false;
            this.panel1.Visible = true;
        }
        #endregion Forge
        #region Spigot
        private void Spigot_Click(object sender, EventArgs e)
        {
            this.Home_0.BackColor = System.Drawing.Color.Gray;
            this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.panel2.Visible = false;
            this.panel1.Visible = true;
        }
        #endregion Spigot
        #region Vanilla 
        private void Vanilla_Click(object sender, EventArgs e)
        {
            this.Home_0.BackColor = System.Drawing.Color.Gray;
            this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.panel2.Visible = false;
            this.panel1.Visible = true;
        }

        #endregion Vanilla

        #region CreatePanel
        private void panel2_Paint(object sender, PaintEventArgs e){}
        #endregion

        #region Home

        private void Home_0_Click(object sender, EventArgs e)
        {        
            this.Home_0.BackColor = System.Drawing.Color.Gray;
            this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.panel1.Visible = true;
            this.panel2.Visible = false;            
            this.label3.Visible = true;           
            clicked_0 = true;   
            
        }
        private void Home_0_MouseMove(object sender, MouseEventArgs e)
        {
            this.Home_0.BackColor = System.Drawing.Color.Gray;
            if (!clicked)
            {
                this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            }
            if (!clicked_1)
            {
                this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            }
        }
        private void Home_0_MouseLeave(object sender, EventArgs e)
        {
            if (clicked_0)
            {
                this.Home_0.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                this.Home_0.BackColor = System.Drawing.Color.FromArgb(40,40,40);
            }
            
        }
        #endregion

        #region diagnostic

        private void diagnostic_Click(object sender, EventArgs e)
        {
            this.Home_0.BackColor = System.Drawing.Color.FromArgb(40, 40, 40); 
            this.Diagnostics.BackColor = System.Drawing.Color.Gray; 
            this.panel2.Visible = false;
            this.panel2.Visible = false;
            this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            clicked_1 = true;
            clicked = false;
            clicked_0 = false;
        }
        private void diagnostic_MouseMove(object sender, MouseEventArgs e)
        {
            this.Diagnostics.BackColor = System.Drawing.Color.Gray;
            if (!clicked)
            {
                this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            }
            if (!clicked_0)
            {
                this.Home_0.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            }
            
        }
        private void diagnostic_MouseLeave(object sender, EventArgs e)
        {
            if (clicked_1)
            {
                this.Diagnostics.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            }
        }
        #endregion
        #region Port Forward
        private void PortForward_MouseMove(object sender, MouseEventArgs e)
        {
            this.pf.BackColor = System.Drawing.Color.Gray;
            if (!clicked_1)
            {
                this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            }
            if (!clicked_0)
            {
                this.Home_0.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            }
        }
        private void PortForward_MouseLeave(object sender, EventArgs e)
        {
            if (clicked)
            {
                this.pf.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            }
        }
        private void PortForward_Click(object sender, EventArgs e)
        {
            this.Home_0.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.pf.BackColor = System.Drawing.Color.Gray;
            this.panel2.Visible = false;
            this.panel2.Visible = false;
            this.panel1.Visible = false;
            this.label3.Visible = false;
            clicked = true;
            clicked_1 = false;
            clicked_0 = false; 
            
        }
        #endregion
        #region labels - Home, Diagnostics, Port Forwarding

        private void Home_Click(object sender, EventArgs e)
        {
            this.Home_0.BackColor = System.Drawing.Color.Gray;
            this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.panel1.Visible = true;
            this.panel2.Visible = false;
            this.label3.Visible = true;
            if (!clicked && !clicked_1)
            {
                clicked_0 = true;
            }
        }
        private void Home_MouseMove(object sender, EventArgs e)
        {
            this.Home_0.BackColor = System.Drawing.Color.Gray;
            this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);           

        }
        private void Home_MouseLeave(object sender, EventArgs e)
        {
            if (clicked_0)
            {
                this.Home_0.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                this.Home_0.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Home_0.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.Diagnostics.BackColor = System.Drawing.Color.Gray;
            this.panel2.Visible = false;
            this.panel2.Visible = false;
            this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            if (!clicked && !clicked_0)
            {
                clicked_1 = true;
            }
        }
        private void label9_MouseMove(object sender, EventArgs e)
        {
            this.Diagnostics.BackColor = System.Drawing.Color.Gray;
            this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.Home_0.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            
            
        }
        private void label9_MouseLeave(object sender, EventArgs e)
        {
            if (clicked)
            {
                this.pf.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            }
        }

        private void Port_Forward_Click(object sender, EventArgs e)
        {
            this.Home_0.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.pf.BackColor = System.Drawing.Color.Gray;
            this.panel2.Visible = false;
            this.panel2.Visible = false;
            this.panel1.Visible = false;
            this.label3.Visible = false;
            if (!clicked_1 && !clicked_0)
            {
                clicked = true;
            }
        }
        private void Port_Forward_MouseMove(object sender, EventArgs e)
        {
            this.pf.BackColor = System.Drawing.Color.Gray;
            this.Diagnostics.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.Home_0.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
           
         
        }
        private void Port_Forward_MouseLeave(object sender, EventArgs e)
        {
            if (clicked)
            {
                this.pf.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                this.pf.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            }
        }
        #endregion
    }
}
