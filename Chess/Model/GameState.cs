//-----------------------------------------------------------------------
// <copyright file="GameState.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the ChessBoard logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Model
{
    using System;
    using System.Collections.Generic;
    [Serializable]

    /// <summary>
    /// The GameState class that represents a chessboard.
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// The Tile 2D Array of the ChessBoard.
        /// </summary>
        private Tile[,] chessBoard;

        /// <summary>
        /// The name of this ChessBoard instance.
        /// </summary>
        private string name;

        /// <summary>
        /// Represents the amount of columns.
        /// </summary>
        private int column;

        /// <summary>
        /// Represents the value of rows.
        /// </summary>
        private int row;

        /// <summary>
        /// A list containing the chess pieces in the white graveyard.
        /// </summary>
        private List<ChessPiece> whiteGraveyard;

        /// <summary>
        /// A list containing the chess pieces in the black graveyard.
        /// </summary>
        private List<ChessPiece> blackGraveyard;

        /// <summary>
        /// Initializes a new instance of the GameState class.
        /// </summary>
        /// <param name="width">Sets the width of the ChessBoard.</param>
        /// <param name="height">Sets the height of the ChessBoard.</param>
        /// <param name="name">Sets the name of the ChessBoard.</param>
        /// <param name="board">Sets the board 2d array.</param>
        public GameState(int width, int height, string name, Tile[,] board)
        {
            this.blackGraveyard = new List<ChessPiece>();
            this.whiteGraveyard = new List<ChessPiece>();
            this.column = width;
            this.row = height;
            this.name = name;
            this.chessBoard = board;
        }

        /// <summary>
        /// Gets or sets the value of whiteGraveYard.
        /// </summary>
        /// <value>The value of whiteGraveYard.</value>
        public List<ChessPiece> WhiteGraveyard
        {
            get
            {
                return this.whiteGraveyard;
            }

            set
            {
                this.whiteGraveyard = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of blackGraveyard.
        /// </summary>
        /// <value>The value of blackGraveYard.</value>
        public List<ChessPiece> BlackGraveyard
        {
            get
            {
                return this.blackGraveyard;
            }

            set
            {
                this.blackGraveyard = value;
            }
        }

        /// <summary>
        /// Gets the value of column.
        /// </summary>
        /// <value>The value of column.</value>
        public int Column
        {
            get
            {
                return this.column;
            }
        } 

        /// <summary>
        /// Gets the value of row.
        /// </summary>
        /// <value>The value of row.</value>
        public int Row
        {
            get
            {
                return this.row;
            }
        }

        /// <summary>
        /// Gets the value of name.
        /// </summary>
        /// <value>The value of name.</value>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the value of board.
        /// </summary>
        /// <value>The value of board.</value>
        public Tile[,] ChessBoard
        {
            get
            {
                return this.chessBoard;
            }
        }
    }
}