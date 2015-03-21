Telerik.Sitefinity.Samples.Book
===============================

[![Build Status](http://sdk-jenkins-ci.cloudapp.net/buildStatus/icon?job=Telerik.Sitefinity.Samples.Book.CI)](http://sdk-jenkins-ci.cloudapp.net/job/Telerik.Sitefinity.Samples.Book.CI/)

The Book widget is a Silverlight-based widget that displays all images uploaded in a selected album of Sitefinity Images library. The sample features a widget created with RadBook, part of RadControls for Silverlight suite that is delivered with the Sitefinity SDK.    
You use RadBook to create a native Sitefinity widget.    
You can run the Book widget sample with any type of license.   
Using the Book widget sample, you can:

* Create a RadBook widget
* Register the widget in Sitefinity toolbox
* Upload all images necessary for the widget to function to the Sitefinity Images Library


### Requirements

* Sitefinity license
* .NET Framework 4
* Visual Studio 2012
* Microsoft SQL Server 2008R2 or later versions

### Nuget package restoration
The solution in this repository relies on NuGet packages with automatic package restore while the build procedure takes place.   
For a full list of the referenced packages and their versions see the [packages.config](https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.Book/blob/master/SitefinityWebApp/packages.config) file.    
For a history and additional information related to package versions on different releases of this repository, see the [Releases page](https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.Book/releases).  


### Installation instructions: SDK Samples from GitHub

1. In Solution Explorer, navigate to _SitefinityWebApp_ » *App_Data* » _Sitefinity_ » _Configuration_ and select the **StartupConfig.config** file. 
2. Modify the **dbType**, **sqlInstance** and **dbName** values to match your server settings.
3. Build the solution.


For version-specific details about the required Sitefinity NuGet packages for this sample application, click on [Releases](https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.Book/releases).


### Login

To login to Sitefinity backend, use the following credentials:  
**Username:** admin  
**Password:** password


### Additional resources

[Development: Use and extend Sitefinity functionality](http://docs.sitefinity.com/develop-create-and-manage-website-content)  
[Tutorials: Create widgets](http://docs.sitefinity.com/tutorials-create-widgets)
