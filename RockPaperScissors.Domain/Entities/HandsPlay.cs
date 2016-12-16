using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockPaperScissors.Domain.Entities
{
	public class HandsPlay
	{
		public HandMovementOptions.HandMovement HandPlayFromPlayer1 { get; set; }
		public HandMovementOptions.HandMovement HandPlayFromPlayer2 { get; set; }
	}
}
