namespace ConnectFour.Models;
public sealed class Board
{
    public const int Rows = 6;
    public const int Columns = 7;
    private readonly CellState[,] _cells = new CellState[Rows, Columns];
    public CellState GetCell(int row, int column) => _cells[row, column];
    public bool PlacePiece(int column, CellState player)
    {
        if (column < 0 || column >= Columns || player == CellState.Empty) return false;
        for (int row = Rows - 1; row >= 0; row--)
            if (_cells[row, column] == CellState.Empty) { _cells[row, column] = player; return true; }
        return false;
    }
    public bool HasWon(CellState player)
    {
        if (player == CellState.Empty) return false;
        int[,] directions = { { 0, 1 }, { 1, 0 }, { 1, 1 }, { 1, -1 } };
        for (int row = 0; row < Rows; row++)
            for (int col = 0; col < Columns; col++)
                if (_cells[row, col] == player)
                    for (int d = 0; d < 4; d++)
                    {
                        int dr = directions[d, 0], dc = directions[d, 1];
                        int endRow = row + 3 * dr, endCol = col + 3 * dc;
                        if (endRow < 0 || endRow >= Rows || endCol < 0 || endCol >= Columns) continue;
                        bool win = true;
                        for (int step = 1; step < 4; step++)
                            if (_cells[row + step * dr, col + step * dc] != player) { win = false; break; }
                        if (win) return true;
                    }
        return false;
    }
    public bool IsFull
    {
        get { for (int c = 0; c < Columns; c++) if (_cells[0, c] == CellState.Empty) return false; return true; }
    }
}
