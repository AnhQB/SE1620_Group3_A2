﻿using System;
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
    public partial class ShowGUI : Form
    {
        public ShowGUI()
        {
            InitializeComponent();
            bindGrid("select * from shows order by showdate desc");
        }
        public void bindGrid(string sql)
        {
            
            DataTable dt = ShowDAO.GetInstance().GetDataTable1(sql);
            DataGridViewButtonColumn STT = new DataGridViewButtonColumn
            {
                Name = "STT",
                Text = "STT",
            };
            dataGridView1.Columns.Insert(0, STT);


            dataGridView1.DataSource = dt;

            int rows = dt.Rows.Count;
            lbNumberShows.Text = $"The number of shows:  "+rows;
            int count = dt.Columns.Count;
            if (Settings.UserName != "") //logined
            {
                
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };

                DataGridViewButtonColumn btnBooking = new DataGridViewButtonColumn
                {
                    Name = "Booking",
                    Text = "Booking",
                    UseColumnTextForButtonValue = true
                };

                dataGridView1.Columns.Insert(count, btnEdit);
                dataGridView1.Columns.Insert(count + 1, btnDelete);
                dataGridView1.Columns.Insert(count + 2, btnBooking);
            }
            else // ko login
            {
                btnAddNew.Visible = false; // hidden button add
                DataGridViewButtonColumn btnBooking = new DataGridViewButtonColumn
                {
                    Name = "Booking",
                    Text = "Booking",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Insert(count, btnBooking);
            }

            dataGridView1.Columns["showid"].Visible = false;
            dataGridView1.Columns["status"].Visible = false;

            //đổ data(date, film, room) vào để search vs add
            dateChoose.Value = DateTime.Now;
            cbFilm.DataSource = FilmDAO.GetInstance().GetDataTable();
            cbFilm.DisplayMember = "Title";
            cbFilm.ValueMember = "FilmID";

            cbRoom.DataSource = RoomDAO.GetInstance().GetDataTable();
            cbRoom.DisplayMember = "Name";
            cbRoom.ValueMember = "RoomID";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string film = cbFilm.SelectedValue.ToString();
            DateTime date = dateChoose.Value;
            string roomID = cbRoom.SelectedValue.ToString();
            String sql = "select * from shows where filmID = '"+film+"' and showdate='"+date+"' and roomid="+roomID;
            bindGrid(sql);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex + 1).ToString();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            String filmId = cbFilm.SelectedValue.ToString();
            DateTime date = dateChoose.Value;
            String roomId = cbRoom.SelectedValue.ToString();
            Show show = new Show();
            show.ShowId = -1; //set to understand: add function
            show.FilmId = Int32.Parse(filmId);
            show.ShowDate = date;
            show.RoomId = Int32.Parse(roomId);

            ShowAddEditGUI showAddEdit = new ShowAddEditGUI(show);
            DialogResult dr = showAddEdit.ShowDialog();
        }
    }
}
