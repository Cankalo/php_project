using System;
using System.Collections.Generic;
using System.Linq;

namespace NeutraalKieslab
{
    public static class NewsData
    {
        public static readonly List<NewsArticle> LatestNews = new()
        {
            new NewsArticle
            {
                Id = 1,
                Title = "Kabinet-Schoof demissionair na vertrek PVV-ministers",
                Summary = "Op 3 juni 2025 hebben de ministers van de PVV hun ontslag aangeboden na meningsverschillen over het klimaatbeleid.",
                Content = "Het kabinet-Schoof is demissionair geworden na het vertrek van drie PVV-ministers. De crisis ontstond door fundamentele meningsverschillen over de uitvoering van het klimaatakkoord. Premier Schoof heeft aangekondigd dat er nieuwe verkiezingen zullen worden gehouden in september 2025. De PVV-fractie in de Tweede Kamer blijft wel het kabinet gedogen tot de verkiezingen.",
                PublishDate = new DateTime(2025, 6, 3, 16, 30, 0),
                Category = "Regering",
                Source = "Rijksoverheid",
                Author = "Redactie",
                IsBreaking = true,
                Tags = new List<string> { "kabinet", "PVV", "demissionair", "verkiezingen" }
            },
            new NewsArticle
            {
                Id = 2,
                Title = "Nieuw peilingonderzoek toont verschuivingen in politieke voorkeur",
                Summary = "GL-PvdA stijgt naar 28 zetels, VVD verliest terrein volgens laatste Maurice de Hond peiling.",
                Content = "Het laatste peilingonderzoek van Maurice de Hond toont opvallende verschuivingen in de Nederlandse politieke voorkeur. GroenLinks-PvdA stijgt naar 28 zetels (+3), terwijl de VVD daalt naar 23 zetels (-3). De PVV blijft stabiel op 31 zetels. Opvallend is de stijging van D66 naar 21 zetels. De peiling werd gehouden onder 3.200 respondenten tussen 1 en 5 juni 2025.",
                PublishDate = new DateTime(2025, 6, 5, 14, 15, 0),
                Category = "Peilingen",
                Source = "Maurice de Hond",
                Author = "Peilingbureau",
                IsBreaking = false,
                Tags = new List<string> { "peiling", "GL-PvdA", "VVD", "zetels" }
            },
            new NewsArticle
            {
                Id = 3,
                Title = "Tweede Kamer debatteert over nieuw klimaatbeleid",
                Summary = "Heftig debat verwacht over CO2-reductie doelstellingen en rol van kernenergie in energietransitie.",
                Content = "Vandaag staat het nieuwe klimaatbeleid centraal in een groot Tweede Kamerdebat. De regering wil de CO2-uitstoot met 55% verminderen tegen 2030. Controversieel is vooral het voorstel om kernenergie uit te breiden met drie nieuwe centrales. GL-PvdA en SP zijn fel tegen, terwijl VVD en PVV voorstander zijn. Het debat begint om 13:00 uur en wordt live uitgezonden.",
                PublishDate = new DateTime(2025, 6, 10, 9, 0, 0),
                Category = "Regering",
                Source = "Tweede Kamer",
                Author = "Parlementair verslaggever",
                IsBreaking = false,
                Tags = new List<string> { "klimaat", "kernenergie", "debat", "CO2" }
            },
            new NewsArticle
            {
                Id = 4,
                Title = "Nieuwe kabinetsformatie officieel van start",
                Summary = "Informateur Plasterk start gesprekken met alle partijen voor vorming nieuw kabinet na verkiezingen.",
                Content = "Na de verkiezingsuitslag van 15 september is informateur Ronald Plasterk begonnen met de kabinetsformatie. Alle partijen die de kiesdrempel hebben gehaald worden gehoord. De grootste partij PVV (31 zetels) heeft als eerste het recht om een kabinet te vormen, maar heeft aangegeven open te staan voor samenwerking. GL-PvdA (28 zetels) heeft uitdrukkelijk aangegeven niet in zee te willen gaan met de PVV.",
                PublishDate = new DateTime(2025, 6, 18, 11, 30, 0),
                Category = "Regering",
                Source = "ANP",
                Author = "Politiek verslaggever",
                IsBreaking = true,
                Tags = new List<string> { "formatie", "Plasterk", "verkiezingen", "kabinet" }
            },
            new NewsArticle
            {
                Id = 5,
                Title = "EU-top bespreekt nieuwe migratieregels",
                Summary = "Nederland pleit voor strengere grenscontroles tijdens Europese Raad in Brussel.",
                Content = "In Brussel komen de EU-leiders bijeen om het nieuwe migratiepact te bespreken. Nederland, vertegenwoordigd door minister-president Schoof, pleit voor verstrenging van de buitengrenzen en betere spreiding van asielzoekers. Vooral de zuidelijke EU-landen Italië en Griekenland vragen om meer solidariteit. Het pact moet voor 2026 worden geïmplementeerd.",
                PublishDate = new DateTime(2025, 6, 20, 16, 45, 0),
                Category = "Buitenlandbeleid",
                Source = "Europese Raad",
                Author = "EU-correspondent",
                IsBreaking = false,
                Tags = new List<string> { "EU", "migratie", "Brussel", "asiel" }
            },
            new NewsArticle
            {
                Id = 6,
                Title = "Begroting 2026 gepresenteerd met forse bezuinigingen",
                Summary = "Minister van Financiën kondigt 8 miljard euro aan bezuinigingen aan in zorg en onderwijs.",
                Content = "Minister van Financiën heeft de begroting voor 2026 gepresenteerd met ingrijpende bezuinigingen. In totaal wordt er 8 miljard euro bezuinigd, voornamelijk in de zorg (3,2 miljard) en het onderwijs (2,1 miljard). Tegelijkertijd wordt er geïnvesteerd in defensie (+2,5 miljard) en infrastructuur (+1,8 miljard). De oppositie heeft al aangekondigd tegen de begroting te zullen stemmen.",
                PublishDate = new DateTime(2025, 6, 22, 10, 0, 0),
                Category = "Regering",
                Source = "Ministerie van Financiën",
                Author = "Economisch verslaggever",
                IsBreaking = true,
                Tags = new List<string> { "begroting", "bezuinigingen", "zorg", "onderwijs" }
            },
            new NewsArticle
            {
                Id = 7,
                Title = "Nieuw duurzaamheidsplan: Nederland CO2-neutraal in 2045",
                Summary = "Ambitieus klimaatplan beoogt vijf jaar eerder klimaatneutraal te zijn dan EU-doelstelling.",
                Content = "Het kabinet presenteert een ambitieus duurzaamheidsplan waarmee Nederland in 2045 volledig CO2-neutraal moet zijn. Dit is vijf jaar eerder dan de EU-doelstelling. Het plan omvat massale investeringen in windenergie op zee, zonneparken en kernenergie. Ook komt er een CO2-heffing voor bedrijven en wordt de BTW op vlees verhoogd naar 21%. Milieuorganisaties zijn voorzichtig positief, werkgeversorganisaties kritisch over de kosten.",
                PublishDate = new DateTime(2025, 6, 25, 14, 20, 0),
                Category = "Regering",
                Source = "Ministerie van Klimaat",
                Author = "Milieu correspondent",
                IsBreaking = false,
                Tags = new List<string> { "klimaat", "CO2-neutraal", "duurzaamheid", "energie" }
            }
        };

        public static List<NewsArticle> GetLatestNews(int count = 10)
        {
            return LatestNews.Take(count).OrderByDescending(n => n.PublishDate).ToList();
        }

        public static NewsArticle GetNewsById(int id)
        {
            return LatestNews.FirstOrDefault(n => n.Id == id);
        }

        public static List<NewsArticle> GetNewsByCategory(string category)
        {
            return LatestNews.Where(n => n.Category == category).OrderByDescending(n => n.PublishDate).ToList();
        }
    }

    public class NewsArticle
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public bool IsBreaking { get; set; }
        public List<string> Tags { get; set; } = new();

        public string TimeAgo
        {
            get
            {
                var timeDiff = DateTime.Now - PublishDate;
                if (timeDiff.TotalDays >= 7) return $"{(int)(timeDiff.TotalDays / 7)} weken geleden";
                if (timeDiff.TotalDays >= 1) return $"{(int)timeDiff.TotalDays} dagen geleden";
                if (timeDiff.TotalHours >= 1) return $"{(int)timeDiff.TotalHours} uur geleden";
                return "Zojuist";
            }
        }

        public string CategoryEmoji => Category switch
        {
            "Regering" => "🏛️",
            "Peilingen" => "📊",
            "Buitenlandbeleid" => "🌍",
            _ => "📰"
        };

        public string BreakingText => IsBreaking ? "🔴 BREAKING: " : "";
    }
}