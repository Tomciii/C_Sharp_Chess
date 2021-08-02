//-----------------------------------------------------------------------
// <copyright file="GenericCommand.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the ChessPiece logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// The GenericCommand class.
    /// </summary>
    public class GenericCommand : ICommand
    {
        /// <summary>
        /// An instance of the Action class.
        /// </summary>
        private Action<object> action;

        /// <summary>
        /// Initializes a new instance of the GenericCommand class.
        /// </summary>
        /// <param name="action">Takes an action as input.</param>
        public GenericCommand(Action<object> action)
        {
            this.action = action;
        }

        /// <summary>
        /// The CanExecuteChanged EventHandler.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Checks if a command can be executed.
        /// </summary>
        /// <param name="parameter">Takes a parameter object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Takes a parameter object as input.</param>
        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}
