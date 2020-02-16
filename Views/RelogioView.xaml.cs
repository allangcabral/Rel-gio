﻿using Relogio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Relogio.Views
{
    /// <summary>
    /// Interaction logic for RelogioView.xaml
    /// </summary>
    public partial class RelogioView : Window
    {
        private RelogioViewModel _viewModel;

        public RelogioView()
        {
            InitializeComponent();
            _viewModel = new RelogioViewModel();
            this.DataContext = _viewModel;
        }
    }
}
