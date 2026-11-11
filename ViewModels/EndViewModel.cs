using ConnectFour.Models;
using System.Windows.Input;
namespace ConnectFour.ViewModels;
public sealed class EndViewModel
{
    public string ResultTitle { get; }
    public string ResultDescription { get; }
    public ICommand PlayAgainCommand { get; }
    public ICommand BackToMenuCommand { get; }
    public EndViewModel(GameResult result, Action playAgain, Action backToMenu)
    {
        ResultTitle = result switch { GameResult.PlayerOneWon => "Player One Wins!", GameResult.PlayerTwoWon => "Player Two Wins!", GameResult.Draw => "It's a Draw!", _ => "Game Over" };
        ResultDescription = result == GameResult.Draw ? "A close match. Ready for a rematch?" : "Four in a row. Nicely played.";
        PlayAgainCommand = new RelayCommand(_ => playAgain());
        BackToMenuCommand = new RelayCommand(_ => backToMenu());
    }
}
