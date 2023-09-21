using Memory.Enums;
using Memory.Views.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Memory.ViewModels
{
    public class CuteThemeViewModel : GameViewModel
    {
        public CuteThemeViewModel()
        {
            FillListOfImages();
            CreateMemoryBoard();
            ShuffleCards();
            StartTimer();
        }

        protected override void CreateMemoryBoard()
        {

            MemoryCards = new ObservableCollection<CardComponent>();

            for (int y = 0; y < MemorySize; y++)
            {
                var piece = new CardComponent();

                piece.Id = y;
                piece.CardStatus = CardStatus.CuteCardDown;
                piece.Picture = Images[y];
                MemoryCards.Add(piece);
            }
        }

        protected override async void CheckForMatch()
        {
            isMatchingInProgress = true;
            NumberOfTries++;
            Tries = $"Antal försök: {NumberOfTries}";


            if (SelectedCards.ElementAt(0).Picture == SelectedCards.ElementAt(1).Picture)
            {
                await Task.Delay(800);
                foreach (CardComponent card in SelectedCards)
                {
                    card.CardStatus = CardStatus.CardUp;
                    card.Visibility = Visibility.Hidden;
                }
                CheckForGameFinished();
            }
            else
            {
                await Task.Delay(1000);
                foreach (CardComponent card in SelectedCards)
                {
                    card.CardStatus = CardStatus.CuteCardDown;
                }
            }
            isMatchingInProgress = false;
            SelectedCards.Clear();
        }

        protected void FillListOfImages()
        {
            Images = new ObservableCollection<Uri>()
            {
                new Uri("pack://application:,,,/Memory;component/Images/Cute/Bunny.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Cute/Bunny.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Cute/Chicken.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Cute/Chicken.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Cute/Icecream.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Cute/Icecream.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Cute/Lolipop.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Cute/Lolipop.jpg"),
            };
        }
    }
}
