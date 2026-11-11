using ConnectFour.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace ConnectFour.ViewModels;
public sealed class GameViewModel : ObservableObject
{
    private readonly Game _game = new();
    private readonly Action<GameResult> _showEnd;
    public ObservableCollection<BoardCellViewModel> Cells { get; } = new();
    private string _statusText = "";
    public string StatusText { get => _statusText; private set { _statusText = value; Notify(); } }
    public ICommand DropPieceCommand { get; }
    public ICommand ResetCommand { get; }
    public ICommand BackToMenuCommand { get; }
    public GameViewModel(Action<GameResult> showEnd, Action showStart)
    {
        _showEnd = showEnd;
        DropPieceCommand = new RelayCommand(p => { if (p is int column) MakeMove(column); });
        ResetCommand = new RelayCommand(_ => { _game.Reset(); Refresh(); });
        BackToMenuCommand = new RelayCommand(_ => showStart());
        for (int row = 0; row < Board.Rows; row++)
            for (int col = 0; col < Board.Columns; col++) Cells.Add(new BoardCellViewModel(col));
        Refresh();
    }
    private void MakeMove(int column)
    {
        if (!_game.MakeMove(column)) return;
        Refresh();
        if (_game.IsGameOver) _showEnd(_game.Result);
    }
    private void Refresh()
    {
        for (int row = 0; row < Board.Rows; row++)
            for (int col = 0; col < Board.Columns; col++) Cells[row * Board.Columns + col].State = _game.Board.GetCell(row, col);
        StatusText = _game.CurrentPlayer == CellState.PlayerOne ? "Player One's Turn" : "Player Two's Turn";
    }
}
