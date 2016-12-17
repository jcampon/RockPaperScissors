using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RockPaperScissors.Domain;
using RockPaperScissors.Domain.Entities;
using RockPaperScissors.Domain.Services;
using RockPaperScissors.Web.Models;

namespace RockPaperScissors.Web.Controllers
{
    public class HomeController : Controller
    {
		private readonly IGameOrchestrator _gameOrchestrator;

		public HomeController(IGameOrchestrator gameOrchestrator)
		{
			_gameOrchestrator = gameOrchestrator;
		}

		public HomeController()
		{
			_gameOrchestrator = GetNewGameOrchestrator(); 
		}

	    // GET: /Home/
        public ActionResult Index()
        {
            return View("Index");
        }

		// POST: /Home/
		public ActionResult PlayGame()
		{
			var player1 = GetTheTypeOfPlayerSelectedForPlayer1();

			var resultOfTheGame = PlayTheGame(player1);

			var gameResultViewModel = GetGameResultViewModel(resultOfTheGame);

			return View("GameResult", gameResultViewModel);
		}


		#region Private Helper methods

		// This orchestrator initialisation should not be necessary when using an IoC container but for now will do
	    private IGameOrchestrator GetNewGameOrchestrator()
	    {
			var randomNumberGeneratorService = new RandomNumberGeneratorService();
			var handMovementService = new HandMovementService(randomNumberGeneratorService);
			var handsPlayFactory = new HandsPlayFactory(handMovementService);
			var gamePlayerFactory = new GamePlayerFactory();
			var handsPlayResolverService = new HandsPlayResolverService();
			var gameOrchestrator = new GameOrchestrator(gamePlayerFactory, handsPlayFactory, handsPlayResolverService);

		    return gameOrchestrator;
	    }

	    private GameResult PlayTheGame(int player1)
	    {
			GameResult resultOfTheGame;

			if((GamePlayer.TypeOfPlayer)player1 == GamePlayer.TypeOfPlayer.Human)
			{
				var choiceOfHand = GetTheTypeOfHandPlayedByHumanPlayer();
				resultOfTheGame = _gameOrchestrator.PlayGameOfHumanVersusMachine(choiceOfHand);
			}
			else
				resultOfTheGame = _gameOrchestrator.PlayGameOfMachineVersusMachine();

		    return resultOfTheGame;
	    }

	    private int GetTheTypeOfPlayerSelectedForPlayer1()
	    {
			return Convert.ToInt16(((HttpContext.Request).Form)["Player1"]);
	    }

		private int GetTheTypeOfHandPlayedByHumanPlayer()
		{
			return Convert.ToInt16(((HttpContext.Request).Form)["HandMovementOptions"]);
		}

	    private GameResultViewModel GetGameResultViewModel(GameResult gameResult)
	    {
			return new GameResultViewModel() { FinalResultOfTheGame = gameResult };
	    }

	    #endregion
    }
}
