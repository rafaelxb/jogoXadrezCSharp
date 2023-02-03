
using tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace XadrezConsoleApplication
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);

            imprimirPecasCapturadas(partida);

            mostraTurnoAtual(partida);
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine();
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Pretas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor= aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca peca in conjunto)
            {
                Console.Write(peca + " ");
            }
            Console.Write("]");
        }

        public static void mostraTurnoAtual(PartidaDeXadrez partida)
        {
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
        }
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int linha = 0; linha < tab.linhas; linha++)
            {
                Console.Write(8 - linha + " ");
                for (int coluna = 0; coluna < tab.colunas; coluna++)
                {
                    imprimirPeca(tab.peca(linha,coluna));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int linha = 0; linha < tab.linhas; linha++)
            {
                Console.Write(8 - linha + " ");
                for (int coluna = 0; coluna < tab.colunas; coluna++)
                {
                    if (posicoesPossiveis[linha, coluna])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(linha, coluna));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;

        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna,linha);
        } 

        public static void imprimirPeca(Peca peca)
        {
            if(peca == null)
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
