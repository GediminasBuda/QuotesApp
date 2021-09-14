using Lecture38QuotesApp.Models;
using Lecture38QuotesApp.Models.RequestModels;
using Lecture38QuotesApp.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lecture38QuotesApp
{
    class QuoteApp
    {
        private readonly IQuoteClient _quoteClient;

        public QuoteApp(IQuoteClient iQuotesClient)
        {
            _quoteClient = iQuotesClient;
        }

        public async Task StartAsync()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("WELCOME TO YOUR FAVORITE QUOTES APP!");

            while (true)
            {
                Console.Write("\nAvailable commands: \n" +
                    "1 - Login; \n" +
                    "2 - Exit. \n\n");

                Console.WriteLine();
                var command = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (command)
                {
                    case 1:
                        Console.Write("Enter username or email: ");
                        var loginSignup = Console.ReadLine();

                        Console.Write("Enter password: ");
                        var password = Console.ReadLine();

                        var user = await _quoteClient.CreateSession(new CreateSessionRequest
                        {
                            User = new User
                            {
                                Login = loginSignup,
                                Password = password
                            }
                        });

                        var login = false;

                        if (user.UserToken != null)
                        {
                            login = true;
                            Console.WriteLine("\nYou've logged-in successfully!\n");
                        }

                        if (user.UserToken == null)
                        {
                            Console.WriteLine("\nInvalid username or password!");
                        }

                        int quoteId;

                        while (login)
                        {
                            Console.WriteLine("Available commands:");
                            Console.WriteLine("1 - Show all Quotes");
                            Console.WriteLine("2 - Show Quote by Id");
                            Console.WriteLine("3 - Show Quotes by Author");
                            Console.WriteLine("4 - Add new Quote");
                            Console.WriteLine("5 - To Like a Quote");
                            Console.WriteLine("6 - Exit");

                            var chosenCommand = Console.ReadLine();

                            switch (chosenCommand)
                            {
                                case "1":

                                    var quotes = (await _quoteClient.GetAllQuotes());
                                    foreach (var item in quotes.Quotes)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    break;

                                case "2":

                                    Console.WriteLine("Enter Id: ");
                                    var quoteid = Convert.ToInt32(Console.ReadLine());
                                    var quote = await _quoteClient.GetQuote(quoteid);
                                    Console.WriteLine(quote);
                                    break;

                                case "3":
                                    Console.WriteLine("\nEnter Author's Name: ");
                                    var Name = Console.ReadLine();
                                    Console.WriteLine("\nEnter Author's Surname: ");
                                    var Surname = Console.ReadLine();
                                    var authorQuotes = (await _quoteClient.GetQuoteByName(Name, Surname));
                                    
                                    foreach (var item in authorQuotes.Quotes)
                                    {
                                        Console.WriteLine(item);
                                    }

                                    break;

                                case "4":

                                    Console.WriteLine("\nEnter author's name: ");
                                    var authorName = Console.ReadLine();

                                    Console.WriteLine("\nEnter author's quote: ");
                                    var quoteBody = Console.ReadLine();

                                    var addQuote = await _quoteClient.AddQuote(new QuoteRequest
                                    {
                                        Quote = new QuoteR
                                        {
                                            Author = authorName,
                                            Body = quoteBody
                                        },
                                        
                                    }, user.UserToken);
                                    Console.WriteLine(addQuote);
                                    break;

                                case "5":

                                    Console.WriteLine("\nEnter quote ID you want to favorite: ");

                                    quoteId = Convert.ToInt32(Console.ReadLine());

                                    var quoteFav = await _quoteClient.FavQuote(quoteId, user.UserToken);

                                    Console.WriteLine(quoteFav);

                                    break;


                                case "6":
                                    var sessionCanceled = await _quoteClient.CancelSession(user.UserToken);
                                    Console.WriteLine(sessionCanceled);

                                    login = false;

                                    break;
                                default:
                                    Console.WriteLine("Bad command! \n");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        return;
                    default:
                        Console.WriteLine("Bad command! \n");
                        break;
                }
            }
        }
    }
}
