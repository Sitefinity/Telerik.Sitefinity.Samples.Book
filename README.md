Telerik.Sitefinity.Samples.Book
===============================

The Book widget is a Silverlight-based widget that displays all images uploaded in a selected album of Sitefinity Images library. The sample features a widget created with RadBook, part of RadControls for Silverlight suite that is delivered with the Sitefinity SDK.

You use RadBook to create a native Sitefinity widget. 

You can run the Book widget sample with any type of license. 

Using the Book widget sample, you can:

* Create a RadBook widget
* Register the widget in Sitefinity toolbox
* Upload all images necessary for the widget to function to the Sitefinity Images Library


### Requirements

* .NET Framework 4

* Visual Studio 2012

* Microsoft SQL Server 2008R2 or later versions


### Installation instructions: SDK Samples from GitHub



1. In Solution Explorer, navigate to _SitefinityWebApp_ -> *App_Data* -> _Sitefinity_ -> _Configuration_ and select the **DataConfig.config** file. 
2. Modify the **connectionString** value to match your server address.
3. Build the solution.

The project refers to the following NuGet packages:

**BookWidget** library

*	Telerik.Sitefinity.Core.nupkg

*	OpenAccess.Core.nupkg

**BookSilverlight** library

*	Telerik.Sitefinity.SDK.Silverlight.nupkg

**SitefinityWebApp** library

*	Telerik.Sitefinity.All.nupkg

**Telerik.Sitefinity.Samples.Common** library

*	Telerik.Sitefinity.Core.nupkg

*	Telerik.Sitefinity.Content.nupkg

*	OpenAccess.Core.nupkg

You can find the packages in the official [Sitefinity Nuget Server](http://nuget.sitefinity.com).


### Login

To login to Sitefinity backend, use the following credentials: 

**Username:** admin

**Password:** password


### Additional resources

[Developers Guide](http://www.sitefinity.com/documentation/documentationarticles/developers-guide)

[Create a book widget](http://www.sitefinity.com/documentation/documentationarticles/developers-guide/how-to/how-to-create-a-book-widget)
