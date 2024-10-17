
namespace Maui_TP1.Views;

public partial class vGeolocalisation : ContentPage
{
    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;

    public vGeolocalisation()
    {
        InitializeComponent();
    }
    

    private void annulation(object sender, EventArgs e)
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }

    private async void GetCurrentLocationAsync()
    {
        try
        {
            _isCheckingLocation = true;
            GeolocationRequest geolocationRequest = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            _cancelTokenSource = new CancellationTokenSource();
            Location location = await Geolocation.Default.GetLocationAsync(geolocationRequest, _cancelTokenSource.Token);
            if (location != null)
            {
                longitude.Text = location.Longitude.ToString();
                latitude.Text = location.Latitude.ToString();
                altitude.Text = location.Altitude.ToString();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            _isCheckingLocation = false;
        }
    }

    private void GetCurrentLocation(object sender, EventArgs e)
    {
        GetCurrentLocationAsync();
    }
}