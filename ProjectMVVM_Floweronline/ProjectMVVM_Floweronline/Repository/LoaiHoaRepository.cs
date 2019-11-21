using System;
using System.Collections.ObjectModel;
using ProjectMVVM_Floweronline.Helpers;
using ProjectMVVM_Floweronline.Interface;
using ProjectMVVM_Floweronline.Models;

namespace ProjectMVVM_Floweronline.Repository
{
    public class LoaiHoaRepository : ILoaiHoaRepository
    {
        Database db;
        public LoaiHoaRepository()
        {
            db = new Database();
        }
        public bool Delete(LoaiHoa lh)
        {
            return db.DeleteLoaiHoa(lh);
        }
        public bool Insert(LoaiHoa lh)
        {
            return db.InsertLoaiHoa(lh);
        }
        public bool Update(LoaiHoa lh)
        {
            return db.UpdateLoaiHoa(lh);
        }
        public LoaiHoa GetLoaiHoaById(int MaLoai)
        {
            return db.GetLoaiHoaById(MaLoai);
        }
        public ObservableCollection<LoaiHoa> GetLoaiHoas()
        {
            return new ObservableCollection<LoaiHoa>(db.GetLoaiHoas());
        }
    }
}
