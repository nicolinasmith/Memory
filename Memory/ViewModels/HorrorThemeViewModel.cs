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
    public class HorrorThemeViewModel : GameViewModel
    {
        public HorrorThemeViewModel()
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
                piece.CardStatus = CardStatus.HorrorCardDown;
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
                var soundPlayer = new SoundPlayer(Properties.Resources.Correct);
                soundPlayer.Play();

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
                    card.CardStatus = CardStatus.HorrorCardDown;
                }
                var soundPlayer = new SoundPlayer(Properties.Resources.Wrong);
                soundPlayer.Play();
            }
            isMatchingInProgress = false;
            SelectedCards.Clear();
        }

        protected void FillListOfImages()
        {
            Images = new ObservableCollection<Uri>()
            {
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Clown.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Clown.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/House.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/House.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Skull.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Skull.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Spider.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Spider.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Doll.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Doll.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Hands.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Hands.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Pumpkin.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Pumpkin.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Tree.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Tree.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Murderer.jpg"),
                new Uri("pack://application:,,,/Memory;component/Images/Horror/Murderer.jpg"),
            };
        }
    }
}
