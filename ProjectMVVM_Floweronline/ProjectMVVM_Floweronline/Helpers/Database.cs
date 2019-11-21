using System;
using System.Collections.Generic;
using System.Linq;
using ProjectMVVM_Floweronline.Models;
using SQLite;
using Xamarin.Forms.Internals;

namespace ProjectMVVM_Floweronline.Helpers
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public Database()
        {
            try
            {
                using (var connection = new
                    SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.CreateTable<LoaiHoa>();
                    connection.CreateTable<Hoa>();
                }
            }
            catch (SQLiteException ex)
            {
                //  Log.Info("SQLiteExeption", ex.Message);
            }
        }
        #region "Loại hoa"
        public List<LoaiHoa> GetLoaiHoas()
        {
            try
            {
                using (var connection = new
                    SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    return connection.Table<LoaiHoa>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
        public LoaiHoa GetLoaiHoaById(int MaLoai)
        {
            try
            {
                using (var connection = new
                    SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var dsh = from lsh in connection.Table<LoaiHoa>().ToList()
                              where lsh.MaLoai == MaLoai
                              select lsh;
                    return dsh.ToList<LoaiHoa>().FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
        public bool InsertLoaiHoa(LoaiHoa lh)
        {
            try
            {
                using (var connection = new
                    SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Insert(lh);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public bool UpdateLoaiHoa(LoaiHoa lh)
        {
            try
            {
                using (var connection = new
                    SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Update(lh);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public bool DeleteLoaiHoa(LoaiHoa lh)
        {
            try
            {
                using (var connection = new
                    SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Delete(lh);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        #endregion
    }
}
