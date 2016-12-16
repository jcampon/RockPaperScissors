using System;
using NUnit.Framework;
using RockPaperScissors.Domain.Entities;
using RockPaperScissors.Domain.Services;

namespace RockPaperScissors.Tests.Domain.Services
{
	[TestFixture]
	public class TestsForHandsPlay
	{
		[Test]
		public void Test_that_the_overriden_equals_function_works_as_expected()
		{
			// Act
			var handsPlay1 = new HandsPlay(HandMovementOptions.HandMovement.Paper, HandMovementOptions.HandMovement.Rock);
			var handsPlay2 = new HandsPlay(HandMovementOptions.HandMovement.Paper, HandMovementOptions.HandMovement.Rock);
			var handsPlay3 = new HandsPlay(HandMovementOptions.HandMovement.Scissors, HandMovementOptions.HandMovement.Scissors);

			// Assert
			Assert.That(handsPlay1.Equals(handsPlay2), Is.True);
			Assert.That(handsPlay2.Equals(handsPlay3), Is.False);
		}
	}
}
