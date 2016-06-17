using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.IO;

namespace iCodeMobile.Model
{
    public class DialogFragmentClient : DialogFragment
    {
        GridView lv_teste;
        SearchView sv_teste;
        ArrayAdapter adp;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.listarclientes, container, false);

            lv_teste = v.FindViewById<GridView>(Resource.Id.lv_teste);

            sv_teste = v.FindViewById<SearchView>(Resource.Id.sv_teste);

            sv_teste.QueryTextChange += (sender, args) =>
            {
                var service = new WebReference.Service();
                service.ListaClienteAsync(args.NewText);
                service.ListaClienteCompleted += (o, eventArgs) =>
                {
                    List<string> Dados = new List<string>();

                    foreach (var clienteFornecedor in eventArgs.Result)
                    {
                        Dados.Add(clienteFornecedor.cliente_fornecedor_id.ToString() + " - " + clienteFornecedor.cliente_fornecedor_nome);
                    } 

                    adp = new ArrayAdapter(Activity, Android.Resource.Layout.SimpleListItem1,Dados);
                    lv_teste.Adapter = adp;
                };
            };

            return v;
        }
    }
}