using System;
using System.Collections.Generic;
using System.Text;

namespace MoqExample
{
    public class StockBroker
    {
		private IStockMarketService service;

		public StockBroker(IStockMarketService service)
		{
			this.service = service;
		}

		public double GetShareValue(string name)
		{
			return service.GetShareValue(name);
		}

		public void BuyShares(string shareName, int amount)
		{
			service.ReserveShares(shareName, amount);
			service.BuyReservedShares();
		}
		/*
		void SellShares(string name, int amount)
		*/
	}
}
