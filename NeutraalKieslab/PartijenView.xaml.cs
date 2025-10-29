// ===========================================
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NeutraalKieslab { 

public partial class PartijenView : UserControl
{
    public PartijenView()
    {
        InitializeComponent();
        UpdatePartyDataWithPolls();
    }

    private void UpdatePartyDataWithPolls()
    {
        // Update party cards with real polling data
        foreach (var party in PoliticalData.Parties.Values)
        {
            var card = FindName($"{party.Name}_Card") as Border;
            if (card?.Child is StackPanel stackPanel)
            {
                // Add polling information
                var pollText = new TextBlock
                {
                    Text = $"Huidige peiling: {party.CurrentPolls} zetels",
                    FontSize = 12,
                    Foreground = (System.Windows.Media.Brush)FindResource("AccentGreen"),
                    Margin = new Thickness(0, 8, 0, 0)
                };

                var changeText = new TextBlock
                {
                    Text = $"(2023: {party.PreviousElection} zetels, {(party.CurrentPolls > party.PreviousElection ? "+" : "")}{party.CurrentPolls - party.PreviousElection})",
                    FontSize = 10,
                    Foreground = (System.Windows.Media.Brush)FindResource("DarkGray"),
                    Margin = new Thickness(0, 2, 0, 0)
                };

                stackPanel.Children.Add(pollText);
                stackPanel.Children.Add(changeText);
            }
        }
    }

    // All existing filter methods remain the same...
    private void FilterAll(object sender, RoutedEventArgs e) => ShowAllParties();
    private void FilterLiberaal(object sender, RoutedEventArgs e) => FilterByCategory("Liberaal");
    private void FilterSociaaldemocratisch(object sender, RoutedEventArgs e) => FilterByCategory("Sociaaldemocratisch");
    private void FilterRechtsPopulistisch(object sender, RoutedEventArgs e) => FilterByCategory("Rechts-populistisch");
    private void FilterProgressiefLiberaal(object sender, RoutedEventArgs e) => FilterByCategory("Progressief-liberaal");
    private void FilterLinkse(object sender, RoutedEventArgs e) => FilterByCategory("Links");
    private void FilterConservatief(object sender, RoutedEventArgs e) => FilterByCategory("Conservatief");
    private void FilterMilieu(object sender, RoutedEventArgs e) => FilterByCategory("Milieu");
    private void FilterOverige(object sender, RoutedEventArgs e) => FilterByCategory("Overige");

    private void FilterByCategory(string category)
    {
        // Hide all cards first
        ShowAllParties();

        // Show only parties in selected category
        var partiesToShow = PoliticalData.Parties.Values
            .Where(p => p.Category == category)
            .Select(p => p.Name)
            .ToArray();

        // Hide all except selected
        foreach (var party in PoliticalData.Parties.Keys)
        {
            var card = FindName($"{party}_Card") as Border;
            if (card != null)
            {
                card.Visibility = partiesToShow.Contains(party) ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }

    private void ShowAllParties()
    {
        // Show all party cards
        foreach (var partyName in PoliticalData.Parties.Keys)
        {
            var card = FindName($"{partyName}_Card") as Border;
            if (card != null)
            {
                card.Visibility = Visibility.Visible;
            }
        }
    }
}
}