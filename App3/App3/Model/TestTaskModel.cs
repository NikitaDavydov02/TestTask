using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Xml;

namespace App3.Model
{
    class TestTaskModel
    {
        private HttpClient client;
        public List<OfferModel> Offers { get; private set; }

        public TestTaskModel()
        {
            client = new HttpClient();
            Offers = new List<OfferModel>();
            Offers = Task.Run(() => MakeRequest()).Result;
        }
        private async Task<List<OfferModel>> MakeRequest()
        {
            List<OfferModel> output = new List<OfferModel>();
            using (client)
            {
                HttpResponseMessage result = await client.GetAsync("https://yastatic.net/market-export/_/partner/help/YML.xml");
                if (result.IsSuccessStatusCode)
                {
                    string response = "";
                    response = await result.Content.ReadAsStringAsync();
                    XmlDocument xmlDoc = new XmlDocument(); 
                    xmlDoc.LoadXml(response); 
                    XmlNodeList offers = xmlDoc.GetElementsByTagName("offer");
                    foreach(XmlNode offer in offers)
                    {
                        OfferModel offerModel = new OfferModel();
                        offerModel.Id = offer.Attributes["id"].Value;
                        string avaliable = offer.Attributes["available"].Value;
                        if (avaliable == "true")
                            offerModel.Avaliable = true;
                        else
                            offerModel.Avaliable = false;
                        offerModel.Type = offer.Attributes["type"].Value;
                        offerModel.Url = offer["url"].InnerText.ToString();
                        offerModel.Price = Convert.ToDecimal(offer["price"].InnerText);
                        offerModel.Picture = offer["picture"].InnerText.ToString();
                        string delivery = offer.Attributes["delivery"].Value;
                        if (delivery == "true")
                            offerModel.Delivery = true;
                        else
                            offerModel.Delivery = false;
                        output.Add(offerModel);

                    }
                    
                }
            }
            return output;

        }
    }
}
