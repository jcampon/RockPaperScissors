using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RockPaperScissors.Domain.Entities;

namespace RockPaperScissors.Domain.Services
{
	public interface IHandMovementService
	{
		HandMovementOptions.HandMovement GetHandMovementPlayedByHumanPlayer(int handMovementValue);
		HandMovementOptions.HandMovement GetHandMovementPlayedByComputerPlayer();
	}	
	
	public class HandMovementService : IHandMovementService
	{
		private readonly IRandomNumberGeneratorService _randomNumberGeneratorService;

		public HandMovementService(IRandomNumberGeneratorService randomNumberGeneratorService)
		{
			_randomNumberGeneratorService = randomNumberGeneratorService;
		}

		public HandMovementOptions.HandMovement GetHandMovementPlayedByHumanPlayer(int handMovementValue)
		{
			return (HandMovementOptions.HandMovement) handMovementValue;
		}

		public HandMovementOptions.HandMovement GetHandMovementPlayedByComputerPlayer()
		{
			return (HandMovementOptions.HandMovement)_randomNumberGeneratorService.GetRandomNumber();
		}
	}
}
