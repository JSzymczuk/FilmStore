namespace FilmStore.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FilmStore.Models.FilmStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FilmStore.Models.FilmStoreDbContext context)
        {
            var userManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Role

            string[] roles = { "Administrator" };

            foreach (var role in roles)
            {
                if (!roleManager.RoleExists(role))
                {
                    roleManager.Create(new IdentityRole(role));
                }
            }

            // Gatunki filmów

            List<MovieGenre> genres = new List<MovieGenre>
            {
                new MovieGenre { Name = "Dramat" },
                new MovieGenre { Name = "Biograficzny" },
                new MovieGenre { Name = "Komedia" },
                new MovieGenre { Name = "Gangsterski" },
                new MovieGenre { Name = "Kryminał" },
                new MovieGenre { Name = "Akcja" },
                new MovieGenre { Name = "Animacja" },
                new MovieGenre { Name = "Familijny" },
                new MovieGenre { Name = "Przygodowy" },
                new MovieGenre { Name = "Musical" },
                new MovieGenre { Name = "Fantasy" }
            };

            foreach (var genre in genres)
            { context.MovieGenres.Add(genre); }

            // Typy nośników

            List<ProductType> types = new List<ProductType>
            {
                new ProductType { Name = "VHS" },
                new ProductType { Name = "DVD" },
                new ProductType { Name = "Blu-ray" },
                new ProductType { Name = "produkt cyfrowy" }
            };

            foreach (var type in types)
            { context.ProductTypes.Add(type); }

            // Produkty

            List<Product> products = new List<Product>
            {
                #region Filmy
                // 1
                new Product
                {
                    Title = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    Studio = "Monolith",
                    Starring = "Tim Robbins, Morgan Freeman, Bob Gunton, William Sadler",
                    ReleaseDate = new DateTime(1994, 09, 10),
                    Duration = 142,

                    Name = "Skazani na Shawshank",
                    Desription = "Adaptacja powieści Stephena Kinga. Andy Dufresne w więzieniu Shawshank odsiaduje karę dożywotniego więzienia za podwójne morderstwo, którego nie popełnił. W Shawshank rządzą sadystyczni strażnicy; dyrektor więzienia to hipokryta i oszust. Ale Andy jest sprytniejszy od każdego z nich. Lata, jakie przyjdzie mu spedzić w celi, wykorzysta na przygotowanie misternego planu zemsty - tak zaskakujacego, że zmyli nawet najbliższych współwięźniów.",
                    Price = 19.99,
                    DiscountPrice = null,
                    Quantity = 6,

                    ThumbPath = "thumbs/prod00.jpg",
                    CoverPath = "prod00.jpg",
                    ActiveFrom = new DateTime(2017, 03, 01),
                    IsDeleted = false,

                    Genres = new List<MovieGenre> { genres[0] },
                    ProductType = types[1]
                },
                // 2
                new Product
                {
                    Title = "Intouchables",
                    Director = "Olivier NakacheEric Toledano",
                    Starring = "François Cluzet, Omar Sy, Anne Le Ny, Audrey Fleurot",
                    Studio = "ADD Media Entertainment",
                    ReleaseDate = new DateTime(2012, 11, 08),
                    Duration = 112,

                    Name = "Nietykalni",
                    Desription = "Sparaliżowany milioner zatrudnia do opieki młodego chłopaka z przedmieścia, który właśnie wyszedł z więzienia.",
                    Price = 31.99,
                    DiscountPrice = null,
                    Quantity = 2,

                    ThumbPath = "thumbs/prod01.jpg",
                    CoverPath = "prod01.jpg",
                    ActiveFrom = new DateTime(2017, 03, 01),
                    IsDeleted = false,

                    Genres = new List<MovieGenre> { genres[0], genres[1], genres[2] },
                    ProductType = types[1]
                },
                // 3
                new Product
                {
                    Title = "The Green Mile",
                    Director = "Frank Darabont",
                    Starring = "Tom Hanks, David Morse, Bonnie Hunt, Michael Clarke Duncan, James Cromwell",
                    Studio = "	Universal Pictures",
                    ReleaseDate = new DateTime(2007, 01, 01),
                    Duration = 188,

                    Name = "Zielona mila",
                    Desription = "",
                    Price = 20.99,
                    DiscountPrice = null,
                    Quantity = 4,

                    ThumbPath = "thumbs/prod02.jpg",
                    CoverPath = "prod02.jpg",
                    ActiveFrom = new DateTime(2017, 03, 01),
                    IsDeleted = false,

                    Genres = new List<MovieGenre> { genres[0] },
                    ProductType = types[1]
                },
                // 4
                new Product
                {
                    Title = "Pulp Fiction",
                    Director = "Quentin Tarantino",
                    Starring = "John Travolta, Samuel L. Jackson, Uma Thurman, Bruce Willis",
                    Studio = "",
                    ReleaseDate = new DateTime(1995, 05, 19),
                    Duration = 148,

                    Name = "Pulp Fiction (Filmbox)",
                    Desription = "Vincent Vega i Jules Winnfield, dwaj zawodowi mordercy na usługach gangstera Marsellusa Wallace, odzyskują należącą do ich szefa tajemniczą czarną teczkę. Marsellus zleca Vincentowi opiekę nad swą młodą, intrygująca żoną, Mią. Gangster przekupuje też boksera Butcha Coolidge'a, każąc mu przegrać jedną z następnych walk. Butch przyjmuje pieniądze, ale decyduje się na podwójne oszustwo. Po odzyskaniu czarnej teczki Marsellusa Wallace i zabiciu młodych złodziei Vincent i Jules zabierają zakładnika, którego Vincent przypadkowo zabija strzałem z pistoletu. Całe wnętrze samochodu oraz twarze i ubrania Vincenta i Julesa spływają krwią.",
                    Price = 37.44,
                    DiscountPrice = null,
                    Quantity = 3,

                    ThumbPath = "thumbs/prod03.jpg",
                    CoverPath = "prod03.jpg",
                    ActiveFrom = new DateTime(2017, 03, 01),
                    IsDeleted = false,

                    Genres = new List<MovieGenre> { genres[3] },
                    ProductType = types[1]
                },
                // 5
                new Product
                {
                    Title = "Pokot",
                    Director = "Agnieszka Holland",
                    Starring = "Agnieszka Mandat, Wiktor Zborowski, Jakub Gierszał, Patrycja Volny, Borys Szyc",
                    Studio = "",
                    ReleaseDate = new DateTime(2017, 06, 30),
                    Duration = 128,

                    Name = "Pokot",
                    Desription = "W Sudetach dochodzi do serii morderstw, których ofiarami są myśliwi. Wobec bezradności policji śledztwo rozpoczyna emerytowana inżynierka.",
                    Price = null,
                    DiscountPrice = null,
                    Quantity = 0,

                    ThumbPath = "thumbs/prod04.jpg",
                    CoverPath = "prod04.jpg",
                    ActiveFrom = new DateTime(2017, 03, 01),
                    IsDeleted = false,

                    Genres = new List<MovieGenre> { genres[4] },
                    ProductType = types[2]
                },
                // 6
                new Product
                {
                    Title = "Sherlock",
                    Director = "Jeremy Lovering",
                    Starring = "David Newman, Toby Jones, Lasco Atkins, Greg Bennett",
                    ReleaseDate = new DateTime(2017, 02, 09),

                    Name = "Sherlock seria 4 (BBC)",
                    Desription = "\"Sherlock\" produkcji BBC to serial, który bije rekordy popularności na całym świecie, ma rzesze fanatycznych wręcz wielbicieli i uznany został za najlepszą adaptację przygód Sherlocka Holmesa, jaka do tej pory powstała. \"Sherlock\", w postać którego wciela się Benedict Cumberbatch, korzysta ze smartphone'a, laptopa i Internetu. Jest zabójczo przystojny i elegancki, choć przy tym mocno ekscentryczny, ale też diabelsko inteligentny i równie cyniczny. Jest człowiekiem na wskroś nowoczesnym - umie rozpoznać programistę po krawacie, a pilota samolotów po kciukach. Ma analityczny umysł, a zarabia rozwiązując zagadki kryminalne. Im dziwniejsze, tym lepiej. Watson natomiast twardo stąpa po ziemi. Razem tworzą duet, którego nic nie powstrzyma. Mistrzowski scenariusz i dialogi sprawiają, że film hipnotyzuje od pierwszych minut i pozostawia widza w napięciu do ostatniego ujęcia. W rolę słynnego detektywa wcielił się Benedict Cumberbatch (\"Pokuta\", \"Szpieg\"). Rola doktora Watsona przypadła Martinowi Freemanowi, znanemu z serialu \"Biuro\" lub filmu \"Autostopem przez galaktykę\".",
                    Price = 99.99,
                    DiscountPrice = 79.99,
                    Quantity = 11,

                    ThumbPath = "thumbs/prod05.jpg",
                    CoverPath = "prod05.jpg",
                    ActiveFrom = new DateTime(2017, 03, 01),
                    IsDeleted = false,

                    Genres = new List<MovieGenre> { genres[0], genres[4] },
                    ProductType = types[2]
                },
                // 7
                new Product
                {
                    Title = "Jack Reacher: Never Go Back",
                    Director = "Edward Zwick",
                    Starring = "Tom Cruise, Cobie Smulders, Aldis Hodge, Holt McCallany",
                    ReleaseDate = new DateTime(2017, 03, 15),
                    Duration = 118,

                    Name = "Jack Reacher: Nigdy nie wracaj",
                    Desription = "Jack Reacher powraca do kwatery głównej swojego oddziału, gdzie nieoczekiwanie zostaje oskarżony o zabójstwo sprzed szesnastu lat.",
                    Price = 54.99,
                    DiscountPrice = 49.99,
                    Quantity = 5,

                    ThumbPath = "thumbs/prod06.jpg",
                    CoverPath = "prod06.jpg",
                    ActiveFrom = new DateTime(2017, 03, 01),
                    IsDeleted = false,

                    Genres = new List<MovieGenre> { genres[4], genres[5] },
                    ProductType = types[2]
                },
                // 8
                new Product
                {
                    Title = "Frozen",
                    Director = "Chris Buck, Jennifer Lee",
                    Starring = "Kristen Bell, Idina Menzel, Jonathan Groff, Josh Gad",
                    Studio = "",
                    ReleaseDate = new DateTime(1990, 12, 31),
                    Duration = 0,

                    Name = "Kraina lodu",
                    Desription = "Walt Disney Pictures",
                    Price = 69.99,
                    DiscountPrice = null,
                    Quantity = 2,

                    ThumbPath = "thumbs/prod07.jpg",
                    CoverPath = "prod07.jpg",
                    ActiveFrom = new DateTime(2017, 03, 01),
                    IsDeleted = false,

                    Genres = new List<MovieGenre> { genres[6], genres[7], genres[8], genres[9] },
                    ProductType = types[2]
                },
                // 9
                new Product
                {
                    Title = "Pirates of the Caribbean: The Curse of the Black Pearl",
                    Director = "Gore Verbinski",
                    Starring = "Johnny Depp, Orlando Bloom, Keira Knightley, Geoffrey Rush",
                    Studio = "Walt Disney Home Video",
                    ReleaseDate = new DateTime(2014, 10, 24),
                    Duration = 143,

                    Name = "Piraci z Karaibów: Klątwa Czarnej Perły",
                    Desription = "Kowal Will Turner sprzymierza się z kapitanem Jackiem Sparrowem, by odzyskać swoją miłość - porwaną córkę gubernatora.",
                    Price = 25.99,
                    DiscountPrice = null,
                    Quantity = 3,

                    ThumbPath = "thumbs/prod08.jpg",
                    CoverPath = "prod08.jpg",
                    ActiveFrom = new DateTime(2017, 03, 01),
                    IsDeleted = false,

                    Genres = new List<MovieGenre> { genres[8], genres[10] },
                    ProductType = types[1]
                },
                // 10
                new Product
                {
                    Title = "Pirates of the Caribbean: On Stranger Tides",
                    Director = "Rob Marshall",
                    Starring = "Johnny Depp, Penélope Cruz, Geoffrey Rush, Ian McShane",
                    Studio = "Walt Disney Home Video",
                    ReleaseDate = new DateTime(2014, 10, 24),
                    Duration = 137,

                    Name = "Piraci z Karaibów: Na nieznanych wodach",
                    Desription = "Kapitan Jack Sparrow poszukuje słynnej Fontanny Młodości. Na swojej drodze spotyka piękną Angelikę i okrutnego Czarnobrodego.",
                    Price = 29.99,
                    DiscountPrice = null,
                    Quantity = 4,

                    ThumbPath = "thumbs/prod09.jpg",
                    CoverPath = "prod09.jpg",
                    ActiveFrom = new DateTime(2017, 03, 01),
                    IsDeleted = false,

                    Genres = new List<MovieGenre> { genres[8], genres[10] },
                    ProductType = types[1]
                }

                #endregion
            };

            foreach (var p in products)
            {
                if (p.ProductType.Products == null)
                {
                    p.ProductType.Products = new List<Product>();
                }
                p.ProductType.Products.Add(p);
                foreach (var g in p.Genres)
                {
                    if (g.Products != null)
                    {
                        g.Products = new List<Product>();
                    }
                    g.Products.Add(p);
                }
                context.Products.Add(p);
            }

            string email = "admin@filmstore.pl";
            var user = new AppUser
            {
                UserName = "admin",
                FirstName = "Jerzy",
                LastName = "Wszędziborski",
                Email = email,
                PasswordHash = userManager.PasswordHasher.HashPassword("pass")
            };
            userManager.Create(user);
            user = userManager.FindByEmail(email);
            userManager.AddToRole(user.Id, "Administrator");


        }
    }
}
