using System;
using System.Collections.Generic;
using chessConsole.chess;
using chessConsole.tabuleiro;

namespace chessConsole
{
    internal class Tela
    {
        public static void imprimirGame(ChessGame game)
        {
            imprimirTabuleiro(game.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(game);
            Console.WriteLine();
            Console.WriteLine("turno: " + game.turno);

            if (!game.terminada)
            {
                Console.WriteLine("aguardando jogada: " + game.jogadorAtual);
                if (game.xeque)
                {
                    Console.WriteLine("check!");
                }
            }
            else
            {
                Console.WriteLine("checkmate!");
                Console.WriteLine("vencedor: " + game.jogadorAtual);
            }
        }

        public static void imprimirPecasCapturadas(ChessGame game)
        {
            Console.WriteLine("peças capturadas:");
            Console.WriteLine("brancas: ");
            imprimirConjunto(game.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.WriteLine("pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(game.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca peca in conjunto)
            {
                Console.Write(peca + " ");
            }
            Console.Write("]");
        }


        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor= fundoOriginal;
                    }
                    
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }


        public static PosicaoChess lerPosicaoChess()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoChess(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }

                Console.Write(" ");
            }
        }
    }
}
