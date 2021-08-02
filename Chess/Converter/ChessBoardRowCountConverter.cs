//-----------------------------------------------------------------------
// <copyright file="ChessBoardRowCountConverter.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the ChessBoardRowCountConverter logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// The ChessBoardRowCountConverter class.
    /// </summary>
    public class ChessBoardRowCountConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to an observable collection of row numbers.
        /// </summary>
        /// <param name="value">Takes an object as a value input.</param>
        /// <param name="targetType">Takes a targetType as input.</param>
        /// <param name="parameter">Takes a parameter as input.</param>
        /// <param name="culture">Takes a culture as input.</param>
        /// <returns>Returns an observable collection of row numbers.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameState chessBoard = (GameState)value;
            ObservableCollection<string> result = new ObservableCollection<string>();

            for (int i = chessBoard.Row; i > 0; i--)
            {
                if (i < 10)
                {
                    result.Add("0" + i.ToString());
                }
                else
                {
                    result.Add(i.ToString());
                }
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
