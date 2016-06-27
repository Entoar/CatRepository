using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace iCodeMobile.Fragments
{
    public class FragmentPDV : Android.Support.V4.App.Fragment
    {
        Button button_SelectClient;
       
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static FragmentPDV NewInstance()
        {
            var fragPDV = new FragmentPDV {Arguments = new Bundle()};
            return fragPDV;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View v = inflater.Inflate(Resource.Layout.fragment_pdv, null);

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            button_SelectClient = v.FindViewById<Button>(Resource.Id.button_SelectClient);
            
            return v;
        }

    }
}