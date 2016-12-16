using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RockPaperScissors.Domain.Entities;

namespace RockPaperScissors.Domain.Services
{
	public interface IHandsPlayResolverService
	{
		HandsPlayResultOptions.Result ResolveHandsPlayWithStrategies(HandsPlay handsPlay);
	}	
	
	public class HandsPlayResolverService : IHandsPlayResolverService
	{
		private readonly Dictionary<HandsPlay, HandsPlayResultOptions.Result> _listOfHandPlayStrategies;

		public HandsPlayResolverService()
		{
			_listOfHandPlayStrategies = new Dictionary<HandsPlay, HandsPlayResultOptions.Result>
			{
				{new HandsPlay(HandMovementOptions.HandMovement.Rock, HandMovementOptions.HandMovement.Rock), HandsPlayResultOptions.Result.Draw},
				{new HandsPlay(HandMovementOptions.HandMovement.Rock, HandMovementOptions.HandMovement.Paper), HandsPlayResultOptions.Result.Player2Wins},
				{new HandsPlay(HandMovementOptions.HandMovement.Rock, HandMovementOptions.HandMovement.Scissors), HandsPlayResultOptions.Result.Player1Wins},

				{new HandsPlay(HandMovementOptions.HandMovement.Paper, HandMovementOptions.HandMovement.Rock), HandsPlayResultOptions.Result.Player1Wins},
				{new HandsPlay(HandMovementOptions.HandMovement.Paper, HandMovementOptions.HandMovement.Paper), HandsPlayResultOptions.Result.Draw},
				{new HandsPlay(HandMovementOptions.HandMovement.Paper, HandMovementOptions.HandMovement.Scissors), HandsPlayResultOptions.Result.Player2Wins},

				{new HandsPlay(HandMovementOptions.HandMovement.Scissors, HandMovementOptions.HandMovement.Rock), HandsPlayResultOptions.Result.Player2Wins},
				{new HandsPlay(HandMovementOptions.HandMovement.Scissors, HandMovementOptions.HandMovement.Paper), HandsPlayResultOptions.Result.Player1Wins},
				{new HandsPlay(HandMovementOptions.HandMovement.Scissors, HandMovementOptions.HandMovement.Scissors), HandsPlayResultOptions.Result.Draw}
			};
		}

		public HandsPlayResultOptions.Result ResolveHandsPlayWithStrategies(HandsPlay handsPlay)
		{
			foreach (var strategy in _listOfHandPlayStrategies.Where(strategy => strategy.Key.Equals(handsPlay)))
				return strategy.Value;

			return HandsPlayResultOptions.Result.Draw;
		}
	}
}
