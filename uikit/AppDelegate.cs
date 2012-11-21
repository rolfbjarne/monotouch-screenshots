using System;

using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ScreenShot_CaptureTestApp
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		UINavigationController nav;
		DialogViewController dvc;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			dvc = new DialogViewController (
				new RootElement ("Root") {
					new Section ("Main") {
						new StringElement ("Capture", () => {
							var uiv = new UIViewController ();
							uiv.View = new UIImageView (UIScreen.MainScreen.Capture ());
							nav.PushViewController (uiv, true);
						}),
					},
				}
			);

			nav = new UINavigationController (dvc);
			window.RootViewController = nav;
			window.MakeKeyAndVisible ();

			return true;
		}

		static void Main (string[] args)
		{
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}

