using System;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            this.CompanyName = companyName;
            Director = director;
            this.PricePerShare = pricePerShare;
            this. TotalNumberOfShares = totalNumberOfShares;
            this.MarketCapitaliZation = PricePerShare * TotalNumberOfShares; // should I use the props or the ctor values?
        }
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitaliZation { get; set; }


        public override string ToString()
        {
            return $"Company: {CompanyName}{Environment.NewLine}Director: {Director}{Environment.NewLine}Price per share: ${PricePerShare}{Environment.NewLine}Market capitalization: ${MarketCapitaliZation}";
            
        }
    }
}
