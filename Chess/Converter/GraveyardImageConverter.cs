//----------------------------------------------------------------
// <copyright file="GraveyardImageConverter.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the GraveyardImageConverter logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// The GraveyardImageConverter class.
    /// </summary>
    public class GraveyardImageConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to an observable collection representing the chess pieces in the graveyard.
        /// </summary>
        /// <param name="value">Takes an object as a value input.</param>
        /// <param name="targetType">Takes a targetType as input.</param>
        /// <param name="parameter">Takes a parameter as input.</param>
        /// <param name="culture">Takes a culture as input.</param>
        /// <returns>Returns an observable collection representing the chess pieces in the graveyard.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<ChessPiece> graveyard = (ObservableCollection<ChessPiece>)value;
            ObservableCollection<string> result = new ObservableCollection<string>();
            string player = (string)parameter;
            
            if (player.Equals("white"))
            {
                for (int i = 0; i < graveyard.Count; i++)
                {
                    result.Add($"Images/{graveyard[i]}_W.png");
                }

                for (int i = result.Count; i < 16; i++)
                {
                    result.Add(null);
                }
            }
            else if (player.Equals("black"))
            {
                for (int i = 0; i < graveyard.Count; i++)
                {
                    result.Add($"Images/{graveyard[i]}_B.png");
                }

                for (int i = result.Count; i < 16; i++)
                {
                    result.Add(null);
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
