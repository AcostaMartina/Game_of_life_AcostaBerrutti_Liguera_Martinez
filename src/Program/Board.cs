/*
 Esta clase lo que hace es representar directamente el tablero, contando el largo y ancho del tablero y si las células 
 están vivas o muertas, guardando estos valores únicamente para usarlos después en otras partes del programa.
 Cumple con el SRP porque tiene una única responsabilidad que es modelar el tablero. 
 Y el Expert porque es la clase que tiene todos los datos importantes o necesarios para el resto de clases. 
*/
using System.Diagnostics;

namespace Ucu.Poo.GameOfLife;

public class Board //hace pública esta clase para que pueda ser utilizada luego, fuera de este código
{
    private bool[,] _Cells;
    public bool [,] Cells // representa al tablero con dos valores, true (célula viva) y false (célula muerta)
    {
        get { return _Cells; }
        set { _Cells = value; }
    }

    private int _Width;
    public int Width //guarda el ancho del tablero
    {
        get { return _Width;}
        set { _Width = value; }
    }

    private int _Height;

    public int Height //guarda el largo del tablero
    {
        get { return _Height;}
        set { _Height = value; }
    }

    public Board(bool[,] cells) //construye o inicializa el tablero con los datos que le llegan (las cells (bool) que le llega), calculando sus dimensiones
    {
        Cells = cells;
        Width = cells.GetLength(0);
        Height = cells.GetLength(1);
    }
}