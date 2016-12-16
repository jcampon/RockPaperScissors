namespace RockPaperScissors.Domain.Entities
{
	public class GameTurn
	{
		public HandsPlay HandsPlayOfTheTurn;
		public HandsPlayResultOptions.Result ResultOfTheHandsPlay { get; set; }
	}
}