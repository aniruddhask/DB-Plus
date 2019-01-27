using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DragExtenderProvider;

namespace CompleteDataBaseAccess
{
    public partial class TableView : UserControl
    {
        private string _strTableName;
        DragExtender oDragExtender;
        public TableView(string TableName)
        {
            InitializeComponent();
            oDragExtender = new DragExtender();
            _strTableName = TableName;
        }

        private void TableView_Load(object sender, EventArgs e)
        {
            lblTableName.Text = _strTableName;
            oDragExtender.Control = this;
            oDragExtender.SetDraggable(lblTableName, true);
            lblTableName.ForeColor = this.BackColor;
            lblTableName.BackColor = this.ForeColor;
        }
        public void AddColumn(string ColumnName)
        {
            chklstColumns.Items.Add(ColumnName);
        }

        private void TableView_Resize(object sender, EventArgs e)
        {
            pnlTableName.Width = this.Width;
            pnlTableName.Height = this.Height - 14;
            chklstColumns.Width = pnlTableName.Width - 1;
            chklstColumns.Height = pnlTableName.Height - 1;
        }

        private void btnMinMax_Click(object sender, EventArgs e)
        {
            if (this.Height == 154)
            {
                btnMinMax.Text = "+";
                this.Height = 15;
            }
            else
            {
                btnMinMax.Text = "-";
                this.Height = 154;
            }
        }

        private void chklstColumns_MouseDown(object sender, MouseEventArgs e)
        {
            //Clipboard.SetDataObject(_strTableName + "." + chklstColumns.SelectedItem.ToString());
        }
    }
    public class ColumnView : CheckedListBox
    {
        int _iSelectedIndex = 0;
        int _iSelectedIndex1 = 0;
        public ColumnView()
        { }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _iSelectedIndex = SelectedIndex;
            _iSelectedIndex1 = SelectedIndex;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            _iSelectedIndex = SelectedIndex;
        }
        protected override void OnMouseHover(EventArgs e)
        {
            _iSelectedIndex = SelectedIndex;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            _iSelectedIndex = SelectedIndex;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _iSelectedIndex = SelectedIndex;
        }
        protected override void OnMouseCaptureChanged(EventArgs e)
        {
            _iSelectedIndex = SelectedIndex;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            _iSelectedIndex = SelectedIndex;
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            _iSelectedIndex = SelectedIndex;
        }
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            _iSelectedIndex = SelectedIndex;
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            _iSelectedIndex = SelectedIndex;
        }
    }
}
