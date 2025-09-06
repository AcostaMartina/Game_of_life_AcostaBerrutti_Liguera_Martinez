using System;
namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BoardReader reader = new BoardReader();
            bool[,] boardfile = reader.LoadFromFiles("board.txt");
            
            Board board = new Board(boardfile);
            
            GameLogic game = new GameLogic(board);
            
            GamePrinter printer = new GamePrinter();

            while (true)
            {
                printer.ShowBoard(board);
                game.CalculateNextGeneration();
            }
        }
    }
}