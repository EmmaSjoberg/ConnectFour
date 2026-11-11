using ConnectFour.Models;
namespace ConnectFour.ViewModels;
public sealed class MainViewModel : ObservableObject
{
    private object _currentView;
    public object CurrentView { get => _currentView; private set { _currentView = value; Notify(); } }
    public MainViewModel() => _currentView = new StartViewModel(ShowGame);
    private void ShowStart() => CurrentView = new StartViewModel(ShowGame);
    private void ShowGame() => CurrentView = new GameViewModel(ShowEnd, ShowStart);
    private void ShowEnd(GameResult result) => CurrentView = new EndViewModel(result, ShowGame, ShowStart);
}
