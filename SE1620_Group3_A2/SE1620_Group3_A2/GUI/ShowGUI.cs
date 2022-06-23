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
    public partial class ShowGUI : Form
    {
        CinemaContext context;
        public ShowGUI()
        {
            InitializeComponent();

            context = new CinemaContext();
            cbFilm.DataSource = context.Films.ToList<Models.Film>();
            cbFilm.DisplayMember = "Title";
            cbFilm.ValueMember = "FilmId";

            dateChoose.Value = DateTime.Now;

            cbRoom.DataSource = context.Rooms.ToList<Models.Room>();
            cbRoom.DisplayMember = "Name";
            cbRoom.ValueMember = "RoomId";

            bindGrid(false);
        }

        void bindGrid(bool filter)
        {

            //DataTable dt = ShowDAO.GetInstance().GetDataTable();
            //int count = dt.Columns.Count;

            //dataGridView1.DataSource = dt;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = context.Shows
                .Where(s => s.FilmId == (filter ? (int)cbFilm.SelectedValue : s.FilmId)
                && s.ShowDate == (filter ? dateChoose.Value : s.ShowDate)
                && s.RoomId == (filter ? (int)cbRoom.SelectedValue : s.RoomId))
                .OrderByDescending(s => s.ShowDate)
                .ToList<Models.Show>();

            int count = dataGridView1.Columns.Count;
            int rows = dataGridView1.Rows.Count;
            lbNumberShows.Text = $"The number of shows:  " + rows;


            DataGridViewButtonColumn btnBookings = new DataGridViewButtonColumn
            {
                Name = "Booking",
                Text = "Bookings",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count, btnBookings);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
            {
                Name = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count+1, btnEdit);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count + 2, btnDelete);

            dataGridView1.Columns["showId"].Visible = false;
            dataGridView1.Columns["status"].Visible = false;
            dataGridView1.Columns["Film"].Visible = false;
            dataGridView1.Columns["Room"].Visible = false;
            dataGridView1.Columns["Bookings"].Visible = false;
            if(Settings.UserName == "")
            {
                dataGridView1.Columns["Edit"].Visible = false;
                dataGridView1.Columns["Delete"].Visible = false;
            }

        }

        //public void bindGrid1(IOrderedQueryable<Models.Show> query)
        //{


        //    /* DataGridViewButtonColumn STT = new DataGridViewButtonColumn
        //     {
        //         Name = "STT",
        //         Text = "STT",
        //     };
        //     dataGridView1.Columns.Insert(0, STT);*/

        //    dataGridView1.Columns.Clear();

        //    dataGridView1.DataSource = query;

            

        //    IQueryable<Models.Show> dt = query;
        //    int rows = dt.Count();
        //    lbNumberShows.Text = $"The number of shows:  "+rows;
        //    int count = 7;

        //    if (Settings.UserName != "") //logined
        //    {

        //            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn()
        //            {
        //                Name = "Edit",
        //                Text = "Edit",
        //                UseColumnTextForButtonValue = true
        //            };
        //            dataGridView1.Columns.Insert(count, btnEdit);
        //            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn()
        //            {
        //                Name = "Delete",
        //                Text = "Delete",
        //                UseColumnTextForButtonValue = true
        //            };
        //            dataGridView1.Columns.Insert(count, btnDelete);
        //            DataGridViewButtonColumn btnBooking = new DataGridViewButtonColumn()
        //            {
        //                Name = "Bookings",
        //                Text = "Bookings",
        //                UseColumnTextForButtonValue = true
        //            };
        //            dataGridView1.Columns.Insert(count, btnBooking);


        //    }
        //    else // ko login
        //    {
        //        btnAddNew.Visible = false; // hidden button add
        //        DataGridViewButtonColumn btnBooking = new DataGridViewButtonColumn
        //        {
        //            Name = "Booking",
        //            Text = "Booking",
        //            UseColumnTextForButtonValue = true
        //        };
        //        dataGridView1.Columns.Insert(count, btnBooking);
        //    }

        //    dataGridView1.Columns["showid"].Visible = false;
        //    dataGridView1.Columns["status"].Visible = false;

        //    //đổ data(date, film, room) vào để search vs add
        //    dateChoose.Value = DateTime.Now;

        //    context = new CinemaContext();
        //    cbFilm.DataSource = context.Films.ToList<Models.Film>();
        //    //cbFilm.DataSource = FilmDAO.GetInstance().GetDataTable("select * from Films");
        //    cbFilm.DisplayMember = "Title";
        //    cbFilm.ValueMember = "FilmID";

        //    //cbRoom.DataSource = RoomDAO.GetInstance().GetDataTable("select * from rooms");
        //    cbRoom.DisplayMember = "Name";
        //    cbRoom.ValueMember = "RoomID";
        //    //bindGrid("select * from shows order by showdate desc");
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string film = cbFilm.SelectedValue.ToString();
            //DateTime date = dateChoose.Value;
            //string roomID = cbRoom.SelectedValue.ToString();
            //String sql = "select * from shows where filmID = '"+film+"' and showdate='"+date+"' and roomid="+roomID;
            //IOrderedQueryable<Models.Show> query = (IOrderedQueryable<Models.Show>)context.Shows
            //    .Where(s => s.FilmId == Int32.Parse(film)
            //    && s.ShowDate == date
            //    && s.RoomId == Int32.Parse(roomID))
            //    .OrderByDescending(s=>s.ShowDate);
            //bindGrid(query);

            bindGrid(true);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
           // this.dataGridView1.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex + 1).ToString();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //int filmId = cbFilm.SelectedValue.ToString();
            //DateTime date = dateChoose.Value;
            //String roomId = cbRoom.SelectedValue.ToString();
            //DTL.Show show = new DTL.Show();
            //show.ShowId = -1; //set to understand: add function
            //show.FilmId = Int32.Parse(filmId);
            //show.ShowDate = date;
            //show.RoomId = Int32.Parse(roomId);

            int roomId;
            roomId = (int)cbRoom.SelectedValue;
            ShowAddEditGUI f = new ShowAddEditGUI(1, roomId, context);

            //ShowAddEditGUI showAddEdit = new ShowAddEditGUI(show);
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
                bindGrid(true);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                int showId = (int)dataGridView1.Rows[e.RowIndex].Cells["ShowID"].Value;
                ShowAddEditGUI f = new ShowAddEditGUI(0, showId, context);
                DialogResult dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                    bindGrid(true);
                //DTL.Show show1 = ShowDAO.GetInstance().GetById(showId);
                //ShowAddEditGUI showAddEdit = new ShowAddEditGUI(show1);
                //DialogResult dr = showAddEdit.ShowDialog();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                int showId = (int)dataGridView1.Rows[e.RowIndex].Cells["ShowID"].Value;
                DialogResult rs = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.No) return;
                try
                {
                    //Show show = ShowDAO.GetInstance().GetById(showId);
                    Show show = context.Shows.Find(showId);
                    context.Shows.Remove(show);
                    context.SaveChanges();

                    bindGrid(true);
                    MessageBox.Show("That shows is deleted!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (e.ColumnIndex == dataGridView1.Columns["Booking"].Index)
            {
                int showId = (int)dataGridView1.Rows[e.RowIndex].Cells["ShowID"].Value;
                BookingGUI b = new BookingGUI(showId,context);
                b.ShowDialog();


            }
        }

        private void ShowGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
