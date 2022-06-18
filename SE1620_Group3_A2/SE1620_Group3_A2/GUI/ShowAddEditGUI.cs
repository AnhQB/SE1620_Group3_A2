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
using SE1620_Group3_A2.DTL;

namespace SE1620_Group3_A2.GUI
{
    
    public partial class ShowAddEditGUI : Form
    {
        static int add;
        public ShowAddEditGUI(Show show)
        {
            InitializeComponent();
            if (show.ShowId == -1) add = 1; //add
            else add = 0; //edit

            if (add == 1)
            {
                cbRoom.DataSource = RoomDAO.GetInstance().GetDataTable();
                cbRoom.DisplayMember = "Name";
                cbRoom.ValueMember = "RoomId";
                cbRoom.Enabled = true;

                dateChoose.Value = show.ShowDate;

                cbSlot.DataSource = SlotDAO.GetInstance().GetDataTable();
                cbSlot.DisplayMember = "slot";
                cbSlot.ValueMember = "slot";


                cbFilm.DataSource = FilmDAO.GetInstance().GetDataTable();
                cbFilm.DisplayMember = "title";
                cbFilm.ValueMember = "FilmId";
                cbFilm.SelectedValue = show.FilmId;
            }
            else
            {
                cbRoom.DataSource = RoomDAO.GetInstance().GetDataTable();
                cbRoom.DisplayMember = "Name";
                cbRoom.ValueMember = "RoomId";
                cbRoom.Enabled = false;
                cbRoom.SelectedValue = show.RoomId;

                dateChoose.Value = show.ShowDate;
                dateChoose.Enabled = false;

                cbSlot.DataSource = SlotDAO.GetInstance().GetDataTable();
                cbSlot.DisplayMember = "slot";
                cbSlot.ValueMember = "slot";
                cbSlot.SelectedValue = show.Slot;


                cbFilm.DataSource = FilmDAO.GetInstance().GetDataTable();
                cbFilm.DisplayMember = "title";
                cbFilm.ValueMember = "FilmId";
                cbFilm.SelectedValue = show.FilmId;
                 
                txtPrice.Text = show.Price.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String roomId = cbRoom.SelectedValue.ToString();
            DateTime date = dateChoose.Value;
            String slot = cbSlot.SelectedValue.ToString();
            String filmId = cbFilm.SelectedValue.ToString();
            decimal price;
            try
            {
                price = decimal.Parse(txtPrice.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Price must be a number");
                return;
            }
            Show show = new Show();
            show.ShowId = Settings.showid;
            show.RoomId = Int32.Parse(roomId);
            show.ShowDate = date;
            show.Slot = Int32.Parse(slot);
            show.FilmId = Int32.Parse(filmId);
            show.Price = price;
            //MessageBox.Show(show.ToString());
            //add here
            if (add == 1)
            {

                try
                {
                    ShowDAO.GetInstance().AddShow(show);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't add show");
                    return;
                }

                new ShowGUI().bindGrid("select * from shows order by showdate desc");

                return;
            }
            //edit here
            try
            {
                ShowDAO.GetInstance().EditShow(show);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't edit show");
                return;
            }

            new ShowGUI();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
