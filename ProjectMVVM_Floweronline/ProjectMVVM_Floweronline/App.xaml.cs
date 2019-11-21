using System;
using ProjectMVVM_Floweronline.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMVVM_Floweronline
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PageInsertLoaiHoa();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
