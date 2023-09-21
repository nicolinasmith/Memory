using Memory.Commands;
using Memory.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Memory.ViewModels
{
    internal sealed class MainViewModel : BaseViewModel
    {
        private static MainViewModel _instance;

        public BaseViewModel CurrentViewModel { get; set; } = new StartGameViewModel();

        public static MainViewModel Instance { get => _instance ?? (_instance = new MainViewModel()); }


        public ICommand StartGameCommand { get; set; }
        public ICommand EndGameCommand { get; set; }
        public ICommand RestartGameCommand { get; set; }

        public bool IsGameButtonsEnabled { get; set; } = false;

        private MainViewModel()
        {
            StartGameCommand = new RelayCommand(x => StartGameByChosenTheme(x));
            EndGameCommand = new RelayCommand(x => EndGame());
            RestartGameCommand = new RelayCommand(x => RestartGame());
        }

        /// <summary>
        /// Changes current view model to chosen theme mode
        /// </summary>
        /// <param name="x">Chosen theme</param>
        private void StartGameByChosenTheme(object x)
        {
            if (x.ToString() == "cute")
            {
                var soundPlayer = new SoundPlayer(Properties.Resources.Yay);
                soundPlayer.Play();
                MainViewModel.Instance.CurrentViewModel = new CuteThemeViewModel();
            }
            else if (x.ToString() == "horror")
            {
                var soundPlayer = new SoundPlayer(Properties.Resources.Evil);
                soundPlayer.Play();

                MainViewModel.Instance.CurrentViewModel = new HorrorThemeViewModel();
            }
        }

        /// <summary>
        /// Restarts the game
        /// </summary>
        protected void RestartGame()
        {
            MainViewModel.Instance.CurrentViewModel = new StartGameViewModel();
        }

        /// <summary>
        /// Upon button click on FinishedGamePage ends the game
        /// </summary>
        protected void EndGame()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
