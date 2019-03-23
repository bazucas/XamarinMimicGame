using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XamarinMimicGame.Annotations;

namespace XamarinMimicGame.ViewModel
{
    public class GameViewModel: INotifyPropertyChanged
    {
        private byte _wordPoints;
        public byte WordPoints
        {
            get => _wordPoints;
            set
            {
                _wordPoints = value;
                OnPropertyChanged(nameof(WordPoints));
            }
        }

        private string _word;
        public string Word
        {
            get => _word;
            set
            {
                _word = value;
                OnPropertyChanged(nameof(Word));
            }
        }

        private string _wordCount;
        public string WordCount
        {
            get => _wordCount;
            set
            {
                _wordCount = value;
                OnPropertyChanged(nameof(WordCount));
            }
        }

        private bool _isVisibleCountContainer;
        public bool IsVisibleCountContainer
        {
            get => _isVisibleCountContainer;
            set
            {
                _isVisibleCountContainer = value;
                OnPropertyChanged(nameof(IsVisibleCountContainer));
            }
        }

        private bool _isVisibleStartContainer;
        public bool IsVisibleStartContainer
        {
            get => _isVisibleStartContainer;
            set
            {
                _isVisibleStartContainer = value;
                OnPropertyChanged(nameof(IsVisibleStartContainer));
            }
        }

        private bool _isVisibleBtnShow;
        public bool IsVisibleBtnShow
        {
            get => _isVisibleBtnShow;
            set
            {
                _isVisibleBtnShow = value;
                OnPropertyChanged(nameof(IsVisibleBtnShow));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command ShowWord { get; set; }
        public Command Success { get; set; }
        public Command Fail { get; set; }
        public Command Start { get; set; }

        public GameViewModel()
        {
            IsVisibleCountContainer = false;
            IsVisibleStartContainer = false;
            IsVisibleBtnShow = true;
            Word = "***********";

            ShowWord = new Command(ShowWordAction);
            Success = new Command(ShowWordAction);
            Fail = new Command(ShowWordAction);
            Start = new Command(StartAction);
        }

        private void ShowWordAction()
        {
            WordPoints = 3;
            Word = "Bark";
            IsVisibleBtnShow = false;
            IsVisibleStartContainer = true;
        }

        private void StartAction()
        {
            IsVisibleStartContainer = false;
            IsVisibleCountContainer = true;

            var i = Persistance.DataPersistance.Game.WordTime;
            Device.StartTimer(TimeSpan.FromSeconds(1), () => 
            {
                WordCount = i.ToString();
                i--;
                return true;
            });
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
