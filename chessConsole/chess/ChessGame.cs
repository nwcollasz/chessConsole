using System;
using chessConsole.tabuleiro;

namespace chessConsole.chess
{
    internal class ChessGame
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }

        public ChessGame()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        private void colocarPecas()
        { 
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoChess('c', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoChess('d', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoChess('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoChess('d', 8).toPosicao());

        }
    }
}
