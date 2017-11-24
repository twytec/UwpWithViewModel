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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UwpWithViewModel.UC
{
    public sealed partial class PlayerControlUC : UserControl
    {
        public ViewModel.AppViewModel ViewModel { get; set; }

        public PlayerControlUC()
        {
            this.InitializeComponent();

            ViewModel = Model.GlobalAppModel.AppViewModel;
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.OnPlay();
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.OnPause();
        }
    }
}
