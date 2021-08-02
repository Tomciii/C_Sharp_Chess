//-----------------------------------------------------------------------
// <copyright file="BoardWidthConverter.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the ChessTileWidthConverter logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// Contains the converter logic for the Tile width.
    /// </summary>
    public class BoardWidthConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to an integer representing the board width.
        /// </summary>
        /// <param name="value">Takes an object as a value input.</param>
        /// <param name="targetType">Takes a targetType as input.</param>
        /// <param name="parameter">Takes a parameter as input.</param>
        /// <param name="culture">Takes a culture as input.</param>
        /// <returns>Returns an integer representing the board width.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int columnSize = 30;

            GameState chessBoard = (GameState)value;

            if (chessBoard.Row < 11 && chessBoard.Column < 11)
            {
                columnSize = 80;
                return chessBoard.Column * columnSize;
            }

            if (chessBoard.Row < 15 && chessBoard.Column < 15)
            {
                columnSize = 60;
                return chessBoard.Column * columnSize;
            }

            if (chessBoard.Row < 19 && chessBoard.Column < 19)
            {
                columnSize = 40;
                return chessBoard.Column * columnSize;
            }

            return chessBoard.Column * columnSize;
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
    }
}