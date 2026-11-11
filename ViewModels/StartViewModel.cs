using System.Windows.Input;
namespace ConnectFour.ViewModels;
public sealed class StartViewModel
{
    public ICommand StartGameCommand { get; }
    public StartViewModel(Action startGame) => StartGameCommand = new RelayCommand(_ => startGame());
}
