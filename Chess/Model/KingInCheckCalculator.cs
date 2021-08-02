//----------------------------------------------------------------------
// <copyright file="KingInCheckCalculator.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the KingInCheckCalculator logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Model
{
    /// <summary>
    /// The KingInCheckCalculator class.
    /// </summary>
    public class KingInCheckCalculator
    {
        /// <summary>
        /// Checks whether a King is in check.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        public bool IsKingInCheck(Player player, GameState gameState)
        {
            for (int i = 0; i < gameState.Row; i++)
            {
                for (int j = 0; j < gameState.Column; j++)
                {
                    if (gameState.ChessBoard[i, j].IsOccupied)
                    {
                        if (gameState.ChessBoard[i, j].Piece is King && gameState.ChessBoard[i, j].Piece.Player == player)
                        {
                            Coordinates coordinates = new Coordinates(i, j);
                            bool kingInCheck = this.CheckIsKingInCheck(player, gameState, coordinates);
                            return kingInCheck;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether King is in check.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckIsKingInCheck(Player player, GameState gameState, Coordinates coordinates)
        {
            bool kingInCheck = this.CheckHorizontalLeftTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckHorizontalRightTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckVerticalUpTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckVerticalDownTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckDiagonalTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckKnightTiles(player, gameState, coordinates);

            return kingInCheck;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the diagonal tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckDiagonalTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            bool kingInCheck = this.CheckDiagonalUpLeftTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckDiagonalUpRightTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckDiagonalDownRightTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckDiagonalDownLeftTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            return false;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the knight tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckKnightTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            bool kingInCheck = this.CheckLeftKnightTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckRightKnightTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckUpKnightTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckDownKnightTiles(player, gameState, coordinates);

            return kingInCheck;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the down knight tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckDownKnightTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            if (coordinates.X + 2 < gameState.Row)
            {
                if (coordinates.Y + 1 < gameState.Column)
                {
                    if (gameState.ChessBoard[coordinates.X + 2, coordinates.Y + 1].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X + 2, coordinates.Y + 1].Piece.Player != player && gameState.ChessBoard[coordinates.X + 2, coordinates.Y + 1].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            if (coordinates.X + 2 < gameState.Row)
            {
                if (coordinates.Y - 1 >= 0)
                {
                    if (gameState.ChessBoard[coordinates.X + 2, coordinates.Y - 1].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X + 2, coordinates.Y - 1].Piece.Player != player && gameState.ChessBoard[coordinates.X + 2, coordinates.Y - 1].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the up knight tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckUpKnightTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            if (coordinates.X - 2 >= 0)
            {
                if (coordinates.Y + 1 < gameState.Column)
                {
                    if (gameState.ChessBoard[coordinates.X - 2, coordinates.Y + 1].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X - 2, coordinates.Y + 1].Piece.Player != player && gameState.ChessBoard[coordinates.X - 2, coordinates.Y + 1].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            if (coordinates.X - 2 >= 0)
            {
                if (coordinates.Y - 1 >= 0)
                {
                    if (gameState.ChessBoard[coordinates.X - 2, coordinates.Y - 1].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X - 2, coordinates.Y - 1].Piece.Player != player && gameState.ChessBoard[coordinates.X - 2, coordinates.Y - 1].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the right knight tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckRightKnightTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            if (coordinates.X - 1 >= 0)
            {
                if (coordinates.Y + 2 < gameState.Column)
                {
                    if (gameState.ChessBoard[coordinates.X - 1, coordinates.Y + 2].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X - 1, coordinates.Y + 2].Piece.Player != player && gameState.ChessBoard[coordinates.X - 1, coordinates.Y + 2].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            if (coordinates.X - 1 >= 0)
            {
                if (coordinates.Y - 2 >= 0)
                {
                    if (gameState.ChessBoard[coordinates.X - 1, coordinates.Y - 2].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X - 1, coordinates.Y - 2].Piece.Player != player && gameState.ChessBoard[coordinates.X - 1, coordinates.Y - 2].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the left knight tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckLeftKnightTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            if (coordinates.X + 1 < gameState.Row)
            {
                if (coordinates.Y + 2 < gameState.Column)
                {
                    if (gameState.ChessBoard[coordinates.X + 1, coordinates.Y + 2].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X + 1, coordinates.Y + 2].Piece.Player != player && gameState.ChessBoard[coordinates.X + 1, coordinates.Y + 2].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            if (coordinates.X + 1 < gameState.Row)
            {
                if (coordinates.Y - 2 >= 0)
                {
                    if (gameState.ChessBoard[coordinates.X + 1, coordinates.Y - 2].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X + 1, coordinates.Y - 2].Piece.Player != player && gameState.ChessBoard[coordinates.X + 1, coordinates.Y - 2].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the diagonal down left tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckDiagonalDownLeftTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            if (coordinates.X < gameState.Row - 1 && coordinates.Y > 0)
            {
                for (int i = 1; i < gameState.Row; i++)
                {
                    if (coordinates.X + i == gameState.Row || coordinates.Y - i == -1)
                    {
                        return false;
                    }

                    if (gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece.Player)
                        {
                            if (player != gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece.Player)
                            {
                                if (player == Player.BLACK && (gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece is Pawn) && i == 1)
                                {
                                    return true;
                                }

                                if (gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece is King && i == 1)
                                {
                                    return true;
                                }

                                if (gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece is Queen || gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece is Bishop)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the diagonal down right tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckDiagonalDownRightTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            if (coordinates.X < gameState.Row - 1 && coordinates.Y < gameState.Column - 1)
            {
                for (int i = 1; i < gameState.Row; i++)
                {
                    if (coordinates.X + i == gameState.Row || coordinates.Y + i == gameState.Column)
                    {
                        return false;
                    }

                    if (gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece.Player)
                        {
                            if (player != gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece.Player)
                            {
                                if (player == Player.BLACK && (gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece is Pawn) && i == 1)
                                {
                                    return true;
                                }

                                if (gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece is King && i == 1)
                                {
                                    return true;
                                }

                                if (gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece is Queen || gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece is Bishop)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the vertical down tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckVerticalDownTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            if (coordinates.X < gameState.Row - 1)
            {
                for (int i = coordinates.X + 1; i < gameState.Row; i++)
                {
                    if (gameState.ChessBoard[i, coordinates.Y].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[i, coordinates.Y].Piece.Player)
                        {
                            if (gameState.ChessBoard[i, coordinates.Y].Piece is King && i == coordinates.X + 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[i, coordinates.Y].Piece is Queen || gameState.ChessBoard[i, coordinates.Y].Piece is Rook)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (i != coordinates.X)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the diagonal vertical up tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckVerticalUpTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            if (coordinates.X > 0)
            {
                for (int i = coordinates.X; i >= 0; i--)
                {
                    if (gameState.ChessBoard[i, coordinates.Y].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[i, coordinates.Y].Piece.Player)
                        {
                            if (gameState.ChessBoard[i, coordinates.Y].Piece is King && i == coordinates.X - 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[i, coordinates.Y].Piece is Queen || gameState.ChessBoard[i, coordinates.Y].Piece is Rook)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (i != coordinates.X)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the horizontal right tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckHorizontalRightTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            if (coordinates.Y < gameState.Column - 1)
            {
                for (int i = coordinates.Y; i < gameState.Column; i++)
                {
                    if (gameState.ChessBoard[coordinates.X, i].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[coordinates.X, i].Piece.Player)
                        {
                            if (gameState.ChessBoard[coordinates.X, i].Piece is King && i == coordinates.Y + 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[coordinates.X, i].Piece is Queen || gameState.ChessBoard[coordinates.X, i].Piece is Rook)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (coordinates.Y != i)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the horizontal left tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckHorizontalLeftTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            if (coordinates.Y > 0)
            {
                for (int i = coordinates.Y; i >= 0; i--)
                {
                    if (gameState.ChessBoard[coordinates.X, i].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[coordinates.X, i].Piece.Player)
                        {
                            if (gameState.ChessBoard[coordinates.X, i].Piece is King && i == coordinates.Y - 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[coordinates.X, i].Piece is Queen || gameState.ChessBoard[coordinates.X, i].Piece is Rook)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (coordinates.Y != i)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the diagonal right up tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckDiagonalUpRightTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            if (coordinates.X > 0)
            {
                for (int i = 1; i < gameState.Row; i++)
                {
                    if (coordinates.X - i == -1 || coordinates.Y + i == gameState.Column)
                    {
                        break;
                    }

                    if (gameState.ChessBoard[coordinates.X - i, coordinates.Y + i].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[coordinates.X - i, coordinates.Y + i].Piece.Player)
                        {
                            if (player == Player.WHITE && (gameState.ChessBoard[coordinates.X - i, coordinates.Y + i].Piece is Pawn) && i == 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[coordinates.X - i, coordinates.Y + i].Piece is King && i == 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[coordinates.X - i, coordinates.Y + i].Piece is Queen || gameState.ChessBoard[coordinates.X - i, coordinates.Y + i].Piece is Bishop)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether King is in check. Scans the diagonal left up tiles.
        /// </summary>
        /// <param name="player">Takes a player enum as input.</param>
        /// <param name="gameState">Takes a GameState object as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckDiagonalUpLeftTiles(Player player, GameState gameState, Coordinates coordinates)
        {
            if (coordinates.X > 0 && coordinates.Y > 0)
            {
                for (int i = 1; i < gameState.Row; i++)
                {
                    if (coordinates.X - i == -1 || coordinates.Y - i == -1)
                    {
                        return false;
                    }

                    if (gameState.ChessBoard[coordinates.X - i, coordinates.Y - i].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[coordinates.X - i, coordinates.Y - i].Piece.Player)
                        {
                            if (player == Player.WHITE && (gameState.ChessBoard[coordinates.X - i, coordinates.Y - i].Piece is Pawn) && i == 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[coordinates.X - i, coordinates.Y - i].Piece is King && i == 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[coordinates.X - i, coordinates.Y - i].Piece is Queen || gameState.ChessBoard[coordinates.X - i, coordinates.Y - i].Piece is Bishop)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }
    }
}
