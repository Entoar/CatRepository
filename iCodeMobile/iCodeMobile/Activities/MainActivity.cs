using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Support.Design.Widget;
using iCodeMobile.Fragments.Clientes;
using iCodeMobile.Fragments.PDV;
using iCodeMobile.Fragments.Produtos;

namespace iCodeMobile.Activities
{
    [Activity(Label = "iCode Mobile",LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/Icon")]
    public class MainActivity : BaseActivity
    {

        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.main;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            drawerLayout = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            //Set hamburger items menu
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            //setup navigation view
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            //handle navigation
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);

                switch (e.MenuItem.ItemId)
                {
                    //PDV - Pedido de Vendas
                    case Resource.Id.nav_home_pdv:
                        ListItemClicked(0);
                        break;
                    case Resource.Id.nav_home_pdv_novo_pedido:
                        ListItemClicked(1);
                        break;
                    case Resource.Id.nav_home_pdv_listar_pedido:
                        ListItemClicked(2);
                        break;
                    //Produtos
                    case Resource.Id.nav_home_prdoutos:
                        ListItemClicked(3);
                        break;
                    case Resource.Id.nav_home_produtos_novo_produto:
                        ListItemClicked(4);
                        break;
                    case Resource.Id.nav_home_produtos_listar_produto:
                        ListItemClicked(5);
                        break;
                    //Clientes
                    case Resource.Id.nav_home_clientes:
                        ListItemClicked(6);
                        break;
                    case Resource.Id.nav_home_clientes_novo_cliente:
                        ListItemClicked(7);
                        break;
                    case Resource.Id.nav_home_clientes_listar_cliente:
                        ListItemClicked(8);
                        break;

                }

                Snackbar.Make(drawerLayout, "Você selecionou o menu: " + e.MenuItem.TitleFormatted, Snackbar.LengthLong)
                    .Show();

                drawerLayout.CloseDrawers();
            };


            //if first time you will want to go ahead and click first item.
            if (savedInstanceState == null)
            {
                ListItemClicked(0);
            }
        }

        int oldPosition = -1;
        private void ListItemClicked(int position)
        {
            //this way we don't load twice, but you might want to modify this a bit.
            if (position == oldPosition)
                return;

            oldPosition = position;

            Android.Support.V4.App.Fragment fragment = null;
            switch (position)
            {
                //PDV - Pedido de Vendas
                case 0:
                    fragment = FragmentPDV.NewInstance();
                    break;
                case 1:
                    fragment = FragmentNovoPedido.NewInstance();
                    break;
                case 2:
                    fragment = FragmentListarPedidos.NewInstance();
                    break;
                
                //Produtos
                case 3:
                    fragment = FragmentProdutos.NewInstance();
                    break;
                case 4:
                    fragment = FragmentNovoProduto.NewInstance();
                    break;
                case 5:
                    fragment = FragmentListarProdutos.NewInstance();
                    break;

                //Clientes
                case 6:
                    fragment = FragmentClientes.NewInstance();
                    break;
                case 7:
                    fragment = FragmentNovoCliente.NewInstance();
                    break;
                case 8:
                    fragment = FragmentListarClientes.NewInstance();
                    break;
            }

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

