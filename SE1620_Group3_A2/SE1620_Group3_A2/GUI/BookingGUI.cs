using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SE1620_Group3_A2.Models;

namespace SE1620_Group3_A2.GUI
{
    public partial class BookingGUI : Form
    {
        int id;
        CinemaContext context;
        public BookingGUI(int id, CinemaContext context)
        {
            InitializeComponent();
            this.context = context;
            this.id = id;
            //MessageBox.Show(panel1.Width + "");

            bindPanel();
            bindGrid();
        }

        private void bindPanel()
        {
            panel1.Controls.Clear();
            //đổ data vào datagrid
            List<Booking> bookings = context.Bookings
                .Where(s => s.ShowId == id)
                .ToList<Models.Booking>();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = bookings;


            //đổ data vào checkbox seat
            bool[] arr = new bool[100];
            //String s = "";
            foreach (Booking b in bookings)
            {
                String seatStatus = b.SeatStatus;
                //for (var i = 0; i < 100; i++)
                //{
                //    s += seatStatus[i] + "/";
                //}
                for (var i = 0; i < 100; i++)
                {
                    if(arr[i] == false)
                    {
                        if (seatStatus[i] == '1')
                        {
                            arr[i] = true;
                        }
                        else
                        {
                            arr[i] = false;
                        }

                    }

                }
                //MessageBox.Show("chuoi: " + s);
            }


            //int m = 0;
            //int n = 0;
            //int x = panel1.Width / 10 * (m+1);
            //int y = panel1.Height / 10 * (n+1);

            //CheckBox c = new CheckBox();
            //c.Location = new Point(x, y);
            //panel1.Controls.Add(c);
            ////CheckBox c1 = new CheckBox();
            ////c.Location = new Point(x, y);
            ////panel1.Controls.Add(c1);

            for (var n = 0; n < 10; n++)
            {
                //int n = 0;
                for (var m = 0; m < 10; m++)
                {
                    int index = n * 10 + m;
                    int x = panel1.Width / 10 * (m + 1);
                    int y = panel1.Height / 10 * (n + 1);


                    //panel1.Location = new System.Drawing.Point(x, y);
                    CheckBox c = new CheckBox();
                    c.Checked = arr[index];
                    c.Location = new Point(x, y);
                    c.Size = new Size(20, 20);
                    if (arr[index] == true)
                    {
                        c.Enabled = false;
                    }

                    panel1.Controls.Add(c);
                }
            }
        }

        private void bindGrid()
        {
            dataGridView1.DataSource = context.Bookings
                .Where(s => s.ShowId == id)
                .ToList<Booking>();
            int count = dataGridView1.Columns.Count;

            int rows = dataGridView1.Rows.Count;
            label1.Text = $"Number of bookings:  " + rows;

            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn
            {
                Name = "Detail",
                Text = "Detail",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count, btnDetail);
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count, btnDelete);

            dataGridView1.Columns["Show"].Visible = false;
            dataGridView1.Columns["ShowID"].Visible = false;
            dataGridView1.Columns["BookingID"].Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int bookingId = (int)dataGridView1.Rows[e.RowIndex].Cells["BookingID"].Value;
            if(e.ColumnIndex == dataGridView1.Columns["Detail"].Index)
            {
                BookingDetailGUI detailGUI = new BookingDetailGUI(bookingId, context);
                DialogResult dr = detailGUI.ShowDialog();
                
            }
            if(e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                DialogResult rs = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.No) return;
                try
                {
                    //Show show = ShowDAO.GetInstance().GetById(showId);
                    Booking booking = context.Bookings.Find(bookingId);

                    context.Bookings.Remove(booking);
                    context.SaveChanges();
                    bindPanel();
                    bindGrid();
                    MessageBox.Show("That shows is deleted!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void btnCreateNewBooking_Click(object sender, EventArgs e)
        {
            BookingAddGUI addGUI = new BookingAddGUI(id, context);
            DialogResult dr = addGUI.ShowDialog();
            if(dr == DialogResult.OK)
            {
                bindPanel();
                bindGrid();
            }
        }
    }
}
