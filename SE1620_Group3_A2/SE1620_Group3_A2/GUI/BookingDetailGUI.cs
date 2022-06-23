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
    public partial class BookingDetailGUI : Form
    {
        int bookingID;
        CinemaContext context;
        public BookingDetailGUI(int bookingID, CinemaContext context)
        {
            InitializeComponent();
            this.bookingID = bookingID;
            this.context = context;

            List<Booking> bookings = context.Bookings
               .Where(s => s.BookingId == bookingID)
               .ToList<Models.Booking>();

            bool[] arr = new bool[100];

            int amount = 0;

            foreach (Booking b in bookings)
            {
                String seatStatus = b.SeatStatus;
                for (var i = 0; i < 100; i++)
                {
                    if (seatStatus[i] == '1')
                    {
                        arr[i] = true;
                        amount += 10000;
                        continue;
                    }
                    arr[i] = false;
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

            txtName.Text = bookings[0].Name;
            txtAmount.Text = bookings[0].Amount.ToString();

        }
    }
}
