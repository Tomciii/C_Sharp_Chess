//----------------------------------------------------------------
// <copyright file="KingXPositionConverter.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the KingXPositionConverter logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// The KingXPositionConverter class.
    /// </summary>
    public class KingXPositionConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to an integer value containing the X coordinate of the king.
        /// </summary>
        /// <param name="value">Takes an object as a value input.</param>
        /// <param name="targetType">Takes a targetType as input.</param>
        /// <param name="parameter">Takes a parameter as input.</param>
        /// <param name="culture">Takes a culture as input.</param>
        /// <returns>Returns an integer value containing the X coordinate of the king.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int x = 0;
            Player player = (Player)Enum.Parse(typeof(Player), (string)parameter);

            GameState gameState = (GameState)value;
            int tileWidth = this.GetTileWidth(gameState);

            for (int i = 0; i < gameState.Row; i++)
            {
                for (int j = 0; j < gameState.Column; j++)
                {
                    if (gameState.ChessBoard[i, j].IsOccupied)
                    {
                        if (gameState.ChessBoard[i, j].Piece is King)
                        {
                            if (player == gameState.ChessBoard[i, j].Piece.Player)
                            {
                                return (double)(tileWidth * j);
                            }
                        }
                    }
                }
            }

            return x;
        }

        /// <summary>
        /// Converts a converted value back to its original value.
        /// </summary>
        /// <param name="value">Takes an object as a value input.</param>
        /// <param name="targetType">Takes a targetType as input.</param>
        /// <param name="parameter">Takes a parameter as input.</param>
        /// <param name="culture">Takes a culture as input.</param>
        /// <returns>Returns a value object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the tile width.
        /// </summary>
        /// <param name="chessBoard">Takes the current board as input.</param>
        /// <returns>Returns an integer value representing the tile width.</returns>
        private int GetTileWidth(GameState chessBoard)
        {
            int columnSize = 30;

            if (chessBoard.Row < 11 && chessBoard.Column < 11)
            {
                columnSize = 80;
                return columnSize;
            }

            if (chessBoard.Row < 15 && chessBoard.Column < 15)
            {
                columnSize = 60;
                return columnSize;
            }

            if (chessBoard.Row < 19 && chessBoard.Column < 19)
            {
                columnSize = 40;
                return columnSize;
            }

            return columnSize;
        }
    }
}
