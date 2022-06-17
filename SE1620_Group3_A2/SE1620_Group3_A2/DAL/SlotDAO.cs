using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE1620_Group3_A2.DAL
{
    class SlotDAO:DAO
    {
        static SlotDAO Instance;
        SlotDAO() { }
        static SlotDAO() => Instance = new SlotDAO();
        public static SlotDAO GetInstance() => Instance;

        public DataTable GetDataTable() => GetDataTable("select distinct(slot) from shows ");
    }
}
