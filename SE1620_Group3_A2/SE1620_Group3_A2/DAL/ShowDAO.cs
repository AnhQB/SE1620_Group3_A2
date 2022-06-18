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

        public void AddShow(Show show)
        {
            String sql = $"INSERT INTO [dbo].[Shows] ([RoomID],[FilmID],[ShowDate],[Price],[Status],[Slot])" +
                $" VALUES ({show.RoomId},{show.FilmId},'{show.ShowDate}',{show.Price},0,{show.Slot})";
            SqlCommand cmd = new SqlCommand(sql);

            Update(cmd);
        }

        internal void EditShow(Show show)
        {
            String sql = $"UPDATE [Shows] SET[RoomID] = {show.RoomId},[FilmID]={show.FilmId} ,[ShowDate] ='{show.ShowDate}' " +
                $",[Price] ={show.Price} ,[Status] = 0 ,[Slot] = {show.Slot} WHERE showID = {show.ShowId} ";

            SqlCommand cmd = new SqlCommand(sql);

            Update(cmd);
        }

        internal void Delete(int showId)
        {
            SqlCommand cmd2 = new SqlCommand("delete from Shows where ShowID =" + showId);
            Update(cmd2);
        }
    }
}
