using Android.App;
using Android.Content;
using Android.Gms.Gcm;
using Android.Gms.Gcm.Iid;
using Android.OS;
using Android.Util;
using Android.Widget;
using Gcm.Client;
using gladOS.Core.Models;
using gladOS.Droid.Models;
using Java.Lang;
using Microsoft.WindowsAzure.MobileServices;
using MvvmCross.Droid.Views;
using System;
using System.Net;

namespace gladOS.Droid.Views
{
    [Activity(Label = "HomeViewModel")]
    public class HomeView : MvxActivity
    {
        public static HomeView instance = new HomeView();

        public static HomeView CurrentActivity
        {
            get
            {
                return instance;
            }
        }

        public MobileServiceClient CurrentClient
        {
            get
            {
                var client = new MobileServiceClient("https://opglados.azurewebsites.net/");
                return client;
            }
        }
        protected override void OnCreate(Bundle bundle)
        {
            instance = this;

            base.OnCreate(bundle);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.HomeView);

            //check setup
            GcmClient.CheckDevice(this);
            GcmClient.CheckManifest(this);
            //register the app for push
            GcmClient.Register(this, Constants.Constants.SenderID);

            ImageView homePicture = FindViewById<ImageView>(Resource.Id.homePicture);

            string name = GlobalLocalPerson.Name;

            switch(name)
            {
                case "Bruce Wayne":
                    homePicture.SetImageResource(Resource.Drawable.brucewayne);
                    break;
                case "John Wayne":
                    homePicture.SetImageResource(Resource.Drawable.johnwayne);
                    break;
                case "Gandalf Grey":
                    homePicture.SetImageResource(Resource.Drawable.gandalf);
                    break;
                case "Winston Churchill":
                    homePicture.SetImageResource(Resource.Drawable.winston);
                    break;
                case "Peter Parker":
                    homePicture.SetImageResource(Resource.Drawable.spiderman);
                    break;
                case "Tony Stark":
                    homePicture.SetImageResource(Resource.Drawable.ironMan);
                    break;
                default:
                    homePicture.SetImageResource(Resource.Drawable.steve);
                    break;
            }
        }

    }
}