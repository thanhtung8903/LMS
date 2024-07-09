using System.Windows;
using System.Windows.Controls;
using BusinessObjects;
using LMSWPF.ViewModels;

namespace LMSWPF.Views;

public partial class Books : Page
    {
        public Books() => InitializeComponent();

        private LMSDbContext _db = new LMSDbContext();

        private void Books_Load(object sender, EventArgs e) => Read();

        private void Read()
        {
            dg.ItemsSource = null;

            dg.ItemsSource = _db.Books.Select(x => new BookViewModel()
            {
                ID = x.Id,
                BOOK = x.Title,
                AUTHOR = x.Author.FirstName + " " + x.Author.LastName,
                CATEGORY = x.Category.Name,
                PUBLISHER = x.Publisher.Name,
                YEAR = x.Year.ToString(),
                NUMBEROFPAGES = x.Page.ToString(),
                STATUS = x.Status == "Active"
            }).ToList<BookViewModel>();

            comboAuthor.ItemsSource = (from x in _db.Authors
                                       select new
                                       {
                                           x.Id,
                                           AUTHOR = x.FirstName + " " + x.LastName,
                                       }).ToList();

            comboCategory.ItemsSource = (from x in _db.Categories
                                         select new
                                         {
                                             x.Id,
                                             x.Name
                                         }).ToList();

            comboPublisher.ItemsSource = (from x in _db.Publishers
                                          select new
                                          {
                                              x.Id,
                                              x.Name
                                          }).ToList();
        }

        private void Clear()
        {
            TxtId.Text = "";
            TxtBook.Text = "";
            comboAuthor.Text = "";
            comboCategory.Text = "";
            comboPublisher.Text = "";
            txtYear.Text = "";
            txtPage.Text = "";
            TxtBook.Focus();
        }

        private void DataGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            int? bookId = (dg.SelectedItem as BookViewModel)?.ID;
            TxtId.Text = bookId.ToString();
            TxtBook.Text = (dg.SelectedItem as BookViewModel)?.BOOK;
            comboAuthor.Text = (dg.SelectedItem as BookViewModel)?.AUTHOR;
            comboCategory.Text = (dg.SelectedItem as BookViewModel)?.CATEGORY;
            comboPublisher.Text = (dg.SelectedItem as BookViewModel)?.PUBLISHER;
            txtYear.Text = (dg.SelectedItem as BookViewModel)?.YEAR;
            txtPage.Text = (dg.SelectedItem as BookViewModel)?.NUMBEROFPAGES;
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            int authorId = int.Parse(comboAuthor.SelectedValue.ToString());
            int categoryId = int.Parse(comboCategory.SelectedValue.ToString());
            int publisherId = int.Parse(comboPublisher.SelectedValue.ToString());

            Author author = _db.Authors.FirstOrDefault(a => a.Id == authorId);
            Category category = _db.Categories.FirstOrDefault(c => c.Id == categoryId);
            Publisher publisher = _db.Publishers.FirstOrDefault(p => p.Id == publisherId);

            if (author != null && category != null && publisher != null)
            {
                Book t = new Book()
                {
                    Title = TxtBook.Text,
                    Author = author,
                    Category = category,
                    Publisher = publisher,
                    Year = int.Parse(txtYear.Text),
                    Page = int.Parse(txtPage.Text),
                    Status = "Active"
                };

                _db.Books.Add(t);
                await _db.SaveChangesAsync();
                Clear();
                Read();
            }
            else
            {
                // Handle the case where the author, category, or publisher is not found
            }
        }

        private void btnRead_Click(object sender, RoutedEventArgs e) => Read();

        private async void btnUptd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int? bookId = (dg.SelectedItem as BookViewModel)?.ID;
                if (bookId != null)
                {
                    Book bookToUpdate = await _db.Books.FindAsync(bookId.Value);
                    if (bookToUpdate != null)
                    {
                        bookToUpdate.Title = TxtBook.Text;

                        int authorId = int.Parse(comboAuthor.SelectedValue.ToString());
                        int categoryId = int.Parse(comboCategory.SelectedValue.ToString());
                        int publisherId = int.Parse(comboPublisher.SelectedValue.ToString());

                        Author author = _db.Authors.FirstOrDefault(a => a.Id == authorId);
                        Category category = _db.Categories.FirstOrDefault(c => c.Id == categoryId);
                        Publisher publisher = _db.Publishers.FirstOrDefault(p => p.Id == publisherId);

                        if (author != null && category != null && publisher != null)
                        {
                            bookToUpdate.Author = author;
                            bookToUpdate.Category = category;
                            bookToUpdate.Publisher = publisher;
                            bookToUpdate.Year = int.Parse(txtYear.Text);
                            bookToUpdate.Page = int.Parse(txtPage.Text);

                            await _db.SaveChangesAsync();
                            Clear();
                            Read();
                        }
                        else
                        {
                            MessageBox.Show("Author, Category, or Publisher not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Book not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private async void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            int? bookId = (dg.SelectedItem as BookViewModel)?.ID;
            if (bookId != null)
            {
                Book bookToDelete = _db.Books.Single(a => a.Id == bookId);
                bookToDelete.Status = "Inactive";
                _ = await _db.SaveChangesAsync();
                Clear();
                Read();
            }
        }
    }