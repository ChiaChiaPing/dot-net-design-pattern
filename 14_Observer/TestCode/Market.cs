using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;


namespace TestCode
{
    public class Market
    {
        // Onservable Collection
        public BindingList<float> Prices = new BindingList<float>();
        public void AddPrice(float prices)
        {
            this.Prices.Add(prices);
        }
    }
}
