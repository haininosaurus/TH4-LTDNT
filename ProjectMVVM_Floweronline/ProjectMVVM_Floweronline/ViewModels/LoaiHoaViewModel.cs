using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ProjectMVVM_Floweronline.Interface;
using ProjectMVVM_Floweronline.Models;
using ProjectMVVM_Floweronline.Repository;
using Xamarin.Forms;

namespace ProjectMVVM_Floweronline.ViewModels
{
    public class LoaiHoaViewModel : INotifyPropertyChanged
    {
        private LoaiHoa loaihoa;
        public ILoaiHoaRepository loaiHoaRepository;
        public ICommand AddLoaiHoa { get; private set; }
        public ICommand UpdateLoaiHoa { get; private set; }
        public ICommand DeleteLoaiHoa { get; private set; }

        public LoaiHoaViewModel()
        {
            loaiHoaRepository = new LoaiHoaRepository();
            LoadLoaiHoa();
            AddLoaiHoa = new Command(Insert);
            UpdateLoaiHoa = new Command(Update, CanExe);
            DeleteLoaiHoa = new Command(Delete, CanExe);
            loaihoa = new LoaiHoa();
        }

        private void Delete()
        {
            loaiHoaRepository.Delete(Loaihoa);
            LoadLoaiHoa();
        }

        private void Update()
        {
            loaiHoaRepository.Update(Loaihoa);
            LoadLoaiHoa();
        }

        private void Insert()
        {
            loaiHoaRepository.Insert(Loaihoa);
            LoadLoaiHoa();
        }

        private bool CanExe()
        {
            if (Loaihoa == null || Loaihoa.MaLoai == 0)
                return false;
            else
                return true;
        }

        public LoaiHoa Loaihoa
        {
            get { return loaihoa; }
            set
            {
                loaihoa = value;
                RaisePropertyChanged("Loaihoa");
                ((Command)UpdateLoaiHoa).ChangeCanExecute();
            }
        }

        public int MaLoai
        {
            get { return loaihoa.MaLoai; }
            set
            {
                loaihoa.MaLoai = value;
                RaisePropertyChanged("MaLoai");
            }
        }

        ObservableCollection<LoaiHoa> loaihoalist;
        public ObservableCollection<LoaiHoa> LoaiHoaList
        {
            get { return loaihoalist; }
            set
            {
                loaihoalist = value;
                RaisePropertyChanged("LoaiHoaList");
            }
        }

        public string TenLoai
        {
            get { return loaihoa.TenLoai; }
            set
            {
                loaihoalist = value;
                RaisePropertyChanged("LoaiHoaList");
            }
        }

        void LoadLoaiHoa()
        {
            LoaiHoaList = loaiHoaRepository.GetLoaiHoas();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
