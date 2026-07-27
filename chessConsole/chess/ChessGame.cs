using System;
using chessConsole.tabuleiro;

namespace chessConsole.chess
{
    internal class ChessGame
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
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

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não há peça nessa posição.");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("Apenas movimente uma peça que é sua.");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para essa peça.");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }
        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
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
