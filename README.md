# XamarinChartJS
An easy to use Nuget Package for Xamarin.Forms to use Chart.js in WebViews with C# configuration

## Setup Steps
For the plugin to work offline, you must add a copy of Chart.js ```3.2.0``` to both iOS and Android projects as shown below.
You can download it from here: following link [Chart.js 3.2.0 CDN Link](https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.2.0/chart.min.js)

### Android
1. Add the file downloaded above to your root Android folder named ```chart.min.js```
2. Set the ```Build Action``` to ```AndroidAsset```

### iOS
1. Add the file downloaded above to your root iOS folder named ```chart.min.js```
2. Set the ```Build Action``` to ```BundleResource```