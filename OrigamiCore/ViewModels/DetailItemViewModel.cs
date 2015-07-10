using Cirrious.MvvmCross.ViewModels;
using OrigamiCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrigamiCore.ViewModels
{
    public class DetailItemViewModel : MvxViewModel
    {
        private OrigamiItem _item;

        public DetailItemViewModel()
        {
        }

        public async void Init(string id)
        {
            Item = await DataProvider.GetItemAsync(id);
        }

        public OrigamiItem Item
        {
            get { return _item; }
            set { _item = value; RaisePropertyChanged(() => Item); }
        }
    }
}