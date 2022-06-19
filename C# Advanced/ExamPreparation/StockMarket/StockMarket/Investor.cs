using System;
using System.Collections.Generic;
using System.Linq;

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


        public void BuyStock(Stock stock)
        {

            if (stock.MarketCapitaliZation >= 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock);
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock currComp = Portfolio.FirstOrDefault(c => c.CompanyName == companyName);
            if (!Portfolio.Select(c => c.CompanyName).Contains(companyName))
            {
                return $"{companyName} does not exist.";
            }
            else if (currComp.PricePerShare >= sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                Portfolio.Remove(currComp);
                MoneyToInvest += sellPrice;
                return $"{companyName} was sold.";
            }
        }
        public Stock FindStock(string companyName)
        {


            if (!Portfolio.Select(c => c.CompanyName).Contains(companyName))
            {
                return null;
            }
            else
            {
                Stock currComp = Portfolio.FirstOrDefault(c => c.CompanyName == companyName);
                return currComp;
            }
        }
        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count == 0)
            {
                return null;
            }
            else
            {
                decimal marketCapt = decimal.MinValue;
                foreach (var comp in Portfolio)
                {
                    if (comp.MarketCapitaliZation > marketCapt)
                    {
                        marketCapt = comp.MarketCapitaliZation;
                    }
                }
                Stock currComp = Portfolio.FirstOrDefault(c => c.MarketCapitaliZation == marketCapt);

                return currComp;
            }
        }
        public string InvestorInformation()
        {
            return $"The investor {FullName} with a broker {BrokerName} has stocks:{Environment.NewLine}{string.Join($"{Environment.NewLine}", Portfolio)}";
        }
    }

}
