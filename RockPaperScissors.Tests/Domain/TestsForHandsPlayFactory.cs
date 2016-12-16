using System;
using NUnit.Framework;
using RockPaperScissors.Domain;
using RockPaperScissors.Domain.Entities;
using RockPaperScissors.Domain.Services;

namespace RockPaperScissors.Tests.Domain
{
	[TestFixture]
	public class TestsForHandsPlayFactory
	{
		private IHandMovementService _handMovementService;
		private IRandomNumberGeneratorService _randomNumberGeneratorService;
		private IHandsPlayFactory _handsPlayFactory;

		[SetUp]
		public void SetUp()
		{
			_randomNumberGeneratorService = new RandomNumberGeneratorService();
			_handMovementService = new HandMovementService(_randomNumberGeneratorService);
			_handsPlayFactory = new HandsPlayFactory(_handMovementService);
		}

		[Test]
		[TestCase(HandMovementOptions.HandMovement.Rock)]
		[TestCase(HandMovementOptions.HandMovement.Paper)]
		[TestCase(HandMovementOptions.HandMovement.Scissors)]
		public void Test_that_the_factory_returns_a_valid_hands_play_from_humand_and_computer_players_using(HandMovementOptions.HandMovement handPlayChoiceByHumanPlayer)
		{
			// act
			var handsPlayObtained = _handsPlayFactory.GetHandsPlayFromHumandAndComputerPlayersUsing((int)handPlayChoiceByHumanPlayer);

			// assert
			Assert.That(handsPlayObtained, Is.Not.Null);
			Assert.That(handsPlayObtained.HandPlayFromPlayer1, Is.TypeOf<HandMovementOptions.HandMovement>());
			Assert.That(handsPlayObtained.HandPlayFromPlayer2, Is.TypeOf<HandMovementOptions.HandMovement>());
			Assert.That(handsPlayObtained.HandPlayFromPlayer1, Is.EqualTo(handPlayChoiceByHumanPlayer));
		}

		[Test]
		public void Test_that_the_factory_returns_a_valid_hands_play_from_both_computer_players()
		{
			// act
			var handsPlayObtained = _handsPlayFactory.GetHandsPlayFromBothComputerPlayers();

			// assert
			Assert.That(handsPlayObtained, Is.Not.Null);
			Assert.That(handsPlayObtained.HandPlayFromPlayer1, Is.TypeOf<HandMovementOptions.HandMovement>());
			Assert.That(handsPlayObtained.HandPlayFromPlayer2, Is.TypeOf<HandMovementOptions.HandMovement>());
		}
	}
}
