using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            start: // start label

            Board[] gameBoard = new Board[2];      
            string[] playerNames = new string[2];

            GameManager gameManager = new GameManager();
            gameManager.Execute();
            gameBoard = gameManager.InitiateBoard();
            Board B1 = gameBoard[0]; // Player 1's board
            Board B2 = gameBoard[1]; // Player 2's board

            playerNames = gameManager.GetUserNames();
            B1._playerName = playerNames[0];
            B2._playerName = playerNames[1];

            gameManager.GetPlayerShipLocations(B1);
            gameManager.GetPlayerShipLocations(B2);

            gameManager.PlayBattleShip(B1, B2);     

            goto start; // start label is at the beginning of program.cs, player can play again or quit from the start menu
        }
    }
}
