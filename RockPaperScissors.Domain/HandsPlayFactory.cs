using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RockPaperScissors.Domain.Entities;
using RockPaperScissors.Domain.Services;

namespace RockPaperScissors.Domain
{
	public interface IHandsPlayFactory
	{
		HandsPlay GetHandsPlayFromHumandAndComputerPlayersUsing(int handPlayChoiceByHumanPlayer);
		HandsPlay GetHandsPlayFromBothComputerPlayers();
	}

	public class HandsPlayFactory : IHandsPlayFactory
	{
		private readonly IHandMovementService _handMovementService;

		// Default constructor to enable Dependency Injection through here and for when we add an IoC container
		public HandsPlayFactory(IHandMovementService handMovementService)
		{
			_handMovementService = handMovementService;
		}

		public HandsPlay GetHandsPlayFromHumandAndComputerPlayersUsing(int handPlayChoiceByHumanPlayer)
		{
			var handMovementFromPlayer1 = _handMovementService.GetHandMovementPlayedByHumanPlayer(handPlayChoiceByHumanPlayer);
			var handMovementFromPlayer2 = _handMovementService.GetHandMovementPlayedByComputerPlayer();
						
			return new HandsPlay(handMovementFromPlayer1, handMovementFromPlayer2);
		}

		public HandsPlay GetHandsPlayFromBothComputerPlayers()
		{
			var handMovementFromPlayer1 = _handMovementService.GetHandMovementPlayedByComputerPlayer();
			var handMovementFromPlayer2 = _handMovementService.GetHandMovementPlayedByComputerPlayer();

			return new HandsPlay(handMovementFromPlayer1, handMovementFromPlayer2);
		}
	}
}
