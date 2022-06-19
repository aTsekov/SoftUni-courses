using System.Collections.Generic;

namespace StockMarket
{
    public class Investor
    {
       
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            this.FullName = fullName;
            this.Email = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;


        }
        public int Count
        {
            get { return this.Portfolio.Count; }
        }
        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public Investor()
        {

        }

        //Method void BuyStock(Stock stock) – add a single stock of the given company if the stock’s market capitalization is bigger than $10000 and the investor has enough money.Then reduce the MoneyToInvest by the price of the stock.If a stock cannot be bought the method should not do anything.

        public  void BuyStock(Stock stock)
        {
            
            if (stock.MarketCapitaliZation >10000 && MoneyToInvest > stock.PricePerShare)
            {
                Portfolio.Add(stock);
            }
        }
    }
}
