﻿Geolocator Readme

## Android specific in your BaseActivity or MainActivity (for Xamarin.Forms) add this code:

public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
{
    PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
}

## Getting Started:

Put this code in a method that is marked with the async keyword.

var locator = CrossGeolocator.Current;
locator.DesiredAccuracy = 50;

var position = await locator.GetPositionAsync (10000);

Console.WriteLine ("Position Status: {0}", position.Timestamp);
Console.WriteLine ("Position Latitude: {0}", position.Latitude);
Console.WriteLine ("Position Longitude: {0}", position.Longitude);


**IMPORTANT**
Android:
The ACCESS_COARSE_LOCATION & ACCESS_FINE_LOCATION permissions are required, but the library will automatically add this for you. 
Additionally, if your users are running Marshmallow the Plugin will automatically prompt them for runtime permissions.

iOS:
In iOS 8 you now have to call either RequestWhenInUseAuthorization or RequestAlwaysAuthorization on the location manager. Additionally you need to add either the concisely named NSLocationWhenInUseUsageDescription or NSLocationAlwaysUsageDescription to your Info.plist. 
See:  http://motzcod.es/post/97662738237/scanning-for-ibeacons-in-ios-8

You will need to add a new string entry called NSLocationWhenInUseUsageDescription or NSLocationAlwaysUsageDescription.

iOS Background updates:
New in iOS 9 allowsBackgroundLocationUpdates must be set if using in a background agent. This is exposed via the ListenerSettings
that are passed to StartListeningAysnc. The presence of the UIBackgroundModes key with the location value is required for background 
updates; you use this property to enable and disable the behavior based on your app’s behavior.

Windows Phone:
You must set the ID_CAP_LOCATION permission.
