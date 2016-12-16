using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RockPaperScissors.Domain.Entities;
using RockPaperScissors.Domain.Services;

namespace RockPaperScissors.Domain
{
	public interface IGameOrchestrator
	{
		GameResult PlayGameOfHumanVersusMachine(int handPlayChoiceByHumanPlayer);
		GameResult PlayGameOfMachineVersusMachine();
	}

	public class GameOrchestrator : IGameOrchestrator
	{
		private readonly IGamePlayerFactory _gamePlayerFactory;
		private readonly IHandsPlayFactory _handsPlayFactory;
		private readonly IHandsPlayResolverService _handsPlayResolverService;

		// Default constructor to enable Dependency Injection through here and for when we add an IoC container
		public GameOrchestrator(IGamePlayerFactory gamePlayerFactory, IHandsPlayFactory handsPlayFactory, IHandsPlayResolverService handsPlayResolverService)
		{
			_gamePlayerFactory = gamePlayerFactory;
			_handsPlayFactory = handsPlayFactory;
			_handsPlayResolverService = handsPlayResolverService;
		}

		public GameResult PlayGameOfHumanVersusMachine(int handPlayChoiceByHumanPlayer)
		{
			var handsPlayExecuted = GetHandsPlayFromHumandAndComputerPlayersUsing(handPlayChoiceByHumanPlayer);
			var gameTurnPlayed = ResolveTurnOfHandsPlayFromPlayersUsing(handsPlayExecuted);

			var gameResult = GetResultOfTheGameOfHumanVersusMachine();
			gameResult.LastHandsPlay = gameTurnPlayed.HandsPlayOfTheTurn;
			gameResult.ListOfTurns.Add(gameTurnPlayed);

			return gameResult;
		}

		public GameResult PlayGameOfMachineVersusMachine()
		{
			var gameTurnPlayed = GetResultOfOneTurnOfHandsPlayBetweenComputerPlayers(); 

			var gameResult = GetResultOfTheGameOfMachineVersusMachine();
			gameResult.LastHandsPlay = gameTurnPlayed.HandsPlayOfTheTurn;
			gameResult.ListOfTurns.Add(gameTurnPlayed);

			if (gameTurnPlayed.ResultOfTheHandsPlay != HandsPlayResultOptions.Result.Draw)
				return gameResult;

			return KeepPlayingUntilThereIsAWinningPlayer(gameResult);
		}

		#region Private Helper Methods

		private GameTurn ResolveTurnOfHandsPlayFromPlayersUsing(HandsPlay handsPlayExecuted)
		{
			var gameTurn = new GameTurn
				{
					HandsPlayOfTheTurn = handsPlayExecuted,
					ResultOfTheHandsPlay = _handsPlayResolverService.ResolveHandsPlay(handsPlayExecuted)
				};

			return gameTurn;
		}

		private GameResult GetResultOfTheGameOfHumanVersusMachine()
		{
			return new GameResult
			{
				Player1 = CreateAHumanPlayer(),
				Player2 = CreateAComputerPlayerFor(GamePlayer.NumberOfPlayer.Player2),
			};
		}

		private GameResult GetResultOfTheGameOfMachineVersusMachine()
		{
			return new GameResult
			{
				Player1 = CreateAComputerPlayerFor(GamePlayer.NumberOfPlayer.Player1),
				Player2 = CreateAComputerPlayerFor(GamePlayer.NumberOfPlayer.Player2)
			};
		}

		private GameTurn GetResultOfOneTurnOfHandsPlayBetweenComputerPlayers()
		{
			var newHandsPlay = GetHandsPlayFromBothComputerPlayers();

			return ResolveTurnOfHandsPlayFromPlayersUsing(newHandsPlay);			
		}

		private GameResult KeepPlayingUntilThereIsAWinningPlayer(GameResult resultOfTheGameAfterOneTurn)
		{
			var listOfTurnsPlayed = resultOfTheGameAfterOneTurn.ListOfTurns;
			var currentResult = HandsPlayResultOptions.Result.Draw;

			do
			{
				var gameTurnResult = GetResultOfOneTurnOfHandsPlayBetweenComputerPlayers();
				currentResult = gameTurnResult.ResultOfTheHandsPlay;
				listOfTurnsPlayed.Add(gameTurnResult);

			} while (currentResult == HandsPlayResultOptions.Result.Draw);

			var gameResult = GetResultOfTheGameOfMachineVersusMachine();
			gameResult.LastHandsPlay = listOfTurnsPlayed.Last().HandsPlayOfTheTurn;
			gameResult.ListOfTurns.AddRange(listOfTurnsPlayed);

			return gameResult;
		}

		private HumanPlayer CreateAHumanPlayer()
		{
			return _gamePlayerFactory.GetHumanPlayer();
		}

		private ComputerPlayer CreateAComputerPlayerFor(GamePlayer.NumberOfPlayer numberOfPlayer)
		{
			return _gamePlayerFactory.GetComputerPlayer((int)numberOfPlayer);
		}

		private HandsPlay GetHandsPlayFromHumandAndComputerPlayersUsing(int handPlayChoiceByHumanPlayer)
		{
			return _handsPlayFactory.GetHandsPlayFromHumandAndComputerPlayersUsing(handPlayChoiceByHumanPlayer);
		}

		private HandsPlay GetHandsPlayFromBothComputerPlayers()
		{
			return _handsPlayFactory.GetHandsPlayFromBothComputerPlayers();
		}

		#endregion
	}
}
