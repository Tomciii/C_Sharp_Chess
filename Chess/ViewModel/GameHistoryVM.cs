//----------------------------------------------------------------------
// <copyright file="GameHistoryVM.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the GameHistoryVM logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using Chess.Model;

    /// <summary>
    /// The GameHistoryVM class.
    /// </summary>
    [Serializable]
    public class GameHistoryVM
    {
        /// <summary>
        /// An observable collection containing GamState objects.
        /// </summary>
        private ObservableCollection<GameState> gameHistory;

        /// <summary>
        /// Initializes a new instance of the GameHistoryVM class.
        /// </summary>
        public GameHistoryVM()
        {
            this.gameHistory = new ObservableCollection<GameState>();
        }

        /// <summary>
        /// Gets or sets the value of gameHistory.
        /// </summary>
        /// <value>The value of gameHistory.</value>
        public ObservableCollection<GameState> GameHistory
        {
            get
            {
                return this.gameHistory;
            }

            set
            {
                this.gameHistory = value;
            }
        }
    }
}
