using System.Windows;
using System.Windows.Controls;

namespace NeutraalKieslab { 

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
    }

    private void StartStemwijzer(object sender, RoutedEventArgs e)
    {
        // Navigate to Stemwijzer
        var mainWindow = Window.GetWindow(this) as MainWindow;
        mainWindow?.ContentArea.SetValue(ContentControl.ContentProperty, new StemwijzerView());
    }

    private void ViewParties(object sender, RoutedEventArgs e)
    {
        // Navigate to Partijen
        var mainWindow = Window.GetWindow(this) as MainWindow;
        mainWindow?.ContentArea.SetValue(ContentControl.ContentProperty, new PartijenView());
    }

    private void LearnMore(object sender, RoutedEventArgs e)
    {
        // Navigate to Over Ons
        var mainWindow = Window.GetWindow(this) as MainWindow;
        mainWindow?.ContentArea.SetValue(ContentControl.ContentProperty, new OverOnsView());
    }
}
}