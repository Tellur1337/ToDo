﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddJob : ContentPage
    {
        public AddJob()
        {
            InitializeComponent();
        }
    }
}