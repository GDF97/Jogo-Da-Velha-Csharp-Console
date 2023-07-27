using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] gameboard = { '1' , '2', '3', '4', '5', '6', '7', '8', '9' };
            bool circleTurn = false;
            bool endGame = false;

            Console.WriteLine("Bem Vindo ao Jogo da Velha!");
            Console.WriteLine("Jogador 1: X\nJogador 2: O");
            Console.WriteLine("Aperte qualquer tecla para começar...");
            Console.ReadKey();
            do
            {
                if (checkForDraw(gameboard) || checkForWinner(gameboard))
                {
                    endGame = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Vez do jogador {0}", switchPlayers(circleTurn) == 'X' ? 1 : 2);
                    gameDisplay(gameboard);
                    int casa = int.Parse(Console.ReadLine());

                    if (gameboard[casa - 1] == 'X' || gameboard[casa - 1] == 'O')
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        if(switchPlayers(circleTurn) == 'X')
                        {
                            gameboard[casa - 1 ] = 'X';
                            circleTurn = true;
                        }
                        else
                        {
                            gameboard[casa - 1] = 'O';
                            circleTurn = false;
                        }
                    }
                }

            } while (endGame == false);

            Console.Clear();
            Console.WriteLine("Fim de jogo\n");
            gameDisplay(gameboard);
            
            if (checkForWinner(gameboard))
            {
                Console.WriteLine("\nO jogador {0} ganhou", circleTurn == true ? 1 : 2);
            }

            if (checkForDraw(gameboard))
            {
                Console.WriteLine("\nDeu Velha!");
            }

            Console.ReadKey();
        }            

        static void gameDisplay(char[] gameboard)
        {
            Console.WriteLine("{0} | {1} | {2}\n" +
                "----------\n" +
                "{3} | {4} | {5}\n" +
                "----------\n" +
                "{6} | {7} | {8}", 
                gameboard[0], gameboard[1], gameboard[2], 
                gameboard[3], gameboard[4], gameboard[5], 
                gameboard[6], gameboard[7], gameboard[8]);
            
        }

        
        static char switchPlayers(bool circleTurn)
        {
            if(!circleTurn)
            {
                return 'X';
            }
            return 'O';
        }

        static bool checkForDraw(char[] gameboard)
        {
            bool end = true;

            for(int i = 0; i < 9; i++)
            {
                if (gameboard[i] != 'X' && gameboard[i] != 'O')
                {
                    end = false;
                    break;
                }
            }

            return end;
        }

        static bool checkForWinner(char[] gameboard)
        {
            if (gameboard[0] == gameboard[1] && gameboard[1] == gameboard[2])
            {
                return true;
            } else if (gameboard[3] == gameboard[4] && gameboard[4] == gameboard[5])
            {
                return true;
            } else if(gameboard[6] == gameboard[7] && gameboard[7] == gameboard[8])
            {
                return true;
            } else if (gameboard[0] == gameboard[3] && gameboard[3] == gameboard[6])
            {
                return true;
            } else if(gameboard[1] == gameboard[4] && gameboard[4] == gameboard[7])
            {
                return true;
            } else if(gameboard[2] == gameboard[5] && gameboard[5] == gameboard[8])
            {
                return true;
            } else if (gameboard[0] == gameboard[4] && gameboard[4] == gameboard[8])
            {
                return true;
            } else if(gameboard[2] == gameboard[4] && gameboard[4] == gameboard[6])
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
