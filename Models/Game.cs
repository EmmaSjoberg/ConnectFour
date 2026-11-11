namespace ConnectFour.Models;
public sealed class Game
{
    public Board Board { get; private set; } = new();
    public CellState CurrentPlayer { get; private set; } = CellState.PlayerOne;
    public GameResult Result { get; private set; } = GameResult.Ongoing;
    public bool IsGameOver => Result != GameResult.Ongoing;
    public bool MakeMove(int column)
    {
        if (IsGameOver || !Board.PlacePiece(column, CurrentPlayer)) return false;
        if (Board.HasWon(CurrentPlayer))
            Result = CurrentPlayer == CellState.PlayerOne ? GameResult.PlayerOneWon : GameResult.PlayerTwoWon;
        else if (Board.IsFull) Result = GameResult.Draw;
        else CurrentPlayer = CurrentPlayer == CellState.PlayerOne ? CellState.PlayerTwo : CellState.PlayerOne;
        return true;
    }
    public void Reset() { Board = new Board(); CurrentPlayer = CellState.PlayerOne; Result = GameResult.Ongoing; }
}
