using System.Windows;
using System.Windows.Controls;
using BusinessObjects;

namespace LMSWPF.Views;

public partial class Publishers : Page
{
    public Publishers()
    {
        InitializeComponent();
    }

    private LMSDbContext _db = new LMSDbContext();

    private void Publishers_OnLoaded_OnLoaded(object sender, RoutedEventArgs e) => Read();

    private void Read()
    {
        dg.ItemsSource = null;
        dg.ItemsSource = _db.Publishers.ToList();
    }

    private async void btnCreate_Click(object sender, RoutedEventArgs e)
    {
        Publisher newPublisher = new Publisher()
        {
            Name = txtPublisher.Text,
            Status = "Active"
        };

        _ = _db.Publishers.Add(newPublisher);
        _ = await _db.SaveChangesAsync();
        Read();
    }

    private void btnRead_Click(object sender, RoutedEventArgs e) => Read();

    private async void btnUptd_Click(object sender, RoutedEventArgs e)
    {
        int? publisherId = (dg.SelectedItem as Publisher)?.Id;

        if (publisherId != null)
        {
            Publisher publisherToUpdate = (from a in _db.Publishers where a.Id == publisherId select a).Single();
            publisherToUpdate.Name = txtPublisher.Text;

            _ = await _db.SaveChangesAsync();
            Read();
        }
    }

    private async void BtnDelete_OnClick(object sender, RoutedEventArgs e)
    {
        int? publisherId = (dg.SelectedItem as Publisher)?.Id;
        if (publisherId != null)
        {
            Publisher publisherToDel = _db.Publishers.Single(a => a.Id == publisherId);
            publisherToDel.Status = "Inactive";
            
            
            
            _ = await _db.SaveChangesAsync();
            Read();
        }
    }

    private void DataGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
    {
        TxtId.Text = (dg.SelectedItem as Publisher)?.Id.ToString();
        txtPublisher.Text = (dg.SelectedItem as Publisher)?.Name;
    }
}