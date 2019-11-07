using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace AndroidEmpty
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Creación de objetos traidos desde la vista
            Button btn = FindViewById<Button>(Resource.Id.btnConvertir); //Así llamo el objecto al codigo
            EditText txt = FindViewById<EditText>(Resource.Id.txtTelefono);
            TextView lbl = FindViewById<TextView>(Resource.Id.lblConvertido);
            SeekBar SeekBar = FindViewById<SeekBar>(Resource.Id.seekBar1);
            CalendarView calendario = new CalendarView(this);
            calendario.DateChange += Calendario_DateChange;
            //Evento clickdel botton
            btn.Click += (sender, e) =>
            {
                lbl.Text = "Hoola carajitos del señor xd";
                string translatedText = PhoneTranslator.ToNumber(txt.Text);
                if (string.IsNullOrWhiteSpace(translatedText))
                {
                    lbl.Text = string.Empty;
                }
                else
                {
                    lbl.Text = translatedText;
                }


                //Android.App.AlertDialog alerta = new Android.App.AlertDialog.Builder(this).Create();

                //alerta.SetTitle("Erros");
                //alerta.SetMessage("Prueba");
                //alerta.SetButton("Cancelar",
                //            (a, b) =>
                //            {

                //            });
                //alerta.Show();

            };

        }

        private void Calendario_DateChange(object sender, CalendarView.DateChangeEventArgs e)
        {

            throw new System.NotImplementedException();
        }
    }
}