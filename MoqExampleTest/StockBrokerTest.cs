using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using MoqExample;

namespace MoqExampleTest
{
	public class StockBrokerTest
	{
		// calls GetShareValue with correct parameters
		// returns a valid number (inte infinity, inte negativt osv.)
		// throws on invalid parameters

		[Fact]
		public void GetShareValue_CallsGetShareValueWithCorrectParameters()
		{
			// arrange
			var mockService = new Mock<IStockMarketService>();
			var broker = new StockBroker(mockService.Object);
			string stockName = "kalle-anka";

			// act
			broker.GetShareValue(stockName);

			// assert
			mockService.Verify(m => m.GetShareValue(stockName), Times.Once());
		}

		[Fact]
		public void BuyShares_CallsReserveSharesWithCorrectParameters()
		{
			var mockService = new Mock<IStockMarketService>();
			StockBroker broker = new StockBroker(mockService.Object);
			string shareName = "Ericsson";
			int amount = 12;

			broker.BuyShares(shareName, amount);

			mockService.Verify(m => m.ReserveShares(
				It.IsNotNull<string>(),
				It.Is<int>(x => x == amount)), Times.Once());
		}
		[Fact]
		public void BuyShares_CallsBuyReservedShares()
		{
			var mockService = new Mock<IStockMarketService>();
			StockBroker broker = new StockBroker(mockService.Object);
			string shareName = "IT Högskolan";
			int amount = 5000;

			broker.BuyShares(shareName, amount);

			mockService.Verify(m => m.BuyReservedShares(), Times.Once);
		}
	}
	public class FakeService : IStockMarketService
	{
		public void BuyReservedShares()
		{
			throw new NotImplementedException();
		}

		public double GetShareValue(string name)
		{
			throw new NotImplementedException();
		}

		public void ReserveShares(string name, int amount)
		{
			throw new NotImplementedException();
		}

		public void SellShares(string name, int amount)
		{
			throw new NotImplementedException();
		}
	}
}
