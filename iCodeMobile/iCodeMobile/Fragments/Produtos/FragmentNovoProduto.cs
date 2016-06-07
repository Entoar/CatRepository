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

namespace iCodeMobile.Fragments.Produtos
{
    public class FragmentNovoProduto : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static FragmentNovoProduto NewInstance()
        {
            var fragNovoProduto = new FragmentNovoProduto {Arguments = new Bundle()};
            return fragNovoProduto;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_produtos_novo_produto, null);
        }
    }
}