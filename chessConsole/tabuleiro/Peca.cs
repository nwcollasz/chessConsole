using System.Reflection.PortableExecutable;

namespace chessConsole.tabuleiro
{
    public class Peca
    {
        public Posicao posicao {get; set;}
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca (Tabuleiro tab, Cor cor)
        {
            this.cor = cor;
            this.posicao = null;
            this.tab = tab;
            this.qteMovimentos = 0;
        }

    }
}