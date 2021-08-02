//----------------------------------------------------------------------
// <copyright file="MoveCalculator.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the MoveCalculator logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The MoveCalculator class.
    /// </summary>
    [Serializable]
    public class MoveCalculator : IMoveCalculator
    {
        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="bishop">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <returns>Returns a List of Coordinates.</returns>
        public List<Coordinates> CalculateLegalMoves(Bishop bishop, GameState chessBoard, Coordinates coordinates)
        {
            List<Coordinates> result = new List<Coordinates>();

            this.CalculateDiagonalMoves(result, bishop, chessBoard, coordinates);

            return result;
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="king">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <returns>Returns a List of Coordinates.</returns>
        public List<Coordinates> CalculateLegalMoves(King king, GameState chessBoard, Coordinates coordinates)
        {
            List<Coordinates> result = new List<Coordinates>();

            this.CalculateKingUpMoves(king, chessBoard, coordinates, result);
            this.CalculateKingDownMoves(king, chessBoard, coordinates, result);
            this.CalculateKingSideMoves(king, chessBoard, coordinates, result);

            return result;
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="rook">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <returns>Returns a List of Coordinates.</returns>
        public List<Coordinates> CalculateLegalMoves(Rook rook, GameState chessBoard, Coordinates coordinates)
        {
            List<Coordinates> result = new List<Coordinates>();

            this.CalculateVerticalMoves(result, rook, chessBoard, coordinates);
            this.CalculateHorizontalMoves(result, rook, chessBoard, coordinates);

            return result;
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="queen">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <returns>Returns a List of Coordinates.</returns>
        public List<Coordinates> CalculateLegalMoves(Queen queen, GameState chessBoard, Coordinates coordinates)
        {
            List<Coordinates> result = new List<Coordinates>();

            this.CalculateVerticalMoves(result, queen, chessBoard, coordinates);
            this.CalculateHorizontalMoves(result, queen, chessBoard, coordinates);
            this.CalculateDiagonalMoves(result, queen, chessBoard, coordinates);

            return result;
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="knight">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <returns>Returns a List of Coordinates.</returns>
        public List<Coordinates> CalculateLegalMoves(Knight knight, GameState chessBoard, Coordinates coordinates)
        {
            List<Coordinates> result = new List<Coordinates>();

            this.CalculateDownKnightMoves(knight, chessBoard, coordinates, result);
            this.CalculateUpKnightMoves(knight, chessBoard, coordinates, result);
            this.CalculateRightKnightMoves(knight, chessBoard, coordinates, result);
            this.CalculateLeftKnightMoves(knight, chessBoard, coordinates, result);

            return result;
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="pawn">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <returns>Returns a List of Coordinates.</returns>
        public List<Coordinates> CalculateLegalMoves(Pawn pawn, GameState chessBoard, Coordinates coordinates)
        {
            List<Coordinates> result = new List<Coordinates>();
           
            if (pawn.Player == Player.WHITE)
            {
                if (coordinates.X > 0 && !chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y].IsOccupied)
                {
                    result.Add(new Coordinates(coordinates.X - 1, coordinates.Y));
                }

                this.CalculatePawnUpAttackMoves(pawn, chessBoard, coordinates, result);
            }
            else if (pawn.Player == Player.BLACK)
            {
                if (coordinates.X < chessBoard.Row - 1)
                {
                    if (!chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y].IsOccupied)
                    {
                        result.Add(new Coordinates(coordinates.X + 1, coordinates.Y));
                    }
                }

                this.CalculatePawnDownAttackMoves(pawn, chessBoard, coordinates, result);
            }

            return result;
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        /// <param name="chessPiece">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        private void CalculateDiagonalDownLeftMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Coordinates coordinates)
        {
            if (coordinates.X < chessBoard.Row - 1 && coordinates.Y > 0)
            {
                for (int i = 1; i < chessBoard.Row; i++)
                {
                    if (coordinates.X + i == chessBoard.Row || coordinates.Y - i == -1)
                    {
                        break;
                    }

                    if (!chessBoard.ChessBoard[coordinates.X + i, coordinates.Y - i].IsOccupied)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X + i, coordinates.Y - i));
                    }
                    else
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X + i, coordinates.Y - i));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        /// <param name="chessPiece">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        private void CalculateDiagonalMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Coordinates coordinates)
        {
            this.CalculateDiagonalDownLeftMoves(possibleMoves, chessPiece, chessBoard, coordinates);
            this.CalculateDiagonalDownRightMoves(possibleMoves, chessPiece, chessBoard, coordinates);
            this.CalculateDiagonalUpRightMoves(possibleMoves, chessPiece, chessBoard, coordinates);
            this.CalculateDiagonalUpLeftMoves(possibleMoves, chessPiece, chessBoard, coordinates);
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        /// <param name="chessPiece">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        private void CalculateDiagonalUpLeftMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Coordinates coordinates)
        {
            if (coordinates.X > 0 && coordinates.Y > 0)
            {
                for (int i = 1; i < chessBoard.Row; i++)
                {
                    if (coordinates.X - i == -1 || coordinates.Y - i == -1)
                    {
                        break;
                    }

                    if (!chessBoard.ChessBoard[coordinates.X - i, coordinates.Y - i].IsOccupied)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X - i, coordinates.Y - i));
                    }
                    else
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[coordinates.X - i, coordinates.Y - i].Piece.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X - i, coordinates.Y - i));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        /// <param name="chessPiece">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        private void CalculateDiagonalUpRightMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Coordinates coordinates)
        {
            if (coordinates.X > 0)
            {
                for (int i = 1; i < chessBoard.Row; i++)
                {
                    if (coordinates.X - i == -1 || coordinates.Y + i == chessBoard.Column)
                    {
                        break;
                    }

                    if (!chessBoard.ChessBoard[coordinates.X - i, coordinates.Y + i].IsOccupied)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X - i, coordinates.Y + i));
                    }
                    else
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[coordinates.X - i, coordinates.Y + i].Piece.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X - i, coordinates.Y + i));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        /// <param name="chessPiece">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        private void CalculateDiagonalDownRightMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Coordinates coordinates)
        {
            if (coordinates.X < chessBoard.Row - 1 && coordinates.Y < chessBoard.Column - 1)
            {
                for (int i = 1; i < chessBoard.Row; i++)
                {
                    if (coordinates.X + i == chessBoard.Row || coordinates.Y + i == chessBoard.Column)
                    {
                        break;
                    }

                    if (!chessBoard.ChessBoard[coordinates.X + i, coordinates.Y + i].IsOccupied)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X + i, coordinates.Y + i));
                    }
                    else
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X + i, coordinates.Y + i));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="pawn">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        private void CalculatePawnDownAttackMoves(Pawn pawn, GameState chessBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.X < chessBoard.Row - 1 && coordinates.Y < chessBoard.Column - 1)
            {
                if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y + 1].IsOccupied)
                {
                    if (pawn.Player != chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y + 1].Piece.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X + 1, coordinates.Y + 1));
                    }
                }
            }

            if (coordinates.X < chessBoard.Row - 1 && coordinates.Y > 0)
            {
                if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y - 1].IsOccupied)
                {
                    if (pawn.Player != chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y - 1].Piece.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X + 1, coordinates.Y - 1));
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="pawn">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        private void CalculatePawnUpAttackMoves(Pawn pawn, GameState chessBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.X > 0 && coordinates.Y < chessBoard.Column - 1)
            {
                if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y + 1].IsOccupied)
                {
                    if (pawn.Player != chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y + 1].Piece.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X - 1, coordinates.Y + 1));
                    }
                }
            }

            if (coordinates.X > 0 && coordinates.Y > 0)
            {
                if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y - 1].IsOccupied)
                {
                    if (pawn.Player != chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y - 1].Piece.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X - 1, coordinates.Y - 1));
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        /// <param name="chessPiece">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        private void CalculateVerticalDownMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Coordinates coordinates)
        {
            if (coordinates.X < chessBoard.Row - 1)
            {
                for (int i = coordinates.X + 1; i < chessBoard.Row; i++)
                {
                    if (chessBoard.ChessBoard[i, coordinates.Y].IsOccupied)
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[i, coordinates.Y].Piece.Player)
                        {
                            possibleMoves.Add(new Coordinates(i, coordinates.Y));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(i, coordinates.Y));
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        /// <param name="chessPiece">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        private void CalculateVerticalUpMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Coordinates coordinates)
        {
            if (coordinates.X > 0)
            {
                for (int i = coordinates.X; i >= 0; i--)
                {
                    if (chessBoard.ChessBoard[i, coordinates.Y].IsOccupied)
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[i, coordinates.Y].Piece.Player)
                        {
                            possibleMoves.Add(new Coordinates(i, coordinates.Y));
                            break;
                        }
                        else
                        {
                            if (i != coordinates.X)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(i, coordinates.Y));
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        /// <param name="chessPiece">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        private void CalculateHorizontalMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Coordinates coordinates)
        {
            this.CalculateHorizontalRightMoves(possibleMoves, chessPiece, chessBoard, coordinates);
            this.CalculateHorizontalLeftMoves(possibleMoves, chessPiece, chessBoard, coordinates);
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        /// <param name="chessPiece">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        private void CalculateHorizontalLeftMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Coordinates coordinates)
        {
            if (coordinates.Y > 0)
            {
                for (int i = coordinates.Y; i >= 0; i--)
                {
                    if (chessBoard.ChessBoard[coordinates.X, i].IsOccupied)
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[coordinates.X, i].Piece.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X, i));
                            break;
                        }
                        else
                        {
                            if (coordinates.Y != i)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X, i));
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        /// <param name="chessPiece">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        private void CalculateHorizontalRightMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Coordinates coordinates)
        {
           if (coordinates.Y < chessBoard.Column - 1)
            {
                for (int i = coordinates.Y; i < chessBoard.Column; i++)
                {
                    if (chessBoard.ChessBoard[coordinates.X, i].IsOccupied)
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[coordinates.X, i].Piece.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X, i));
                            break;
                        }
                        else
                        {
                            if (coordinates.Y != i)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X, i));
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        /// <param name="chessPiece">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        private void CalculateVerticalMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Coordinates coordinates)
        {
            this.CalculateVerticalDownMoves(possibleMoves, chessPiece, chessBoard, coordinates);
            this.CalculateVerticalUpMoves(possibleMoves, chessPiece, chessBoard, coordinates);
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="knight">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <param name="result">Takes a List of Coordinates as input.</param>
        private void CalculateLeftKnightMoves(Knight knight, GameState chessBoard, Coordinates coordinates, List<Coordinates> result)
        {
            if (coordinates.X + 1 < chessBoard.Row)
            {
                if (coordinates.Y + 2 < chessBoard.Column)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y + 2].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y + 2].Piece.Player != knight.Player)
                        {
                            result.Add(new Coordinates(coordinates.X + 1, coordinates.Y + 2));
                        }
                    }
                    else
                    {
                        result.Add(new Coordinates(coordinates.X + 1, coordinates.Y + 2));
                    }
                }
            }

            if (coordinates.X + 1 < chessBoard.Row)
            {
                if (coordinates.Y - 2 >= 0)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y - 2].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y - 2].Piece.Player != knight.Player)
                        {
                            result.Add(new Coordinates(coordinates.X + 1, coordinates.Y - 2));
                        }
                    }
                    else
                    {
                        result.Add(new Coordinates(coordinates.X + 1, coordinates.Y - 2));
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="knight">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        private void CalculateRightKnightMoves(Knight knight, GameState chessBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.X - 1 >= 0)
            {
                if (coordinates.Y + 2 < chessBoard.Column)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y + 2].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y + 2].Piece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X - 1, coordinates.Y + 2));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X - 1, coordinates.Y + 2));
                    }
                }
            }

            if (coordinates.X - 1 >= 0)
            {
                if (coordinates.Y - 2 >= 0)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y - 2].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y - 2].Piece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X - 1, coordinates.Y - 2));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X - 1, coordinates.Y - 2));
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="knight">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        private void CalculateUpKnightMoves(Knight knight, GameState chessBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.X - 2 >= 0)
            {
                if (coordinates.Y + 1 < chessBoard.Column)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 2, coordinates.Y + 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X - 2, coordinates.Y + 1].Piece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X - 2, coordinates.Y + 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X - 2, coordinates.Y + 1));
                    }
                }
            }

            if (coordinates.X - 2 >= 0)
            {
                if (coordinates.Y - 1 >= 0)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 2, coordinates.Y - 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X - 2, coordinates.Y - 1].Piece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X - 2, coordinates.Y - 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X - 2, coordinates.Y - 1));
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="knight">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        private void CalculateDownKnightMoves(Knight knight, GameState chessBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.X + 2 < chessBoard.Row)
            {
                if (coordinates.Y + 1 < chessBoard.Column)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 2, coordinates.Y + 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X + 2, coordinates.Y + 1].Piece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X + 2, coordinates.Y + 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X + 2, coordinates.Y + 1));
                    }
                }
            }

            if (coordinates.X + 2 < chessBoard.Row)
            {
                if (coordinates.Y - 1 >= 0)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 2, coordinates.Y - 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X + 2, coordinates.Y - 1].Piece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X + 2, coordinates.Y - 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X + 2, coordinates.Y - 1));
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="king">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        private void CalculateKingSideMoves(King king, GameState chessBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.Y - 1 >= 0)
            {
                if (chessBoard.ChessBoard[coordinates.X, coordinates.Y - 1].IsOccupied)
                {
                    if (chessBoard.ChessBoard[coordinates.X, coordinates.Y - 1].Piece.Player != king.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X, coordinates.Y - 1));
                    }
                }
                else
                {
                    possibleMoves.Add(new Coordinates(coordinates.X, coordinates.Y - 1));
                }
            }

            if (coordinates.Y < chessBoard.Column - 1)
            {
                if (chessBoard.ChessBoard[coordinates.X, coordinates.Y + 1].IsOccupied)
                {
                    if (chessBoard.ChessBoard[coordinates.X, coordinates.Y + 1].Piece.Player != king.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X, coordinates.Y + 1));
                    }
                }
                else
                {
                    possibleMoves.Add(new Coordinates(coordinates.X, coordinates.Y + 1));
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="king">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        private void CalculateKingDownMoves(King king, GameState chessBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.X < chessBoard.Row - 1)
            {
                if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y].IsOccupied)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y].Piece.Player != king.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X + 1, coordinates.Y));
                    }
                }
                else
                {
                    possibleMoves.Add(new Coordinates(coordinates.X + 1, coordinates.Y));
                }

                if (coordinates.Y - 1 >= 0)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y - 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y - 1].Piece.Player != king.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X + 1, coordinates.Y - 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X + 1, coordinates.Y - 1));
                    }
                }

                if (coordinates.Y + 1 < chessBoard.Column)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y + 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y + 1].Piece.Player != king.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X + 1, coordinates.Y + 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X + 1, coordinates.Y + 1));
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the possible moves the selected chess piece can do.
        /// </summary>
        /// <param name="king">Takes the selected chess piece as input.</param>
        /// <param name="chessBoard">Takes the current chess board as input.</param>
        /// <param name="coordinates">Takes the coordinates of the selected chess piece as input.</param>
        /// <param name="possibleMoves">Takes a List of Coordinates as input.</param>
        private void CalculateKingUpMoves(King king, GameState chessBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.X > 0)
            {
                if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y].IsOccupied)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y].Piece.Player != king.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X - 1, coordinates.Y));
                    }
                }
                else
                {
                    possibleMoves.Add(new Coordinates(coordinates.X - 1, coordinates.Y));
                }

                if (coordinates.Y - 1 >= 0)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y - 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y - 1].Piece.Player != king.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X - 1, coordinates.Y - 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X - 1, coordinates.Y - 1));
                    }
                }

                if (coordinates.Y + 1 < chessBoard.Column)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y + 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y + 1].Piece.Player != king.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.X - 1, coordinates.Y + 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.X - 1, coordinates.Y + 1));
                    }
                }
            }
        }
    }
}