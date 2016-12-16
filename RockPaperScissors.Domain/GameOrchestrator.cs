using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RockPaperScissors.Domain.Entities;

namespace RockPaperScissors.Domain
{
	public interface IGameOrchestrator
	{
		GameResult PlayGameOfHumanVersusMachine(int handPlayChoiceByHumanPlayer);
		GameResult PlayGameOfMachineVersusMachine();
	}

	public class GameOrchestrator : IGameOrchestrator
	{
		public GameResult PlayGameOfHumanVersusMachine(int handPlayChoiceByHumanPlayer)
		{
			throw new Exception("Method not implemented yet");
		}

		public GameResult PlayGameOfMachineVersusMachine()
		{
			throw new Exception("Method not implemented yet");
		}
	}
}
