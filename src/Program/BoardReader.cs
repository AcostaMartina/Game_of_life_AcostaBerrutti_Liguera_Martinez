//Justificacion de la clase: Se creó la clase ya que solo se encarga de la lectura del archivo "board.txt" cambiando los
//valores de 1 y 0 a verdadero y falso y devovliendolo como un matriz. Además toda la información que necesita la 
//obtiene la clase en sí. 


using System.IO;

namespace Ucu.Poo.GameOfLife
{
    public class BoardReader
    {
        //Lee el url, donde iría "board.txt" y lo devuelve como una matriz de booleanos
        public bool[,] LoadFromFiles(string url)
        {
            //Convierte en archivo en un solo string
            string content = File.ReadAllText(url);
            //Divide el contenido por linea
            string[] contentLines = content.Split('\n');
            //Crea la matriz de booleanos
            bool[,] board = new bool[contentLines.Length, contentLines[0].Length];
            //Recorre las filas
            for (int y = 0; y < contentLines.Length; y++)
            {
                //Recorre las columnas
                for (int x = 0; x < contentLines[y].Length; x++)
                {
                    //Si hay un "1" lo convierte en una celula viva
                    if (contentLines[y][x] == '1')
                    {
                        board[x, y] = true;
                    }
                }
            }
            //Devuelve la matriz de booleanos
            return board;
        }
    }
}