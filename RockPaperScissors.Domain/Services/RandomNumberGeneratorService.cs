using System;

namespace RockPaperScissors.Domain.Services
{
	public interface IRandomNumberGeneratorService
	{
		int GetRandomNumber();
	}

	public class RandomNumberGeneratorService : IRandomNumberGeneratorService
	{
		private readonly Random _randomNumberGenerator = new Random();

		public int GetRandomNumber()
		{
			return _randomNumberGenerator.Next(1, 4);
		}
	}
}