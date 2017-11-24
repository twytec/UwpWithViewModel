using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace UwpWithViewModel
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            Model.GlobalAppModel.AppViewModel.ShowBusy += (s, e) => { pr.Visibility = Visibility.Visible; pr.IsActive = true; };
            Model.GlobalAppModel.AppViewModel.HideBusy += (s, e) => { pr.Visibility = Visibility.Collapsed; pr.IsActive = false; };

            Model.GlobalAppModel.AppViewModel.PlaySong += AppViewModel_PlaySong;
            Model.GlobalAppModel.AppViewModel.Pause += (s, e) => { player.Pause(); };
            Model.GlobalAppModel.AppViewModel.Play += (s, e) => { player.Play(); };

            Load();
        }

        private void AppViewModel_PlaySong(Model.SongModel song, EventArgs args)
        {
            player.Source = new Uri(song.Path);
            player.Play();
        }

        async void Load()
        {
            await Model.GlobalAppModel.AppViewModel.Init();
        }
    }
}
