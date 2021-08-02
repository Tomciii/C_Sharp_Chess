//-----------------------------------------------------------------------
// <copyright file="ChessPieceImageConverter.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the ChessPieceImageConverter logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// Contains the converter logic for the ChessPiece images.
    /// </summary>
    public class ChessPieceImageConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to an observable collection of chess piece images.
        /// </summary>
        /// <param name="value">Takes an object as a value input.</param>
        /// <param name="targetType">Takes a targetType as input.</param>
        /// <param name="parameter">Takes a parameter as input.</param>
        /// <param name="culture">Takes a culture as input.</param>
        /// <returns>Returns an observable collection of chess piece images.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<string> chessPieceImages = new ObservableCollection<string>();

                GameState chessBoard = (GameState)value;

                for (int i = 0; i < chessBoard.Row; i++)
                {
                    for (int j = 0; j < chessBoard.Column; j++)
                    {
                        if (chessBoard.ChessBoard[i, j].IsOccupied)
                        {
                            if (chessBoard.ChessBoard[i, j].Piece.Player == Player.BLACK)
                            {
                                chessPieceImages.Add($"Images/{chessBoard.ChessBoard[i, j].Piece}_B.png");
                            }
                            else if (chessBoard.ChessBoard[i, j].Piece.Player == Player.WHITE)
                            {
                                chessPieceImages.Add($"Images/{chessBoard.ChessBoard[i, j].Piece}_W.png");
                            }
                        }
                        else
                        {
                            chessPieceImages.Add(null);
                        }
                    }
                }

                return chessPieceImages;
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
