using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Serialization;


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
        
        OpenFileDialog fdlg = new OpenFileDialog();
        string directory; 
        public Form1()
        {
            InitializeComponent();
        }
        #region serializer
        class datatypes 
        {
            public string directory { get; set; }
            public int frequency { get; set; }
            public string gdrivefolder { get; set; }

            public string unitoftime { get; set; }

            public bool delete { get; set; }
            public bool uploadFileToFolder { get; set; }

            public bool createnewfile { get; set; }

            public bool uploadFileToFolder_0 { get; set; }
           public XmlSerializer WriteData(string filename)
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    var XML = new XmlSerializer(typeof(datatypes));
                    XML.Serialize(fs, this);
                    return XML;
                }               
            }
            public datatypes ReadData(string filename, XmlSerializer XML)
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    return (datatypes)XML.Deserialize(sr);
                }
            }
        }
        #endregion
        #region CreateOK
        private void okpanel_click(object sender, EventArgs e)
        {

            this.panel4.BackColor = System.Drawing.Color.Gray;
            datatypes dt = new datatypes();

            // check if values passed are indeed valid
            if(fdlg.FileName != null && this.richTextBox1 != null && this.richTextBox3 != null)
            {
                bool result = int.TryParse(this.richTextBox1.Text, out int frequency);
                if(frequency > 0)
                {
                    switch (comboBox1.Text)
                    {
                        case "Minutes":
                            dt.unitoftime = "Minutes";
                            break;
                        case "Seconds":
                            dt.unitoftime = "Seconds";
                            break;
                        case "Hours":
                            dt.unitoftime = "Hours";
                            break;
                        case "Days":
                            dt.unitoftime = "Days";
                             break;                                       
                    }
                    dt.frequency = frequency;
                    dt.gdrivefolder = this.richTextBox3.Text;
                    dt.delete = false;
                    dt.uploadFileToFolder_0 = true;
                    dt.uploadFileToFolder = true;
                    dt.createnewfile = true; 
                } else { result = false; }
                if (!result)
                {
                    MessageBox.Show("Something went horribly  wrong in parsing the input values! Line 73");
                }
                try
                {
                    XmlSerializer xml = dt.WriteData("saveload.xml");
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not Found: \"saveload.ini\"");
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show("Directory not Found: \"saveload.ini\"");
                }
                catch
                {
                    MessageBox.Show("An Unexpected Error Occured!");
                }
            }
            else
            {
                MessageBox.Show("Enter in a correct parameter!");
            }
            Process.Start("backup.exe");
        }
        bool IsMultiple(int x, int y)
        {
            return x % y == 0; 
        }
        #endregion
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
           if (this.  Change.Visible)
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
        #region browse     
        private void label14_Click(object sender, EventArgs e)
        {
            fdlg.Title = "Google API JSON File";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "JSON File (*.json;)|*.json";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                directory = fdlg.FileName;
                fdlg.Dispose();
            }

        }
        #endregion browse
        #region comboboxpaint
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index >= 0 ? e.Index : 0;
            var brush = Brushes.Black;
            e.DrawBackground();
            e.Graphics.DrawString(comboBox1.Items[index].ToString(), 
            e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
        #endregion


    }
}
