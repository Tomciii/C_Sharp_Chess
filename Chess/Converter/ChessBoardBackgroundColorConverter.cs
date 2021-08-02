//-----------------------------------------------------------------------
// <copyright file="ChessBoardBackgroundColorConverter.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the ChessBoardBackgroundValueConverter logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;
    using Chess.Model;

    /// <summary>
    /// Contains the converter logic for the chessboard background.
    /// </summary>
    public class ChessBoardBackgroundColorConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to an observable collection of SolidColorBrushes.
        /// </summary>
        /// <param name="value">Takes an object as a value input.</param>
        /// <param name="targetType">Takes a targetType as input.</param>
        /// <param name="parameter">Takes a parameter as input.</param>
        /// <param name="culture">Takes a culture as input.</param>
        /// <returns>Returns an observable collection of SolidColorBrushes.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameState chessBoard = (GameState)value;
            ObservableCollection<SolidColorBrush> result = new ObservableCollection<SolidColorBrush>();
            for (int i = 0; i < chessBoard.Row; i++)
            {
                for (int j = 0; j < chessBoard.Column; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        result.Add(Brushes.Gray);
                    }
                    else
                    {
                        result.Add(Brushes.Black);
                    }
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