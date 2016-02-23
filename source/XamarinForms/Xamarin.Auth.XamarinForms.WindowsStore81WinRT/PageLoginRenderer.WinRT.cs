using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Xamarin.Forms;

using Xamarin.Forms.Platform.WinRT;

[assembly:
    //Xamarin.Forms.ExportRenderer                  // mc++ no Export Renderer
    Xamarin.Forms.Platform.WinRT.ExportRenderer     // mc++ asked in Forms room - nobody answered
            //Xamarin.Forms.Platform.WinPhone.ExportRenderer
            (
            // ViewElement to be rendered (from Portable/Shared)
            typeof(Xamarin.Auth.XamarinForms.PageOAuth),
            // platform specific Renderer : global::Xamarin.Forms.Platform.iOS.PageRenderer
            typeof(Xamarin.Auth.XamarinForms.Authentication.WindowsStore81WinRT.PageOAuthRenderer)
            )
]
namespace Xamarin.Auth.XamarinForms.Authentication.WindowsStore81WinRT
{
    public partial class PageOAuthRenderer :
                global::Xamarin.Forms.Platform.WinRT.PageRenderer    // mc++ mc#
    {
        bool IsShown;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged (e);

            // OnElementChanged is fired before ViewDidAppear, using it to pass data

            PageOAuth e_new = e.NewElement as PageOAuth;


            Login();

            return;
        }

        public void Login()
        {
            //base.UpdateLayout();

            if (!IsShown)
            {

                IsShown = true;

                throw new ArgumentOutOfRangeException("Unknown OAuth");
            }
            return;
        }


        private void Auth_Completed(object sender, global::Xamarin.Auth.AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                // e.Account contains info:
                //		e.AccountProperties[""]
                //
                // use access tokenmore detailed user info from the API

                this.AccountProperties = e.Account.Properties;
            }
            else
            {
                // The user cancelled
            }

            // dismiss UI on iOS, because it was manually created
            //DismissViewController(true, null);

            // possibly do something to dismiss THIS viewcontroller, 
            // or else login screen does not disappear             

            return;
        }

        protected Dictionary<string, string> account_properties;

        public Dictionary<string, string> AccountProperties
        {
            protected get
            {
                return account_properties;
            }
            set
            {
                account_properties = value;
            }
        }
    }
}