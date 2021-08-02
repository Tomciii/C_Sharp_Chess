//-----------------------------------------------------------------------
// <copyright file="CommandLineHandler.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the CommandLineHandler logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.ViewModel
{
    using System;
    using System.Linq;
    [Serializable]

    /// <summary>
    /// The CommandLineHandler class.
    /// </summary>
    public class CommandLineHandler
    {
        /// <summary>
        /// Represents the command line arguments.
        /// </summary>
        private string[] args;

        /// <summary>
        /// Represents the width and height of the ChessBoard.
        /// </summary>
        private int[] boardSize;

        /// <summary>
        /// Initializes a new instance of the CommandLineHandler class.
        /// </summary>
        public CommandLineHandler()
        {
            this.args = Environment.GetCommandLineArgs();
            this.boardSize = this.AnalyseCommandLineArgs();
        }

        /// <summary>
        /// Gets the value of boardSize.
        /// </summary>
        /// <value>The value of boardSize.</value>
        public int[] BoardSize
        {
            get
            {
                return this.boardSize;
            }
        }

        /// <summary>
        /// Analyses the command line arguments.
        /// </summary>
        /// <returns>Returns an integer array.</returns>
        private int[] AnalyseCommandLineArgs()
        {
            int[] result = { 8, 8 };

            if (this.args.Length < 4)
            {
                if (this.args.Length == 1)
                {
                    return result;
                }

                if (this.args[1].Equals("-size") && this.args.Length > 2)
                {
                    string[] size = this.GetBoardSizeArguments();

                    if (size != null)
                    {
                        result = this.ParseToIntArray(size);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the board size arguments from the command line arguments.
        /// </summary>
        /// <returns>Returns a string array.</returns>
        private string[] GetBoardSizeArguments()
        {
            string[] size = null;

                if (this.args[2].Contains('X'))
                {
                    size = this.args[2].Split('X');
                }
                else if (this.args[2].Contains('x'))
                {
                    size = this.args[2].Split('x');
                }

            return size;
        }

        /// <summary>
        /// Parses a string array into an integer array.
        /// </summary>
        /// <param name="size">Takes a string array as input.</param>
        /// <returns>Returns an integer array.</returns>
        private int[] ParseToIntArray(string[] size)
        {
            int[] result = { 8, 8 };

            if (size.Length < 3 && size.Length > 1)
            {
                bool parseSuccessful = false;

                for (int i = 0; i < size.Length; i++)
                {
                    int number;
                    parseSuccessful = int.TryParse(size[i], out number);

                    if (parseSuccessful && (number > 7 && number < 27))
                    {
                        result[i] = number;
                    }
                    else
                    {
                        result[i] = 8;
                    }
                }
            }

            return result;
        }
    }
}