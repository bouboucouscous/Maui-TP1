namespace Maui_TP1.Views;

public partial class vEcran : ContentPage
{
    public vEcran()
    {
        InitializeComponent();
        Screen_Info();
    }

    public void Screen_Info()
    {
        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        stringBuilder.AppendLine($"Width: {DeviceDisplay.Current.MainDisplayInfo.Width}");
        stringBuilder.AppendLine($"Density: {DeviceDisplay.Current.MainDisplayInfo.Density}");
        stringBuilder.AppendLine($"Orientation: {DeviceDisplay.Current.MainDisplayInfo.Orientation}");
        stringBuilder.AppendLine($"RefreshRate: {DeviceDisplay.Current.MainDisplayInfo.RefreshRate}");
        lbScreenInfo.Text = stringBuilder.ToString();
    }
}