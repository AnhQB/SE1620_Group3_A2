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
    public partial class BookingAddGUI : Form
    {
        int id;
        decimal amount;
        CinemaContext context;
        bool[] arrAdd = new bool[100];

        public BookingAddGUI(int showId, CinemaContext context)
        {
            InitializeComponent();
            this.context = context;
            this.id = showId;
            //MessageBox.Show(panel1.Width + "");
            //đổ data vào datagrid
            List<Booking> bookings = context.Bookings
                .Where(s => s.ShowId == id)
                .ToList<Models.Booking>();

            //đổ data vào checkbox seat
            bool[] arr = new bool[100];
            foreach (Booking b in bookings)
            {
                String seatStatus = b.SeatStatus;
                for (var i = 0; i < 100; i++)
                {
                    if (arr[i] == false)
                    {
                        if (seatStatus[i] == '1')
                        {
                            arr[i] = true;
                            continue;
                        }
                        arr[i] = false;
                    }
                        
                }
            }

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
                    c.CheckedChanged += new EventHandler(check_CheckedChanged);
                    if (arr[index] == true)
                    {
                        c.Enabled = false;
                    }

                    panel1.Controls.Add(c);
                }
            }

            txtAmount.Enabled = false;
        }

        private void check_CheckedChanged(Object sender, EventArgs e)
        {
            //get index checkbox:
            //MessageBox.Show(""+ ((CheckBox)sender).Location);
            int w = panel1.Width / 10;
            int h = panel1.Height / 10;
            //MessageBox.Show("w:" + w + "h:" + h);
            int x = ((CheckBox)sender).Location.X;
            int y = ((CheckBox)sender).Location.Y;
            int index = (y / h - 1) * 10 + (x / w - 1);
            //MessageBox.Show("" + index);


            if (((CheckBox)sender).Checked)
            {

                //update amount
                amount += 10000;
                txtAmount.Text = amount.ToString();
                //add index seat to arr
                this.arrAdd[index] = true;


            }
            else
            {
                amount -= 10000;
                txtAmount.Text = amount.ToString();
                this.arrAdd[index] = false;
            }

            //String s = "";
            //for (var i = 0; i < 100; i++)
            //{
            //    s += Convert.ToInt32(this.arrAdd[i])+"/";
            //}
            //MessageBox.Show(s);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string seatStatus = getStrSeatStatus();
            string name = txtName.Text;
            decimal amount = this.amount;

            Booking booking = new Booking {
                Amount = amount,
                Name = name,
                SeatStatus = seatStatus,
                ShowId = id,
            };
            //MessageBox.Show(booking.Amount + "/"+booking.Name+"/"+booking.SeatStatus+"/"+booking.ShowId);
            context.Bookings.Add(booking);
            context.SaveChanges();
            resetSeatStatus();
            MessageBox.Show("Booking success!");
        }

        private string getStrSeatStatus()
        {
            String s = "";
            for (var i = 0; i < 100; i++)
            {
                s += Convert.ToInt32(this.arrAdd[i]);
            }
            return s;
        }
        private void resetSeatStatus()
        {
            String s = "";
            for (var i = 0; i < 100; i++)
            {
                this.arrAdd[i] = false;
            }
        }
    }
}
