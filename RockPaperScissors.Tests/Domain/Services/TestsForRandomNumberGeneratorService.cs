using System;
using Moq;
using NUnit.Framework;
using RockPaperScissors.Domain;
using RockPaperScissors.Domain.Entities;
using RockPaperScissors.Domain.Services;

namespace RockPaperScissors.Tests.Domain.Services
{
	[TestFixture]
	public class TestsForRandomNumberGeneratorService
	{
		private readonly IRandomNumberGeneratorService _randomNumberGeneratorService = 
			new RandomNumberGeneratorService();

		[Test]
		public void Test_that_the_service_returns_values_between_1_and_3_only()
		{
			for (var i = 1; i <= 1000; i++)
				Assert.That(_randomNumberGeneratorService.GetRandomNumber(), Is.InRange(1, 3));
		}

		[Test]
		public void Test_that_the_service_returns_values_evenly_distributed()
		{
			// Arrange
			var CounterFor1s = 0;
			var CounterFor2s = 0;
			var CounterFor3s = 0;

			// Act
			for(var i = 1; i <= 10000; i++)
			{
				switch(_randomNumberGeneratorService.GetRandomNumber())
				{
					case 1:
						{
							CounterFor1s++;
							break;
						}
					case 2:
						{
							CounterFor2s++;
							break;
						}
					case 3:
						{
							CounterFor3s++;
							break;
						}
				}
			}

			// Assert that each number should have appeared around 33% of times of the total of calls
			Assert.That(CounterFor1s, Is.InRange(3000, 3500));  
			Assert.That(CounterFor2s, Is.InRange(3000, 3500));
			Assert.That(CounterFor3s, Is.InRange(3000, 3500));
		}


	}
}
