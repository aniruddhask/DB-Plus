using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CompleteDataBaseAccess
{
    public partial class frmSolar : Form
    {
        public frmSolar()
        {
            InitializeComponent();
        }
        Graphics oGraphics;
        double dAngle = 0.0;
        double dAngleMoon = 0.0;
        double dAngleMars = 120.0;
        double fYEarth;
        double fXEarth;
        double fYMoon;
        double fXMoon;
        double fYMars;
        double fXMars;
        private void frmSolar_Load(object sender, EventArgs e)
        {
            try
            {
                oGraphics = this.CreateGraphics();
                this.BackColor = Color.Black;
                timer1.Start();
                CreateSun();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RunEarth()
        {
            try
            {
                //oGraphics.FillEllipse(Brushes.Black, (float)fXEarth, (float)fYEarth, 20, 20);
                dAngle += 0.001;
                fXEarth = Width / 2 + 120.0 * Math.Cos(dAngle);
                fYEarth = Height / 2 + 90 * Math.Sin(dAngle);
                oGraphics.FillEllipse(Brushes.Blue, (float)fXEarth, (float)fYEarth, 15, 16);
                //RunMoon();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RunMars()
        {
            try
            {
                //oGraphics.FillEllipse(Brushes.Black, (float)fXMars, (float)fYMars, 30, 25);
                dAngleMars += 0.00007;
                fXMars = Width / 2 + 180.0 * Math.Cos(dAngleMars);
                fYMars = Height / 2 + 150 * Math.Sin(dAngleMars);
                oGraphics.FillEllipse(Brushes.DarkRed, (float)fXMars, (float)fYMars, 20, 22);
                //RunMoon();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RunMoon()
        {
            try
            {
                oGraphics.FillEllipse(Brushes.Black, (float)fXMoon, (float)fYMoon, 5, 5);
                dAngleMoon += 0.005;
                fXMoon = fXEarth + 25.0 * Math.Cos(dAngleMoon);
                fYMoon = fYEarth + 25 * Math.Sin(dAngleMoon);
                oGraphics.FillEllipse(Brushes.Wheat, (float)fXMoon, (float)fYMoon, 5, 5);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreateSun()
        {
            try
            {
                oGraphics.FillEllipse(Brushes.Yellow, Width / 2, Height / 2, 30, 30);
                RunEarth();
                RunMars();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                CreateSun();
                //oThread = new Thread(new ThreadStart(CreateSun));
            }
            catch (Exception ex)
            {
            }
        }
    }
}