<div align="center">
  <img width="128" src="./Plugin/icon.png" alt="Plugin Icon">
  <h1 >XamarinChartJS</h1>
</div>

![Nuget](https://img.shields.io/nuget/v/Xamarin.Plugin.ChartJS) 
[![.NET](https://github.com/ChristopherMWood/XamarinChartJSPlugin/actions/workflows/dotnet.yml/badge.svg)](https://github.com/ChristopherMWood/XamarinChartJSPlugin/actions/workflows/dotnet.yml)

# Plugin Deprecated
**NOTE:** This plugin is deprecated and no longer being maintained due to the release of .NET Maui. The new repo with Maui support is located here.
- https://github.com/ChristopherMWood/maui-chartjs-plugin

## About

An easy to use (or at least intented to be easy) Nuget Package for Xamarin.Forms to use Chart.js in Xamarin with C# configurations. This came about because looking for a full featured charting library that doesn't cost hundreds if not thousands for a license on Mobile is not easy. And when you find an open source native library, they are pretty good but nothing compared to what the Web world has had for so long. In my research I found a proof of concept of the idea of using Charts in WebViews and I extended that idea with Chart.js, one of my favorite Web charting frameworks.

## Features
- 100% C# Configuration
- Bindings support for View and Chart configuration
- Runs Offline

## Current Target Versions
| Platform      | Version       | Why          |
| ------------- | ------------- | -------------
| Chart.js      | 3.2.0         | Latest version on initial development. Other versions have not been tested but may work. |

## Setup

### Install Plugin
- Add ```Xamarin.Plugin.ChartJS``` into your Xamarin Shared project only. 

**Note:** The plugin only needs to be installed in the shared project right now. In upcoming versions, the plan is to add custom renderers to enable some extra features and more clean cross platform usage.

### Add Local Chart.js File
For the plugin to work, you must add a copy of Chart.js ```3.2.0``` to both iOS and Android projects as shown below. This is what enables it to work offline.
You can download it from here: following link [Chart.js 3.2.0 CDN Link](https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.2.0/chart.min.js)

- Android
  1. Add the file downloaded above to your ```Assets``` Android folder and name it ```chart.min.js```
  2. Set the ```Build Action``` to ```AndroidAsset```
- iOS
  1. Add the file downloaded above to your ```Resources``` iOS folder and name it ```chart.min.js```
  2. Set the ```Build Action``` to ```BundleResource```

## How to Use
The best way to see examples is to clone the repo and run the Sample project. A working version of Android and iOS are implemented there with examples of all use cases used during development. As new features are added and bugs found, more examples will be added there for clarity. Below is the TLDR if needed.

### TLDR Setup
Add this to your XAML header
```cs
xmlns:views="clr-namespace:Plugin.XamarinChartJS;assembly=Xamarin.Plugin.ChartJS"
```
Add this into your page content
```cs
<views:ChartView Config="{Binding ChartConfig}" HeightRequest="200"/>
```
Add a chart Config that can be binded to in your backend (page or viewModel)
```cs
public ChartViewConfig ChartConfig { get; set; }
```

**Note:** You can also dynamically add ChartViews purely from code as you would any other view.

### Configuring the Chart
The ```ChartViewConfig``` object contains two things. The view settings and the Chart.js configuration which is meant to be 1-1 with the Javscript settings provided by Chart.js. All properties in this object are bound to the ChartView so if you change them, the Chart will dynamically update from that.
```cs
public Color BackgroundColor    //The views background color
public ChartConfig ChartConfig  //The Chart.js config
// More to be added as needed
```
To configure the ```ChartConfig``` object, refer to the documentation on https://www.chartjs.org/ since it is just an extension of the JSON config specified there.

### Helper Values
Where possible, helper constants and values are being added to help prevent typos. Below are some of what is available.
```cs
Plugin.XamarinChartJS.ChartTypes   //String constants for all Chart Types (line, bar, etc...)
```
