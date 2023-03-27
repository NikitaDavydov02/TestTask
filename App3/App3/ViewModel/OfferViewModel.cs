using System;
using System.Collections.Generic;
using System.Text;
using App3.Model;

namespace App3.ViewModel
{
    class OfferViewModel
    {
        public OfferViewModel(OfferModel model)
        {
            offerModel = model;
        }
        private OfferModel offerModel;
        public string Id
        {
            get { return offerModel.Id; }
        }
        
    }
}
