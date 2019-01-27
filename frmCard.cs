using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompleteDataBaseAccess
{
    public partial class frmCard : Form
    {
        int iNoOfPlayers = 4;
        public frmCard()
        {
            InitializeComponent();
        }
        Graphics oGraphics;
        private void frmCard_Load(object sender, EventArgs e)
        {
            oGraphics = panel1.CreateGraphics();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            try
            {
                Pen oPen = new Pen(Color.Red);
                Font oFont = new Font("Verdana", 8);
                oGraphics.DrawEllipse(oPen, 10, 10, panel1.Width - 20, panel1.Height - 20);
                oGraphics.DrawString("Aniruddha", oFont, Brushes.Green, (float)((panel1.Width - 20) * Math.Cos(0)), (float)((panel1.Height - 20) * Math.Sin(0)));
            }
            catch (Exception ex)
            {

            }
        }
    }
}