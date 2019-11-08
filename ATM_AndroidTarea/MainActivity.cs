using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace ATM_AndroidTarea
{

    public class User
    {
        public string username { get; set; }
        public string pass { get; set; }
        public double pisto { get; set; }
    }

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        List<User> usuarios;
        User usuarioLogin;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            usuarios = new List<User>
            {
                new User
                {
                    pass="1234",
                    username="RonaldRis",
                    pisto=10000
                },
                new User
                {
                    pass="2525",
                    username="Nelsón",
                    pisto=500
                },
                new User
                {
                    pass="1230",
                    username="Bryan",
                    pisto=1000
                }
            };

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);


            //Inicializo las variables
            LinearLayout layoutLogin = FindViewById<LinearLayout>(Resource.Id.linearLayoutLogin);
            RelativeLayout layoutPist = FindViewById<RelativeLayout>(Resource.Id.relativeLayout1);

            FloatingActionButton fabin = FindViewById<FloatingActionButton>(Resource.Id.fabin);
            FloatingActionButton fabout = FindViewById<FloatingActionButton>(Resource.Id.fabout);

            Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);

            EditText txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            EditText txtpass = FindViewById<EditText>(Resource.Id.txtPass);
            EditText txtPisto = FindViewById<EditText>(Resource.Id.txtCantPisto);

            TextView lblLogin = FindViewById<TextView>(Resource.Id.lblLogin);
            TextView lblUsername = FindViewById<TextView>(Resource.Id.lblUsername);
            TextView lblpisto = FindViewById<TextView>(Resource.Id.lblPistoTotal);


            layoutLogin.Visibility = ViewStates.Visible;
            layoutPist.Visibility = ViewStates.Invisible;

            fabin.Click += (sender, e) =>
            {

                Android.App.AlertDialog alerta = new Android.App.AlertDialog.Builder(this).Create();
                double cant = Convert.ToDouble(txtPisto.Text);
                alerta.SetTitle("Deposito");
                alerta.SetMessage("$ " + cant);
                alerta.Show();
                usuarioLogin.pisto += cant;
                txtPisto.Text = "";

                lblpisto.Text = $"Cantidad total $ {usuarioLogin.pisto:N2}";
            };
            fabout.Click += (sender, e) =>
            {
                double cant = Convert.ToDouble(txtPisto.Text);
                Android.App.AlertDialog alerta = new Android.App.AlertDialog.Builder(this).Create();
                if (cant <= usuarioLogin.pisto)
                {

                    alerta.SetTitle("Retiro");
                    alerta.SetMessage("$ " + cant);
                    alerta.Show();
                    usuarioLogin.pisto -= cant;
                    txtPisto.Text = "";
                }
                else
                {
                    alerta.SetTitle("Error");
                    alerta.SetMessage("No hay fondos suficientes");
                    alerta.Show();
                }
                lblpisto.Text = $"Cantidad total $ {usuarioLogin.pisto:N2}";

            };
            btnLogin.Click += (sender, e) =>
            {

                var user = usuarios.Find(u => u.username == txtUsername.Text);
                if (user == null)
                {
                    lblLogin.Text = "No existe el usuario";
                    return;
                }
                if (user.pass != txtpass.Text)
                {
                    lblLogin.Text = "Contraseña incorrecta";
                    return;
                }

                usuarioLogin = user;
                lblUsername.Text = usuarioLogin.username;
                lblpisto.Text = $"Cantidad total $ {usuarioLogin.pisto:N2}";

                layoutLogin.Visibility = ViewStates.Invisible;
                layoutPist.Visibility = ViewStates.Visible;

            };
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }


    }
}

