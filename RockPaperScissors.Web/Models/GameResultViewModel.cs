using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Web;
using RockPaperScissors.Domain.Entities;

namespace RockPaperScissors.Web.Models
{
	public class GameResultViewModel
	{
		public GameResult FinalResultOfTheGame { get; set; }

		public string DisplayMessageWithResultOfTheGame()
		{
			var displayMessage = String.Empty;
			var result = FinalResultOfTheGame.ResultOfTheGame();
			switch(result)
			{
				case HandsPlayResultOptions.Result.Draw:
				{
					displayMessage = "IT'S A DRAW!";
					break;
				}
				case HandsPlayResultOptions.Result.Player1Wins:
				{
					displayMessage = "IT'S A WIN FOR " + GetReferenceToPlayer1(FinalResultOfTheGame).ToUpper() + "!!!!";
					break;
				}
				case HandsPlayResultOptions.Result.Player2Wins:
				{
					displayMessage = "THE PLAYER 2 WINS!!!!";
					break;
				}
			}
			return displayMessage;
		}

		public List<string> DisplayMessageWithListOfTurnsOfTheGame()
		{
			var counterOfTurnsPlayed = 0;
			var listOfTurnMessages = new List<string>();

			foreach(var turn in FinalResultOfTheGame.ListOfTurns)
			{
				var messageForTurn = ComposeFinalResultMessage(FinalResultOfTheGame, turn, ++counterOfTurnsPlayed);
				listOfTurnMessages.Add(messageForTurn);
			}

			return listOfTurnMessages;
		}

		#region private helper methods

		private string ComposeFinalResultMessage(GameResult finalResult, GameTurn turn, int counterOfTurnsPlayed)
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.Append("Time: ");
			stringBuilder.Append(DateTime.Now.ToLongTimeString());
			stringBuilder.Append(" - Turn ");
			stringBuilder.Append(counterOfTurnsPlayed);
			stringBuilder.Append(": ");
			stringBuilder.Append(GetReferenceToPlayer1(finalResult));
			stringBuilder.Append(" chose ");
			stringBuilder.Append(turn.HandsPlayOfTheTurn.HandPlayFromPlayer1.ToString().ToUpper());
			stringBuilder.Append(" and the Player 2 chose ");
			stringBuilder.Append(turn.HandsPlayOfTheTurn.HandPlayFromPlayer2.ToString().ToUpper());
			
			return stringBuilder.ToString();
		}

		private string GetReferenceToPlayer1(GameResult finalResultOfTheGame)
		{
			return (finalResultOfTheGame.Player1.PlayerType == GamePlayer.TypeOfPlayer.Human)
				? "You "
				: "The player 1 ";
		}

		#endregion


	}

}