using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App3.ViewModel;

namespace App3
{
    public partial class MainPage : ContentPage
    {
        private TestTaskViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new TestTaskViewModel();
            BindingContext = viewModel;
            listView.ItemsSource = viewModel.Offers;
        }
    }
}
