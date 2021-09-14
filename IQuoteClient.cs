using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lecture38QuotesApp.Models.ResponseModels;
using Lecture38QuotesApp.Models.RequestModels;
using Lecture38QuotesApp.Models.Entities;

namespace Lecture38QuotesApp
{
    public interface IQuoteClient
    {
        Task<QuoteResponse> GetAllQuotes();
        Task<Quote> GetQuote(int quoteid);
        Task<QuoteResponse> GetQuoteByName(string name, string surname);
        Task<CreateSessionResponse> CreateSession(CreateSessionRequest user);

        Task<Quote> AddQuote(QuoteRequest quote, string userToken);
        Task<Quote> FavQuote(int id, string userToken);
        Task<LogoutResponse> CancelSession(string userToken);
    }
}
