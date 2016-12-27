
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Image img = new Image
            {
                HeightRequest = 200,
                Source = "https://uat.performax360.com/Assets/images/performax.png"
            };

            Entry Email = new Entry
            {
                Placeholder = "Email"
            };
            Entry password = new Entry
            {
                IsPassword = true,
                Placeholder = "password"
            };
            Button button = new Button
            {

                Text = "Login",
                BackgroundColor = Color.FromHex("#169bd5")
            };

            Label label = new Label
            {

                Text = "Don't Have An Account Yet.",

            };
            Label registerLabel = new Label
            {
                FontAttributes = FontAttributes.Bold,
                Text = "REGISTER NOW",

            };



            registerLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                //Command = new Command(() => Navigation.PushAsync(new AboutPage())),
                Command = new Command(() => DisplayAlert("Register", "Can be redirected to some register page", "OK"))
            });
            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            StackLayout myStackLayout = new StackLayout
            {
                Children = {
                label,registerLabel
                 },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            var p = new PopupLayout
            {
                Content = new StackLayout
                {
                    Children =
                {
                  img,Email,
                    password,button,myStackLayout
                 }
                }
            };

            this.Content = p;

            Label notificationLabel = new Label
            {
                Text = "Notifications"
            };

            Button notificationButton = new Button
            {

                Text = "Close",
                BackgroundColor = Color.FromHex("169bd5")
            };
            notificationButton.Clicked += delegate
            {
                p.DismissPopup();
            };
            var customcell = new DataTemplate(typeof(CustomCell));
            List<Notification> Notifications = new List<Notification>();
            Notification a = new Notification();
            a.Heading = "Heading";
            a.Description = "Description";
            a.ImageUri = "https://uat.performax360.com/Assets/images/performax.png";
            NotificationViewModel vm = new NotificationViewModel();
            for (int i = 0; i < 15; i++)
                Notifications.Add(a);

            ListView list = new ListView
            {
                ItemTemplate = customcell
        
            };
            Button clearAll = new Button
            {
                Text = "Clear All"
            };
            clearAll.Clicked += delegate
            {
                list.ItemsSource = null;
                clearAll.IsVisible = false;
            };
            Frame frame = new Frame
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        notificationLabel,list,notificationButton,clearAll
                    }
                }
            };
            StackLayout layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                WidthRequest = App.ScreenWidth - 20,
                HeightRequest = App.ScreenHeight - 40,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("#D2FFFF"),
                Children =
                {
                   frame
                }
            };
            button.Clicked += delegate
            {
                var username = Email.Text;
                var passWord = password.Text;
                list.ItemsSource = vm.Notifications;
                clearAll.IsVisible = true;
                p.ShowPopup(layout);
            };
        }
    }
}
