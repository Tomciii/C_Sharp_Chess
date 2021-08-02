//----------------------------------------------------------------
// <copyright file="PossibleMovesConverter.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the PossibleMovesConverter logic.</summary>
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
    /// The PossibleMovesConverter class.
    /// </summary>
    public class PossibleMovesConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts a value to an observable collection of SolidColorBrushes representing the possible Tiles.
        /// </summary>
        /// <param name="values">Takes an object as a values input.</param>
        /// <param name="targetType">Takes a targetType as input.</param>
        /// <param name="parameter">Takes a parameter as input.</param>
        /// <param name="culture">Takes a culture as input.</param>
        /// <returns>Returns an observable collection of SolidColorBrushes representing the possible Tiles.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<SolidColorBrush> result = new ObservableCollection<SolidColorBrush>();
            ObservableCollection<Coordinates> possibleMoves = (ObservableCollection<Coordinates>)values[0];
            GameState board = (GameState)values[1];

            for (int i = 0; i < board.Row; i++)
            {
                for (int j = 0; j < board.Column; j++)
                {
                    for (int k = 0; k < possibleMoves.Count; k++)
                    {
                        if (possibleMoves[k].X == i && possibleMoves[k].Y == j)
                        {
                            result.Add(Brushes.LightGreen);
                            break;
                        }
                        else
                        {
                            if (k == possibleMoves.Count - 1)
                            {
                                result.Add(null);
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Converts a converted value back to its original value.
        /// </summary>
        /// <param name="value">Takes an object as a value input.</param>
        /// <param name="targetTypes">Takes targetTypes as input.</param>
        /// <param name="parameter">Takes a parameter as input.</param>
        /// <param name="culture">Takes a culture as input.</param>
        /// <returns>Returns a value object.</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
