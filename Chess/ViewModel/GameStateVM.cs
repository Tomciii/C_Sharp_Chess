//-----------------------------------------------------------------------
// <copyright file="GameStateVM.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the GameStateVM logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using Chess.Commands;
    using Chess.Model;

    /// <summary>
    /// The GameSessionVM class.
    /// </summary>
    public class GameStateVM : INotifyPropertyChanged
    {
        /// <summary>
        /// An observable collection of GameState. Represents the game History.
        /// </summary>
        private ObservableCollection<GameState> gameHistory;

        /// <summary>
        /// An instance of the ChessBoardHandler class.
        /// </summary>
        private ChessBoardCreator chessBoardHandler;

        /// <summary>
        /// An instance of the CommandLineHandler class.
        /// </summary>
        private CommandLineHandler commandLineHandler;

        /// <summary>
        /// An observable collection of chess pieces representing the white graveyard.
        /// </summary>
        private ObservableCollection<ChessPiece> whiteGraveyard;

        /// <summary>
        /// An observable collection of chess pieces representing the black graveyard.
        /// </summary>
        private ObservableCollection<ChessPiece> blackGraveyard;

        /// <summary>
        /// An instance of the MoveCalculator class.
        /// </summary>
        private MoveCalculator moveCalculator;

        /// <summary>
        /// An instance of the GameState class.
        /// </summary>
        private GameState currentBoard;

        /// <summary>
        /// Represents the amount of columns.
        /// </summary>
        private int column;

        /// <summary>
        /// An instance of the KingInCheckCalculator class.
        /// </summary>
        private KingInCheckCalculator inCheckCalculator;

        /// <summary>
        /// Represents the amount of rows.
        /// </summary>
        private int row;

        /// <summary>
        /// An observable collection representing the possible moves.
        /// </summary>
        private ObservableCollection<Coordinates> possibleMoves;

        /// <summary>
        /// A boolean representing the value of whiteKingInCheck.
        /// </summary>
        private bool whiteKingInCheck;

        /// <summary>
        /// A boolean representing the value of blackKingInCheck.
        /// </summary>
        private bool blackKingInCheck;

        /// <summary>
        /// Initializes a new instance of the GameStateVM class.
        /// </summary>
        public GameStateVM()
        {
            this.moveCalculator = new MoveCalculator();
            this.possibleMoves = new ObservableCollection<Coordinates>();
            this.blackGraveyard = new ObservableCollection<ChessPiece>();
            this.whiteGraveyard = new ObservableCollection<ChessPiece>();
            this.commandLineHandler = new CommandLineHandler();
            this.chessBoardHandler = new ChessBoardCreator();
            this.inCheckCalculator = new KingInCheckCalculator();
            this.gameHistory = new ObservableCollection<GameState>();

            this.whiteKingInCheck = false;
            this.blackKingInCheck = false;

            this.column = this.commandLineHandler.BoardSize[0];
            this.row = this.commandLineHandler.BoardSize[1];
            this.SelectedTile = null;

            this.StartNewGame();
        }

        /// <summary>
        /// The PropertyChanged EventHandler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the value of SelectedTile.
        /// </summary>
        /// <value>The value of SelectedTile.</value>
        public Coordinates SelectedTile
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value of CurrentBoard.
        /// </summary>
        /// <value>The value of CurrentBoard.</value>
        public GameState CurrentBoard
        {
            get
            {
                return this.currentBoard;
            }

            set
            {
                this.currentBoard = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of possibleMoves.
        /// </summary>
        /// <value>The value of possibleMoves.</value>
        public ObservableCollection<Coordinates> PossibleMoves
        {
            get
            {
                return this.possibleMoves;
            }

            set
            {
                this.possibleMoves = value;
            }
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

        /// <summary>
        /// Gets or sets the value of whiteGraveyard.
        /// </summary>
        /// <value>The value of whiteGraveyard.</value>
        public ObservableCollection<ChessPiece> WhiteGraveyard
        {
            get
            {
                return this.whiteGraveyard;
            }

            set
            {
                this.whiteGraveyard = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item is enabled.
        /// </summary>
        /// <value>The value of BlackPlayerWon.</value>
        public bool BlackPlayerWon
        {
            get
            {
                if (this.gameHistory.IndexOf(this.CurrentBoard) % 2 != 0 && this.whiteKingInCheck)
                {
                       return true;
                }

                return false;
            }

            set
            {
                this.BlackPlayerWon = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item is enabled.
        /// </summary>
        /// <value>The value of WhitePlayerWon.</value>
        public bool WhitePlayerWon
        {
            get
            {
                if (this.gameHistory.IndexOf(this.CurrentBoard) % 2 == 0 && this.blackKingInCheck)
                {
                        return true;
                }

                return false;
            }

            set
            {
                this.WhitePlayerWon = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the item is enabled.
        /// </summary>
        /// <value>The value of whiteKingInCheck.</value>
        public bool WhiteKingInCheck
        {
            get
            {
                return this.whiteKingInCheck;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the item is enabled.
        /// </summary>
        /// <value>The value of blackKingInCheck.</value>
        public bool BlackKingInCheck
        {
            get
            {
                return this.blackKingInCheck;
            }
        }

        /// <summary>
        /// Gets or sets the value of blackGraveyard.
        /// </summary>
        /// <value>The value of blackGraveyard.</value>
        public ObservableCollection<ChessPiece> BlackGraveyard
        {
            get
            {
                return this.blackGraveyard;
            }

            set
            {
                this.blackGraveyard = value;
            }
        }

        /// <summary>
        /// Gets the value of LoadTurn.
        /// </summary>
        /// <value>The value of LoadTurn.</value>
        public ICommand LoadTurn
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    int index = (int)obj;

                    if (index != -1)
                    {
                        try
                        {
                            this.currentBoard = this.gameHistory[index];
                            this.WhiteGraveyard = new ObservableCollection<ChessPiece>(this.currentBoard.WhiteGraveyard);
                            this.BlackGraveyard = new ObservableCollection<ChessPiece>(this.currentBoard.BlackGraveyard);
                            this.UpdateVM();
                        }
                        catch
                        {
                            this.UpdateVM();
                        }
                    }
                });
            }
        }

        /// <summary>
        /// Gets the value of NotifyVM.
        /// </summary>
        /// <value>The value of NotifyVM.</value>
        public ICommand NotifyVM
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    this.currentBoard = this.gameHistory[this.gameHistory.Count - 1];
                    this.row = this.currentBoard.Row;
                    this.column = this.currentBoard.Column;
                    this.WhiteGraveyard = new ObservableCollection<ChessPiece>(this.currentBoard.WhiteGraveyard);
                    this.BlackGraveyard = new ObservableCollection<ChessPiece>(this.currentBoard.BlackGraveyard);
                    this.UpdateVM();
                });
            }
        }

        /// <summary>
        /// Gets the value of StartNewGameSession.
        /// </summary>
        /// <value>The value of StartNewGameSession.</value>
        public ICommand StartNewGameSession
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    this.StartNewGame();
                    this.UpdateVM();
                });
            }
        }

        /// <summary>
        /// Gets the value of SelectTile.
        /// </summary>
        /// <value>The value of SelectTile.</value>
        public ICommand SelectTile
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    if (!this.WhitePlayerWon && !BlackPlayerWon)
                    {
                        if (this.SelectedTile != null)
                        {
                            this.TryToMovePiece(obj);
                            this.FirePropertyChanged("PossibleMoves");
                            this.FirePropertyChanged("WhitePlayerWon");
                            this.FirePropertyChanged("BlackPlayerWon");
                            return;
                        }

                        this.SelectPiece(obj);
                        this.FirePropertyChanged("PossibleMoves");
                    }
                });
            }
        }

        /// <summary>
        /// Gets the board name of a board based on the moved chess pieces.
        /// </summary>
        /// <param name="oldCoordinates">Takes the old coordinates of the selected chess piece as input.</param>
        /// <param name="newCoordinates">Takes the new coordinates of the selected chess piece as input.</param>
        /// <param name="rowCount">Takes an integer representing the chessboard row as input.</param>
        /// <returns>Returns a string representing the board name.</returns>
        public string GetChessBoardName(Coordinates oldCoordinates, Coordinates newCoordinates, int rowCount)
        {
            string oldPosition = this.IntToStringConverter(oldCoordinates.Y) + this.IntToRowConverter(oldCoordinates.X, rowCount);
            string newPosition = this.IntToStringConverter(newCoordinates.Y) + this.IntToRowConverter(newCoordinates.X, rowCount);

            return oldPosition + " -> " + newPosition;
        }

        /// <summary>
        /// Converts an integer to the row value.
        /// </summary>
        /// <param name="i">Takes an integer as input.</param>
        /// <param name="rowCount">Takes the rowCount as input.</param>
        /// <returns>Returns a string containing the row information.</returns>
        public string IntToRowConverter(int i, int rowCount)
        {
            return (rowCount - i).ToString();
        }

        /// <summary>
        /// Gets the coordinates of a selected chess piece.
        /// </summary>
        /// <param name="obj">Takes an object containing the coordinates information as input.</param>
        /// <returns>Returns an integer array.</returns>
        public int[] GetCoordinates(object obj)
        {
            string[] input = obj.ToString().Split(' ');
            int[] result = new int[2];

            result[0] = int.Parse(input[0]);
            result[1] = int.Parse(input[1]);

            return result;
        }

        /// <summary>
        /// Fires the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Takes a propertyName string as input.</param>
        protected virtual void FirePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Converts integer values to character values.
        /// </summary>
        /// <param name="i">Takes an integer as value.</param>
        /// <returns>Returns a character as a string.</returns>
        private string IntToStringConverter(int i)
        {
            switch (i)
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "E";
                case 5:
                    return "F";
                case 6:
                    return "G";
                case 7:
                    return "H";
                case 8:
                    return "I";
                case 9:
                    return "J";
                case 10:
                    return "K";
                case 11:
                    return "L";
                case 12:
                    return "M";
                case 13:
                    return "N";
                case 14:
                    return "O";
                case 15:
                    return "P";
                case 16:
                    return "Q";
                case 17:
                    return "R";
                case 18:
                    return "S";
                case 19:
                    return "T";
                case 20:
                    return "U";
                case 21:
                    return "V";
                case 22:
                    return "W";
                case 23:
                    return "X";
                case 24:
                    return "Y";
                case 25:
                    return "Z";
                default: return string.Empty;
            }
        }

        /// <summary>
        /// Creates a new GameState based on the moved chess piece.
        /// </summary>
        /// <param name="oldCoordinates">Takes the old coordinates of the moved piece as input.</param>
        /// <param name="newCoordinates">Takes the new coordinates of the moved piece as input.</param>
        /// <returns>Returns a new GameState object.</returns>
        private GameState CreateNextGameState(Coordinates oldCoordinates, Coordinates newCoordinates)
        {
            Tile[,] newBoard = new Tile[this.currentBoard.Row, this.currentBoard.Column];

            for (int i = 0; i < this.currentBoard.Row; i++)
            {
                for (int j = 0; j < this.currentBoard.Column; j++)
                {
                    newBoard[i, j] = new Tile(this.currentBoard.ChessBoard[i, j].IsOccupied, this.currentBoard.ChessBoard[i, j].Piece);
                }
            }

            ChessPiece movingChessPiece = newBoard[oldCoordinates.X, oldCoordinates.Y].Piece;

            ChessPiece deadChessPiece = null;
            bool chessPieceDied = this.CheckIfChessPieceDied(newBoard, newCoordinates);
           
            if (chessPieceDied)
            {
                deadChessPiece = newBoard[newCoordinates.X, newCoordinates.Y].Piece;
            }

            newBoard[newCoordinates.X, newCoordinates.Y].Piece = movingChessPiece;
            newBoard[newCoordinates.X, newCoordinates.Y].IsOccupied = true;
            newBoard[oldCoordinates.X, oldCoordinates.Y].IsOccupied = false;

            string moveName = this.GetChessBoardName(oldCoordinates, newCoordinates, this.currentBoard.Row);
            GameState result = new GameState(this.currentBoard.Column, this.currentBoard.Row, moveName, newBoard);

            if (chessPieceDied)
            {
                this.KillChessPiece(deadChessPiece);
            }

            return result;
        }

        /// <summary>
        /// Checks if a chess piece died from a chess piece move.
        /// </summary>
        /// <param name="board">Takes a board as input.</param>
        /// <param name="coordinates">Takes a coordinates object as input.</param>
        /// <returns>Returns a boolean value.</returns>
        private bool CheckIfChessPieceDied(Tile[,] board, Coordinates coordinates)
        {
            if (board[coordinates.X, coordinates.Y].IsOccupied)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds a chess piece to a graveyard.
        /// </summary>
        /// <param name="deadChessPiece">Takes a ChessPiece object as input.</param>
        private void KillChessPiece(ChessPiece deadChessPiece)
        {
            if (deadChessPiece.Player == Player.WHITE)
            {
                this.WhiteGraveyard.Add(deadChessPiece);
                this.FirePropertyChanged("WhiteGraveyard");
            }
            else if (deadChessPiece.Player == Player.BLACK)
            {
                this.BlackGraveyard.Add(deadChessPiece);
                this.FirePropertyChanged("BlackGraveyard");
            }
        }

        /// <summary>
        /// Tries to move a chess piece to it's destination tile.
        /// </summary>
        /// <param name="obj">Takes an object containing current coordinates as input.</param>
        private void TryToMovePiece(object obj)
        {
            int[] oldCoordinates = this.GetCoordinates(obj);
            Coordinates moveCoordinates = new Coordinates(oldCoordinates[0], oldCoordinates[1]);

            foreach (Coordinates possibleCoordinates in this.possibleMoves)
            {
                if (moveCoordinates.X == possibleCoordinates.X && moveCoordinates.Y == possibleCoordinates.Y)
                {
                    GameState newGameState = this.CreateNextGameState(this.SelectedTile, moveCoordinates);

                    if (this.currentBoard != this.gameHistory[this.gameHistory.Count - 1])
                    {
                        while (this.currentBoard != this.gameHistory[this.gameHistory.Count - 1])
                        {
                            this.gameHistory.Remove(this.gameHistory[this.gameHistory.Count - 1]);
                        }
                    }

                    this.CopyGraveyards(newGameState);

                    this.gameHistory.Add(newGameState);
                    this.currentBoard = newGameState;

                    this.possibleMoves.Clear();
                    this.FinishMove();
                    break;
                }
            }

            this.SelectPiece(obj);
        }

        /// <summary>
        /// Copies over the graveyard states from the current GameState to the new GameState.
        /// </summary>
        /// <param name="newChessBoard">Takes the new GameState as input.</param>
        private void CopyGraveyards(GameState newChessBoard)
        {
            foreach (ChessPiece chessPiece in this.WhiteGraveyard)
            {
                newChessBoard.WhiteGraveyard.Add(chessPiece);
            }

            foreach (ChessPiece chesspiece in this.BlackGraveyard)
            {
                newChessBoard.BlackGraveyard.Add(chesspiece);
            }
        }

        /// <summary>
        /// Updates the GameSessionVM.
        /// </summary>
        private void FinishMove()
        {
            this.blackKingInCheck = this.inCheckCalculator.IsKingInCheck(Player.BLACK, this.CurrentBoard);
            this.whiteKingInCheck = this.inCheckCalculator.IsKingInCheck(Player.WHITE, this.CurrentBoard);

            this.FirePropertyChanged("WhiteKingInCheck");
            this.FirePropertyChanged("BlackKingInCheck");

            this.FirePropertyChanged("WhieGraveyard");
            this.FirePropertyChanged("BlackGraveyard");

            this.possibleMoves.Clear();
            this.FirePropertyChanged("CurrentBoard");
            this.FirePropertyChanged("PossibleMoves");
            this.SelectedTile = null;
        }

        /// <summary>
        /// Selects a ChessPiece object if possible.
        /// </summary>
        /// <param name="obj">Takes an object containing coordinates information of the selected Tile as input.</param>
        private void SelectPiece(object obj)
        {
            int[] selectedTile = this.GetCoordinates(obj);

            Coordinates selectedPieceCoordinates = new Coordinates(selectedTile[0], selectedTile[1]);
          
            if (this.currentBoard.ChessBoard[selectedPieceCoordinates.X, selectedPieceCoordinates.Y].IsOccupied)
            {
                ChessPiece piece = this.currentBoard.ChessBoard[selectedPieceCoordinates.X, selectedPieceCoordinates.Y].Piece;

                if (this.gameHistory.IndexOf(this.currentBoard) % 2 == 0)
                {
                    if (piece.Player == Player.WHITE)
                    {
                        this.GetPossibleMoves(selectedPieceCoordinates);
                    }
                }
                else
                {
                    if (piece.Player == Player.BLACK)
                    {
                        this.GetPossibleMoves(selectedPieceCoordinates);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the possible moves of a ChessPiece.
        /// </summary>
        /// <param name="selectedPiece">Takes the coordinates of the selected piece as input.</param>
        private void GetPossibleMoves(Coordinates selectedPiece)
        {
            List<Coordinates> list;

            if (this.currentBoard.ChessBoard[selectedPiece.X, selectedPiece.Y].IsOccupied)
            {
                list = this.currentBoard.ChessBoard[selectedPiece.X, selectedPiece.Y].Piece.CalculatePossibleMoves(this.moveCalculator, this.currentBoard, selectedPiece);
            }
            else
            {
                return;
            }

            ObservableCollection<Coordinates> collection = new ObservableCollection<Coordinates>(list);
            this.possibleMoves = collection;
            this.SelectedTile = selectedPiece;
        }

        /// <summary>
        /// Updates the GameStateVM.
        /// </summary>
        private void UpdateVM()
        {
            this.blackKingInCheck = this.inCheckCalculator.IsKingInCheck(Player.BLACK, this.CurrentBoard);
            this.whiteKingInCheck = this.inCheckCalculator.IsKingInCheck(Player.WHITE, this.CurrentBoard);

            this.FirePropertyChanged("WhiteGraveyard");
            this.FirePropertyChanged("BlackGraveyard");
            this.FirePropertyChanged("GameHistory");
            this.FirePropertyChanged("CurrentBoard");
            this.FirePropertyChanged("WhitePlayerWon");
            this.FirePropertyChanged("BlackPlayerWon");
            this.FirePropertyChanged("WhiteKingInCheck");
            this.FirePropertyChanged("BlackKingInCheck");
        }

        /// <summary>
        /// Starts a new game of chess.
        /// </summary>
        private void StartNewGame()
        {
            GameState chessBoard = this.chessBoardHandler.CreateNewBoard(this.column, this.row, "Start");
            this.gameHistory.Clear();
            this.gameHistory.Add(chessBoard);
            this.possibleMoves.Clear();
            this.blackGraveyard.Clear();
            this.whiteGraveyard.Clear();
            this.currentBoard = chessBoard;
        }
    }
}