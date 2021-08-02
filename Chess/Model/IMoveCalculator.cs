//----------------------------------------------------------------------
// <copyright file="IMoveCalculator.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the IMoveCalculator logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// The IMoveCalculator interface.
    /// </summary>
    public interface IMoveCalculator
    {
        /// <summary>
        /// A List of Coordinates containing possible moves for a selected chess piece.
        /// </summary>
        /// <param name="bishop">Takes a Bishop instance as input.</param>
        /// <param name="chessBoard">Takes a GameState instance as input.</param>
        /// <param name="coordinates">Takes a Coordinates instance as input.</param>
        /// <returns>Returns a List of Coordinates.</returns>
        List<Coordinates> CalculateLegalMoves(Bishop bishop, GameState chessBoard, Coordinates coordinates);

        /// <summary>
        /// A List of Coordinates containing possible moves for a selected chess piece.
        /// </summary>
        /// <param name="pawn">Takes a Pawn instance as input.</param>
        /// <param name="chessBoard">Takes a GameState instance as input.</param>
        /// <param name="coordinates">Takes a Coordinates instance as input.</param>
        /// <returns>Returns a List of Coordinates.</returns>
        List<Coordinates> CalculateLegalMoves(Pawn pawn, GameState chessBoard, Coordinates coordinates);

        /// <summary>
        /// A List of Coordinates containing possible moves for a selected chess piece.
        /// </summary>
        /// <param name="rook">Takes a Rook instance as input.</param>
        /// <param name="chessBoard">Takes a GameState instance as input.</param>
        /// <param name="coordinates">Takes a Coordinates instance as input.</param>
        /// <returns>Returns a List of Coordinates.</returns>
        List<Coordinates> CalculateLegalMoves(Rook rook, GameState chessBoard, Coordinates coordinates);

        /// <summary>
        /// A List of Coordinates containing possible moves for a selected chess piece.
        /// </summary>
        /// <param name="queen">Takes a Queen instance as input.</param>
        /// <param name="chessBoard">Takes a GameState instance as input.</param>
        /// <param name="coordinates">Takes a Coordinates instance as input.</param>
        /// <returns>Returns a List of Coordinates.</returns>
        List<Coordinates> CalculateLegalMoves(Queen queen, GameState chessBoard, Coordinates coordinates);

        /// <summary>
        /// A List of Coordinates containing possible moves for a selected chess piece.
        /// </summary>
        /// <param name="knight">Takes a Knight instance as input.</param>
        /// <param name="chessBoard">Takes a GameState instance as input.</param>
        /// <param name="coordinates">Takes a Coordinates instance as input.</param>
        /// <returns>Returns a List of Coordinates.</returns>
        List<Coordinates> CalculateLegalMoves(Knight knight, GameState chessBoard, Coordinates coordinates);

        /// <summary>
        /// A List of Coordinates containing possible moves for a selected chess piece.
        /// </summary>
        /// <param name="king">Takes a King instance as input.</param>
        /// <param name="chessBoard">Takes a GameState instance as input.</param>
        /// <param name="coordinates">Takes a Coordinates instance as input.</param>
        /// <returns>Returns a List of Coordinates.</returns>
        List<Coordinates> CalculateLegalMoves(King king, GameState chessBoard, Coordinates coordinates);
    }
}