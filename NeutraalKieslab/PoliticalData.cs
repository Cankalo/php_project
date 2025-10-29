using System;
using System.Collections.Generic;
using System.Linq;

namespace NeutraalKieslab
{
    public static class PoliticalData
    {
        public static readonly List<PoliticalQuestion> Questions = new()
        {
            new PoliticalQuestion
            {
                Id = 1,
                Text = "Nederland moet zo snel mogelijk stoppen met fossiele subsidies.",
                Category = "Klimaat & Energie",
                PartyPositions = new()
                {
                    ["VVD"] = AnswerType.Oneens,
                    ["PVV"] = AnswerType.Oneens,
                    ["CDA"] = AnswerType.Neutraal,
                    ["D66"] = AnswerType.Eens,
                    ["GL-PvdA"] = AnswerType.Eens,
                    ["SP"] = AnswerType.Eens
                }
            },
            new PoliticalQuestion
            {
                Id = 2,
                Text = "Er moeten strengere regels komen voor immigratie en asiel.",
                Category = "Immigratie & Integratie",
                PartyPositions = new()
                {
                    ["VVD"] = AnswerType.Eens,
                    ["PVV"] = AnswerType.Eens,
                    ["CDA"] = AnswerType.Eens,
                    ["D66"] = AnswerType.Oneens,
                    ["GL-PvdA"] = AnswerType.Oneens,
                    ["SP"] = AnswerType.Neutraal
                }
            },
            new PoliticalQuestion
            {
                Id = 3,
                Text = "Het minimumloon moet worden verhoogd naar €16 per uur.",
                Category = "Economie & Werk",
                PartyPositions = new()
                {
                    ["VVD"] = AnswerType.Oneens,
                    ["PVV"] = AnswerType.Neutraal,
                    ["CDA"] = AnswerType.Neutraal,
                    ["D66"] = AnswerType.Eens,
                    ["GL-PvdA"] = AnswerType.Eens,
                    ["SP"] = AnswerType.Eens
                }
            },
            new PoliticalQuestion
            {
                Id = 4,
                Text = "De zorgpremie moet worden afgeschaft en vervangen door belastingfinanciering.",
                Category = "Zorg & Welzijn",
                PartyPositions = new()
                {
                    ["VVD"] = AnswerType.Oneens,
                    ["PVV"] = AnswerType.Neutraal,
                    ["CDA"] = AnswerType.Oneens,
                    ["D66"] = AnswerType.Neutraal,
                    ["GL-PvdA"] = AnswerType.Eens,
                    ["SP"] = AnswerType.Eens
                }
            },
            new PoliticalQuestion
            {
                Id = 5,
                Text = "Nederland moet meer geld uitgeven aan defensie en krijgsmacht.",
                Category = "Buitenland & Defensie",
                PartyPositions = new()
                {
                    ["VVD"] = AnswerType.Eens,
                    ["PVV"] = AnswerType.Eens,
                    ["CDA"] = AnswerType.Eens,
                    ["D66"] = AnswerType.Neutraal,
                    ["GL-PvdA"] = AnswerType.Oneens,
                    ["SP"] = AnswerType.Oneens
                }
            },
            new PoliticalQuestion
            {
                Id = 6,
                Text = "De AOW-leeftijd moet worden verlaagd naar 65 jaar.",
                Category = "Pensioenen & Ouderen",
                PartyPositions = new()
                {
                    ["VVD"] = AnswerType.Oneens,
                    ["PVV"] = AnswerType.Eens,
                    ["CDA"] = AnswerType.Neutraal,
                    ["D66"] = AnswerType.Oneens,
                    ["GL-PvdA"] = AnswerType.Eens,
                    ["SP"] = AnswerType.Eens
                }
            },
            new PoliticalQuestion
            {
                Id = 7,
                Text = "Nederland moet kernenergie uitbreiden als onderdeel van de energietransitie.",
                Category = "Klimaat & Energie",
                PartyPositions = new()
                {
                    ["VVD"] = AnswerType.Eens,
                    ["PVV"] = AnswerType.Eens,
                    ["CDA"] = AnswerType.Eens,
                    ["D66"] = AnswerType.Neutraal,
                    ["GL-PvdA"] = AnswerType.Oneens,
                    ["SP"] = AnswerType.Oneens
                }
            },
            new PoliticalQuestion
            {
                Id = 8,
                Text = "Grote bedrijven moeten meer belasting betalen dan nu het geval is.",
                Category = "Economie & Belastingen",
                PartyPositions = new()
                {
                    ["VVD"] = AnswerType.Oneens,
                    ["PVV"] = AnswerType.Neutraal,
                    ["CDA"] = AnswerType.Neutraal,
                    ["D66"] = AnswerType.Eens,
                    ["GL-PvdA"] = AnswerType.Eens,
                    ["SP"] = AnswerType.Eens
                }
            }
        };

        public static readonly Dictionary<string, PoliticalParty> Parties = new()
        {
            ["VVD"] = new PoliticalParty { Name = "VVD", FullName = "Volkspartij voor Vrijheid en Democratie", Description = "Liberale partij voor vrijheid en ondernemerschap", Category = "Liberaal", CurrentPolls = 26, PreviousElection = 24, LeaderName = "Dilan Yeşilgöz" },
            ["PVV"] = new PoliticalParty { Name = "PVV", FullName = "Partij voor de Vrijheid", Description = "Populistische partij tegen immigratie", Category = "Rechts-populistisch", CurrentPolls = 31, PreviousElection = 37, LeaderName = "Geert Wilders" },
            ["CDA"] = new PoliticalParty { Name = "CDA", FullName = "Christen-Democratisch Appèl", Description = "Christendemocratische partij met conservatieve waarden", Category = "Conservatief", CurrentPolls = 21, PreviousElection = 5, LeaderName = "Henri Bontenbal" },
            ["D66"] = new PoliticalParty { Name = "D66", FullName = "Democraten 66", Description = "Progressief-liberale partij voor democratie", Category = "Progressief-liberaal", CurrentPolls = 18, PreviousElection = 24, LeaderName = "Rob Jetten" },
            ["GL-PvdA"] = new PoliticalParty { Name = "GL-PvdA", FullName = "GroenLinks-PvdA", Description = "Linkse alliantie voor sociale rechtvaardigheid", Category = "Links", CurrentPolls = 25, PreviousElection = 17, LeaderName = "Frans Timmermans" },
            ["SP"] = new PoliticalParty { Name = "SP", FullName = "Socialistische Partij", Description = "Socialistische partij voor de gewone mensen", Category = "Links", CurrentPolls = 11, PreviousElection = 9, LeaderName = "Lilian Marijnissen" }
        };

        public static List<PartyResult> CalculateMatches(List<UserAnswer> answers)
        {
            var results = new List<PartyResult>();

            foreach (var party in Parties.Values)
            {
                var totalQuestions = answers.Count;
                var matches = 0;

                foreach (var answer in answers)
                {
                    var question = Questions.FirstOrDefault(q => q.Id == answer.QuestionId);
                    if (question?.PartyPositions.TryGetValue(party.Name, out var partyPosition) == true)
                    {
                        var matchScore = CalculateMatchScore(answer.Answer, partyPosition);
                        matches += matchScore;
                    }
                }

                var percentage = totalQuestions > 0 ? (int)Math.Round((double)matches / (totalQuestions * 2) * 100) : 0;
                results.Add(new PartyResult
                {
                    PartyName = party.Name,
                    FullName = party.FullName,
                    Description = party.Description,
                    Percentage = percentage
                });
            }

            return results.OrderByDescending(r => r.Percentage).ToList();
        }

        private static int CalculateMatchScore(AnswerType userAnswer, AnswerType partyPosition)
        {
            if (userAnswer == partyPosition) return 2; // Perfect match
            if (userAnswer == AnswerType.Neutraal || partyPosition == AnswerType.Neutraal) return 1; // Partial match
            return 0; // No match
        }
    }

    public class PoliticalQuestion
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public Dictionary<string, AnswerType> PartyPositions { get; set; } = new();
    }

    public class PoliticalParty
    {
        public string Name { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int CurrentPolls { get; set; }
        public int PreviousElection { get; set; }
        public string LeaderName { get; set; } = string.Empty;
    }

    public class PartyResult
    {
        public string PartyName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Percentage { get; set; }
        public string PercentageText => $"{Percentage}%";
        public int Position { get; set; }
    }
}