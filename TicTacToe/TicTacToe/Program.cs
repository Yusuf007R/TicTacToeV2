using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace TicTacToe1._1
{
    class Program
    {
        //variables
        static string[] cas = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static string Turno, TurnoLetra, player1, player2, turn = "1", input;
        static bool playing = true, win = false, cpumode;
        static int Player1Wins, Player2Wins;

        //metodo

        static void Reset()
        {
            for (int i = 1; i < cas.Length; i++)
            {
                cas[i] = Convert.ToString(i);
            }
            playing = true;
            win = false;
            turn = "1";
            Console.Clear();
            Tablero();
        }




        static void checkInput()
        {
            input = Console.ReadLine();

            if (playing == true && win == false)
            {
                if (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "7" && input != "8" && input != "9" && input != "quit" && input != "Quit")
                {
                    Console.WriteLine("Entrada incorrecta, Inserta un numero del 1 al 9 que no haya sido ya escogido o inserta \"quit\" para salir.");
                }
                else
                {
                    if (input == "quit" || input == "Quit")
                    {
                        Console.Clear();
                        asciitext(true);
                        Thread.Sleep(1200);
                        Console.WriteLine("Partida Terminada.");
                        Console.Write("Cerrando En ");
                        Thread.Sleep(1200);
                        Console.Write("3 ");
                        Thread.Sleep(1200);
                        Console.Write("2 ");
                        Thread.Sleep(1200);
                        Console.Write("1 ");
                        cerrar();
                    }

                    int inputnum = Convert.ToInt32(input);
                    if (cas[inputnum] == input)
                    {
                        if (turn == "1")
                        {
                            cas[inputnum] = "x";
                            turn = "2"; ;
                            Console.Clear();
                            Tablero();
                        }
                        else
                        {
                            cas[inputnum] = "o";
                            turn = "1";
                            Console.Clear();
                            Tablero();

                        }

                    }
                    else
                    {
                        Console.WriteLine("Esta Casilla ya esta tomada.");
                    }


                }
            }


        }





        static void empate()
        {

            if (cas[1] != "1" && cas[2] != "2" && cas[3] != "3" && cas[4] != "4" && cas[5] != "5" && cas[6] != "6" && cas[7] != "7" && cas[8] != "8" && cas[9] != "9")
            {
                asciitext(false);
                Console.WriteLine("Nadie Gano, ¡EMPATE!");
                Console.WriteLine("Gracias Por Jugar:3");
                Console.WriteLine("Pulsa Enter Para Reiniciar.");
                Console.ReadLine();
                Reset();
            }
        }

        static bool CheckWin()
        {
            if (cas[1] == cas[2] && cas[2] == cas[3])
            {
                return true;
            }
            else if (cas[4] == cas[5] && cas[5] == cas[6])
            {
                return true;
            }
            else if (cas[7] == cas[8] && cas[8] == cas[9])
            {
                return true;
            }
            else if (cas[1] == cas[4] && cas[4] == cas[7])
            {
                return true;
            }
            else if (cas[2] == cas[5] && cas[5] == cas[8])
            {
                return true;
            }
            else if (cas[3] == cas[6] && cas[6] == cas[9])
            {
                return true;
            }
            else if (cas[7] == cas[5] && cas[5] == cas[7])
            {
                return true;
            }
            else if (cas[1] == cas[5] && cas[5] == cas[9])
            {
                return true;
            }

            return false;

        }

        static void Winner()
        {
            if (playing == true && win == true)
            {
                Console.Clear();
                Tablero();
                if (turn == "1")
                {
                    asciitext(false);
                    Console.WriteLine("{0} a Ganado el Juego.", player2);
                    Console.WriteLine("Gracias Por Jugar:3");
                    Player2Wins = Player2Wins + 1;
                }
                else
                {
                    asciitext(false);
                    Console.WriteLine("{0} a Ganado el Juego.", player1);
                    Console.WriteLine("Gracias Por Jugar:3");
                    Player1Wins = Player1Wins + 1;
                }
                Console.WriteLine("Pulsa Enter Para Reiniciar.");
                Console.ReadLine();
                Reset();
            }
        }


        public static void cpucheck()
        {


            do
            {


                string inputxd = Console.ReadLine();
                if (inputxd == "1")
                {
                    cpumode = true;
                    break;

                }

                if (inputxd == "2")
                {
                    cpumode = false;
                    break;

                }
                else
                {
                    Console.WriteLine("\"" + inputxd + "\"" + " " + "no es una opcion correcta");
                }
            } while (true);
        }


        public static void cerrar()
        {
            Environment.Exit(0);
        }

        /*  static void playmusica()
           {
               WindowsMediaPlayer musica = new WindowsMediaPlayer();
               System.IO.File.WriteAllBytes(@"C:\Users\Public\xd.mp3", TicTacToeSimple.Properties.Resources.xd);
               musica.URL = "C:\\Users\\Public\\xd.mp3";
               musica.settings.autoStart = true;
               musica.settings.setMode("loop", true);
               musica.controls.play();
               musica.settings.volume = 1;
               Thread.Sleep(500);
               musica.settings.volume = 5;
               Thread.Sleep(500);
               musica.settings.volume = 10;
           }
       */
        public static void asciitext(bool text1)
        {
            if (text1 == true)
            {
                Console.WriteLine(@"
 _______ _        _______           _______         
|__   __(_)      |__   __|         |__   __|        
   | |   _  ___     | | __ _  ___     | | ___   ___ 
   | |  | |/ __|    | |/ _` |/ __|    | |/ _ \ / _ \
   | |  | | (__     | | (_| | (__     | | (_) |  __/
   |_|  |_|\___|    |_|\__,_|\___|    |_|\___/ \___|
");
            }
            else
            {
                Console.WriteLine(@"
(_) ____                          _                        _ 
| ||  _ \                        | |                      | |
| || |_) |_   _  ___ _ __        | |_   _  ___  __ _  ___ | |
| ||  _ <| | | |/ _ \ '_ \   _   | | | | |/ _ \/ _` |/ _ \| |
| || |_) | |_| |  __/ | | | | |__| | |_| |  __/ (_| | (_) |_|
|_||____/ \__,_|\___|_| |_|  \____/ \__,_|\___|\__, |\___/(_)
                                                __/ |        
                                               |___/     
");
            }
        }

        static void inicio()
        {

            do
            {

                string input = Console.ReadLine();
                if (input == "1")
                {
                    cpumode = true;
                    break;

                }

                if (input == "2")
                {
                    cpumode = false;
                    break;

                }
                else
                {
                    Console.WriteLine("\"" + input + "\"" + " " + "no es una opcion correcta");
                }
            } while (true);

            if (cpumode == true)
            {

                Console.WriteLine("¿Cual es el nombre del Jugador Uno?");
                player1 = Console.ReadLine();

            }
            else
            {
                Console.WriteLine("¿Cual es el nombre del Jugador Uno?");
                player1 = Console.ReadLine();
                Console.WriteLine("Muy Bien, ¿Cual es el nombre del Jugador Dos?");
                player2 = Console.ReadLine();
                Console.WriteLine("Bien, {0} sera \"x\" {1} sera \"o\"", player1, player2);
                Console.WriteLine("{0} Empieza, para escojer la casilla donde pondras tu \"x\" escoge el numero que corresponde a esa casilla.", player1);
                Console.WriteLine("Recuerda que para cerrar el juego debes poner \"quit\"");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Preciona una tecla para continuar.");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Tablero();
            }



        }

        public static void Tablero()
        {


            asciitext(true);

            if (turn == "1")
            {
                Turno = player1;
                TurnoLetra = "x";
            }
            else
            {
                Turno = player2;
                TurnoLetra = "o";
            }
            Console.WriteLine("Turno de {0}, su letra es {1}", Turno, TurnoLetra);
            Console.WriteLine("╔══════════════════════════════════════════════════════╗ ");
            Console.WriteLine("║                                                      ║  ");
            Console.WriteLine("║                                                      ║  ");
            Console.WriteLine("║                                                      ║  ");
            Console.WriteLine("║                      {0}║  {1}  ║{2}                       ║ ", cas[1], cas[2], cas[3]);
            Console.WriteLine("║                     ══╬═════╬══                      ║ ");
            Console.WriteLine("║                      {0}║  {1}  ║{2}                       ║ ", cas[4], cas[5], cas[6]);
            Console.WriteLine("║                     ══╬═════╬══                      ║ ");
            Console.WriteLine("║                      {0}║  {1}  ║{2}                       ║ ", cas[7], cas[8], cas[9]);
            Console.WriteLine("║                                                      ║  ");
            Console.WriteLine("║                                                      ║  ");
            Console.WriteLine("║                                                      ║  ");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝ ");
            Console.WriteLine("Partidas Ganadas de {0}:{1}, Partidas Ganadas de {2}:{3} ", player1, Player1Wins, player2, Player2Wins);

        }

        static void Main(string[] args)
        {
            Console.Title = "Tic-Tac-Toe";
            //playmusica();
            asciitext(true);
            Console.WriteLine("Bienvenido a Tic-Tac-Toe.");
            Console.WriteLine("Escribe \"1\" para jugar contra la maquina o \"2\" para dos jugadores");
            inicio();
            do
            {
                checkInput();
                CheckWin();
                win = CheckWin();
                empate();
                Winner();
            } while (true);


        }
    }
}

