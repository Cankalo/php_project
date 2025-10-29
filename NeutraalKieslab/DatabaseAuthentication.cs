using System;
using System.Collections.Generic;
using System.Linq;

namespace NeutraalKieslab
{
    public class UserManager
    {
        private static UserManager? _instance;
        private readonly List<User> _users;
        private User? _currentUser;

        private UserManager()
        {
            _users = new List<User>();

            // Add demo users manually (NO RegisterUser method needed)
            var demoUser = new User
            {
                Id = Guid.NewGuid(),
                Email = "demo@neutraalkieslab.nl",
                PasswordHash = "demo123",
                Salt = "salt",
                FirstName = "Demo",
                LastName = "Gebruiker",
                Phone = "0612345678",
                CreatedAt = DateTime.Now,
                LastLogin = DateTime.Now
            };
            _users.Add(demoUser);

            var janUser = new User
            {
                Id = Guid.NewGuid(),
                Email = "jan@example.com",
                PasswordHash = "password123",
                Salt = "salt",
                FirstName = "Jan",
                LastName = "de Vries",
                Phone = "0687654321",
                CreatedAt = DateTime.Now,
                LastLogin = DateTime.Now
            };
            _users.Add(janUser);
        }

        public static UserManager Instance => _instance ??= new UserManager();

        public User? CurrentUser => _currentUser;

        public bool IsLoggedIn => _currentUser != null;

        public LoginResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return new LoginResult { Success = false, Message = "Email en wachtwoord zijn verplicht." };

            var user = _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (user == null)
                return new LoginResult { Success = false, Message = "Gebruiker niet gevonden." };

            // Simple password check (no complex hashing for demo)
            if (user.PasswordHash != password)
                return new LoginResult { Success = false, Message = "Incorrect wachtwoord." };

            _currentUser = user;
            user.LastLogin = DateTime.Now;

            return new LoginResult
            {
                Success = true,
                Message = $"Welkom terug, {user.FirstName}!",
                User = user
            };
        }

        public LoginResult Register(string email, string password, string firstName, string lastName, string phone)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return new LoginResult { Success = false, Message = "Alle verplichte velden moeten ingevuld zijn." };

            if (_users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
                return new LoginResult { Success = false, Message = "Er bestaat al een account met dit e-mailadres." };

            if (password.Length < 6)
                return new LoginResult { Success = false, Message = "Wachtwoord moet minimaal 6 karakters lang zijn." };

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Email = email,
                PasswordHash = password, // Simple storage for demo
                Salt = "salt",
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                CreatedAt = DateTime.Now,
                LastLogin = DateTime.Now
            };

            _users.Add(newUser);
            _currentUser = newUser;

            return new LoginResult
            {
                Success = true,
                Message = $"Account succesvol aangemaakt! Welkom, {firstName}!",
                User = newUser
            };
        }

        public void Logout()
        {
            _currentUser = null;
        }

        public void SaveQuizResult(QuizResult result)
        {
            if (_currentUser != null)
            {
                _currentUser.QuizResults.Add(result);
                result.UserId = _currentUser.Id;
                result.CompletedAt = DateTime.Now;
            }
        }

        public List<QuizResult> GetUserQuizResults()
        {
            return _currentUser?.QuizResults ?? new List<QuizResult>();
        }
    }

    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set; }
        public List<QuizResult> QuizResults { get; set; } = new();

        public string FullName => $"{FirstName} {LastName}";
    }

    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public User? User { get; set; }
    }

    public class QuizResult
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public DateTime CompletedAt { get; set; }
        public List<UserAnswer> Answers { get; set; } = new();
        public List<PartyMatch> Matches { get; set; } = new();
    }

    public class UserAnswer
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public AnswerType Answer { get; set; }
    }

    public class PartyMatch
    {
        public string PartyName { get; set; } = string.Empty;
        public int Percentage { get; set; }
        public int Position { get; set; }
    }
}