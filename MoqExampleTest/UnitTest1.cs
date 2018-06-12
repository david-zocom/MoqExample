using Moq;
using System;
using Xunit;

namespace MoqExampleTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
			var mockBear = new Mock<Bear>();
			Bear bear = mockBear.Object;
			bear.Speak();

			mockBear.Verify(m => m.Speak(), Times.Once());
        }

		
    }

	public class Bear
	{
		public virtual void Speak()
		{
			Console.WriteLine("Roar");
		}
	}
}


