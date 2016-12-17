using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using RockPaperScissors;
using RockPaperScissors.Domain;
using RockPaperScissors.Domain.Services;
using RockPaperScissors.Web.Controllers;

namespace RockPaperScissors.Tests.Web.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
		private IGamePlayerFactory _gamePlayerFactory;
		private IHandsPlayFactory _handsPlayFactory;
		private IHandsPlayResolverService _handsPlayResolverService;
		private IRandomNumberGeneratorService _randomNumberGeneratorService;
		private IHandMovementService _handMovementService;
		private IGameOrchestrator _gameOrchestrator;
		
		[SetUp]
		public void SetUp()
		{
			_randomNumberGeneratorService = new RandomNumberGeneratorService();
			_handMovementService = new HandMovementService(_randomNumberGeneratorService);
			_handsPlayFactory = new HandsPlayFactory(_handMovementService);
			_gamePlayerFactory = new GamePlayerFactory();
			_handsPlayResolverService = new HandsPlayResolverService();
			_gameOrchestrator = new GameOrchestrator(_gamePlayerFactory, _handsPlayFactory, _handsPlayResolverService);
		}

        [Test]
        public void Test_that_the_index_action_returns_an_index_view()
        {
            // Arrange
			var controller = new HomeController(_gameOrchestrator);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
			Assert.That(result.ViewName, Is.EqualTo("Index"));
        }

		[Test]
		public void Test_that_the_playgame_action_returns_an_gameresult_view()
		{
			// Arrange
			var controller = new HomeController(_gameOrchestrator);

			// Act
			var result = controller.Index() as ViewResult;

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.ViewName, Is.EqualTo("GameResult"));
		}
    }
}
