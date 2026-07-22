using chessConsole.tabuleiro;
using chessConsole.chess;
using System;

namespace chessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PosicaoChess pos = new PosicaoChess('c', 7);
            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosicao());

        }
    }
}