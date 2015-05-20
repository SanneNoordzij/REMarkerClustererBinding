using System;

using UIKit;
using MapKit;
using REMarkerClustererBinding;
using Foundation;
using MapDemo;
using System.Drawing;

namespace REMarkerClusterBindingExample
{
	public partial class ViewController : UIViewController, IREMarkerClusterDelegate
	{
		REMarkerClusterer cluster;
		public static UISegmentedControl segment;
		MKMapView mapView;
		MapDelegate mapDelegate;
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void LoadView ()
		{
			base.LoadView ();
			mapView = new MKMapView (UIScreen.MainScreen.Bounds);
			View = mapView;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			segment = new UISegmentedControl (new string[]{"Simple", "Custom pins"});
			segment.SelectedSegment = 0;
			segment.ValueChanged += SegmentControlChanged;

			NavigationItem.TitleView = segment;

			cluster = new REMarkerClusterer (mapView, this);
			cluster.GridSize = 20;
			cluster.ClusterTitle = "Title";
			AddClusterItems ();
			cluster.Clusterize (false);
			cluster.ZoomToAnnotationsBounds (cluster.Markers);
			mapDelegate = new MapDelegate ();
			mapView.Delegate = mapDelegate;
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

		private void SegmentControlChanged(object sender, EventArgs e)
		{
			mapView.RemoveAnnotations (mapView.Annotations);
			cluster.Clusterize (false);
		}
		public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate (fromInterfaceOrientation);
			cluster.ZoomToAnnotationsBounds (cluster.Markers);
		}

		class MapDelegate: MKMapViewDelegate
		{
			string defaultPinID = "REDefaultPin";
			string markerPinID = "REMarkerPin";
			public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, IMKAnnotation annotation)
			{
				if(ThisIsTheCurrentLocation(mapView, annotation))
				{
					return null;
				}
				string pinID;
				
				if(ViewController.segment.SelectedSegment == 0){
					pinID = defaultPinID;
				}else{
					pinID = markerPinID;
				}
				MKPinAnnotationView annotationView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation (pinID);

				if(annotationView == null){
					annotationView = new MKPinAnnotationView (annotation, pinID);
					annotationView.CanShowCallout = true;

					if(segment.SelectedSegment == 1){
						annotationView.Image = UIImage.FromBundle ("Images/Pin_Red");
					}
				}
				return annotationView;
			}

			private bool ThisIsTheCurrentLocation(MKMapView mapView, IMKAnnotation annotation)
			{
				var userLocationAnnotation = ObjCRuntime.Runtime.GetNSObject(annotation.Handle) as MKUserLocation;
				if(userLocationAnnotation != null)
				{
					return userLocationAnnotation == mapView.UserLocation;
				}

				return false;
			}
		}	
	}
}

