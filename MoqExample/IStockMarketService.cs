using System;
using System.Collections.Generic;
using System.Text;

namespace MoqExample
{
    public interface IStockMarketService
    {
		double GetShareValue(string name);
		void ReserveShares(string name, int amount);
		void BuyReservedShares();
		void SellShares(string name, int amount);
    }
}
