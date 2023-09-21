using Memory.Commands;
using Memory.Enums;
using Memory.Views.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Memory.ViewModels
{
    public abstract class GameViewModel : BaseViewModel
    {
        public ICommand CardIsClickedCommand { get; protected set; }

        public ObservableCollection<CardComponent> MemoryCards { get; set; }

        public ObservableCollection<Uri> Images { get; set; }

        public HashSet<CardComponent> SelectedCards = new HashSet<CardComponent>();

        public DispatcherTimer Timer { get; set; }

        public string CurrentTime { get; set; }

        int elapsedTime = 0;

        public int NumberOfTries { get; set; } = 0;

        public string Tries { get; set; }

        protected int MemorySize = 8;

        protected bool isMatchingInProgress = false;



        public GameViewModel()
        {

            CardIsClickedCommand = new RelayCommand(execute: x => FlipACard(x));

            Tries = $"Antal försök: {NumberOfTries}";
        }

        /// <summary>
        /// Creates the memory board
        /// </summary>
        protected abstract void CreateMemoryBoard();


        /// <summary>
        /// Shuffles the memory cards
        /// </summary>
        protected void ShuffleCards()
        {
            Random randomNr = new Random();
            int nrOfCards = MemoryCards.Count;

            while (nrOfCards > 1)
            {
                nrOfCards--;
                int randomPlace = randomNr.Next(nrOfCards + 1);
                CardComponent value = MemoryCards[randomPlace];
                MemoryCards[randomPlace] = MemoryCards[nrOfCards];
                MemoryCards[nrOfCards] = value;
            }
        }

        /// <summary>
        /// Starts the timer for the memory
        /// </summary>
        protected void StartTimer()
        {
            Timer = new DispatcherTimer(DispatcherPriority.Render);
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += (sender, args) =>
            {
                elapsedTime++;
                CurrentTime = TimeSpan.FromSeconds(elapsedTime).ToString();
            };
            Timer.Start();
        }

        /// <summary>
        /// Flips a memory card and adds to list when clicked
        /// </summary>
        /// <param name="x">Memory card object</param>
        protected void FlipACard(object x)
        {
            if (isMatchingInProgress) { return; }

            CardComponent card = (CardComponent)x;
            card.CardStatus = CardStatus.CardUp;
            SelectedCards.Add(card);

            if (SelectedCards.Count == 2)
            {
                CheckForMatch();
            }
        }

        /// <summary>
        /// Checks if the selected cards match
        /// </summary>
        protected abstract void CheckForMatch();


        /// <summary>
        /// Checks if all cards are matched for the game to end
        /// </summary>
        protected void CheckForGameFinished()
        {
            int count = 0;
            foreach (CardComponent card in MemoryCards)
            {
                if (card.CardStatus == CardStatus.CardUp)
                {
                    count++;
                }
                if (count == MemoryCards.Count)
                {
                    Timer.Stop();

                    string message = $"Du har matchat alla kort, bra jobbat! \nDin tid var: {CurrentTime} på {NumberOfTries} försök. \n \nVill du spela igen?";
                    MainViewModel.Instance.CurrentViewModel = new EndGameViewModel(message);

                }
            }
        }
    }
}
