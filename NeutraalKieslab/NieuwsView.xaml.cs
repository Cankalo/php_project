using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NeutraalKieslab
{
    public partial class NieuwsView : UserControl
    {
        private List<NewsArticle> _allNews;
        private string _currentFilter = "All";

        public NieuwsView()
        {
            InitializeComponent();
            LoadNews();
        }

        private void LoadNews()
        {
            _allNews = NewsData.GetLatestNews();
            DisplayNews(_allNews);
        }

        private void DisplayNews(List<NewsArticle> articles)
        {
            // Clear existing news cards
            NewsContainer.Children.Clear();

            foreach (var article in articles)
            {
                var newsCard = CreateNewsCard(article);
                NewsContainer.Children.Add(newsCard);
            }
        }

        private Border CreateNewsCard(NewsArticle article)
        {
            var card = new Border
            {
                Background = Brushes.White,
                CornerRadius = new CornerRadius(8),
                Margin = new Thickness(20, 15, 20, 15), // FIXED: 4 parameters
                Padding = new Thickness(30, 30, 30, 30), // FIXED: 4 parameters
                MinHeight = 120,
                Cursor = Cursors.Hand
            };

            // Add hover effect
            card.Effect = new System.Windows.Media.Effects.DropShadowEffect
            {
                Color = Colors.LightGray,
                Direction = 270,
                ShadowDepth = 2,
                Opacity = 0.4
            };

            // Create grid layout
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Icon/Category
            var iconBorder = new Border
            {
                Background = (Brush)FindResource("LightGray"),
                Width = 60,
                Height = 60,
                CornerRadius = new CornerRadius(4),
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 5, 15, 0) // FIXED: 4 parameters
            };

            var iconText = new TextBlock
            {
                Text = article.CategoryEmoji,
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            iconBorder.Child = iconText;
            Grid.SetColumn(iconBorder, 0);

            // Content
            var contentStack = new StackPanel { VerticalAlignment = VerticalAlignment.Center };

            // Breaking news indicator
            if (article.IsBreaking)
            {
                var breakingText = new TextBlock
                {
                    Text = "🔴 BREAKING NEWS",
                    FontSize = 12,
                    FontWeight = FontWeights.Bold,
                    Foreground = (Brush)FindResource("BreakingRed"),
                    Margin = new Thickness(0, 0, 0, 5) // FIXED: 4 parameters
                };
                contentStack.Children.Add(breakingText);
            }

            var titleText = new TextBlock
            {
                Text = article.Title,
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                Foreground = (Brush)FindResource("PrimaryBlue"),
                Margin = new Thickness(0, 0, 0, 8), // FIXED: 4 parameters
                TextWrapping = TextWrapping.Wrap
            };

            var summaryText = new TextBlock
            {
                Text = article.Summary,
                FontSize = 14,
                Foreground = (Brush)FindResource("DarkGray"),
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 0, 0, 10) // FIXED: 4 parameters
            };

            var metaText = new TextBlock
            {
                Text = $"{article.Source} • {article.TimeAgo}",
                FontSize = 12,
                Foreground = (Brush)FindResource("DarkGray")
            };

            contentStack.Children.Add(titleText);
            contentStack.Children.Add(summaryText);
            contentStack.Children.Add(metaText);

            Grid.SetColumn(contentStack, 1);

            grid.Children.Add(iconBorder);
            grid.Children.Add(contentStack);
            card.Child = grid;

            // Add click handler for full article
            card.MouseLeftButtonUp += (s, e) => ShowFullArticle(article);

            // Add hover effect
            card.MouseEnter += (s, e) =>
            {
                card.Effect = new System.Windows.Media.Effects.DropShadowEffect
                {
                    Color = Colors.Gray,
                    Direction = 270,
                    ShadowDepth = 4,
                    Opacity = 0.6
                };
            };

            card.MouseLeave += (s, e) =>
            {
                card.Effect = new System.Windows.Media.Effects.DropShadowEffect
                {
                    Color = Colors.LightGray,
                    Direction = 270,
                    ShadowDepth = 2,
                    Opacity = 0.4
                };
            };

            return card;
        }

        private void ShowFullArticle(NewsArticle article)
        {
            // Create and show custom article window
            var articleWindow = new NewsArticleWindow(article)
            {
                Owner = Window.GetWindow(this) // Set parent window for proper modal behavior
            };

            articleWindow.ShowDialog(); // Show as modal dialog
        }

        // Filter methods
        private void FilterAll(object sender, RoutedEventArgs e)
        {
            _currentFilter = "All";
            DisplayNews(_allNews);
            UpdateActiveFilter(sender as Button);
        }

        private void FilterBreaking(object sender, RoutedEventArgs e)
        {
            _currentFilter = "Breaking";
            var breakingNews = _allNews.Where(n => n.IsBreaking).ToList();
            DisplayNews(breakingNews);
            UpdateActiveFilter(sender as Button);
        }

        private void FilterByCategory(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var category = button?.Tag?.ToString();

            if (!string.IsNullOrEmpty(category))
            {
                _currentFilter = category;
                var filteredNews = NewsData.GetNewsByCategory(category);
                DisplayNews(filteredNews);
                UpdateActiveFilter(button);
            }
        }

        private void UpdateActiveFilter(Button activeButton)
        {
            // Simple active filter highlighting - find parent and reset buttons
            try
            {
                // Reset all filter buttons to default style
                var parent = this.Parent;
                // This is a simplified approach - you might need to adjust based on your exact XAML structure

                // Set active button style
                if (activeButton != null)
                {
                    activeButton.Background = (Brush)FindResource("PrimaryBlue");
                    activeButton.Foreground = Brushes.White;
                }
            }
            catch
            {
                // If the complex parent finding fails, just highlight the active button
                if (activeButton != null)
                {
                    activeButton.Background = (Brush)FindResource("PrimaryBlue");
                    activeButton.Foreground = Brushes.White;
                }
            }
        }
    }
}