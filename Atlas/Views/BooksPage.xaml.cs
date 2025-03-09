using Atlas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlas.Views
{
    partial class BooksPage : ContentPage
    {
        public BooksPage(BooksViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as BooksViewModel)?.LoadBooksCommand.Execute(null);
        }
    }
}



