//----------------------------------------------------------------------
// <copyright file="ColumnAsCharConverter.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the ColumnAsCharConverter logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// The ColumnAsCharConverter class.
    /// </summary>
    public class ColumnAsCharConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to an observable collection of letters containing the chess board column.
        /// </summary>
        /// <param name="value">Takes an object as a value input.</param>
        /// <param name="targetType">Takes a targetType as input.</param>
        /// <param name="parameter">Takes a parameter as input.</param>
        /// <param name="culture">Takes a culture as input.</param>
        /// <returns>Returns an observable collection of letters containing the chess board column.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameState chessBoard = (GameState)value;
            ObservableCollection<char> result = new ObservableCollection<char>();

            for (char symbol = 'A'; symbol <= 'Z'; symbol++)
            {
                if (result.Count == chessBoard.Column)
                {
                    break;
                }

                result.Add(symbol);
            }

            return result;
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
