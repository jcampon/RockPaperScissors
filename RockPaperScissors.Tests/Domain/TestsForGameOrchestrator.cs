using System;
using NUnit.Framework;
using RockPaperScissors.Domain;
using RockPaperScissors.Domain.Entities;
using RockPaperScissors.Domain.Services;

namespace RockPaperScissors.Tests.Domain
{
	[TestFixture]
	public class TestsForGameOrchestrator
	{
		private IGamePlayerFactory _gamePlayerFactory;
		private IHandsPlayFactory _handsPlayFactory;
		private IHandsPlayResolverService _handsPlayResolverService;
		private IRandomNumberGeneratorService _randomNumberGeneratorService;
		private IHandMovementService _handMovementService;
		private IGameOrchestrator _gameOrchestrator;

		[SetUp]
		public void SetUp()
		{
			_randomNumberGeneratorService = new RandomNumberGeneratorService();
			_handMovementService = new HandMovementService(_randomNumberGeneratorService);
			_handsPlayFactory = new HandsPlayFactory(_handMovementService);
			_gamePlayerFactory = new GamePlayerFactory();
			_handsPlayResolverService = new HandsPlayResolverService();
			_gameOrchestrator = new GameOrchestrator(_gamePlayerFactory, _handsPlayFactory, _handsPlayResolverService);
		}

		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void Test_view_model_for_game_of_human_versus_machine(int handPlayChoiceByHumanPlayer)
		{
			// Act
			var gameResult = _gameOrchestrator.PlayGameOfHumanVersusMachine(handPlayChoiceByHumanPlayer);

			// Assert
			Assert.That(gameResult, Is.TypeOf<GameResult>());
			Assert.That(gameResult.Player1, Is.TypeOf<HumanPlayer>());
			Assert.That(gameResult.Player2, Is.TypeOf<ComputerPlayer>());
			Assert.That(gameResult.LastHandsPlay.HandPlayFromPlayer1, Is.EqualTo((HandMovementOptions.HandMovement)handPlayChoiceByHumanPlayer));
			Assert.That(gameResult.LastHandsPlay.HandPlayFromPlayer2, Is.TypeOf<HandMovementOptions.HandMovement>());
			Assert.That(gameResult.ResultOfTheGame(), Is.TypeOf<HandsPlayResultOptions.Result>());
			Assert.That(gameResult.ListOfTurns.Count, Is.EqualTo(1));
		}

		[Test]
		public void Test_view_model_for_game_of_machine_versus_machine()
		{
			// Act
			var gameResult = _gameOrchestrator.PlayGameOfMachineVersusMachine();

			// Assert
			Assert.That(gameResult, Is.TypeOf<GameResult>());
			Assert.That(gameResult.Player1, Is.TypeOf<ComputerPlayer>());
			Assert.That(gameResult.Player2, Is.TypeOf<ComputerPlayer>());
			Assert.That(gameResult.LastHandsPlay.HandPlayFromPlayer1, Is.TypeOf<HandMovementOptions.HandMovement>());
			Assert.That(gameResult.LastHandsPlay.HandPlayFromPlayer2, Is.TypeOf<HandMovementOptions.HandMovement>());
			Assert.That(gameResult.ResultOfTheGame(), Is.TypeOf<HandsPlayResultOptions.Result>());
			Assert.That(gameResult.ListOfTurns.Count, Is.GreaterThanOrEqualTo(1));
		}

	}
}
