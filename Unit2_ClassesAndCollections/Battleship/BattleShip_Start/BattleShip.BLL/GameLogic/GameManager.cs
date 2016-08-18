using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.BLL.GameLogic
{
    public class GameManager
    {
        public Board[] InitiateBoard()
        {
            Board b1 = new Board();
            Board b2 = new Board();
            Board[] gameboard = { b1, b2 };
            return gameboard;
        }

        public string[] GetUserNames()
        {
            string[] players = { "p1", "p2" };
            Console.Write("\n   Player 1 name : ");
            players[0] = Console.ReadLine();
            Console.Write("\n   Player 2 name : ");
            players[1] = Console.ReadLine();
            Console.Clear();
            return players;
        }

        public Coordinate GetUserShot()
        {
            string usershot = "";
            bool resX = false;
            int shotX, shotY;

            do
            {
                Console.WriteLine("  Enter Y Coordinate of shot (A-J) and X Coordinate of shot (1-10), then press enter : ");
                usershot = Console.ReadLine();
                shotY = Converter.ConvertY(usershot.Substring(0, 1));
                resX = int.TryParse(usershot.Substring(1), out shotX);
            } while (shotY == 11 || resX == false);

            Coordinate Coordinate = new Coordinate(shotX, shotY);
            return Coordinate;
        }

        public string anyKey = "press any key to continue";
        public void ValidateFireShot(FireShotResponse response)
        {
            if (response.ShotStatus == ShotStatus.Invalid)
            {
                Console.WriteLine("\n Invalid coordinate, try again -- {0}", anyKey);
                Console.ReadKey();
            }
            if (response.ShotStatus == ShotStatus.Duplicate)
            {
                Console.WriteLine("\n Duplicate shot, try again -- {0}", anyKey);
                Console.ReadKey();
            }
            if (response.ShotStatus == ShotStatus.Hit)
            {
                Console.WriteLine("\n You hit something! -- {0}", anyKey);
                Console.ReadKey();
            }
            if (response.ShotStatus == ShotStatus.HitAndSunk)
            {
                Console.WriteLine("\n You sank your opponents {0}! --  {1}", response.ShipImpacted, anyKey);
                Console.ReadKey();
            }
            if (response.ShotStatus == ShotStatus.Miss)
            {
                Console.WriteLine("\n Your projectile splashes into the ocean, you missed -- {0}", anyKey);
                Console.ReadKey();
            }
        }

        public void PlayBattleShip(Board B1, Board B2)
        {
            FireShotResponse B1response = new FireShotResponse(); // FSR objects to contain 
            FireShotResponse B2response = new FireShotResponse(); // fireshot responses for both players

            while (B1response.ShotStatus != ShotStatus.Victory
                   && B2response.ShotStatus != ShotStatus.Victory) // Until someone wins, do the following loop
            {
                Console.WriteLine("\n\n  Player 2: {0}'s board, Player 1: {1}'s turn \n\n\n", B2._playerName, B1._playerName);
                ShowPlayerBoard(B2);
                Console.WriteLine("\n\n");

                do
                {
                    Coordinate shotCoordinate2 = GetUserShot(); // get user input annd create a coordinate obj
                    B2response = B2.FireShot(shotCoordinate2); // fire a shot and store a response
                    ValidateFireShot(B2response); // get shot response message
                } while (B2response.ShotStatus == ShotStatus.Duplicate || B2response.ShotStatus == ShotStatus.Invalid);

                Console.Clear();
                Console.WriteLine("\n  Shot Result, Press Any Key To Continue \n\n\n");
                ShowPlayerBoard(B2);

                if (B2response.ShotStatus == ShotStatus.Victory) // did player 1 win?
                    break;

                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("\n\n  Player 1: {0}'s board, Player 2: {1}'s turn \n\n\n", B1._playerName, B2._playerName);
                ShowPlayerBoard(B1);
                Console.WriteLine("\n\n");

                do
                {
                    Coordinate shotCoordinate1 = GetUserShot(); // get user input annd create a coordinate obj
                    B1response = B1.FireShot(shotCoordinate1); // fire a shot and store the response
                    ValidateFireShot(B1response); // get shot response message
                } while (B1response.ShotStatus == ShotStatus.Duplicate || B1response.ShotStatus == ShotStatus.Invalid);

                Console.Clear();
                Console.WriteLine("\n  Shot Result, Press Any Key To Continue \n\n\n");
                ShowPlayerBoard(B1);

                if (B1response.ShotStatus == ShotStatus.Victory) // did player 2 win?
                    break;

                Console.ReadKey();
                Console.Clear();
            }
            if (B1response.ShotStatus == ShotStatus.Victory)
                Console.WriteLine("\n\n\n    {0},  You have sunk all your opponent's ships, you win! -- {1}", B2._playerName, anyKey);

            if (B2response.ShotStatus == ShotStatus.Victory)
                Console.WriteLine("\n\n\n    {0},  You have sunk all your opponent's ships, you win! -- {1}", B1._playerName, anyKey);

            Console.ReadKey();
        }

        public void ShowPlayerShipPlacement(Ship ship)
        {
            Coordinate coordinate = new Coordinate(0, 0);
            int[] Xnumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] Yletters = new string[] { "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            for (int k = 0; k < 10; k++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                if (k == 0)
                {
                    Console.Write("     " + " {0} " + "  ", Xnumbers[k]);
                }

                if (k > 0)
                {
                    Console.Write("   " + "{0}" + "   ", Xnumbers[k]);
                }

                if (k == 9)
                {
                    Console.ResetColor();
                    Console.WriteLine("\n");
                }
            }

            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    coordinate.XCoordinate = j;
                    coordinate.YCoordinate = i;
                    if (j == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" " + "{0}" + " ", Yletters[i]);
                        Console.ResetColor();
                    }

                    if (ship.BoardPositions.Contains(coordinate) == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("   " + 'X' + "   ");
                        Console.ResetColor();

                        if (j == 10)
                            Console.WriteLine("\n\n");
                    }

                    if (ship.BoardPositions.Contains(coordinate) == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("  " + "***" + "  ");
                        Console.ResetColor();

                        if (j == 10)
                            Console.WriteLine("\n\n");
                    }
                }

            }
        }

        public void ShowPlayerBoard(Board board)
        {
            Coordinate coordinate = new Coordinate(0, 0);
            int[] Xnumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] Yletters = new string[] { "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            for (int k = 0; k < 10; k++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                if (k == 0)
                {
                    Console.Write("     " + " {0} " + "  ", Xnumbers[k]);
                }

                if (k > 0)
                {
                    Console.Write("   " + "{0}" + "   ", Xnumbers[k]);
                }

                if (k == 9)
                {
                    Console.ResetColor();
                    Console.WriteLine("\n");
                }
            }

            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    coordinate.XCoordinate = j;
                    coordinate.YCoordinate = i;
                    if (j == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" " + "{0}" + " ", Yletters[i]);
                        Console.ResetColor();
                    }

                    if (board.ShotHistory.ContainsKey(coordinate) == true)
                    {
                        if (board.ShotHistory[coordinate] == ShotHistory.Hit)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("   " + 'H' + "   ");
                            Console.ResetColor();

                            if (j == 10)
                                Console.WriteLine("\n\n");
                        }

                        if (board.ShotHistory[coordinate] == ShotHistory.Miss)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("   " + 'M' + "   ");
                            Console.ResetColor();

                            if (j == 10)
                                Console.WriteLine("\n\n");
                        }

                        if (board.ShotHistory[coordinate] == ShotHistory.Unknown)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("  " + "???" + "  ");
                            Console.ResetColor();

                            if (j == 10)
                                Console.WriteLine("\n\n");
                        }
                    }
                    if (board.ShotHistory.ContainsKey(coordinate) == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("  " + "???" + "  ");
                        Console.ResetColor();

                        if (j == 10)
                            Console.WriteLine("\n\n");
                    }
                }
            }
        }

        private ShipDirection NumberToDirection(int direction)
        {
            switch (direction)
            {
                case 0:
                    return ShipDirection.Up;
                case 1:
                    return ShipDirection.Down;
                case 2:
                    return ShipDirection.Left;
                case 3:
                    return ShipDirection.Right;
                default:
                    return ShipDirection.Invalid;
            }
        }

        public void GetPlayerShipLocations(Board board)
        {
            ShipPlacement response = new ShipPlacement();
            int shipCounter = 0;
            int direction = 0;
            bool resD = false;
            bool resX = false;
            int shipX, shipY;
            string userdirection;

            foreach (var value in Enum.GetValues(typeof(ShipType))) {
                Console.Clear();
                PlaceShipRequest playership = new PlaceShipRequest();
                playership.ShipType = (ShipType)value;

                do
                {
                do
                {
                    Console.WriteLine(" \n  {1}, Enter your {0} Y-Coordinate (A-J) and X-Coordinate (1-10) : ", playership.ShipType.ToString(), board._playerName);
                    userdirection = (Console.ReadLine( ));
                    shipY = Converter.ConvertY(userdirection.Substring(0, 1));
                    resX = int.TryParse(userdirection.Substring(1), out shipX);
                } while (shipY == 11 || resX == false);

                Coordinate shipCoordinate = new Coordinate(shipX, shipY);
                playership.Coordinate = shipCoordinate;
                ShipDirectionMenu();
              
                do
                {
                do
                    {
                        resD = int.TryParse(Console.ReadLine( ), out direction);
                        if (resD == false)
                        {
                            Console.WriteLine(" Please enter a number that corresponds to the menu, try again ");                           
                        }
                    } while (resD == false);
   
                    playership.Direction = NumberToDirection(direction);

                    if (playership.Direction == ShipDirection.Invalid)
                    {
                        Console.WriteLine(" That is not a valid ship direction, try again ");     
                    }
                } while (playership.Direction == ShipDirection.Invalid);

                response = board.PlaceShip(playership);

                if (response == ShipPlacement.NotEnoughSpace)
                {
                    Console.WriteLine("\n Not Enough Space, try again");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (response == ShipPlacement.Overlap)
                {
                    Console.WriteLine("\n Overlaps another ship, try again");
                    Console.ReadKey();
                    Console.Clear();
                }
                    
                } while (response != ShipPlacement.Ok);

                Console.WriteLine("\n\n\n");
                ShowPlayerShipPlacement(board._ships[shipCounter]);
                shipCounter++;
                Console.WriteLine("  " + anyKey);
                Console.ReadKey();
            }
    } 
        
        public void Execute()
        {
            string userInput;

            do
            {
                DisplayMenu();

                userInput = Console.ReadLine();

                ProcessUserChoice(userInput);
            } while (userInput != "Q" && userInput !="q" && userInput != "1");
        }

        private void ProcessUserChoice(string userInput)
        {
            switch (userInput)
            {
                case "1":        
                    Console.Clear();
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
      
        public void ShipDirectionMenu()
        {           
            Console.WriteLine("\n\n   0 = up");
            Console.WriteLine("   1 = down");
            Console.WriteLine("   2 = left");
            Console.WriteLine("   3 = right");
            Console.Write("   Enter your choice: ");
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n");
            
Console.WriteLine("     | |         | | | | | |         | |        ");
Console.WriteLine("     | |__   __ _| |_| |_| | ___  ___| |__  _ _ __  ");
Console.WriteLine("     | |_ | / _| | __| __| |/ _ || __| |_ || | |_ | ");
Console.WriteLine("     | |_) | (_| | |_| |_| |  __/|__ | | | | | |_) |");
Console.WriteLine("     |_|__/ |__|_||__||__|_||___||___/_| |_|_| |__/ ");
Console.WriteLine("                                             | |    ");
Console.WriteLine("                                             |_|    ");

            Console.WriteLine("\n      1. Play Battleship\n");
            Console.WriteLine("      2. Q to quit");
            Console.WriteLine("\n");
            Console.Write("      Enter your choice: ");
            Console.ResetColor();
        }
              
    }
}
