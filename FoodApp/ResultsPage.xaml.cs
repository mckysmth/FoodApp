using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.Model;
using FoodApp.Services;
using Xamarin.Forms;

namespace FoodApp
{
    public partial class ResultsPage : ContentPage
    {
        private Group group;

        public ResultsPage()
        {
            InitializeComponent();
        }

        public ResultsPage(Group group)
        {
            InitializeComponent();

            this.group = group;

            Device.StartTimer(TimeSpan.FromSeconds(10),  () => 
            {
                Findresults();

                return true;
            });

        }

        private async void Findresults()
        {
            if (await EveryoneIsDoneAsync())
            {
                Place place = await AzureService.GetWinningPlace(group);
                ResultsPlease.Text = place.Name;
            }
        }

        private async System.Threading.Tasks.Task<bool> EveryoneIsDoneAsync()
        {
            return await AzureService.EveryoneIsDoneAsync(group);

        }
    }
}
