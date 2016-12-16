using System;
using NUnit.Framework;
using RockPaperScissors.Domain;
using RockPaperScissors.Domain.Entities;

namespace RockPaperScissors.Tests.Domain
{
	[TestFixture]
	public class TestsForGameOrchestrator
	{
		private IGameOrchestrator _gameOrchestrator;

		[SetUp]
		public void SetUp()
		{
			_gameOrchestrator = new GameOrchestrator();
		}

		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		private void Test_view_model_for_game_of_human_versus_machine(int handPlayChoiceByHumanPlayer)
		{
			// Act
			var gameResult = _gameOrchestrator.PlayGameOfHumanVersusMachine(handPlayChoiceByHumanPlayer);

			// Assert
			Assert.That(gameResult, Is.TypeOf<GameResult>());
			Assert.That(gameResult.Player1, Is.TypeOf<HumanPlayer>());
			Assert.That(gameResult.Player2, Is.TypeOf<ComputerPlayer>());
			Assert.That(gameResult.LastHandsPlay.HandPlayFromPlayer1, Is.EqualTo(handPlayChoiceByHumanPlayer));
			Assert.That(gameResult.LastHandsPlay.HandPlayFromPlayer2, Is.TypeOf<HandMovementOptions.HandMovement>());
			Assert.That(gameResult.ResultOfTheGame(), Is.TypeOf<HandsPlayResultOptions.Result>());
			Assert.That(gameResult.ListOfTurns.Count, Is.EqualTo(1));
		}

		[Test]
		private void Test_view_model_for_game_of_machine_versus_machine()
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
