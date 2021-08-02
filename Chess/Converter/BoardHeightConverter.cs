//-----------------------------------------------------------------------
// <copyright file="BoardHeightConverter.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the ChessTileHeightConverter logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// Contains the converter logic for the Tile height.
    /// </summary>
    public class BoardHeightConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to an integer representing the board height.
        /// </summary>
        /// <param name="value">Takes an object as a value input.</param>
        /// <param name="targetType">Takes a targetType as input.</param>
        /// <param name="parameter">Takes a parameter as input.</param>
        /// <param name="culture">Takes a culture as input.</param>
        /// <returns>Returns an integer representing the board height.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rowSize = 30;

            GameState chessBoard = (GameState)value;

            if (chessBoard.Row < 11 && chessBoard.Column < 11)
            {
                rowSize = 80;
                return chessBoard.Row * rowSize;
            }

            if (chessBoard.Row < 15 && chessBoard.Column < 15)
            {
                rowSize = 60;
                return chessBoard.Row * rowSize;
            }

            if (chessBoard.Row < 19 && chessBoard.Column < 19)
            {
                rowSize = 40;
                return chessBoard.Row * rowSize;
            }

            return chessBoard.Row * rowSize;
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
