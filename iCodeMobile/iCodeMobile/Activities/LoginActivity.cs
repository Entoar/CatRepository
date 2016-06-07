using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using iCodeMobile.WebReference;

namespace iCodeMobile.Activities
{
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        #region Declaração de Objetos

        ImageView imageView_Login;
        TextView textView_Login;
        EditText editText_User;
        EditText editText_Password;
        Button button_Login;

        #endregion
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            #region Definição de Objetos

            imageView_Login = FindViewById<ImageView>(Resource.Id.imageView_Login);
            textView_Login = FindViewById<TextView>(Resource.Id.textView_Login);
            editText_User = FindViewById<EditText>(Resource.Id.editText_User);
            editText_Password = FindViewById<EditText>(Resource.Id.editText_Password);
            button_Login = FindViewById<Button>(Resource.Id.button_Login);

            #endregion

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
        }

        private void ServiceOnLoginCompleted(object sender, loginCompletedEventArgs eventArgs)
        {
            button_Login.Enabled = true;

            if (eventArgs.Result == null)
            {
                textView_Login.Text = Resources.GetText(Resource.String.loginInvalid);
                editText_Password.Text = string.Empty;
                return;
            }

            var it = new Intent(this, typeof(MainActivity));
            StartActivity(it);

        }
    }
}