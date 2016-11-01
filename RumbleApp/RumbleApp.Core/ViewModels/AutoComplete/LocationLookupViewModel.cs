using Acr;
using RumbleApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumbleApp.Core.ViewModels.AutoComplete
{
    public class LocationLookupViewModel : BaseViewModel
    {

        private ObservableCollection<AddressLookup> _items;
        private Command<string> _searchCommand;
        private Command<AddressLookup> _cellSelectedCommand;
        private AddressLookup _selectedItem;

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public ObservableCollection<AddressLookup> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        /// <summary>
        /// Gets the selected cell command.
        /// </summary>
        /// <value>
        /// The selected cell command.
        /// </value>
        public Command<AddressLookup> CellSelectedCommand
        {
            get
            {
                return _cellSelectedCommand ?? (_cellSelectedCommand = new Command<AddressLookup>(parameter => Debug.WriteLine(parameter.Address)));
            }
        }

        /// <summary>
        /// Gets the search command.
        /// </summary>
        /// <value>
        /// The search command.
        /// </value>
        public Command<string> SearchCommand
        {
            get
            {
                //if (SearchTerm.Length > 5)
                //{
                // do google lookup here if more than 4 characters have been entered
                return _searchCommand ?? (_searchCommand = new Command<string>(
                    obj => { },
                    obj => !string.IsNullOrEmpty(obj.ToString())));
                //}
                //else return "";
            }
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>The selected item.</value>
        public AddressLookup SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public string SearchTerm { get; set; }

        private ILocationServices Loc { get; set; }

        public LocationLookupViewModel(ILocationServices _loc)
        {
            Items = new ObservableCollection<AddressLookup>();
            Loc = _loc;
        }

    
        public async void GetItems(string search)
        {
            _items.Clear();
           var addresses =  await Loc.GetAddressesAsync(search);
            foreach(var loc in addresses.predictions)
            {
                _items.Add(new AddressLookup() { Address = loc.description });
            }
            OnPropertyChanged("Items");
        }
    }

    public class AddressLookup
    {
        public string Address { get; set; }
    }
}