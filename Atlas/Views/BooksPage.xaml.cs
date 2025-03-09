using Atlas.Models;
using Atlas.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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

            var book = new Book
            {
                Title = "MAUI in Action",
                Author = "Matt",
                CurrentPage = 150,
                TotalPages = 300
            };

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as BooksViewModel)?.LoadBooksCommand.Execute(null);
        }

        private void TestBookModel()
        {
            Debug.WriteLine("=== Testing Book Model ===");

            // Test 1: Default Values
            var book = new Book();
            Debug.WriteLine($"Default Author: {book.Author}"); // Should be "Unknown"
            Debug.WriteLine($"Default Start Date: {book.StartDate}"); // ~DateTime.Now

            // Test 2: Validation
            var invalidBook = new Book { Title = "", Author = "", TotalPages = -5 };
            var validationErrors = ValidateBook(invalidBook);
            Debug.WriteLine("Validation Errors:");
            foreach (var error in validationErrors)
            {
                Debug.WriteLine($"- {error}");
            }

            // Test 3: Progress Calculation
            var validBook = new Book
            {
                Title = "MAUI in Action",
                Author = "Matt",
                CurrentPage = 150,
                TotalPages = 300
            };
            Debug.WriteLine($"Progress: {validBook.ProgressString}"); // Should be "150 / 300 (50%)"
        }

        private List<string> ValidateBook(Book book)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(book);
            Validator.TryValidateObject(book, context, results, true);
            return results.Select(r => r.ErrorMessage!).ToList();
        }
    }
}



