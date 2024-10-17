namespace Maui_TP1.Views;

public partial class vBatterie : ContentPage
{
	public vBatterie()
	{
		InitializeComponent();
        Battery.Default.BatteryInfoChanged += Battery_InfoChanged;
        Battery.Default.EnergySaverStatusChanged += Battery_ModeEcoChanged;
    }

    private void Batterie_Clicked(object sender, EventArgs e)
    {
        lbBatterieInfo.Text = BatterieInfo();
    }

    private string BatterieInfo()
    {
        return Battery.Default.PowerSource switch
        {
            BatteryPowerSource.Battery => "Batterie",
            BatteryPowerSource.Unknown => "Inconnue",
            BatteryPowerSource.AC => "AC 220V",
            BatteryPowerSource.Usb => "Cable USB",
            BatteryPowerSource.Wireless => "Chargeur sans fil",
        };
    }

    private string BatteriePerscent(BatteryState e)
    {
        return e switch
        {
            BatteryState.NotPresent => "No present",
            BatteryState.Unknown => "non connue",
            BatteryState.Charging => "Batterie en charge",
            BatteryState.Discharging => "Batterie déchargée",
            BatteryState.Full => "Batterie pleine",
            BatteryState.NotCharging => "batterie en attente de charge",
        };
    }

    private void Battery_InfoChanged(object sender, BatteryInfoChangedEventArgs e)
    {
        lbBatterieInfo.Text = BatteriePerscent(e.State);
        lbBatterieInfo.Text += " pourcentage de batterie " + e.ChargeLevel;
    }

    private async void Battery_ModeEcoChanged(object sender, EnergySaverStatusChangedEventArgs e)
    {
        if (Battery.Default.EnergySaverStatus == EnergySaverStatus.On)
        {
            await DisplayAlert("economie d energie ", "vous avez le droit de cancel l action mais on va vous cancel sur twitter", "ok"); 
        }

    }
}