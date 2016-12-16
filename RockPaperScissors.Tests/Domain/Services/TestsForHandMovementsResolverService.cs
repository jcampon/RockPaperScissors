using System;
using NUnit.Framework;
using RockPaperScissors.Domain.Entities;
using RockPaperScissors.Domain.Services;

namespace RockPaperScissors.Tests.Domain.Services
{
	[TestFixture]
	public class TestsForHandMovementsResolverService
	{
		private IHandsPlayResolverService _handsPlayResolverService;

		[SetUp]
		public void SetUp()
		{
			_handsPlayResolverService = new HandsPlayResolverService();
		}

		[Test]
		[TestCase(HandMovementOptions.HandMovement.Rock, HandMovementOptions.HandMovement.Rock, HandsPlayResultOptions.Result.Draw)]
		[TestCase(HandMovementOptions.HandMovement.Rock, HandMovementOptions.HandMovement.Scissors, HandsPlayResultOptions.Result.Player1Wins)]
		[TestCase(HandMovementOptions.HandMovement.Rock, HandMovementOptions.HandMovement.Paper, HandsPlayResultOptions.Result.Player2Wins)]
		
		[TestCase(HandMovementOptions.HandMovement.Paper, HandMovementOptions.HandMovement.Rock, HandsPlayResultOptions.Result.Player1Wins)]
		[TestCase(HandMovementOptions.HandMovement.Paper, HandMovementOptions.HandMovement.Scissors, HandsPlayResultOptions.Result.Player2Wins)]
		[TestCase(HandMovementOptions.HandMovement.Paper, HandMovementOptions.HandMovement.Paper, HandsPlayResultOptions.Result.Draw)]

		[TestCase(HandMovementOptions.HandMovement.Scissors, HandMovementOptions.HandMovement.Rock, HandsPlayResultOptions.Result.Player2Wins)]
		[TestCase(HandMovementOptions.HandMovement.Scissors, HandMovementOptions.HandMovement.Scissors, HandsPlayResultOptions.Result.Draw)]
		[TestCase(HandMovementOptions.HandMovement.Scissors, HandMovementOptions.HandMovement.Paper, HandsPlayResultOptions.Result.Player1Wins)]

		public void Test_that_the_service_resolves_hand_plays_correctly(int handPlayedByPlayer1, int handPlayedByPlayer2, int expectedResult)
		{
			// Arrange
			var handsPlay = GetHandsPlay(handPlayedByPlayer1, handPlayedByPlayer2);

			// Act
			var resultOfHandsPlay = _handsPlayResolverService.ResolveHandsPlay(handsPlay);

			// Assert
			Assert.That(resultOfHandsPlay, Is.EqualTo((HandsPlayResultOptions.Result)expectedResult));
		}

		#region Private Helper Methods

		private HandsPlay GetHandsPlay(int handPlayedByPlayer1, int handPlayedByPlayer2)
		{
			return new HandsPlay((HandMovementOptions.HandMovement) handPlayedByPlayer1,
			                     (HandMovementOptions.HandMovement) handPlayedByPlayer2);
		}

		#endregion

	}
}
