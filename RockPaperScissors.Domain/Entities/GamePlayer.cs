using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockPaperScissors.Domain.Entities
{
	public abstract class GamePlayer
	{
		public enum TypeOfPlayer 
		{
			Human = 0,
			Computer = 1
		}
		
		public enum NumberOfPlayer
		{
			Player1 = 1,
			Player2 = 2
		}

		public TypeOfPlayer PlayerType { get; protected set; }
		public NumberOfPlayer PlayerNumber { get; protected set; }

		protected GamePlayer(int playerNumer)
		{
			PlayerNumber = (NumberOfPlayer)playerNumer;
		}
	}

	public class HumanPlayer : GamePlayer
	{
		public HumanPlayer(int playerNumer) : base(playerNumer)
		{
			PlayerType = TypeOfPlayer.Human;
		}
	}

	public class ComputerPlayer : GamePlayer
	{
		public ComputerPlayer(int playerNumer) : base(playerNumer)
		{
			PlayerType = TypeOfPlayer.Computer;
		}
	}
}
