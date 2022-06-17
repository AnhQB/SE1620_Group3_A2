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

    }
}
