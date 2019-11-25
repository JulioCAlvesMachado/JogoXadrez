using System;
using tabuleiro;
using xadrez;

namespace ProjetoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.WriteLine();
                    Console.WriteLine("=========================================");
                    Console.WriteLine();
                    Console.Write("Digite a posição de origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    bool[,] PosicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();


                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab, PosicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Digite a posição de destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    Console.WriteLine("=========================================");
                    partida.ExecutaMovimento(origem, destino);
                }

                

                
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
