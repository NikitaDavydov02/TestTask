using System;
using System.Collections.Generic;
using System.Text;
using App3.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace App3.ViewModel
{
    class TestTaskViewModel:INotifyPropertyChanged
    {
        private TestTaskModel model;
        public ObservableCollection<OfferViewModel> Offers;
        
        public TestTaskViewModel()
        {
            model = new TestTaskModel();
            Offers = new ObservableCollection<OfferViewModel>();
            foreach (OfferModel offerModel in model.Offers)
            {
                OfferViewModel offerViewModel = new OfferViewModel(offerModel);
                Offers.Add(offerViewModel);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
