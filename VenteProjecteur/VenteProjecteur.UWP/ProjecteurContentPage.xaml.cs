using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VenteProjecteur.UWP
{

    public class ListeItem
    {
        public string Image { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Prix { get; set; }
        public string Marque { get; set; }
    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjecteurContentPage : ContentPage
    {
        public ProjecteurContentPage()
        {
            InitializeComponent();

            InitControles();
        }

        private void InitControles()
        {
            var listView = new ListView();

            listView.ItemsSource = new ListeItem[]
            {
                new ListeItem { Image = "Images/Projecteuracer.PNG", Titre = "Predator Z650",
                    Description=" vidéoprojecteurs bureautique, home-cinéma et gaming", Prix="$1600.00",Marque = "Acer"},
                new ListeItem { Image = "Images/Projecteurbenq.PNG", Titre = "W2000",
                    Description="une référence pour les projecteurs home-cinéma milieu de gamme",
                    Prix ="$1500.00",Marque = "Benq"},
                new ListeItem { Image = "Images/Projecteurepson.PNG", Titre = "EH-TW7300",
                    Description="N°1 mondial des fabriquants de vidéoprojecteurs", Prix="$3800.18",Marque = "Epson"},
                new ListeItem { Image = "Images/Projecteuroptoma.PNG", Titre = "HD142X",
                    Description=" de nombreux modèles petits et moyens budgets", Prix="$1005.00",Marque = "Optoma"},
                new ListeItem { Image = "Images/Projecteursony.PNG", Titre = "VPL-VW550ES",
                    Description=" modèles home cinéma haut de gamme", Prix="$3200.05",Marque = "Sony"}
            };

            listView.RowHeight = 80;
            listView.BackgroundColor = Color.Black;
            listView.ItemTemplate = new DataTemplate(typeof(ListeItemCell));
            Content = listView;

            listView.ItemTapped += async (sender, e) =>
            {
                ListeItem item = (ListeItem)e.Item;
                await DisplayAlert("Marque", item.Marque.ToString(), "OK");
                ((ListView)sender).SelectedItem = null; // Pour enlever la sélection
            };

        }

        public class ListeItemCell : ViewCell
        {
            public ListeItemCell()
            {
                Label titreLabel = new Label
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    FontSize = 25,
                    FontAttributes = Xamarin.Forms.FontAttributes.Bold,
                    TextColor = Color.White
                };

                titreLabel.SetBinding(Label.TextProperty, "Titre");

                Label descLabel = new Label
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    FontSize = 12,
                    TextColor = Color.White
                };

                descLabel.SetBinding(Label.TextProperty, "Description");

                StackLayout viewLayoutItem = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Children = { titreLabel, descLabel }
                };

                Label prixLabel = new Label
                {
                    HorizontalOptions = LayoutOptions.End,
                    FontSize = 25,
                    TextColor = Color.Aqua
                };

                prixLabel.SetBinding(Label.TextProperty, "Prix");

                StackLayout viewLayout = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(25, 10, 55, 15),
                    Children = { viewLayoutItem, prixLabel }
                };

                View = viewLayout;
            }

        }
    }

}