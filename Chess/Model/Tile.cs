//-----------------------------------------------------------------------
// <copyright file="Tile.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the Tile logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Model
{
    using System;
    [Serializable]

    /// <summary>
    /// The Tile class. Represents a cell of a chess board.
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// Represents if the Tile is occupied.
        /// </summary>
        private bool isOccupied;

        /// <summary>
        /// Represents what chess piece this Tile holds.
        /// </summary>
        private ChessPiece piece;

        /// <summary>
        /// Initializes a new instance of the Tile class.
        /// </summary>
        /// <param name="isOccupied">Sets the value of isOccupied.</param>
        /// <param name="piece">Sets the value of piece.</param>
        public Tile(bool isOccupied, ChessPiece piece)
        {
            this.isOccupied = isOccupied;
            this.piece = piece;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item is enabled.
        /// </summary>
        /// <value>The value of isOccupied.</value>
        public bool IsOccupied
        {
            get
            {
                return this.isOccupied;
            }

            set
            {
                this.isOccupied = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of piece.
        /// </summary>
        /// <value>The value of piece.</value>
        public ChessPiece Piece
        {
            get
            {
                return this.piece;
            }

            set
            {
                this.piece = value;
            }
        }
    }
}