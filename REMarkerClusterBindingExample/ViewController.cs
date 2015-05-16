using System;

using UIKit;
using MapKit;
using REMarkerClustererBinding;

namespace REMarkerClusterBindingExample
{
	public partial class ViewController : UIViewController, IREMarkerClusterDelegate
	{
		REMarkerClusterer cluster;
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var map = new MKMapView (UIScreen.MainScreen.Bounds);
			View = map;
			map.Delegate = this;

			cluster = new REMarkerClusterer (map, this);
			cluster.GridSize = 20;
			cluster.ClusterTitle = "Title";
			AddClusterItems ();
			cluster.Clusterize (false);
			cluster.ZoomToAnnotationsBounds (cluster.Markers);
			// Perform any additional setup after loading the view, typically from a nib.
		}
		private void AddClusterItems(){
			double lat = 36.9628066;
			double lng = -122.0194722;

			for(var i = 0; i< 10; i++){
				double offset = i / 60d;
				lat = lat + offset;
				lng = lng + offset;
				REMarker marker = new REMarker ();
				marker.Coordinate = new CoreLocation.CLLocationCoordinate2D (lat, lng);
				marker.Title = i.ToString ();
				marker.MarkerId = (nuint)i;
				cluster.AddMarker (marker);
			}
		}
		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

