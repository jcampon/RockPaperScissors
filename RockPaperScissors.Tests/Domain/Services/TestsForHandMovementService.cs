using System;
using NUnit.Framework;
using RockPaperScissors.Domain.Entities;
using RockPaperScissors.Domain.Services;

namespace RockPaperScissors.Tests.Domain.Services
{
	[TestFixture]
	public class TestsForHandMovementService
	{
		private IRandomNumberGeneratorService _randomNumberGeneratorService;
		private IHandMovementService _handMovementService;

		[SetUp]
		public void SetUp()
		{
			_randomNumberGeneratorService = new RandomNumberGeneratorService();
			_handMovementService = new HandMovementService(_randomNumberGeneratorService);
		}

		[Test]
		[TestCase(1, HandMovementOptions.HandMovement.Rock)]
		[TestCase(2, HandMovementOptions.HandMovement.Paper)]
		[TestCase(3, HandMovementOptions.HandMovement.Scissors)]
		public void Test_that_the_service_returns_the_correct_hand_movement_by_humar_player(int movementValue, HandMovementOptions.HandMovement expectedHandMovement)
		{
			// Act
			var returneHandMovement = _handMovementService.GetHandMovementPlayedByHumanPlayer(movementValue);

			// Assert
			Assert.That(returneHandMovement, Is.EqualTo(expectedHandMovement));
		}

		[Test]
		public void Test_that_the_service_returns_a_correct_hand_movement_by_computer_player()
		{
			// Act
			var returneHandMovement = _handMovementService.GetHandMovementPlayedByComputerPlayer();

			// Assert
			Assert.That(returneHandMovement, Is.TypeOf<HandMovementOptions.HandMovement>());
		}
	}
}
