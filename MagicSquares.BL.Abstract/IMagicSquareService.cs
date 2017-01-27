namespace MagicSquares.BL.Abstract
{
    public interface IMagicSquareService
    {
        int[,] GetSquare(int squareSize);

        long GetSquareConstant(int squareSize);
    }
}