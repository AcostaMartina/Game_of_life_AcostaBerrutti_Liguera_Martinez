/*
 Se encarga de mostrar e imprimir el tablero.
 Cumple con el SRP porque tiene una única responsabilidad que es la de impresión.
 Y cumple con Expert porque usa la información del Board para representarlo en pantalla.
 */

using System;
using System.Text;
using System.Threading;
namespace Ucu.Poo.GameOfLife;

public class GamePrinter //hace pública esta clase para usarla luego
{
    public void ShowBoard(Board board) //recibe el board y lo imprime
    {
        Console.Clear(); //en lugar de imprimirse un tablero debajo del otro, lo que hace es actualizar el tablero en el mismo lugar
        StringBuilder s = new StringBuilder(); //crea un objeto vacío
        for (int fila = 0; fila < board.Height; fila++) //recorre las filas
        {
            for (int columna = 0; columna < board.Width; columna++) //recorre las columnas
            {
                // si la célula está viva imprime "|X|" sino "___"
                if (board.Cells[columna, fila])
                { s.Append("|X|"); }
                else
                { s.Append ("___"); } 

            }
            s.Append("\n");
        }
        Console.WriteLine(s.ToString()); //imprime el tablero completo
        Thread.Sleep(300); //para que se pueda observar el cambio
    }
}