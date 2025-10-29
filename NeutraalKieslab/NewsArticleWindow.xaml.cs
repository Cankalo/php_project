using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NeutraalKieslab
{
    public partial class NewsArticleWindow : Window
    {
        private NewsArticle _article;

        public NewsArticleWindow(NewsArticle article)
        {
            InitializeComponent();
            _article = article;
            LoadArticle();
        }

        private void LoadArticle()
        {
            // Set window title
            this.Title = $"{_article.CategoryEmoji} {_article.Title} - Neutraal Kieslab";

            // Show breaking news badge if needed
            if (_article.IsBreaking)
            {
                BreakingBadge.Visibility = Visibility.Visible;
            }

            // Set article content
            ArticleTitle.Text = _article.Title;
            SummaryText.Text = _article.Summary;
            ContentText.Text = _article.Content;

            // Set metadata
            CategoryText.Text = $"{_article.CategoryEmoji} {_article.Category}";
            SourceText.Text = $"📍 {_article.Source}";
            DateText.Text = $"📅 {_article.PublishDate.ToString("dd MMMM yyyy, HH:mm", new CultureInfo("nl-NL"))}";
            AuthorText.Text = $"✍️ {_article.Author}";

            // Load tags if any
            if (_article.Tags.Count > 0)
            {
                TagsContainer.Visibility = Visibility.Visible;
                LoadTags();
            }
        }

        private void LoadTags()
        {
            TagsPanel.Children.Clear();

            foreach (var tag in _article.Tags)
            {
                var tagBorder = new Border
                {
                    Background = (Brush)FindResource("AccentGreen"),
                    CornerRadius = new CornerRadius(12),
                    Padding = new Thickness(10, 4, 10, 4),
                    Margin = new Thickness(0, 0, 8, 4)
                };

                var tagText = new TextBlock
                {
                    Text = tag,
                    FontSize = 12,
                    Foreground = Brushes.White,
                    FontWeight = FontWeights.Medium
                };

                tagBorder.Child = tagText;
                TagsPanel.Children.Add(tagBorder);
            }
        }

        private void ShareArticle(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create share text
                var shareText = $"{_article.Title}\n\n{_article.Summary}\n\nBron: {_article.Source}\nGepubliceerd: {_article.PublishDate:dd-MM-yyyy}\n\n#NeutraalKieslab #NederlandsePolitiek";

                // Copy to clipboard
                Clipboard.SetText(shareText);

                // Show confirmation
                MessageBox.Show("Artikel gekopieerd naar klembord!", "Delen", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kon artikel niet delen: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Allow clicking outside content area to close (optional)
        protected override void OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Enable dragging the window
            if (e.ButtonState == System.Windows.Input.MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}