using chessConsole.tabuleiro;
using chessConsole.chess;
using System;

namespace chessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               ChessGame game = new ChessGame();
                while (!game.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(game.tab);

                    Console.WriteLine();

                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoChess().toPosicao();

                    bool[,] posicoesPossiveis = game.tab.peca(origem).movimentosPossiveis();


                    Console.Clear();
                    Tela.imprimirTabuleiro(game.tab, posicoesPossiveis);

                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoChess().toPosicao();

                    game.executaMovimento(origem, destino);
                }
                Tela.imprimirTabuleiro(game.tab);
            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}