using DeckOfCardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCardsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
          
            return View(DeckOfCardsDAL.GetDeckOfCardsModel("new",0));
        }
        [HttpPost]
        public IActionResult Index(string deckId, string card0, string card1, string card2, string card3, string card4,string shuffle)
        {
            int cardCount = 5;
            if (card0 != null && card0 != "")
            {
                cardCount--;
            }
            if (card1 != null && card1 != "")
            {
                cardCount--;
            }
            if (card2 != null && card2 != "")
            {
                cardCount--;
            }
            if (card3 != null && card3 != "")
            {
                cardCount--;
            }
            if (card4 != null && card4 != "")
            {
                cardCount--;
            }

            DeckOfCardsModel result = DeckOfCardsDAL.GetDeckOfCardsModel(deckId,cardCount);

            if (card0 != null && card0 != "")
            {
                result.cards.Add(new Card() { image = card0 });
            }
            if (card1 != null && card1 != "")
            {
                result.cards.Add(new Card() { image = card1 });
            }
            if (card2 != null && card2 != "")
            {
                result.cards.Add(new Card() { image = card2 });
            }
            if (card3 != null && card3 != "")
            {
                result.cards.Add(new Card() { image = card3 });
            }
            if (card4 != null && card4 != "")
            {
                result.cards.Add(new Card() { image = card4 });
            }
            if (shuffle == "true")
            {
                DeckOfCardsDAL.GetDeckOfCardsShuffle(deckId);
            }

            
            return View(result);


        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}