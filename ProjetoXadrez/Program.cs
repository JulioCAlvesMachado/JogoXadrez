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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);

                        Console.WriteLine();
                        Console.WriteLine("=========================================");
                        Console.WriteLine();
                        Console.Write("Digite a posição de origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] PosicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();


                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, PosicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Digite a posição de destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);

                        Console.WriteLine("=========================================");
                        partida.RealizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message); Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine();
                        Console.WriteLine("PRESS SPACE PARA VOLTAR A JOGADA..."); Console.ResetColor();
                        Console.ReadLine();
                    }
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
