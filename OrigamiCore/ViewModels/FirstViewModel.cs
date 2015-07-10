using Cirrious.MvvmCross.ViewModels;
using OrigamiCore.Data;
using System.Collections.Generic;
using System.Linq;

namespace OrigamiCore.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        public List<OrigamiGroup> _items;
        public List<OrigamiGroup> Items
        {
            get
            {
                return _items;
            }
            private set
            {
                _items = value;
                RaisePropertyChanged(() => Items);
            }
        }
        public List<OrigamiItem> _items1;
        public List<OrigamiItem> Items1
        {
            get
            {
                return _items1;
            }
            private set
            {
                _items1 = value;
                RaisePropertyChanged(() => Items1);
            }
        }
        public async void n()
        {
            var items = await DataProvider.GetGroupsAsync();
            _items = items.ToList();
        }
        public FirstViewModel()
        {
            n();
        }
        public System.Windows.Input.ICommand ShowDetailCommand
        {
            get
            {
                return new MvxCommand<OrigamiItem>(item => ShowViewModel<DetailItemViewModel>(new { id = item.UniqueId }));
            }
        }

    }
}

