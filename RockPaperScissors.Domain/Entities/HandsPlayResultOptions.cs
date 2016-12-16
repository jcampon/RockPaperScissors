using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockPaperScissors.Domain.Entities
{
	public static class HandsPlayResultOptions
	{
		public enum Result
		{
			Player1Wins = 1,
			Player2Wins = 2,
			Draw = 3
		}
	}
}
