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
                    try
                    {
                        Console.Clear();
                        Tela.imprimirGame(game);

                        Console.WriteLine();

                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoChess().toPosicao();
                        game.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = game.tab.peca(origem).movimentosPossiveis();


                        Console.Clear();
                        Tela.imprimirTabuleiro(game.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoChess().toPosicao();
                        game.validarPosicaoDeDestino(origem, destino);

                        game.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();

                    }
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