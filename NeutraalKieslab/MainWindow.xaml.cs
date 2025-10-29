using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NeutraalKieslab
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentArea.Content = new HomeView();
            UpdateLoginState();

            // Add click handler to close user menu when clicking elsewhere
            this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
        }

        private void UpdateLoginState()
        {
            if (UserManager.Instance.IsLoggedIn)
            {
                ShowUserProfile();
            }
            else
            {
                ShowLoginButton();
            }
        }

        private void ShowUserProfile()
        {
            var user = UserManager.Instance.CurrentUser;
            if (user != null)
            {
                // Hide login button, show user profile
                LoginButton.Visibility = Visibility.Collapsed;
                UserProfileArea.Visibility = Visibility.Visible;

                // Update user info in header
                UserNameText.Text = user.FullName;
                UserEmailText.Text = user.Email;

                // Update user info in popup
                PopupUserNameText.Text = user.FullName;
                PopupUserEmailText.Text = user.Email;
                PopupUserStatsText.Text = $"Lid sinds: {user.CreatedAt:dd-MM-yyyy} • {user.QuizResults.Count} stemwijzer resultaten";
            }
        }

        private void ShowLoginButton()
        {
            // Show login button, hide user profile
            LoginButton.Visibility = Visibility.Visible;
            UserProfileArea.Visibility = Visibility.Collapsed;
            UserMenuPopup.Visibility = Visibility.Collapsed;
        }

        private void ShowUserMenu(object sender, RoutedEventArgs e)
        {
            // Toggle user menu visibility
            if (UserMenuPopup.Visibility == Visibility.Visible)
            {
                UserMenuPopup.Visibility = Visibility.Collapsed;
            }
            else
            {
                UserMenuPopup.Visibility = Visibility.Visible;
            }
        }

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Close user menu when clicking elsewhere
            if (UserMenuPopup.Visibility == Visibility.Visible)
            {
                // Check if click was outside the popup
                var position = e.GetPosition(UserMenuPopup);
                if (position.X < 0 || position.Y < 0 ||
                    position.X > UserMenuPopup.ActualWidth ||
                    position.Y > UserMenuPopup.ActualHeight)
                {
                    UserMenuPopup.Visibility = Visibility.Collapsed;
                }
            }

            // Allow window dragging
            this.DragMove();
        }

        // Navigation methods
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new HomeView();
            UpdateActiveTab(sender as Button);
            CloseUserMenu();
        }

        private void Nieuws_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new NieuwsView();
            UpdateActiveTab(sender as Button);
            CloseUserMenu();
        }

        private void Stemwijzer_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new StemwijzerView();
            UpdateActiveTab(sender as Button);
            CloseUserMenu();
        }

        private void Partijen_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new PartijenView();
            UpdateActiveTab(sender as Button);
            CloseUserMenu();
        }

        private void Inloggen_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new LoginView();
            UpdateActiveTab(sender as Button);
        }

        private void OverOns_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new OverOnsView();
            UpdateActiveTab(sender as Button);
            CloseUserMenu();
        }

        // User menu actions
        private void ViewMyResults(object sender, RoutedEventArgs e)
        {
            CloseUserMenu();
            var user = UserManager.Instance.CurrentUser;

            if (user != null && user.QuizResults.Count > 0)
            {
                var resultsInfo = $"🗳️ Jouw Stemwijzer Resultaten\n\n";
                resultsInfo += $"Totaal aantal tests: {user.QuizResults.Count}\n\n";

                for (int i = 0; i < user.QuizResults.Count; i++)
                {
                    var result = user.QuizResults[i];
                    resultsInfo += $"Test #{i + 1} - {result.CompletedAt:dd-MM-yyyy HH:mm}\n";
                    resultsInfo += $"Antwoorden gegeven: {result.Answers.Count}\n";
                    if (result.Matches.Count > 0)
                    {
                        var topMatch = result.Matches.OrderByDescending(m => m.Percentage).First();
                        resultsInfo += $"Beste match: {topMatch.PartyName} ({topMatch.Percentage}%)\n";
                    }
                    resultsInfo += "\n";
                }

                MessageBox.Show(resultsInfo, "Mijn Stemwijzer Resultaten", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var message = "Je hebt nog geen stemwijzer tests gedaan.\n\nKlik op 'Stemwijzer' om je eerste test te doen!";
                var result = MessageBox.Show(message, "Geen Resultaten", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    ContentArea.Content = new StemwijzerView();
                }
            }
        }

        private void ViewAccountSettings(object sender, RoutedEventArgs e)
        {
            CloseUserMenu();
            var user = UserManager.Instance.CurrentUser;

            if (user != null)
            {
                var accountInfo = $"⚙️ Account Instellingen\n\n";
                accountInfo += $"👤 Naam: {user.FullName}\n";
                accountInfo += $"📧 Email: {user.Email}\n";
                accountInfo += $"📞 Telefoon: {user.Phone}\n";
                accountInfo += $"📅 Lid sinds: {user.CreatedAt:dd MMMM yyyy}\n";
                accountInfo += $"🕐 Laatste login: {user.LastLogin:dd MMMM yyyy, HH:mm}\n";
                accountInfo += $"📊 Stemwijzer tests: {user.QuizResults.Count}\n\n";
                accountInfo += "Voor het wijzigen van je gegevens, neem contact op met support.";

                MessageBox.Show(accountInfo, "Account Instellingen", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void LogoutUser(object sender, RoutedEventArgs e)
        {
            CloseUserMenu();

            var result = MessageBox.Show(
                $"Weet je zeker dat je wilt uitloggen?",
                "Uitloggen",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (result == MessageBoxResult.Yes)
            {
                UserManager.Instance.Logout();
                UpdateLoginState();
                ContentArea.Content = new HomeView();
                MessageBox.Show("Je bent succesvol uitgelogd.", "Uitgelogd", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CloseUserMenu()
        {
            UserMenuPopup.Visibility = Visibility.Collapsed;
        }

        private void UpdateActiveTab(Button activeButton)
        {
            // Reset all button styles (implement based on your styling needs)
            // Then highlight the active button
        }

        // Public method to refresh login state (call this after successful login)
        public void RefreshLoginState()
        {
            UpdateLoginState();
        }

        // Navigation methods for external calls
        public void NavigateToHome()
        {
            ContentArea.Content = new HomeView();
        }

        public void NavigateToNieuws()
        {
            ContentArea.Content = new NieuwsView();
        }

        public void NavigateToStemwijzer()
        {
            ContentArea.Content = new StemwijzerView();
        }

        public void NavigateToPartijen()
        {
            ContentArea.Content = new PartijenView();
        }

        public void NavigateToLogin()
        {
            ContentArea.Content = new LoginView();
        }

        public void NavigateToOverOns()
        {
            ContentArea.Content = new OverOnsView();
        }
    }
}