using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamd.ImageCarousel.Forms.Plugin.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace GoldenRhino.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        ObservableCollection<FileImageSource> imageSources = new ObservableCollection<FileImageSource>();
        public HomePage()
        {
            InitializeComponent();

            imageSources.Add("ic_about.png");
            imageSources.Add("ic_contact.png");
            imageSources.Add("ic_games.png");

            imgSlider.Images = imageSources;
        }

        async private  void Article3Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("New Games", "There are new games that have come out recently, please locate to the games page" +
                " using the bottom navbar to go and check out what games they are!", "Stop Reading");

        }

      

        async private void Article1Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("App Launched", "Hello all new and exsiting users, we have successfully launched the Golden Rhino app " +
                "and we will continue to update the app based on feeback and ideas we have", "Stop Reading");
        }

        async private void Article2Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("10 Members", "Hello users, we have recently reached our first milestone since release and " +
                "that is reaching 10 members that have registered to the app", "Stop Reading");
        }
    }
}