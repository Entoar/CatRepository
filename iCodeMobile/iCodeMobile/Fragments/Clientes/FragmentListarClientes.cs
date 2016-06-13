using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using Android.OS;
using Android.Views;
using Android.Widget;
using iCodeMobile.WebReference;

namespace iCodeMobile.Fragments.Clientes
{
    public class FragmentListarClientes : Android.Support.V4.App.Fragment
    {
        ListView listView_ListarClientes;
        SearchView searchView_ListarClientes;
        ArrayAdapter adp;
        
       

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static FragmentListarClientes NewInstance()
        {
            var fragListarClientes = new FragmentListarClientes { Arguments = new Bundle() };

            return fragListarClientes;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.fragment_clientes_listar_cliente, null);

            searchView_ListarClientes = (SearchView)view.FindViewById(Resource.Id.searchView_ListarClientes);
            listView_ListarClientes = (ListView)view.FindViewById(Resource.Id.listView_ListarClientes);
           
            searchView_ListarClientes.QueryTextChange +=SearchViewListarClientesOnQueryTextChange;

            return view;
        }

        private void SearchViewListarClientesOnQueryTextChange(object sender, SearchView.QueryTextChangeEventArgs queryText)
        {
            var service = new WebReference.Service();

            service.ListaClienteAsync(queryText.NewText);
            service.ListaClienteCompleted += ServiceOnListaClienteCompleted;
        }

        private void ServiceOnListaClienteCompleted(object sender, ListaClienteCompletedEventArgs EventArgs)
        {
            List<string> dados = new List<string>();

            foreach (var clienteFornecedor in EventArgs.Result)
            {
                dados.Add(clienteFornecedor.cliente_fornecedor_id.ToString() + " - " + clienteFornecedor.cliente_fornecedor_nome);
            }
            adp = new ArrayAdapter(Activity,Android.Resource.Layout.SimpleListItem1,dados);
            listView_ListarClientes.Adapter = adp;
        }
    }
}