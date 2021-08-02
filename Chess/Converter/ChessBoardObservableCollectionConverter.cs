//-----------------------------------------------------------------------
// <copyright file="ChessBoardObservableCollectionConverter.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the ChessBoardObservableCollectionConverter logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// The ChessBoardObservableCollectionConverter class.
    /// </summary>
    public class ChessBoardObservableCollectionConverter : IValueConverter
    {
        /// <summary>
        /// Converts the 2D Array of the Tiles into an observable collection containing the coordinate information.
        /// </summary>
        /// <param name="value">Takes a value object as input.</param>
        /// <param name="targetType">Takes a Type object as input.</param>
        /// <param name="parameter">Takes an object as parameter.</param>
        /// <param name="culture">Takes a CultureInfo instance as input.</param>
        /// <returns>Returns an observable collection containing the coordinates.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameState board = (GameState)value;
            ObservableCollection<string> result = new ObservableCollection<string>();  
            
            for (int i = 0; i < board.Row; i++)
            {
                for (int j = 0; j < board.Column; j++)
                {
                    result.Add($"{i} {j}");
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
