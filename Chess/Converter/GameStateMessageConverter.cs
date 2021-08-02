//----------------------------------------------------------------
// <copyright file="GameStateMessageConverter.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the GameStateMessageConverter logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// The GameStateMessageConverter class.
    /// </summary>
    public class GameStateMessageConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts a value to a string message.
        /// </summary>
        /// <param name="values">Takes an object as a value input.</param>
        /// <param name="targetType">Takes a targetType as input.</param>
        /// <param name="parameter">Takes a parameter as input.</param>
        /// <param name="culture">Takes a culture as input.</param>
        /// <returns>Returns a string message.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool whitePlayerWon = (bool)values[0];
            bool blackPlayerWon = (bool)values[1];
            GameState currentBoard = (GameState)values[3];

            if (whitePlayerWon && blackPlayerWon)
            {
                return "Draw!";
            }

            if (whitePlayerWon)
            {
                return "White Player Won!";
            }
            
            if (blackPlayerWon)
            {
                return "Black Player Won!";
            }

            ObservableCollection<GameState> gameHistory = (ObservableCollection<GameState>)values[2];

            if (gameHistory.IndexOf(currentBoard) % 2 == 0)
            {
                return "White Player's Turn";
            }

            return "Black Player's Turn";
        }

        /// <summary>
        /// Converts a converted value back to its original value.
        /// </summary>
        /// <param name="value">Takes an object as a value input.</param>
        /// <param name="targetTypes">Takes a targetType as input.</param>
        /// <param name="parameter">Takes a parameter as input.</param>
        /// <param name="culture">Takes a culture as input.</param>
        /// <returns>Returns a value object.</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}