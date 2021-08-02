//----------------------------------------------------------------------
// <copyright file="Coordinates.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the Coordinates logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Model
{
    using System;

    /// <summary>
    /// The Coordinates class.
    /// </summary>
    [Serializable]
    public class Coordinates
    {
        /// <summary>
        /// Represents the x coordinate.
        /// </summary>
        private int x;
        
        /// <summary>
        /// Represents the y coordinate.
        /// </summary>
        private int y;

        /// <summary>
        /// Initializes a new instance of the Coordinates class.
        /// </summary>
        /// <param name="x">Sets the value of x.</param>
        /// <param name="y">Sets the value of y.</param>
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Gets the value of x.
        /// </summary>
        /// <value>The value of x.</value>
        public int X 
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// Gets the value of y.
        /// </summary>
        /// <value>The value of y.</value>
        public int Y
        {
            get
            {
                return this.y;
            }
        }
    }
}