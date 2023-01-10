using tabuleiro;
using xadrez;
using XadrezConsoleApplication;

try
{
    Tabuleiro tab = new Tabuleiro(8, 8);

    tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
    tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 4));
    tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));

    tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(7, 0));
    tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(5, 4));
    tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(4, 2));

    Tela.imprimirTabuleiro(tab);
} catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}

