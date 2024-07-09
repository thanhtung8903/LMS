using System.Windows;
using System.Windows.Controls;
using BusinessObjects;

namespace LMSWPF.Views;

public partial class Authors : Page
{
    public Authors()
    {
        InitializeComponent();
    }

    private LMSDbContext _db = new LMSDbContext();


    private void Authors_Load(object sender, EventArgs e)
    {
        Read();
    }

    private void Read()
    {
        dg.ItemsSource = null;
        dg.ItemsSource = _db.Authors.ToList();
    }

    private void DataGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
    {
        txtId.Text = (dg.SelectedItem as Author)?.Id.ToString();
        txtFirstName.Text = (dg.SelectedItem as Author)?.FirstName;
        txtLastName.Text = (dg.SelectedItem as Author)?.LastName;
    }

    private async void btnCreate_Click(object sender, RoutedEventArgs e)
    {
        Author newAuthor = new Author()
        {
            FirstName = txtFirstName.Text,
            LastName = txtLastName.Text,
            Status = "Active"
        };

        _db.Authors.Add(newAuthor);
        _ = await _db.SaveChangesAsync();
        Read();
    }

    private void btnRead_Click(object sender, RoutedEventArgs e)
    {
        Read();
    }

    private async void btnUptd_Click(object sender, RoutedEventArgs e)
    {
        int? authorId = (dg.SelectedItem as Author)?.Id;
        if (authorId != null)
        {
            Author authorToUpdate = (from a in _db.Authors where a.Id == authorId select a).Single();
            authorToUpdate.FirstName = txtFirstName.Text;
            authorToUpdate.LastName = txtLastName.Text;

            _ = await _db.SaveChangesAsync();
            Read();
        }
    }

    private async void BtnDelete_OnClick(object sender, RoutedEventArgs e)
    {
        int? authorId = (dg.SelectedItem as Author)?.Id;
        if (authorId != null)
        {
            Author authorToUpdate = (from a in _db.Authors where a.Id == authorId select a).Single();
            authorToUpdate.Status = "Inactive";

            _ = await _db.SaveChangesAsync();
            Read();
        }
    }
}