using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using iCodeMobile.Static;
using iCodeMobile.WebReference;

namespace iCodeMobile.Activities
{
    [Activity(Label = "iCode Mobile", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        #region Declaração de Componentes

        ImageView imageView_Login;
        ProgressBar progressBar_Login;
        CheckBox checkBox_Login;
        TextView textView_Login;
        EditText editText_User;
        EditText editText_Password;
        Button button_Login;

        #endregion
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            #region Definição de Componentes

            imageView_Login = FindViewById<ImageView>(Resource.Id.imageView_Login);
            textView_Login = FindViewById<TextView>(Resource.Id.textView_Login);
            editText_User = FindViewById<EditText>(Resource.Id.editText_User);
            editText_Password = FindViewById<EditText>(Resource.Id.editText_Password);
            button_Login = FindViewById<Button>(Resource.Id.button_Login);
            progressBar_Login = FindViewById<ProgressBar>(Resource.Id.progressBar_Login);
            checkBox_Login = FindViewById<CheckBox>(Resource.Id.checkBox_Login);

            #endregion
            progressBar_Login.Visibility = ViewStates.Invisible;
            button_Login.Click += ButtonLoginOnClick;
        }

        private void ButtonLoginOnClick(object sender, EventArgs eventArgs)
        {
            if (editText_User.Text == string.Empty)
            {
                textView_Login.Text = Resources.GetText(Resource.String.userEmpty);
                editText_User.Focusable = true;
                return;
            }

            if (editText_Password.Text == string.Empty)
            {
                textView_Login.Text = Resources.GetText(Resource.String.passwordEmpty);
                editText_Password.Focusable = true;
                return;
            }

            var service = new WebReference.Service();
            service.loginCompleted += ServiceOnLoginCompleted;
            service.loginAsync(editText_User.Text, editText_Password.Text);
            textView_Login.Text = Resources.GetText(Resource.String.validating);
            button_Login.Enabled = false;
            progressBar_Login.Visibility = ViewStates.Visible;
        }

        public void ServiceOnLoginCompleted(object sender, loginCompletedEventArgs eventArgs)
        {
            button_Login.Enabled = true;
            if (eventArgs.Result == null)
            {
                textView_Login.Text = Resources.GetText(Resource.String.loginInvalid);
                editText_Password.Text = string.Empty;
                editText_Password.Focusable = false;
                editText_Password.Focusable = false;
                return;
            }

            Session.UsuarioLogado = eventArgs.Result;
            
            var it = new Intent(this, typeof(MainActivity));

            this.StartActivity(it);
            this.OverridePendingTransition(Resource.Animation.abc_slide_in_top, Resource.Animation.abc_slide_in_bottom);

        }

    }
}