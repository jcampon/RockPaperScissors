using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RockPaperScissors.Domain.Entities;

namespace RockPaperScissors.Domain.Services
{
	public interface IHandMovementsResolverService
	{
		HandsPlayResultOptions.Result ResolveHandsPlay(HandsPlay handsPlay);
	}	
	
	public class HandMovementsResolverService : IHandMovementsResolverService
	{
		public HandsPlayResultOptions.Result ResolveHandsPlay(HandsPlay handsPlay)
		{
			var handsPlayResult = (HandsPlayResultOptions.Result) 0;

			switch (handsPlay.HandPlayFromPlayer1)
			{
				case HandMovementOptions.HandMovement.Rock:
				{
					return GetResultWhenPlayer1PlaysRock(handsPlay.HandPlayFromPlayer2);
					break;
				}
				case HandMovementOptions.HandMovement.Paper:
				{
					return GetResultWhenPlayer1PlaysPaper(handsPlay.HandPlayFromPlayer2);
					break;
				}
				case HandMovementOptions.HandMovement.Scissors:
				{
					return GetResultWhenPlayer1PlaysScissors(handsPlay.HandPlayFromPlayer2);
					break;
				}
			}

			return handsPlayResult;
		}



		#region Private Helpers Region

		private HandsPlayResultOptions.Result GetResultWhenPlayer1PlaysRock(
			HandMovementOptions.HandMovement handPlayFromPlayer2)
		{
			var handsPlayResult = (HandsPlayResultOptions.Result)0;

			switch(handPlayFromPlayer2)
			{
				case HandMovementOptions.HandMovement.Rock:
					{
						handsPlayResult = HandsPlayResultOptions.Result.Draw;
						break;
					}
				case HandMovementOptions.HandMovement.Paper:
					{
						handsPlayResult = HandsPlayResultOptions.Result.Player2Wins;
						break;
					}
				case HandMovementOptions.HandMovement.Scissors:
					{
						handsPlayResult = HandsPlayResultOptions.Result.Player1Wins;
						break;
					}
			}

			return handsPlayResult;
		}

		private HandsPlayResultOptions.Result GetResultWhenPlayer1PlaysPaper(
			HandMovementOptions.HandMovement handPlayFromPlayer2)
		{
			var handsPlayResult = (HandsPlayResultOptions.Result) 0;

			switch (handPlayFromPlayer2)
			{
				case HandMovementOptions.HandMovement.Rock:
				{
					handsPlayResult = HandsPlayResultOptions.Result.Player1Wins;
					break;
				}
				case HandMovementOptions.HandMovement.Paper:
				{
					handsPlayResult = HandsPlayResultOptions.Result.Draw;
					break;
				}
				case HandMovementOptions.HandMovement.Scissors:
				{
					handsPlayResult = HandsPlayResultOptions.Result.Player2Wins;
					break;
				}
			}

			return handsPlayResult;
		}

		private HandsPlayResultOptions.Result GetResultWhenPlayer1PlaysScissors(
			HandMovementOptions.HandMovement handPlayFromPlayer2)
		{
			var handsPlayResult = (HandsPlayResultOptions.Result)0;

			switch(handPlayFromPlayer2)
			{
				case HandMovementOptions.HandMovement.Rock:
					{
						handsPlayResult = HandsPlayResultOptions.Result.Player2Wins;
						break;
					}
				case HandMovementOptions.HandMovement.Paper:
					{
						handsPlayResult = HandsPlayResultOptions.Result.Player1Wins;
						break;
					}
				case HandMovementOptions.HandMovement.Scissors:
					{
						handsPlayResult = HandsPlayResultOptions.Result.Draw;
						break;
					}
			}

			return handsPlayResult;
		}

		#endregion

	}
}
