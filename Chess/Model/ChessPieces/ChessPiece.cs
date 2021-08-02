//-----------------------------------------------------------------------
// <copyright file="ChessPiece.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the ChessPiece logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Model
{
    using System;
    using System.Collections.Generic;
    [Serializable]

    /// <summary>
    /// The ChessPiece class.
    /// </summary>
    public abstract class ChessPiece
    {
        /// <summary>
        /// The Player enum.
        /// </summary>
        private Player player;

        /// <summary>
        /// Initializes a new instance of the ChessPiece class.
        /// </summary>
        /// <param name="player">Sets the Player enum of the ChessPiece instance.</param>
        public ChessPiece(Player player)
        {
            this.player = player;
        }

        /// <summary>
        /// Gets the value of player.
        /// </summary>
        /// <value>The value of player.</value>
        public Player Player
        {
            get
            {
                return this.player;
            }
        }

        /// <summary>
        /// Calculates the possible moves for this chess piece.
        /// </summary>
        /// <param name="moveCalculator">Takes an instance of a IMoveCalculator as input.</param>
        /// <param name="board">Takes a GameState instance as input.</param>
        /// <param name="coordinates">Takes a Coordinates object as input.</param>
        /// <returns>Returns a List of Coordinates.</returns>
        public abstract List<Coordinates> CalculatePossibleMoves(IMoveCalculator moveCalculator, GameState board, Coordinates coordinates);
    }
}