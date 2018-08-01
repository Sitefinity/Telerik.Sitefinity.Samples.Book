

Progress.Sitefinity.Samples.Book
===============================

### This repository is not automatically upgraded to latest Sitefintiy version. The repository is monitored for pull requests and fixes. The latest official version of Sitefinity that supports this sample is 8.1. Be aware that using a higher version could cause unexpected behavior. If you successfully upgrade the example to a greater version, please share your work with the community by submitting your changes via pull request.

The Book widget is a Silverlight-based widget that displays all images uploaded in a selected album of Sitefinity CMS Images library. The sample features a widget created with RadBook, part of RadControls for Silverlight suite that is delivered with the Sitefinity CMS SDK.    
You use RadBook to create a native Sitefinity CMS widget.    
You can run the Book widget sample with any type of license.   
Using the Book widget sample, you can:

* Create a RadBook widget
* Register the widget in Sitefinity CMS toolbox
* Upload all images necessary for the widget to function to the Sitefinity Images Library


### Requirements

* Sitefinity CMS license
* .NET Framework 4.5
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

To login into the Sitefinity CMS backend, use the following credentials:  
**Username:** admin  
**Password:** password


### Additional resources

[Development: Use and extend Sitefinity CMS functionality](http://docs.sitefinity.com/develop-create-and-manage-website-content)  
[Tutorials: Create widgets](http://docs.sitefinity.com/tutorials-create-widgets)
