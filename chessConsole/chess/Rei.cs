using System;
using chessConsole.tabuleiro;

namespace chessConsole.chess
{
    internal class Rei : Peca
    {
        private ChessGame game;

        public Rei(Tabuleiro tab, Cor cor, ChessGame game) : base(tab, cor)
        {
            this.game = game;
        }
        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        private bool testeTorreRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);
            
            pos.definirValores(posicao.linha - 1, posicao.coluna); //acima
            if (tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha - 1, posicao.coluna + 1); //nordeste
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha, posicao.coluna + 1); //direita

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna + 1); //sudeste
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna); //abaixo
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna - 1); //sudoeste
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha, posicao.coluna - 1); //esquerda
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha - 1, posicao.coluna - 1); //noroeste
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //roque
            if (qteMovimentos == 0 && !game.xeque)
            {
                //roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if (tab.peca(p1) == null && tab.peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                //roque grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return mat;

        }
    }
}
