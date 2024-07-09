using System.Windows;
using System.Windows.Controls;
using BusinessObjects;

namespace LMSWPF.Views;

 public partial class Categories : Page
    {
        public Categories() => InitializeComponent();

        private LMSDbContext _db = new LMSDbContext();

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Category newCategory = new Category()
            {
                Name = txtCategory.Text,
                Status = "Active"
            };

            _db.Categories.Add(newCategory);
            await _db.SaveChangesAsync();
            Read();
        }

        private void DataGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            TxtId.Text = (dg.SelectedItem as Category)?.Id.ToString();
            txtCategory.Text = (dg.SelectedItem as Category)?.Name;
        }

        private void btnRead_Click(object sender, RoutedEventArgs e) => Read();

        private void Categories_OnLoaded(object sender, RoutedEventArgs e) => Read();

        private void Read()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = _db.Categories.ToList();
        }

        private async void btnUptd_Click(object sender, RoutedEventArgs e)
        {
            int? categoryId = (dg.SelectedItem as Category)?.Id;

            if (categoryId != null)
            {
                Category categoryToUpdate = (from a in _db.Categories where a.Id == categoryId select a).Single();
                categoryToUpdate.Name = txtCategory.Text;

                _ = await _db.SaveChangesAsync();
                Read();
            }
        }

        private async void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            int? categoryId = (dg.SelectedItem as Category)?.Id;
            if (categoryId != null)
            {
                Category categoryToDelete = _db.Categories.Single(a => a.Id == categoryId);
                categoryToDelete.Status = "Inactive";
                _ = await _db.SaveChangesAsync();
                Read();
            }
        }
    }