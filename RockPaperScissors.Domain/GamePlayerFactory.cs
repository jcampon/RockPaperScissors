using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RockPaperScissors.Domain.Entities;

namespace RockPaperScissors.Domain
{
	public interface IGamePlayerFactory
	{
		ComputerPlayer GetComputerPlayer(int playerNumber);
		HumanPlayer GetHumanPlayer();
	}

	public class GamePlayerFactory : IGamePlayerFactory
	{
		public HumanPlayer GetHumanPlayer()
		{
			return new HumanPlayer(1);
		}

		public ComputerPlayer GetComputerPlayer(int playerNumber)
		{
			if (playerNumber < 1 || playerNumber > 2)
				throw new ArgumentOutOfRangeException("playerNumber", "playerNumber should be a value of 1 or 2");

			return new ComputerPlayer(playerNumber);
		}
	}
}
