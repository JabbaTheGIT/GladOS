using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Content;
using Android.Util;
using Gcm.Client;
using WindowsAzure.Messaging;
using System;
using gladOS.Droid.Views;
using gladOS.Droid.Models;
using Microsoft.WindowsAzure.MobileServices;

using Newtonsoft.Json.Linq;
using gladOS.Core.Models;
using MvvmCross.Droid.Views;
using Android.Views;

[assembly: Permission(Name = "com.glados.droid.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.glados.droid.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]

//GET_ACCOUNTS is needed only for Android versions 4.0.3 and below
[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]

namespace gladOS.Droid.Models
{ 
    [BroadcastReceiver(Permission = Gcm.Client.Constants.PERMISSION_GCM_INTENTS)]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_MESSAGE },
        Categories = new string[] { "com.glados.droid" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK },
        Categories = new string[] { "com.glados.droid" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_LIBRARY_RETRY },
        Categories = new string[] { "com.glados.droid" })]
    public class MyBroadcastReceiver : GcmBroadcastReceiverBase<PushHandlerService>
    {
        public static string[] senderIDs = new string[] { "600438788299" };
    }

    [Service]
    public class PushHandlerService : GcmServiceBase
    {
        public static string RegistrationID { get; private set; }
        public PushHandlerService() : base(MyBroadcastReceiver.senderIDs) { }

        public void pushNotification()
        {
            MobileServiceClient client = HomeView.CurrentActivity.CurrentClient;
        }

        protected override void OnRegistered(Context context, string registrationId)
        {
            System.Diagnostics.Debug.WriteLine("The device has been registered with GCM.", "Success!");

            // Get the MobileServiceClient from the current activity instance.
            MobileServiceClient client = HomeView.CurrentActivity.CurrentClient;
            var push = client.GetPush();

            // Define a message body for GCM.
            const string templateBodyGCM = "{\"data\":{\"message\":\"$(messageParam)\"}}";

            // Define the template registration as JSON.
            JObject templates = new JObject();
            templates["genericMessage"] = new JObject
            {
                 {"body", templateBodyGCM }
            };

            try
            {
                // Make sure we run the registration on the same thread as the activity, 
                // to avoid threading errors.
                HomeView.CurrentActivity.RunOnUiThread
                    (
                    // Register the template with Notification Hubs.
                    async () => await push.RegisterAsync(registrationId, templates)
                    );

                System.Diagnostics.Debug.WriteLine(
                    string.Format("Push Installation Id", push.InstallationId.ToString()));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    string.Format("Error with Azure push registration: {0}", ex.Message));
            }
        }

        protected override void OnMessage(Context context, Intent intent)
        {
            string message = string.Empty;
            PendingIntent intender =
                PendingIntent.GetActivity(context, 0,
                new Intent(this, typeof(HomeView)), 0);
            // Extract the push notification message from the intent.
            if (intent.Extras.ContainsKey("message"))
            {
                message = intent.Extras.Get("message").ToString();
                var title = "Message";

                if (message.StartsWith(GlobalLocalPerson.Name + "."))
                {
                    string info = message.Length.ToString();
                    GlobalLocalPerson.Message = info;
                    // Create a notification manager to send the notification.
                    var notificationManager =
                        GetSystemService(Context.NotificationService) as NotificationManager;

                    // Create a new intent to show the notification in the UI.
                    if (message.EndsWith("location ."))
                    {
                        PendingIntent contentIntent =
                            PendingIntent.GetActivity(context, 0,
                            new Intent(this, typeof(PublishLocationView)), 0);
                        intender = contentIntent;
                    }
                    if (message.EndsWith("number ."))
                    {
                        PendingIntent contentIntent =
                            PendingIntent.GetActivity(context, 0,
                            new Intent(this, typeof(ScanBarcodeView)), 0);
                        intender = contentIntent;
                    }


                    // Create the notification using the builder.
                    var builder = new Notification.Builder(context);
                    builder.SetAutoCancel(true);
                    builder.SetContentTitle(title);
                    builder.SetContentText(message);
                    builder.SetSmallIcon(Android.Resource.Drawable.SymActionEmail);
                    builder.SetContentIntent(intender);
                    var notification = builder.Build();

                    // Display the notification in the Notifications Area.
                    notificationManager.Notify(1, notification);
                }

            }
        }


        protected override void OnUnRegistered(Context context, string registrationId)
        {
            throw new NotImplementedException();
        }

        protected override void OnError(Context context, string errorId)
        {
            System.Diagnostics.Debug.WriteLine(
                string.Format("Error occurred in the notification: {0}.", errorId));
        }
    }       
 }
