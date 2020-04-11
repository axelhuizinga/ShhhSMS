﻿using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using ShhhSMS.Services;

namespace ShhhSMS.Fragments
{
    public class ReaderFragment : Fragment
    {
        private string _messageText;

        // TODO: Replace with IOC
        IEncryptionService encryptionService;

        public ReaderFragment()
        {
            encryptionService = new EncryptionService();

            _messageText = "No Message";
        }

        public ReaderFragment(string messageText)
        {

            encryptionService = new EncryptionService();

            _messageText = messageText;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rootView = inflater.Inflate(Resource.Layout.reader, container, false);

            var messageText = rootView.FindViewById<TextView>(Resource.Id.messageText);
            messageText.Text = encryptionService.DecryptMessage(_messageText).GetAwaiter().GetResult();

            return rootView;
        }
    }
}