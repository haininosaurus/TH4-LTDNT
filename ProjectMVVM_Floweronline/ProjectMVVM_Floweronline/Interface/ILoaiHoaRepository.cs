using System;
using System.Collections.ObjectModel;
using ProjectMVVM_Floweronline.Models;

namespace ProjectMVVM_Floweronline.Interface
{
    public interface ILoaiHoaRepository
    {
        ObservableCollection<LoaiHoa> GetLoaiHoas();
        LoaiHoa GetLoaiHoaById(int MaLoai);
        bool Insert(LoaiHoa lh);
        bool Update(LoaiHoa lh);
        bool Delete(LoaiHoa lh);
    }
}