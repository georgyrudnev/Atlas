using Atlas.Models;
using Atlas.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Atlas.ViewModels
{
    public partial class BooksViewModel : BaseViewModel
    {
        private readonly DataService _dataService;

        // Parameterloser Konstruktor (falls benötigt)
        public BooksViewModel()
        {
            // Nur für Design-Time (optional)
        }

        public BooksViewModel(DataService dataService)
        {
            _dataService = dataService;
            LoadBooks();
        }

        public ObservableCollection<Book> Books { get; } = new();

        [RelayCommand]
        private void LoadBooks()
        {
            try
            {
                Books.Clear();
                foreach (var book in _dataService.GetAllBooks())
                {
                    Books.Add(book);
                }
            }
            catch (Exception ex)
            {
                // Handle errors
            }
        }

        [RelayCommand]
        private async Task AddBook()
        {
            await Shell.Current.GoToAsync(nameof(Views.AddBookPage));
        }

        [RelayCommand]
        private void DeleteBook(Book book)
        {
            if (book == null) return;

            _dataService.DeleteBook(book);
            Books.Remove(book);
        }
    }
}