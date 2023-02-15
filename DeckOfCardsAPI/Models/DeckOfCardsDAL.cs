using Newtonsoft.Json;
using System.Net;

namespace DeckOfCardsAPI.Models
{
    public class DeckOfCardsDAL
    {
        public static DeckOfCardsModel GetDeckOfCardsModel(string deckId, int cardCount)//adjust here
        {
            //adjust here
            //setup
            string url = $"https://deckofcardsapi.com/api/deck/{deckId}/draw/?count={cardCount}";
            //request
            WebRequest request = WebRequest.CreateHttp(url);
            WebResponse response = (HttpWebResponse)request.GetResponse();
            //convert to JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();
            //adjust here
            //Convert to C#
            DeckOfCardsModel result = JsonConvert.DeserializeObject<DeckOfCardsModel>(JSON);
            return result;
        }
        public static void GetDeckOfCardsShuffle(string deckId)//adjust here
        {
            //adjust here
            //setup

            string url = $"https://deckofcardsapi.com/api/deck/{deckId}/shuffle/";
            WebRequest request = WebRequest.CreateHttp(url);
            WebResponse response = (HttpWebResponse)request.GetResponse();
        }
        
    }
}
