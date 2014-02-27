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

1. Clone the [Telerik.Sitefinity.Samples.Dependencies](https://github.com/Sitefinty-SDK/Telerik.Sitefinity.Samples.Dependencies) repo to get all assemblies necessary to run for the samples.
2. Fix broken references in the class libraries, for example in **SitefinityWebApp** and **Telerik.Sitefinity.Samples.Common**:

  1. In Solution Explorer, open the context menu of your project node and click _Properties_.  
  
    The Project designer is displayed.
  2. Select the _Reference Paths_ tab page.
  3. Browse and select the folder where **Telerik.Sitefinity.Samples.Dependencies** folder is located.
  4. Click the _Add Folder_ button.


3. In Solution Explorer, navigate to _SitefinityWebApp_ -> *App_Data* -> _Sitefinity_ -> _Configuration_ and select the **DataConfig.config** file. 
4. Modify the **connectionString** value to match your server address.
5. Build the solution.

### Login

To login to Sitefinity backend, use the following credentials: 

**Username:** admin

**Password:** password


### Additional resources

[Developers Guide](http://www.sitefinity.com/documentation/documentationarticles/developers-guide)

[Create a book widget](http://www.sitefinity.com/documentation/documentationarticles/developers-guide/how-to/how-to-create-a-book-widget)
