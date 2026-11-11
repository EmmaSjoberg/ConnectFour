using ConnectFour.Models;
namespace ConnectFour.ViewModels;
public sealed class BoardCellViewModel : ObservableObject
{
    private CellState _state;
    public int Column { get; }
    public BoardCellViewModel(int column) => Column = column;
    public CellState State { get => _state; set { if (_state == value) return; _state = value; Notify(); } }
}
