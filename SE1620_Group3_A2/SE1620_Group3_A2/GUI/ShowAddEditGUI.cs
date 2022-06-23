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
    
    public partial class ShowAddEditGUI : Form
    {
        int add, id;
        CinemaContext context;
        public ShowAddEditGUI(int add, int id, CinemaContext context)
        {
            InitializeComponent();
            this.context = context;
            this.add = add;
            this.id = id;

            cbRoom.DataSource = context.Rooms.ToList<Room>();
            cbRoom.DisplayMember = "Name";
            cbRoom.ValueMember = "RoomId";

            cbFilm.DataSource = context.Films.ToList<Film>();
            cbFilm.DisplayMember = "Title";
            cbFilm.ValueMember = "FilmId";

            if (add == 1) // add
            {
                cbRoom.SelectedValue = id;
                dateChoose.Value = DateTime.Now;

                bool[] slots = new bool[9];
                List<Show> shows = context.Shows
                    .Where(s => s.ShowDate == DateTime.Now.Date
                    && s.RoomId == id)
                    .ToList<Show>();
                foreach (Show s in shows)
                    slots[(int)s.Slot - 1] = true;
                for (int i = 0; i < slots.Length; i++)
                    if (slots[i] == false) cbSlot.Items.Add(i + 1);

                cbSlot.SelectedIndex = 0;


                //cbRoom.DataSource = RoomDAO.GetInstance().GetDataTable("select * from rooms");
                //cbRoom.DisplayMember = "Name";
                //cbRoom.ValueMember = "RoomId";
                //cbRoom.Enabled = true;

                //dateChoose.Value = show.ShowDate;

                //cbSlot.DataSource = SlotDAO.GetInstance().GetDataTable();
                //cbSlot.DisplayMember = "slot";
                //cbSlot.ValueMember = "slot";

                //cbFilm.DataSource = FilmDAO.GetInstance().GetDataTable("select * from Films");
                //cbFilm.DisplayMember = "Title";
                //cbFilm.ValueMember = "FilmId";
                //cbFilm.SelectedValue = show.FilmId;

            }
            else // edit
            {

                Show show = context.Shows.Find(id);
                cbRoom.SelectedValue = show.RoomId;
                dateChoose.Value = show.ShowDate ?? DateTime.Now;

                cbFilm.SelectedValue = show.FilmId;
                txtPrice.Text = show.Price.ToString();

                bool[] slots = new bool[9];
                List<Show> shows = context.Shows
                    .Where(s => s.ShowDate == show.ShowDate
                    && s.RoomId == show.RoomId
                    && s.ShowId != show.ShowId)
                    .ToList<Show>();
                foreach (Show s in shows)
                    slots[(int)s.Slot - 1] = true;
                for (int i = 0; i < slots.Length; i++)
                    if (slots[i] == false) cbSlot.Items.Add(i + 1);

                cbSlot.Text = show.Slot.ToString();
                //cbRoom.DataSource = RoomDAO.GetInstance().GetDataTable($"select * from rooms where RoomID = {show.RoomId}");
                //cbRoom.DisplayMember = "Name";
                //cbRoom.ValueMember = "RoomId";
                //cbRoom.Enabled = false;

                //dateChoose.Value = show.ShowDate;
                //dateChoose.Enabled = false;

                //cbSlot.DataSource = SlotDAO.GetInstance().GetDataTable();
                //cbSlot.DisplayMember = "slot";
                //cbSlot.ValueMember = "slot";
                //cbSlot.SelectedValue = show.Slot;

                //cbFilm.DataSource = FilmDAO.GetInstance().GetDataTable($"select * from Films");
                //cbFilm.DisplayMember = "Title";
                //cbFilm.ValueMember = "FilmId";
                //cbFilm.SelectedValue = show.FilmId;



            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //add here
            if (add == 1)
            { 
                try
                {
                    Show show = new Show();
                    show.RoomId = (int)cbRoom.SelectedValue;
                    show.ShowDate = dateChoose.Value;
                    show.FilmId = (int)cbFilm.SelectedValue;
                    show.Price = decimal.Parse(txtPrice.Text);
                    show.Slot = int.Parse(cbSlot.Text);
                    context.Shows.Add(show);
                    context.SaveChanges();
                    MessageBox.Show("That show is added!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else // edit
            {

                //String roomId = cbRoom.SelectedValue.ToString();
                //DateTime date = dateChoose.Value;
                //String slot = cbSlot.SelectedValue.ToString();
                //String filmId = cbFilm.SelectedValue.ToString();
                //double price;
                //try
                //{
                //    price = double.Parse(txtPrice.Text);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Price must be a number");
                //    return;
                //}
                //Show show = new Show();
                //show.RoomId = Int32.Parse(roomId);
                //show.ShowDate = date;
                //show.Slot = Int32.Parse(slot);
                //show.FilmId = Int32.Parse(filmId);
                //show.Price = price;

                //try
                //{
                //    ShowDAO.GetInstance().Update(show);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Can't edit show");
                //    return;
                //}

                ////new ShowGUI().bindGrid("select * from shows order by showdate desc");

                //return;

                try
                {
                    Show show = context.Shows.Find(id);
                    show.RoomId = (int)cbRoom.SelectedValue;
                    show.ShowDate = dateChoose.Value;
                    show.FilmId = (int)cbFilm.SelectedValue;
                    show.Price = decimal.Parse(txtPrice.Text);
                    show.Slot = int.Parse(cbSlot.Text);
                    context.Shows.Update(show);
                    context.SaveChanges();
                    MessageBox.Show("That show is edited!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ShowAddEditGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
