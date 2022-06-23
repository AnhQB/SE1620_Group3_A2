using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SE1620_Group3_A2.DTL;

namespace SE1620_Group3_A2.DAL
{
    class ShowDAO:DAO
    {
        static ShowDAO Instance;
        ShowDAO() { }
        static ShowDAO() => Instance = new ShowDAO();
        public static ShowDAO GetInstance() => Instance;

        public DataTable GetDataTable1(string sql) => GetDataTable(sql);

        public Show GetById(int id)
        {
            DataTable dt = GetDataTable("select * from Shows where ShowID = " + id);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];

                Show show = new Show
                {
                    ShowId = row["ShowID"],
                    RoomId = row["RoomID"],
                    FilmId = row["FilmID"],
                    ShowDate = row["ShowDate"],
                    Status = row["Status"],
                    Slot = row["Slot"],
                    Price = row["Price"]
                    /*
                    ShowId = (int)row["ShowID"],
                    RoomId = (int)row["RoomID"],
                    FilmId = (int)row["FilmID"],
                    ShowDate = (DateTime)row["ShowDate"],
                    Status = (bool)row["Status"],
                    Slot = (int)row["Slot"],
                    Price = (double)row["Price"]
                     */

                };

            return show;
        }



        public void AddShow(Show show)
        {
            String sql = $"INSERT INTO [dbo].[Shows] ([RoomID],[FilmID],[ShowDate],[Price],[Status],[Slot])" +
                $" VALUES ({show.RoomId},{show.FilmId},'{show.ShowDate}',{show.Price},0,{show.Slot})";
            SqlCommand cmd = new SqlCommand(sql);

            Update(cmd);
        }
        public void Delete(int id)
        {

            SqlCommand cmd1 = new SqlCommand("delete from Bookings where ShowID=" + id);
            Update(cmd1);

            SqlCommand cmd2 = new SqlCommand("delete from Shows where ShowID =" + id);
            Update(cmd2);

        }

         public void Update(Show show)
         {
             String sql = $"Update Shows set FilmID = {show.FilmId}, Price = {show.Price}, Slot = {show.Slot} where ShowID = {show.ShowId}";
             SqlCommand cmd = new SqlCommand(sql);

             Update(cmd);
         } 

       


    }
}
