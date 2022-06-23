using SE1620_Group3_A2.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE1620_Group3_A2.DAL
{
    class FilmDAO:DAO
    {
        static FilmDAO Instance;
        FilmDAO() { }
        static FilmDAO() => Instance = new FilmDAO();
        public static FilmDAO GetInstance() => Instance;

        //public DataTable GetDataTable() => GetDataTable("select * from Films");
        public DataTable GetDataTable1(string sql) => GetDataTable(sql);
        public Film getFilmById(int id)
        {
            DataTable dt = GetDataTable("select * from Films where FilmID = " + id);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];

            Film film = new Film
            {
                FilmId = row["FilmID"],
                GenreId = row["GenreID"],
                Title = row["Title"],
                Year = row["Year"],
                CountryCode = row["CountryCode"]

            };
            return film;

        }
       
    }

}
