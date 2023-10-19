using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;
        public MainViewModel(IConnectivity connectivity) 
        {
            items = new ObservableCollection<string>();

            this.connectivity = connectivity;
        }
        
        [ObservableProperty]
        string text;

        [ObservableProperty]
        ObservableCollection<string> items;

        [RelayCommand]
        async Task Add()
        {
            if (string.IsNullOrEmpty(Text))
                return;

            if(connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Oh não!", "Parece que você está sem conexão à internet", "OK");
                return;
            }
            
            //Adiciona o item.
            Items.Add(Text);

            //Reseta o campo de texto.
            Text = string.Empty;
        }

        [RelayCommand]
        void Delete(string item)
        { 
            if(Items.Contains(item) )
            {
                Items.Remove(item);
            }
        }

        [RelayCommand]
        async Task Tap(string item)
        {
            string parameter = $"{nameof(DetailPage)}?Text={item}";
            await Shell.Current.GoToAsync(parameter);
        }
    }
    
}
