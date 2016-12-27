using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sample
{
    public class CustomCell:ViewCell
    {
        public CustomCell()
        {
            var image = new Image();
            StackLayout cellWrapper = new StackLayout();
            StackLayout horizontalLayout = new StackLayout();

            Label left = new Label();
            Label right = new Label();

            //set bindings
            left.SetBinding(Label.TextProperty, "Heading");
            right.SetBinding(Label.TextProperty, "Description");
            image.SetBinding(Image.SourceProperty, "ImageUri");

            //Set properties for desired design
            cellWrapper.BackgroundColor = Color.FromHex("#eee");
            horizontalLayout.Orientation = StackOrientation.Horizontal;
            right.HorizontalOptions = LayoutOptions.EndAndExpand;
            left.TextColor = Color.FromHex("#f35e20");
            right.TextColor = Color.FromHex("503026");

            //add views to the view hierarchy
            horizontalLayout.Children.Add(image);
            StackLayout vertical = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children ={
                    left,right
                }
            };
            horizontalLayout.Children.Add(vertical);
            cellWrapper.Children.Add(horizontalLayout);
            View = cellWrapper;
        }
    }
    }

