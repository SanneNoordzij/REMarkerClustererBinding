using System;
using CoreLocation;
using Foundation;
using MapKit;
using ObjCRuntime;
using REMarkerClustererBinding;

namespace REMarkerClustererBinding
{
	// @protocol REMarkerClusterDelegate <MKMapViewDelegate>
	[Protocol, Model]
	public partial interface REMarkerClusterDelegate : IMKMapViewDelegate
	{
		// @optional -(void)markerClusterer:(REMarkerClusterer *)markerCluster withMapView:(MKMapView *)mapView updateViewOfAnnotation:(id<MKAnnotation>)annotation withView:(MKAnnotationView *)annotationView;
		[Export ("markerClusterer:withMapView:updateViewOfAnnotation:withView:")]
		void WithMapView (REMarkerClusterer markerCluster, MKMapView mapView, MKAnnotation annotation, MKAnnotationView annotationView);
	}
	public interface IREMarkerClusterDelegate {}
	// @interface RELatLngBounds : NSObject
	[BaseType (typeof(NSObject))]
	public interface RELatLngBounds
	{
		// @property (assign, readwrite, nonatomic) CLLocationCoordinate2D northEast;
		[Export ("northEast", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D NorthEast { get; set; }

		// @property (assign, readwrite, nonatomic) CLLocationCoordinate2D northWest;
		[Export ("northWest", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D NorthWest { get; set; }

		// @property (assign, readwrite, nonatomic) CLLocationCoordinate2D southWest;
		[Export ("southWest", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D SouthWest { get; set; }

		// @property (assign, readwrite, nonatomic) CLLocationCoordinate2D southEast;
		[Export ("southEast", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D SouthEast { get; set; }

		// @property (readwrite, nonatomic, weak) MKMapView * mapView;
		[Export ("mapView", ArgumentSemantic.Weak)]
		MKMapView MapView { get; set; }

		// -(id)initWithMapView:(MKMapView *)mapView;
		[Export ("initWithMapView:")]
		IntPtr Constructor (MKMapView mapView);

		// -(void)setSouthWest:(CLLocationCoordinate2D)sw northEast:(CLLocationCoordinate2D)ne;
		[Export ("setSouthWest:northEast:")]
		void SetSouthWest (CLLocationCoordinate2D sw, CLLocationCoordinate2D ne);

		// -(void)setExtendedBounds:(NSInteger)gridSize;
		[Export ("setExtendedBounds:")]
		void SetExtendedBounds (nint gridSize);

		// -(_Bool)contains:(CLLocationCoordinate2D)coordinate;
		[Export ("contains:")]
		bool Contains (CLLocationCoordinate2D coordinate);
	}

	// @interface RECluster : NSObject <MKAnnotation>
	[BaseType (typeof(NSObject))]
	public interface RECluster : IMKAnnotation
	{
		// @property (readwrite, nonatomic, strong) RELatLngBounds * bounds;
		[Export ("bounds", ArgumentSemantic.Strong)]
		RELatLngBounds Bounds { get; set; }

		// @property (readwrite, nonatomic, weak) REMarkerClusterer * markerClusterer;
		[Export ("markerClusterer", ArgumentSemantic.Weak)]
		REMarkerClusterer MarkerClusterer { get; set; }

		// @property (assign, readwrite, nonatomic) CLLocationCoordinate2D coordinate;
		[Export ("coordinate", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Coordinate { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL averageCenter;
		[Export ("averageCenter")]
		bool AverageCenter { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL hasCenter;
		[Export ("hasCenter")]
		bool HasCenter { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * subtitle;
		[Export ("subtitle")]
		string Subtitle { get; set; }

		// @property (readwrite, nonatomic, strong) NSMutableArray * markers;
		[Export ("markers", ArgumentSemantic.Strong)]
		NSMutableArray Markers { get; set; }

		// @property (readonly, nonatomic, strong) NSString * coordinateTag;
		[Export ("coordinateTag", ArgumentSemantic.Strong)]
		string CoordinateTag { get; }

		// -(id)initWithClusterer:(REMarkerClusterer *)clusterer;
		[Export ("initWithClusterer:")]
		IntPtr Constructor (REMarkerClusterer clusterer);

		// -(BOOL)isMarkerAlreadyAdded:(id<REMarker>)marker;
		[Export ("isMarkerAlreadyAdded:")]
		bool IsMarkerAlreadyAdded (REMarker marker);

		// -(NSInteger)markersInClusterFromMarkers:(NSArray *)markers;
		[Export ("markersInClusterFromMarkers:")]
		nint MarkersInClusterFromMarkers (REMarker[] markers);

		// -(BOOL)addMarker:(id<REMarker>)marker;
		[Export ("addMarker:")]
		bool AddMarker (REMarker marker);

		// -(BOOL)isMarkerInClusterBounds:(id<REMarker>)marker;
		[Export ("isMarkerInClusterBounds:")]
		bool IsMarkerInClusterBounds (REMarker marker);

		// -(void)setAverageCenter;
		[Export ("setAverageCenter")]
		void SetAverageCenter ();

		// -(void)printDescription;
		[Export ("printDescription")]
		void PrintDescription ();
	}

	// @interface REMarker : NSObject <REMarker>
	[BaseType (typeof(NSObject))]
	public interface REMarker : IMKAnnotation
	{
		// @property (assign, readwrite, nonatomic) NSUInteger markerId;
		[Export ("markerId", ArgumentSemantic.Assign)]
		nuint MarkerId { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * subtitle;
		[Export ("subtitle")]
		string Subtitle { get; set; }

		// @property (assign, readwrite, nonatomic) CLLocationCoordinate2D coordinate;
		[Export ("coordinate", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Coordinate { get; set; }

		// @property (readwrite, nonatomic, strong) NSDictionary * userInfo;
		[Export ("userInfo", ArgumentSemantic.Strong)]
		NSDictionary UserInfo { get; set; }
	}

	// @interface REMarkerClusterer : NSObject <MKMapViewDelegate>
	[BaseType (typeof(NSObject))]
	public interface REMarkerClusterer : IMKMapViewDelegate
	{
		// @property (readwrite, nonatomic, weak) MKMapView * mapView;
		[Export ("mapView", ArgumentSemantic.Weak)]
		MKMapView MapView { get; set; }

		// @property (readonly, nonatomic, strong) NSMutableArray * markers;
		[Export ("markers", ArgumentSemantic.Strong)]
		NSMutableArray Markers { get; }

		// @property (readonly, nonatomic, strong) NSMutableArray * clusters;
		[Export ("clusters", ArgumentSemantic.Strong)]
		NSMutableArray Clusters { get; }

		// @property (assign, readwrite, nonatomic) NSInteger gridSize;
		[Export ("gridSize", ArgumentSemantic.Assign)]
		nint GridSize { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL isAverageCenter;
		[Export ("isAverageCenter")]
		bool IsAverageCenter { get; set; }

		// @property (assign, readwrite, nonatomic) CGFloat maxDelayOfSplitAnimation;
		[Export ("maxDelayOfSplitAnimation", ArgumentSemantic.Assign)]
		nfloat MaxDelayOfSplitAnimation { get; set; }

		// @property (assign, readwrite, nonatomic) CGFloat maxDurationOfSplitAnimation;
		[Export ("maxDurationOfSplitAnimation", ArgumentSemantic.Assign)]
		nfloat MaxDurationOfSplitAnimation { get; set; }

		[Wrap ("WeakDelegate")]
		IREMarkerClusterDelegate Delegate { get; set; }

//		 @property (readwrite, nonatomic, weak) id<REMarkerClusterDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IREMarkerClusterDelegate WeakDelegate { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * clusterTitle;
		[Export ("clusterTitle")]
		string ClusterTitle { get; set; }

		// @property (readonly, assign, nonatomic) BOOL animating;
		[Export ("animating")]
		bool Animating { get; }

		// -(id)initWithMapView:(MKMapView *)mapView delegate:(id<REMarkerClusterDelegate>)delegate;
		[Export ("initWithMapView:delegate:")]
		IntPtr Constructor (MKMapView mapView, IREMarkerClusterDelegate Delegate);

		// -(void)addMarker:(id<REMarker>)marker;
		[Export ("addMarker:")]
		void AddMarker (REMarker marker);

		// -(void)addMarkers:(NSArray *)markers;
		[Export ("addMarkers:")]
		void AddMarkers (REMarker[] markers);

		// -(void)removeMarker:(id<REMarker>)marker;
		[Export ("removeMarker:")]
		void RemoveMarker (REMarker marker);

		// -(void)removeAllMarkers;
		[Export ("removeAllMarkers")]
		void RemoveAllMarkers ();

		// -(void)zoomToAnnotationsBounds:(NSArray *)annotations;
		[Export ("zoomToAnnotationsBounds:")]
		void ZoomToAnnotationsBounds (NSMutableArray annotations);

		// -(void)clusterize:(BOOL)animated;
		[Export ("clusterize:")]
		void Clusterize (bool animated);

		// -(BOOL)isAnimating;
		[Export ("isAnimating")]
		bool IsAnimating { get; }

		// -(void)clusterize __attribute__((deprecated("")));
		[Export ("clusterize")]
		void Clusterize ();
	}
}
