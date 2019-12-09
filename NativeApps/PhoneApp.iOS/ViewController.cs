using Foundation;
using System;
using UIKit;

namespace PhoneApp.iOS
{
    public partial class ViewController : UIViewController
    {
        string TranslatedNumber;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            TranslatedNumber = String.Empty;

            btnTranslate.TouchUpInside += (object sender, System.EventArgs e) =>
            {
                var Translator = new PhoneApp.Translator.PhoneTranslator();
                TranslatedNumber = Translator.ToNumber(PhoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(TranslatedNumber))
                {
                    // No hay número a llamar
                    //btnCall.TitleLabel.Text = "Call";
                    //txtPhoneNumber.Text = "";
                    //btnCall.Enabled = false;
                }
                else
                {
                    // Hay un posible número telefónico a llamar
                    //btnCall.TitleLabel.Text = $"Call to {TranslatedNumber}";
                    txtPhoneNumber.Text = $"Call to {TranslatedNumber}";
                    //btnCall.Enabled = true;
                }
            };

            btnLlamar.TouchDown += BtnLlamar_TouchDown;


        }

        private void BtnLlamar_TouchDown(object sender, EventArgs e)
        {
            var url = new NSUrl("tel:" + TranslatedNumber);

            if (!UIApplication.SharedApplication.OpenUrl(url))
            {
                var alert = UIAlertController.Create("Not Supported",
                                            $"Schema 'tel: {TranslatedNumber}' is not supported on this device",
                                            UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
            }

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}