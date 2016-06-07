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

namespace iCodeMobile.Fragments.Clientes
{
    public class FragmentListarClientes : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static FragmentListarClientes NewInstance()
        {
            var fragListarClientes = new FragmentListarClientes {Arguments = new Bundle()};
            return fragListarClientes;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_clientes_listar_cliente, null);
        }
    }
}