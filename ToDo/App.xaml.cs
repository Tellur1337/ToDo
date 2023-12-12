using System;
using System.Collections.Generic;
using System.IO;
using ToDo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo
{
    public partial class App : Application
    {
        public const string _DB = "Jobs.db";
        public static JobRP dataBase;
        public static JobRP MyDB
        {
            get
            {
                if (dataBase == null)
                {
                    dataBase = new JobRP(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _DB));
                }
                return dataBase;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            //
        }

        protected override void OnSleep()
        {
            //
        }

        protected override void OnResume()
        {
            //
        }
    }
}