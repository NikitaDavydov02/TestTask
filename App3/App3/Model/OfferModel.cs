using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Model
{
    class OfferModel
    {
        public string Id { get; set; }
        public bool Avaliable { get; set; } = false;
        public string Type { get; set; } = "";
        public string Url { get; set; } = "";
        public decimal Price { get; set; } = 0;
        public string Picture { get; set; } = "";
        public bool Delivery { get; set; } = false;
    }    
}
