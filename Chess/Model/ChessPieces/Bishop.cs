//-----------------------------------------------------------------------
// <copyright file="Bishop.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the Bishop ChessPiece logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Model
{
    using System;
    using System.Collections.Generic;
    [Serializable]

    /// <summary>
    /// The Bishop class.
    /// </summary>
    public class Bishop : ChessPiece
    {
        /// <summary>
        /// Initializes a new instance of the Bishop class.
        /// </summary>
        /// <param name="player">Sets the Player enum of the King instance.</param>
        public Bishop(Player player) : base(player)
        {
        }

        /// <summary>
        /// Calculates the possible moves for this chess piece.
        /// </summary>
        /// <param name="moveCalculator">Takes an instance of a IMoveCalculator as input.</param>
        /// <param name="board">Takes a GameState instance as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a list of coordinates.</returns>
        public override List<Coordinates> CalculatePossibleMoves(IMoveCalculator moveCalculator, GameState board, Coordinates coordinates)
        {
            return moveCalculator.CalculateLegalMoves(this, board, coordinates);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>Returns a string that represents the Bishop object.</returns>
        public override string ToString()
        {
            return "L";
        }
    }
}