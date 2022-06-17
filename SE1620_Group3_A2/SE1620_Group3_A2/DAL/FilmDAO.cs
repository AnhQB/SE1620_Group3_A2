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

        public DataTable GetDataTable() => GetDataTable("select * from Films");
    }
}
