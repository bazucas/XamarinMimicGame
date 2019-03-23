using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XamarinMimicGame.Annotations;
using XamarinMimicGame.Model;
using XamarinMimicGame.Persistance;
using XamarinMimicGame.View;
using Game = XamarinMimicGame.View.Game;

namespace XamarinMimicGame.ViewModel
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private bool _isVisibleBtnBtnStart;

        private bool _isVisibleBtnShow;

        private bool _isVisibleCountContainer;

        private string _word;

        private string _wordCount;

        private byte _wordPoints;

        public GameViewModel(Group group)
        {
            Group = group;
            GroupName = group.Name;

            GroupNumber = group == DataPersistance.Game.GroupOne ? "Grupo One " : "Grupo Two ";

            IsVisibleCountContainer = false;
            IsVisibleBtnStart = false;
            IsVisibleBtnShow = true;
            Word = "********";

            ShowWord = new Command(ShowWordAction);
            Success = new Command(SuccessAction);
            Fail = new Command(FailAction);
            Start = new Command(StartAction);
        }

        public Group Group { get; set; }
        public string GroupName { get; set; }
        public string GroupNumber { get; set; }

        public byte WordPoints
        {
            get => _wordPoints;
            set
            {
                _wordPoints = value;
                OnPropertyChanged(nameof(WordPoints));
            }
        }

        public string Word
        {
            get => _word;
            set
            {
                _word = value;
                OnPropertyChanged(nameof(Word));
            }
        }

        public string WordCount
        {
            get => _wordCount;
            set
            {
                _wordCount = value;
                OnPropertyChanged(nameof(WordCount));
            }
        }

        public bool IsVisibleCountContainer
        {
            get => _isVisibleCountContainer;
            set
            {
                _isVisibleCountContainer = value;
                OnPropertyChanged(nameof(IsVisibleCountContainer));
            }
        }

        public bool IsVisibleBtnStart
        {
            get => _isVisibleBtnBtnStart;
            set
            {
                _isVisibleBtnBtnStart = value;
                OnPropertyChanged(nameof(IsVisibleBtnStart));
            }
        }

        public bool IsVisibleBtnShow
        {
            get => _isVisibleBtnShow;
            set
            {
                _isVisibleBtnShow = value;
                OnPropertyChanged(nameof(IsVisibleBtnShow));
            }
        }

        public Command ShowWord { get; set; }
        public Command Success { get; set; }
        public Command Fail { get; set; }
        public Command Start { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ShowWordAction()
        {
            WordPoints = 3;
            Word = "Dream";
            var dif = DataPersistance.Game.Difficulty;
            switch (dif)
            {
                case 0:
                {
                    //Random
                    var rd = new Random();
                    var niv = rd.Next(0, 3);
                    var ind = rd.Next(0, DataPersistance.Words[niv].Length);
                    Word = DataPersistance.Words[niv][ind];
                    WordPoints = (byte) (niv == 0 ? 1 : niv == 1 ? 3 : 5);
                    break;
                }
                case 1:
                {
                    //Easy
                    var rd = new Random();
                    var ind = rd.Next(0, DataPersistance.Words[dif - 1].Length);
                    Word = DataPersistance.Words[dif - 1][ind];
                    WordPoints = 1;
                    break;
                }
                case 2:
                {
                    //Normal
                    var rd = new Random();
                    var ind = rd.Next(0, DataPersistance.Words[dif - 1].Length);
                    Word = DataPersistance.Words[dif - 1][ind];
                    WordPoints = 3;
                    break;
                }
                default:
                {
                    //Hard
                    var rd = new Random();
                    var ind = rd.Next(0, DataPersistance.Words[dif - 1].Length);
                    Word = DataPersistance.Words[dif - 1][ind];
                    WordPoints = 5;
                    break;
                }
            }

            IsVisibleBtnShow = false;
            IsVisibleBtnStart = true;
        }

        private void StartAction()
        {
            IsVisibleBtnStart = false;
            IsVisibleCountContainer = true;

            var i = DataPersistance.Game.WordTime;
            WordCount = i.ToString();
            i--;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                WordCount = i.ToString();
                i--;
                if (i < 0) WordCount = "No time left";
                return true;
            });
        }

        private void SuccessAction()
        {
            Group.Score += WordPoints;

            GoNextGroup();
        }

        private void FailAction()
        {
            GoNextGroup();
        }

        private void GoNextGroup()
        {
            Group group;
            if (DataPersistance.Game.GroupOne == Group)
            {
                group = DataPersistance.Game.GroupTwo;
            }
            else
            {
                group = DataPersistance.Game.GroupOne;
                DataPersistance.CurrentRound++;
            }

            if (DataPersistance.CurrentRound > DataPersistance.Game.Rounds)
                Application.Current.MainPage = new Result();
            else
                Application.Current.MainPage = new Game(group);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}