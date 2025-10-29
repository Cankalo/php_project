using System.Windows;
using System.Windows.Controls;

namespace NeutraalKieslab
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            // Check if user is already logged in
            if (UserManager.Instance.IsLoggedIn)
            {
                ShowUserDashboard();
            }
            else
            {
                // Show login form by default
                ShowLoginForm();
            }
        }

        private void ShowLoginForm()
        {
            LoginFormPanel.Visibility = Visibility.Visible;
            RegistrationFormPanel.Visibility = Visibility.Collapsed;
        }

        private void ShowRegistrationForm()
        {
            LoginFormPanel.Visibility = Visibility.Collapsed;
            RegistrationFormPanel.Visibility = Visibility.Visible;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = LoginEmail.Text.Trim();
            string password = LoginPassword.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vul alle velden in.", "Invoerfout", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = UserManager.Instance.Login(email, password);

            if (result.Success)
            {
                MessageBox.Show(result.Message, "Login Succesvol", MessageBoxButton.OK, MessageBoxImage.Information);

                // Refresh the main window to show user profile
                var mainWindow = Window.GetWindow(this) as MainWindow;
                mainWindow?.RefreshLoginState();

                ShowUserDashboard();
            }
            else
            {
                MessageBox.Show(result.Message, "Login Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string email = RegisterEmail.Text.Trim();
            string password = RegisterPassword.Password;
            string firstName = RegisterFirstName.Text.Trim();
            string lastName = RegisterLastName.Text.Trim();
            string phone = RegisterPhone.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Vul alle verplichte velden in.", "Invoerfout", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = UserManager.Instance.Register(email, password, firstName, lastName, phone);

            if (result.Success)
            {
                MessageBox.Show(result.Message, "Registratie Succesvol", MessageBoxButton.OK, MessageBoxImage.Information);

                // Refresh the main window to show user profile
                var mainWindow = Window.GetWindow(this) as MainWindow;
                mainWindow?.RefreshLoginState();

                ShowUserDashboard();
            }
            else
            {
                MessageBox.Show(result.Message, "Registratie Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // These are the correct method names that match the XAML
        private void ShowRegistration_Click(object sender, RoutedEventArgs e)
        {
            ShowRegistrationForm();
            // Clear registration form
            RegisterEmail.Text = "";
            RegisterPassword.Password = "";
            RegisterFirstName.Text = "";
            RegisterLastName.Text = "";
            RegisterPhone.Text = "";
        }

        private void ShowLogin_Click(object sender, RoutedEventArgs e)
        {
            ShowLoginForm();
        }

        private void ShowUserDashboard()
        {
            // Navigate directly to home instead of showing popup
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow?.ContentArea.SetValue(ContentControl.ContentProperty, new HomeView());
        }
    }
}