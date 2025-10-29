using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NeutraalKieslab
{
    public partial class StemwijzerView : UserControl
    {
        private List<PoliticalQuestion> _questions;
        private List<UserAnswer> _answers;
        private int _currentQuestionIndex = 0;
        private bool _quizStarted = false;

        public StemwijzerView()
        {
            InitializeComponent();
            _questions = PoliticalData.Questions.Take(8).ToList();
            _answers = new List<UserAnswer>();
            ShowInstructionState();
        }

        private void ShowInstructionState()
        {
            QuestionPanel.Visibility = Visibility.Visible;
            ResultsPanel.Visibility = Visibility.Collapsed;
            BottomCTA.Visibility = Visibility.Visible;
            CurrentQuestionCard.Visibility = Visibility.Collapsed;
            PreviousQuestionCard.Visibility = Visibility.Collapsed;
            ResultsPreviewCard.Visibility = Visibility.Collapsed;
        }

        private void StartQuiz(object sender, RoutedEventArgs e)
        {
            _quizStarted = true;
            _currentQuestionIndex = 0;
            _answers.Clear();
            BottomCTA.Visibility = Visibility.Collapsed;
            CurrentQuestionCard.Visibility = Visibility.Visible;
            UpdateQuestionDisplay();
        }

        private void UpdateQuestionDisplay()
        {
            if (_currentQuestionIndex < _questions.Count)
            {
                var currentQuestion = _questions[_currentQuestionIndex];
                QuestionText.Text = currentQuestion.Text;

                // Update previous question if exists
                if (_currentQuestionIndex > 0)
                {
                    var previousQuestion = _questions[_currentQuestionIndex - 1];
                    PreviousQuestionText.Text = previousQuestion.Text;
                    PreviousQuestionCard.Visibility = Visibility.Visible;
                }
                else
                {
                    PreviousQuestionCard.Visibility = Visibility.Collapsed;
                }

                // Update results preview
                if (_answers.Count > 0)
                {
                    UpdateResultsPreview();
                    ResultsPreviewCard.Visibility = Visibility.Visible;
                }
            }
        }

        private void UpdateResultsPreview()
        {
            if (_answers.Count == 0) return;

            var partialResults = PoliticalData.CalculateMatches(_answers).Take(3).ToList();

            // Clear existing results
            PartialResults.Children.Clear();

            // Add top 3 matches
            for (int i = 0; i < partialResults.Count; i++)
            {
                var result = partialResults[i];
                var textBlock = new TextBlock
                {
                    Text = $"{result.PartyName}: {result.Percentage}%",
                    FontSize = 16,
                    Foreground = (System.Windows.Media.Brush)FindResource("WebsiteGreen"),
                    Margin = new Thickness(0, 2, 0, 2)
                };
                PartialResults.Children.Add(textBlock);
            }
        }

        private void AnswerEens(object sender, RoutedEventArgs e)
        {
            if (!_quizStarted) return;
            RecordAnswer(AnswerType.Eens);
        }

        private void AnswerNeutraal(object sender, RoutedEventArgs e)
        {
            if (!_quizStarted) return;
            RecordAnswer(AnswerType.Neutraal);
        }

        private void AnswerOneens(object sender, RoutedEventArgs e)
        {
            if (!_quizStarted) return;
            RecordAnswer(AnswerType.Oneens);
        }

        private void RecordAnswer(AnswerType answerType)
        {
            // Remove existing answer for this question
            _answers.RemoveAll(a => a.QuestionId == _questions[_currentQuestionIndex].Id);

            // Add new answer
            _answers.Add(new UserAnswer
            {
                QuestionId = _questions[_currentQuestionIndex].Id,  // FIXED: was *questions[*currentQuestionIndex]
                QuestionText = _questions[_currentQuestionIndex].Text,  // FIXED: was *questions[*currentQuestionIndex]
                Answer = answerType
            });

            // Auto-advance
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_currentQuestionIndex < _questions.Count - 1)
                {
                    _currentQuestionIndex++;
                    UpdateQuestionDisplay();
                }
                else
                {
                    ShowResults();
                }
            }), System.Windows.Threading.DispatcherPriority.Background);
        }

        private void ShowResults()
        {
            QuestionPanel.Visibility = Visibility.Collapsed;
            ResultsPanel.Visibility = Visibility.Visible;
            BottomCTA.Visibility = Visibility.Collapsed;

            // Calculate real results using political data
            var results = PoliticalData.CalculateMatches(_answers);

            // Set position for each result
            for (int i = 0; i < results.Count; i++)
            {
                results[i].Position = i + 1;
            }

            ResultsList.ItemsSource = results;

            // Save results if user is logged in
            if (UserManager.Instance.IsLoggedIn)
            {
                var quizResult = new QuizResult
                {
                    Answers = _answers,
                    Matches = results.Select(r => new PartyMatch
                    {
                        PartyName = r.PartyName,
                        Percentage = r.Percentage,
                        Position = r.Position
                    }).ToList()
                };
                UserManager.Instance.SaveQuizResult(quizResult);
            }
        }

        private void RestartQuiz(object sender, RoutedEventArgs e)
        {
            _quizStarted = false;
            _currentQuestionIndex = 0;
            _answers.Clear();
            ShowInstructionState();
        }

        private void ViewParties(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow?.ContentArea.SetValue(ContentControl.ContentProperty, new PartijenView());
        }
    }
}