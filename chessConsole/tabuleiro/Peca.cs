using System.Reflection.PortableExecutable;

namespace chessConsole.tabuleiro
{
    public class Peca
    {
        public Posicao posicao {get; set;}
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca (Posicao posicao, Cor cor, Tabuleiro tabuleiro)
        {
            this.cor = cor;
            this.posicao = posicao;
            this.tab = tabuleiro;
            this.qteMovimentos = 0;
        }

    }
}