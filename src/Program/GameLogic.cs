namespace Ucu.Poo.GameOfLife;

//Esta clase es la responsable de la lógica del juego de la vida.
//Cumple con SRP porque su única responsabilidad es calcular la siguiente generación del juego.
//Su unica razon de cambio sería si cambian las reglas del juego
//Cumple con expert porque es la clase experta en las reglas del juego de la vida y por eso trabaja con eso,
//y no es experta ni en almacenamiento de datos, visualización ni lectura de archivos. 
public class GameLogic
{
    private Board _board;

    public GameLogic(Board board)
    {
        _board = board;
    }
    
    //Calcula la siguiente generación del tablero aplicando las reglas de Conway.
    public void CalculateNextGeneration()
    {
        int boardWidth = _board.Width;
        int boardHeight = _board.Height;
        
        //Crea un nuevo tablero para la nueva generación sin modificar el anterior.
        bool[,] newCells = new bool[boardWidth, boardHeight];
        Board cloneboard = new Board(newCells);
        
        //Recorre todas las celulas del tablero actual
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                int aliveNeighbors = 0;
                //Cuenta los vecinos vivos en las 8 células que están alrededor de la célula actual.
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        //Se fija si el vecino está dentro del tablero y si está vivo.
                        if (i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && _board.Cells[i, j])
                        {
                            aliveNeighbors++;
                        }
                    }
                }
                
                //Hacemos que no cuente la célula actual como vecina de sí misma.
                if (_board.Cells[x, y])
                {
                    aliveNeighbors--;
                }

                if (_board.Cells[x, y] && aliveNeighbors < 2)
                {
                    //Celula muere por baja población
                    cloneboard.Cells[x, y] = false;
                }
                else if (_board.Cells[x, y] && aliveNeighbors > 3)
                {
                    //Celula muere por sobrepoblación
                    cloneboard.Cells[x, y] = false;
                }
                else if (!_board.Cells[x, y] && aliveNeighbors == 3)
                {
                    //Celula nace por reproducción
                    cloneboard.Cells[x, y] = true;
                }
                else
                {
                    //Celula mantiene el estado que tenía
                    cloneboard.Cells[x, y] = _board.Cells[x, y];
                }
            }
        }
        //Reemplaza el anterior tablero con el nuevo.
        _board = cloneboard;
    } 
}