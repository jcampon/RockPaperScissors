using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockPaperScissors.Domain.Entities
{
	public class HandsPlay
	{
		public HandMovementOptions.HandMovement HandPlayFromPlayer1 { get; protected set; }
		public HandMovementOptions.HandMovement HandPlayFromPlayer2 { get; protected set; }

		public HandsPlay(HandMovementOptions.HandMovement handPlayFromPlayer1, HandMovementOptions.HandMovement handPlayFromPlayer2)
		{
			HandPlayFromPlayer1 = handPlayFromPlayer1;
			HandPlayFromPlayer2 = handPlayFromPlayer2;
		}
	}
}
