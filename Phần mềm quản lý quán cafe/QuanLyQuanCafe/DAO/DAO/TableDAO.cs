using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
             get
                {
                    if (instance == null)
                        instance = new TableDAO();
                    return TableDAO.instance;
                }
                private set { TableDAO.instance = value; }
        }

        private TableDAO() { }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC dbo.USP_GetTable");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }

        public string GetTableByTableId(int idTable)
        {
            string query = "SELECT * FROM dbo.ThongTinBan WHERE BanID = " + idTable;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Table name = new Table(data.Rows[0]);
                return name.Name;
            }

            return null;

        }

        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @IDTable1 , @IDTable2 ", new object[] { id1, id2 });
        }

        public bool InsertTable(string tenBan, string trangThai)
        {
            string query = string.Format("INSERT INTO dbo.ThongTinBan (SoBan, TrangThai) Values (N'{0}', N'{1}')", tenBan, trangThai);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool UpdateTable(string tenBan, string trangThai, int id)
        {
            string query = string.Format("UPDATE dbo.ThongTinBan SET SoBan = N'{0}', TrangThai = N'{1}' WHERE BanID = {2}", tenBan, trangThai, id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool DeleteTable(int id)
        {
            BillDAO.Instance.DeleteBillBytableID(id);

            string query = string.Format("DELETE dbo.ThongTinBan WHERE BanID = " + id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }
    }
}
