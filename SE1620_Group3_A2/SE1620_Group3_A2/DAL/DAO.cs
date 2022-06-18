using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SE1620_Group3_A2.DTL;

namespace SE1620_Group3_A2.DAL
{
    class DAO
    {

        string strConn;
        public DAO()
        {
            var conf = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, true)
               .Build();
            strConn = conf["ConnectionStrings:DbConnection"];

        }

        public Show GetById(int id)
        {
            DataTable dt = GetDataTable("select * from shows where showId = " + id);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            Show show = new Show
            {
                ShowId = (int)row["showId"],
                RoomId = (int)row["roomId"],
                FilmId = (int)row["filmId"],
                ShowDate = (DateTime)row["ShowDate"],
                Status = (bool)row["status"],
                Slot = (int)row["slot"],
                Price = (decimal)row["price"]
            };
            return show;
        }

        public DataTable GetDataTable(string sql)
        {

            //create object conn qection
            SqlConnection conn = new SqlConnection(strConn);

            //create object command
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = conn;

            //create DataAdapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Insert, Update, delete depend cmd
        public void Update(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(strConn);
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
