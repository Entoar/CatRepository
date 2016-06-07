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

namespace iCodeMobile.Fragments.PDV
{
    public class FragmentListarPedidos : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static FragmentListarPedidos NewInstance()
        {
            var fragListarPedidos = new FragmentListarPedidos {Arguments = new Bundle()};
            return fragListarPedidos;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_pdv_listar_pedido, null);
        }

    }
}