using Microsoft.EntityFrameworkCore;

namespace IndividualSeeSharpers.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new SeeSharpersContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<SeeSharpersContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "Paashaas academie",
                    Duration = new TimeSpan(1, 16, 0),
                    Movie3d = false,
                    Thumbnail = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/47044173_146265.jpg&alt=img/movie_placeholder.png",
                    Language = "Nederlands",
                    Description = "De jonge haas Max is supertrots dat hij als eerste stadse haas is aangenomen op de Paashaas Academie. Op een geheime plaats, diep in het bos krijgt hij een speciale training. Pasen staat immers voor de deur en straks moeten Max en zijn nieuwe vrienden ervoor zorgen dat alle kinderen hun paaseieren krijgen. Wanneer het magische gouden ei ineens zwart kleurt, breekt er paniek uit in het bos. Dit betekent dat Pasen in gevaar is! Max zijn enige kans om het grote feest te redden, is samenwerken met het vossenjong Ferdinand. Maar kan een haas een vos wel echt vertrouwen?",
                    DescriptionEn = "The young hare Max is very proud that he has been accepted as the first urban hare at the Easter Bunny Academy. In a secret place, deep in the forest, he receives special training. After all, Easter is just around the corner and soon Max and his new friends will have to make sure that all the children get their Easter eggs. When the magical golden egg suddenly turns black, panic breaks out in the forest. This means Easter is in danger! Max's only chance to save the big party is to team up with the fox cub Ferdinand. But can a hare really trust a fox?",
                    Genre = "Komedie/Animatie",
                    GenreEn = "Comedy/Animation"
                },

                new Movie
                {
                    Title = "Fantastic Beasts: The secrets of dumbledore",
                    Duration = new TimeSpan(2, 23, 0),
                    Movie3d = false,
                    AgeRequirement = 6,
                    Thumbnail = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/15002206_147463.jpg&alt=img/movie_placeholder.png",
                    Language = "English",
                    Description = "Professor Albus Perkamentus weet dat de duistere tovenaar Gellert Grindelwald de macht over de tovenaarswereld wil overnemen. In zijn eentje kan hij hem niet tegenhouden, dus schakelt hij de hulp in van magiezoöloog Newt Scamander. Die gaat samen met een team van tovenaars, heksen en een dappere Dreuzel-bakker een gevaarlijke missie aan, waarbij ze oude en nieuwe fabeldieren tegenkomen en tegenover Grindelwalds groeiende leger van volgers komen te staan. Maar hoelang kan Perkamentus zich afzijdig houden als er zo veel op het spel staat?",
                    DescriptionEn = "Professor Albus Dumbledore knows that the dark wizard Gellert Grindelwald wants to take control of the wizarding world. Unable to stop him on his own, he enlists the help of magic zoologist Newt Scamander. Together with a team of wizards, witches and a brave Muggle baker, he embarks on a dangerous mission, encountering old and new mythical creatures and facing Grindelwald's growing army of followers. But how long can Dumbledore keep his distance when the stakes are so high?",
                    Genre = "Fantasy",
                    GenreEn = "Fantasy"
                },


                new Movie
                {
                    Title = "The Northman",
                    Duration = new TimeSpan(2, 20, 0),
                    Movie3d = false,
                    AgeRequirement = 12,
                    Thumbnail = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/2039522_147051.jpg&alt=img/movie_placeholder.png",
                    Language = "English",
                    Description = "The Northman, de nieuwe film van de visionaire regisseur Robert Eggers (The Lighthouse, The Witch), is een heroïsch actie-epos over een jonge Vikingprins en zijn missie om de moord op zijn vader te wreken. De sterrencast bestaat onder meer uit Alexander Skarsgård, Nicole Kidman, Claes Bang, Anya Taylor-Joy, Ethan Hawke, Björk en Willem Dafoe.",
                    DescriptionEn = "The Northman, the new film from visionary director Robert Eggers (The Lighthouse, The Witch), is a heroic action epic about a young Viking prince and his mission to avenge his father's murder. The star cast includes Alexander Skarsgård, Nicole Kidman, Claes Bang, Anya Taylor-Joy, Ethan Hawke, Björk and Willem Dafoe.",
                    Genre = "Actie/Avontuur",
                    GenreEn = "Action/Adventure"
                },


                new Movie
                {
                    Title = "Sonic the hedgehog 2 (Originele Versie)",
                    Duration = new TimeSpan(2, 02, 0),
                    Movie3d = false,
                    AgeRequirement = 9,
                    Thumbnail = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/02059700_144865.jpg&alt=img/movie_placeholder.png",
                    Language = "English",
                    Description = "Sinds Sonic in Green Hills woont, wil hij maar wat graag laten zien dat hij een echte held is. En die kans krijgt hij als Dr. Robotnik terugkeert, die met zijn nieuwe partner Knuckles op zoek is naar een smaragd met een allesvernietigende kracht. Samen met zijn eigen sidekick Tails reist Sonic de wereld over om de smaragd te vinden voordat deze in de verkeerde handen valt.",
                    DescriptionEn = "Ever since Sonic lives in Green Hills, he's been eager to show that he's a true hero. And he gets that chance when Dr. Robotnik returns, who with his new partner Knuckles searches for an emerald with all-destroying power. Together with his own sidekick Tails, Sonic travels the world to find the emerald before it falls into the wrong hands.",
                    Genre = "Avontuur/Sci-fi",
                    GenreEn = "Adventure/Sci-fi"
                },


                new Movie
                {
                    Title = "Sonic the hedgehog 2 (Nederlandse Versie)",
                    Duration = new TimeSpan(2, 02, 0),
                    Movie3d = false,
                    AgeRequirement = 9,
                    Thumbnail = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/02059700_144865.jpg&alt=img/movie_placeholder.png",
                    Language = "English",
                    Description = "Sinds Sonic in Green Hills woont, wil hij maar wat graag laten zien dat hij een echte held is. En die kans krijgt hij als Dr. Robotnik terugkeert, die met zijn nieuwe partner Knuckles op zoek is naar een smaragd met een allesvernietigende kracht. Samen met zijn eigen sidekick Tails reist Sonic de wereld over om de smaragd te vinden voordat deze in de verkeerde handen valt.",
                    DescriptionEn = "Ever since Sonic lives in Green Hills, he's been eager to show that he's a true hero. And he gets that chance when Dr. Robotnik returns, who with his new partner Knuckles searches for an emerald with all-destroying power. Together with his own sidekick Tails, Sonic travels the world to find the emerald before it falls into the wrong hands.",
                    Genre = "Avontuur/Sci-fi",
                    GenreEn = "Adventure/Sci-fi"
                },


                new Movie
                {
                    Title = "Initiation",
                    Duration = new TimeSpan(1, 37, 0),
                    Movie3d = false,
                    AgeRequirement = 16,
                    Thumbnail = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/93010127_144295.jpg&alt=img/movie_placeholder.png",
                    Language = "English",
                    Description = "Tijdens de introweek van Whiton University komt het zorgeloze feesten van een groep studenten abrupt aan z’n einde wanneer een van de studenten vermoord wordt. De moord ontketent een stortvloed aan sinistere social-media berichten. Ondertussen gaat de killer verder met zijn volgende slachtoffer, de ene na de andere student wordt op gruwelijke wijze vermoord. De studenten en de politie worden gedwongen om zo snel mogelijk de moordenaar te vinden.",
                    DescriptionEn = "During Whiton University's introductory week, a group of students' carefree partying comes to an abrupt end when one of the students is murdered. The murder unleashes a deluge of sinister social media posts. Meanwhile, the killer moves on to his next victim, one student after another being gruesomely murdered. The students and the police are forced to find the killer as soon as possible.",
                    Genre = "Horror",
                    GenreEn = "Horror"
                },


                new Movie
                {
                    Title = "Jackass forever",
                    Duration = new TimeSpan(1, 36, 0),
                    Movie3d = false,
                    AgeRequirement = 12,
                    Thumbnail = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/2039598_145971.jpg&alt=img/movie_placeholder.png",
                    Language = "English",
                    Description = "Weer samen zijn met je beste vrienden, dat is net zo mooi als een perfect uitgevoerde trap in de ballen. De jongens van Jackass keren terug met opnieuw een hele lading hilarische, extreme, absurde en vaak levensgevaarlijke stunts. Hierbij krijgen zij hulp van een aantal interessante nieuwkomers. In Jackass Forever gaan Johnny en het team nog verder dan ooit.",
                    DescriptionEn = "Being with your best friends again is just as beautiful as a perfectly executed kick in the balls. The Jackass boys return with another load of hilarious, extreme, absurd and often life-threatening stunts. They get help from a number of interesting newcomers. In Jackass Forever, Johnny and the team go further than ever.",
                    Genre = "Komedie/Slapstick",
                    GenreEn = "Comedy/Slapstick"
                }
            );

            context.SaveChanges();



            // Look for any Theatres.
            if (context.Theatres.Any())
            {
                return;   // DB has been seeded
            }


            context.Theatres.AddRange(



                new Theatre
                {
                    Number = 1,
                    AmountOfRows = 8,
                    AmountOfSeats = 120,

                },

                new Theatre
                {
                    Number = 2,
                    AmountOfRows = 8,
                    AmountOfSeats = 120,

                },

                new Theatre
                {
                    Number = 3,
                    AmountOfRows = 8,
                    AmountOfSeats = 120,

                },

                new Theatre
                {
                    Number = 4,
                    AmountOfRows = 6,
                    AmountOfSeats = 60,

                },

                new Theatre
                {
                    Number = 5,
                    AmountOfRows = 4,
                    AmountOfSeats = 54,

                },

                new Theatre
                {
                    Number = 6,
                    AmountOfRows = 4,
                    AmountOfSeats = 54,

                }

                );



            context.SaveChanges();


        }


    }
}

