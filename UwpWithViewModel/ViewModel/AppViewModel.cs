using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UwpWithViewModel.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Busy

        public event EventHandler ShowBusy;
        public event EventHandler HideBusy;
        public void OnShowBusy()
        {
            ShowBusy?.Invoke(new object(), new EventArgs());
        }
        public void OnHideBusy()
        {
            HideBusy?.Invoke(new object(), new EventArgs());
        }

        #endregion
        
        public ObservableCollection<Model.SongModel> Songlist { get; set; }

        public async Task Init()
        {
            OnShowBusy();

            await Task.Run(() => LoadSongs());
            await Task.Delay(1000);

            OnHideBusy();
        }

        void LoadSongs()
        {
            Songlist = new ObservableCollection<Model.SongModel>
            {
                new Model.SongModel() { Name = "M1", Path = "ms-appx:///Assets/Track01.mp3" },
                new Model.SongModel() { Name = "M2", Path = "ms-appx:///Assets/Track01.mp3" },
                new Model.SongModel() { Name = "M3", Path = "ms-appx:///Assets/Track01.mp3" },
                new Model.SongModel() { Name = "M4", Path = "ms-appx:///Assets/Track01.mp3" },
                new Model.SongModel() { Name = "M5", Path = "ms-appx:///Assets/Track01.mp3" },
                new Model.SongModel() { Name = "M6", Path = "ms-appx:///Assets/Track01.mp3" },
                new Model.SongModel() { Name = "M7", Path = "ms-appx:///Assets/Track01.mp3" },
                new Model.SongModel() { Name = "M8", Path = "ms-appx:///Assets/Track01.mp3" },
                new Model.SongModel() { Name = "M9", Path = "ms-appx:///Assets/Track01.mp3" },
                new Model.SongModel() { Name = "M10", Path = "ms-appx:///Assets/Track01.mp3" },
            };
        }


        public delegate void SongChangedEventHandler(Model.SongModel song, EventArgs args);

        public event SongChangedEventHandler PlaySong;
        public void OnPlaySong(Model.SongModel song)
        {
            PlaySong?.Invoke(song, new EventArgs());
        }

        public event EventHandler Pause;
        public void OnPause()
        {
            Pause?.Invoke(new object(), new EventArgs());
        }

        public event EventHandler Play;
        public void OnPlay()
        {
            Play?.Invoke(new object(), new EventArgs());
        }
    }
}
