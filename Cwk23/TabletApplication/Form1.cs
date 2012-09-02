using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace TabletApplication
{
    public partial class FormTablet : Form
    {

        public FormTablet()
        {
            InitializeComponent();
        }

        #region chairevents

        private void pictureBoxTable1Chair1_Click(object sender, EventArgs e)
        {
            pictureBoxTable1Chair1.Image = Properties.Resources.Button_Blank_Blue_icon;
            pictureBoxTable1Chair2.Image = Properties.Resources.Button_Blank_Green_icon;
            pictureBoxTable1Chair3.Image = Properties.Resources.Button_Blank_Green_icon;
            pictureBoxTable1Chair4.Image = Properties.Resources.Button_Blank_Green_icon;
        }

        private void pictureBoxTable1Chair2_Click(object sender, EventArgs e)
        {
            pictureBoxTable1Chair1.Image = Properties.Resources.Button_Blank_Green_icon;
            pictureBoxTable1Chair2.Image = Properties.Resources.Button_Blank_Blue_icon;
            pictureBoxTable1Chair3.Image = Properties.Resources.Button_Blank_Green_icon;
            pictureBoxTable1Chair4.Image = Properties.Resources.Button_Blank_Green_icon;
        }

        private void pictureBoxTable1Chair3_Click(object sender, EventArgs e)
        {
            pictureBoxTable1Chair1.Image = Properties.Resources.Button_Blank_Green_icon;
            pictureBoxTable1Chair2.Image = Properties.Resources.Button_Blank_Green_icon;
            pictureBoxTable1Chair3.Image = Properties.Resources.Button_Blank_Blue_icon;
            pictureBoxTable1Chair4.Image = Properties.Resources.Button_Blank_Green_icon;
        }

        private void pictureBoxTable1Chair4_Click(object sender, EventArgs e)
        {
            pictureBoxTable1Chair1.Image = Properties.Resources.Button_Blank_Green_icon;
            pictureBoxTable1Chair2.Image = Properties.Resources.Button_Blank_Green_icon;
            pictureBoxTable1Chair3.Image = Properties.Resources.Button_Blank_Green_icon;
            pictureBoxTable1Chair4.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox45.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox44.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox8.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox9.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox10.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureBox42.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pictureBox12.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            pictureBox13.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            pictureBox14.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            pictureBox15.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            pictureBox43.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            pictureBox17.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            pictureBox18.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            pictureBox19.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            pictureBox20.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            pictureBox50.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            pictureBox22.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            pictureBox23.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            pictureBox24.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            pictureBox25.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            pictureBox49.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            pictureBox27.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            pictureBox28.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            pictureBox29.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            pictureBox30.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            pictureBox31.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            pictureBox32.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            pictureBox33.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            pictureBox34.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            pictureBox35.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            pictureBox36.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            pictureBox37.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            pictureBox38.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            pictureBox39.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            pictureBox40.Image = Properties.Resources.Button_Blank_Blue_icon;
        }
        private void pictureBox41_Click(object sender, EventArgs e)
        {
            pictureBox47.Image = Properties.Resources.Button_Blank_Blue_icon;
        }
        private void pictureBox42_Click(object sender, EventArgs e)
        {
            pictureBox48.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        #endregion 

        private void buttonStartOrder_Click(object sender, EventArgs e)
        {
            tabControl1.Enabled = true;

            Order order = new Order();
        }

        private void buttonAssignWaiter_Click(object sender, EventArgs e)
        {
            labelWaiter.Text = textBoxWaiterName.Text;
        }
    }
}
