using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SE1620_Group3_A2.DAL;

namespace SE1620_Group3_A2.GUI
{
    public partial class ShowGUI : Form
    {
        public ShowGUI()
        {
            InitializeComponent();
            bindGrid();
        }

        void bindGrid()
        {
            DataTable dt = ShowDAO.GetInstance().GetDataTable();
            dataGridView1.DataSource = dt;

            int rows = dt.Rows.Count;
            lbNumberShows.Text = $"The number of shows:  "+rows;
            dataGridView1.Columns["showid"].Visible = false;
            dataGridView1.Columns["status"].Visible = false;
        }
    }
}
