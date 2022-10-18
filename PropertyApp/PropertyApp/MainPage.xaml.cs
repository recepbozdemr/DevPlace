using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PropertyApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public List<PropertyType> PropertyTypeList => GetPropertyTypes();
        public List<Property> PropertyList => GetProperties();

        private List<PropertyType> GetPropertyTypes()
        {
            return new List<PropertyType>
            {
                new PropertyType { TypeName = "Hepsi" },
                new PropertyType { TypeName = "İzmir" },
                new PropertyType { TypeName = "İstanbul" },
                new PropertyType { TypeName = "Ankara" },
                new PropertyType { TypeName = "Eskişehir" }
            };
        }

        private List<Property> GetProperties()
        {
            return new List<Property>
            {
                new Property { Image = "apt1.png", Address = "Bostanlı, Suat Gürbüzer Sk. No:19/A, 35590 Karşıyaka/İzmir", Location = "İzmir", Price = "Varuna Gegin Bostanlı", Bed = "12 MB", Bath = "İçkili", Space = "18:00", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
      new Property { Image = "apt1.png", Address = "Bostanlı, Suat Gürbüzer Sk. No:19/A, 35590 Karşıyaka/İzmir", Location = "İzmir", Price = "Varuna Gegin Bostanlı", Bed = "12 MB", Bath = "İçkili", Space = "18:00", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
      new Property { Image = "apt1.png", Address = "Bostanlı, Suat Gürbüzer Sk. No:19/A, 35590 Karşıyaka/İzmir", Location = "İzmir", Price = "Varuna Gegin Bostanlı", Bed = "12 MB", Bath = "İçkili", Space = "18:00", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
      new Property { Image = "apt1.png", Address = "Bostanlı, Suat Gürbüzer Sk. No:19/A, 35590 Karşıyaka/İzmir", Location = "İzmir", Price = "Varuna Gegin Bostanlı", Bed = "12 MB", Bath = "İçkili", Space = "18:00", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },

            };
        }

        private async void PropertySelected(object sender, EventArgs e)
        {
            var property = (sender as View).BindingContext as Property;
            await this.Navigation.PushAsync(new DetailsPage(property));
        }

        private void SelectType(object sender, EventArgs e)
        {
            var view = sender as View;
            var parent = view.Parent as StackLayout;

            foreach(var child in parent.Children)
            {
                VisualStateManager.GoToState(child, "Normal");
                ChangeTextColor(child, "#707070");
            }

            VisualStateManager.GoToState(view, "Selected");
            ChangeTextColor(view, "#FFFFFF");
        }

        private void ChangeTextColor(View child, string hexColor)
        {
            var txtCtrl = child.FindByName<Label>("PropertyTypeName");

            if (txtCtrl != null)
                txtCtrl.TextColor = Color.FromHex(hexColor);
        }
    }

    public class PropertyType
    {
        public string TypeName { get; set; }
    }

    public class Property
    {
        public string Id => Guid.NewGuid().ToString("N");
        public string PropertyName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Bed { get; set; }
        public string Bath { get; set; }
        public string Space { get; set; }
        public string Details { get; set; }
    }
}
