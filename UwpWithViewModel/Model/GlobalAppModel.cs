using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpWithViewModel.Model
{
    public static class GlobalAppModel
    {
        public static ViewModel.AppViewModel AppViewModel { get; set; }

        public static void Init()
        {
            AppViewModel = new ViewModel.AppViewModel();
        }
    }
}
