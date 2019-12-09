using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;

namespace PhoneApp.Android
{
    [Activity(Label = "@string/app_name", 
        Theme = "@style/AppTheme", 
        MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);



            var PhoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            var TranslateButton = FindViewById<Button>(Resource.Id.btnTranslate);
            var CallButton = FindViewById<Button>(Resource.Id.btnCall);


            CallButton.Enabled = false;
            var TranslatedNumber = string.Empty;

            TranslateButton.Click += (object sender, System.EventArgs e) =>
            {
                var Translator = new PhoneApp.Translator.PhoneTranslator();
                TranslatedNumber = Translator.ToNumber(PhoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(TranslatedNumber))
                {
                    // No hay número a llamar
                    CallButton.Text = "Llamar";
                    CallButton.Enabled = false;
                }
                else
                {
                    // Hay un posible número telefónico a llamar
                    CallButton.Text = $"Llamar al {TranslatedNumber}";
                    CallButton.Enabled = true;
                }
            };

            CallButton.Click += (object sender, System.EventArgs e) =>
            {
                // Intentar marcar el número telefónico
                var CallDialog =
                new global::Android.App.AlertDialog.Builder(this);
                CallDialog.SetMessage($"Llamar al número {TranslatedNumber}?");
                CallDialog.SetNeutralButton("Llamar", delegate
                {
                    // Crear un intento para marcar el número telefónico
                    var CallIntent =
                    new global::Android.Content.Intent(
                    global::Android.Content.Intent.ActionCall);
                    CallIntent.SetData(
                   global::Android.Net.Uri.Parse($"tel:{TranslatedNumber}"));
                    StartActivity(CallIntent);
                });
                CallDialog.SetNegativeButton("Cancelar", delegate { });
                // Mostrar el cuadro de diálogo al usuario y esperar una respuesta.
                CallDialog.Show();
            };







        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}