using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using iCodeMobile.WebReference;
using DialogFragment = Android.Support.V4.App.DialogFragment;
using SearchView = Android.Widget.SearchView;

namespace iCodeMobile.Fragments
{
    public class FragmentListarClientes : DialogFragment
    {
        SearchView sv_teste;
        ListView lv_teste;
        ArrayAdapter adp;
        List<string> dataList; 
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View v = inflater.Inflate(Resource.Layout.listarclientes, null);

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            Dialog.SetTitle(Resources.GetText(Resource.String.titleFragmentListarClientes));
            
            sv_teste = v.FindViewById<SearchView>(Resource.Id.sv_teste);
            lv_teste = v.FindViewById<ListView>(Resource.Id.lv_teste);

           

            sv_teste.QueryTextChange += delegate(object sender, SearchView.QueryTextChangeEventArgs args)
            {
                var service = new WebReference.Service();
                service.ListaClienteAsync(args.NewText.ToUpper());
                service.ListaClienteCompleted+=ServiceOnListaClienteCompleted;
            };

            return v;
        }

        private void ServiceOnListaClienteCompleted(object sender, ListaClienteCompletedEventArgs eventArgs)
        {
            List<string> dataList = eventArgs.Result.Select(clienteFornecedor => clienteFornecedor.cliente_fornecedor_id + " - " + clienteFornecedor.cliente_fornecedor_nome).ToList();

            adp = new ArrayAdapter(Activity, Android.Resource.Layout.SimpleListItem1, dataList);

            lv_teste.Adapter = adp;
            lv_teste.ItemClick += delegate(object o, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(Activity, dataList[args.Position].ToString(), ToastLength.Short);
            };

        }
    }
}