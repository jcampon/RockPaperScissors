using System;
using NUnit.Framework;
using RockPaperScissors.Domain;
using RockPaperScissors.Domain.Entities;

namespace RockPaperScissors.Tests.Domain
{
	[TestFixture]
	public class TestsForGamePlayerFactory
	{
		private readonly IGamePlayerFactory _gamePlayerFactory = new GamePlayerFactory();
		
		[Test]
		public void Test_that_the_factory_returns_a_valid_human_player()
		{
			// act
			var player = _gamePlayerFactory.GetHumanPlayer();

			// assert
			Assert.That(player, Is.InstanceOf(typeof(HumanPlayer)));						
		}

		[Test]
		public void Test_that_a_human_player_is_always_player1()
		{
			// act
			var player = _gamePlayerFactory.GetHumanPlayer();

			// assert
			Assert.That(player.PlayerNumber, Is.EqualTo(GamePlayer.NumberOfPlayer.Player1));
		}

		[Test]
		public void Test_that_a_human_player_is_of_player_type_human()
		{
			// act
			var player = _gamePlayerFactory.GetHumanPlayer();

			// assert
			Assert.That(player.PlayerType, Is.EqualTo(GamePlayer.TypeOfPlayer.Human));
		}

		[Test]
		public void Test_that_the_factory_returns_a_valid_computer_player()
		{
			// act
			var player = _gamePlayerFactory.GetComputerPlayer(1);

			// assert
			Assert.That(player, Is.InstanceOf(typeof(ComputerPlayer)));
		}

		[Test]
		public void Test_that_a_computer_player_is_of_player_type_computer()
		{
			// act
			var player = _gamePlayerFactory.GetComputerPlayer(1);

			// assert
			Assert.That(player.PlayerType, Is.EqualTo(GamePlayer.TypeOfPlayer.Computer));
		}

		[Test]
		public void Test_that_a_computer_player_has_the_correct_number_of_player()
		{
			// act
			var player1 = _gamePlayerFactory.GetComputerPlayer(1);
			var player2 = _gamePlayerFactory.GetComputerPlayer(2);

			// assert
			Assert.That(player1.PlayerNumber, Is.EqualTo(GamePlayer.NumberOfPlayer.Player1));
			Assert.That(player2.PlayerNumber, Is.EqualTo(GamePlayer.NumberOfPlayer.Player2));
		}
	}
}
