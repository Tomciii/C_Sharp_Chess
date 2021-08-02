//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the Player logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Model
{
    using System;
    [Serializable]

    /// <summary>
    /// The Player enum.
    /// </summary>
    public enum Player
    {
        /// <summary>
        /// The enum for the black player.
        /// </summary>
        BLACK, 
        
        /// <summary>
        /// The enum for the white player.
        /// </summary>
        WHITE
    }
}