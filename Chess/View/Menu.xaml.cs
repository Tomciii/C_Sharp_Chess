//-----------------------------------------------------------------------
// <copyright file="Menu.xaml.cs" company="FH WN">
//     Copyright (c) Thomas Horvath. All rights reserved.
// </copyright>
// <summary>This file contains the Menu logic.</summary>
//-----------------------------------------------------------------------
namespace Chess.View
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows;
    using System.Windows.Controls;
    using Chess.ViewModel;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for Menu XAML file.
    /// </summary>
    public partial class Menu : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the Menu class.
        /// </summary>
        public Menu()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Loads a game history of a chess game.
        /// </summary>
        /// <param name="sender">Takes an object as input.</param>
        /// <param name="e">Takes a RoutedEventArgs instance as input.</param>
        private void Button_LoadGame(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Chess Files | *.chess";

            GameHistoryVM loadedGame = null;
            if (openFileDialog.ShowDialog() == true)
            {
                IFormatter formatter = new BinaryFormatter();

                try
                {
                    using (FileStream fs = File.OpenRead(openFileDialog.FileName))
                    {
                        loadedGame = (GameHistoryVM)formatter.Deserialize(fs);
                    }
                }
                catch
                {
                    MessageBox.Show("Could not load the .chess file.", "Chess", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                
                GameStateVM context = (GameStateVM)DataContext;
                 context.GameHistory = loadedGame.GameHistory;
                this.DataContext = context;
            }
        }

        /// <summary>
        /// Saves the current game history of the chess game.
        /// </summary>
        /// <param name="sender">Takes an object as input.</param>
        /// <param name="e">Takes an instance of RoutedEventArgs as input.</param>
            private void Button_SaveGame(object sender, RoutedEventArgs e)
            {
                GameHistoryVM saveGame;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                GameStateVM currentGame = (GameStateVM)DataContext;

                GameHistoryVM gameHistory = new GameHistoryVM();
                gameHistory.GameHistory = currentGame.GameHistory;

                saveFileDialog.Filter = "Chess Files | *.chess";
                saveFileDialog.DefaultExt = ".chess";
                saveFileDialog.FileName = "game";
          
                if (saveFileDialog.ShowDialog() == true)
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(fs, gameHistory);
                        fs.Seek(0, SeekOrigin.Begin);
                        saveGame = (GameHistoryVM)formatter.Deserialize(fs);
                        fs.Close();
                    }
                }
            }
    }
}