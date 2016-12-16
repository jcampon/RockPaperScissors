using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockPaperScissors.Domain.Entities
{
	public class GameResult
	{
		public GamePlayer Player1 { get; set; }
		public GamePlayer Player2 { get; set; }
		public HandsPlay LastHandsPlay { get; set; }
		private List<GameTurn> _listOfTurns;
		public List<GameTurn> ListOfTurns
		{
			get { return _listOfTurns ?? (_listOfTurns = new List<GameTurn>()); }
		}

		public HandsPlayResultOptions.Result ResultOfTheGame()
		{
			return ListOfTurns.Last().ResultOfTheHandsPlay;
		}
	}

}
