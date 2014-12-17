using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Telerik.Sitefinity;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Modules.Pages.Web.UI;
using Telerik.Sitefinity.Web.UI;

namespace BookWidget
{
    /// <summary>
    /// Defines book first page position
    /// </summary>
    public enum PagePosition
    {
        /// <summary>
        /// First page is postioned on the right
        /// </summary>
        Right,
        
        /// <summary>
        /// First page is postioned on the left
        /// </summary>
        Left
    }

    /// <summary>
    /// Defines book hard pages property
    /// </summary>
    public enum HardPages
    {
        /// <summary>
        /// Sets the HardPages poperty to all pages
        /// </summary>
        All,

        /// <summary>
        /// Sets the HardPages poperty to a custom set of pages
        /// </summary>
        Custom,

        /// <summary>
        /// Sets the HardPages poperty to the first page
        /// </summary>
        First,

        /// <summary>
        /// Sets the HardPages poperty to the last and pages
        /// </summary>
        FirstAndLast,

        /// <summary>
        /// Sets the HardPages poperty to the last page
        /// </summary>
        Last,

        /// <summary>
        /// None of the book pages use this property
        /// </summary>
        None
    }

    /// <summary>
    /// Defines how book pages are changed
    /// </summary>
    public enum PageFlipMode
    {
        /// <summary>
        /// Double click to change book pages
        /// </summary>
        DoubleClick,

        /// <summary>
        /// Book pages are not changed by mouse clicks
        /// </summary>
        None,

        /// <summary>
        /// Single click to change pages
        /// </summary>
        SingleClick
    }

    [RequireScriptManager]
    public class Book : SimpleScriptView
    {
        private string albumTitle;
        private string imagesCollection;
        private PagePosition firstPagePosition = PagePosition.Right;
        private HardPages hardPages = HardPages.FirstAndLast;
        private PageFlipMode pageFlipMode = PageFlipMode.SingleClick;
        private int rightPageIndex = 0;

        /// <summary>
        /// Gets or sets the album title for which the widget retrieves images from.
        /// </summary>
        /// <value>The title of the album in which your images are placed.</value>
        [Category("Book Properties")]
        public string AlbumTitle
        {
            get
            {
                return this.albumTitle;
            }

            set
            {
                this.albumTitle = value;
            }
        }

        /// <summary>
        /// Gets or sets the first page position for the book widget
        /// </summary>
        [Category("Book Properties")]
        public PagePosition FirstPagePosition
        {
            get
            {
                return this.firstPagePosition;
            }

            set
            {
                this.firstPagePosition = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the book widget will use hard pages
        /// </summary>
        [Category("Book Properties")]
        public HardPages HardPages
        {
            get
            {
                return this.hardPages;
            }

            set
            {
                this.hardPages = value;
            }
        }

        /// <summary>
        /// Gets or sets how book pages are changed
        /// </summary>
        [Category("Book Properties")]
        public PageFlipMode PageFlipMode
        {
            get
            {
                return this.pageFlipMode;
            }

            set
            {
                this.pageFlipMode = value;
            }
        }

        /// <summary>
        /// Gets or sets the right page index of the book
        /// </summary>
        [Category("Book Properties")]
        public int RightPageIndex
        {
            get
            {
                return this.rightPageIndex;
            }

            set
            {
                this.rightPageIndex = value;
            }
        }

        /// <summary>
        /// Gets the name of the embedded layout template.
        /// </summary>
        /// <value>Full path of the template name as a string.</value>
        /// <remarks>
        /// Override this property to change the embedded template to be used with the dialog
        /// </remarks>
        protected override string LayoutTemplateName
        {
            get { return "BookWidget.Resources.Views.BookTemplate.ascx"; }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> value that corresponds to this Web server control. This property is used primarily by control developers.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> enumeration values.</returns>
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                ////Use div wrapper tag to make easier common styling. This will surround the layout template with a div tag.
                return HtmlTextWriterTag.Div;
            }
        }

        /// <summary>
        /// Gets the collection of images which will populate the book widget
        /// </summary>
        [Browsable(false)]
        protected string ImagesCollection
        {
            get
            {
                if (String.IsNullOrEmpty(this.imagesCollection))
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    this.imagesCollection = serializer.Serialize(this.GetImages());
                }

                return this.imagesCollection;
            }
        } 
        
        /// <summary>
        /// Gets the silverlight control host
        /// </summary>
        [Browsable(false)]
        public HtmlGenericControl SilverlightBook
        {
            get
            {
                return this.Container.GetControl<HtmlGenericControl>("silverlightBook", true);
            }
        }

        /// <summary>
        /// Gets a collection of <see cref="T:System.Web.UI.ScriptDescriptor"/> objects that define script descriptors that the control requires.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerable"/> collection of <see cref="T:System.Web.UI.ScriptDescriptor"/> objects.
        /// </returns>
        public override IEnumerable<System.Web.UI.ScriptDescriptor> GetScriptDescriptors()
        {
            var descriptor = new ScriptBehaviorDescriptor(this.GetType().FullName, this.ClientID);
            descriptor.AddProperty("imagesCollection", this.ImagesCollection);
            var properties = new 
            { 
                firstPagePosition = this.FirstPagePosition.ToString(),
                hardPages = this.HardPages.ToString(),
                pageFlipMode = this.PageFlipMode.ToString(),
                rightPageIndex = this.RightPageIndex,
            };
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var serializedProperties = serializer.Serialize(properties);
            descriptor.AddProperty("properties", serializedProperties);
            descriptor.AddElementProperty("silverlightBookObject", this.SilverlightBook.ClientID);
            return new ScriptDescriptor[] { descriptor };
        }

        /// <summary>
        /// Gets a collection of <see cref="T:System.Web.UI.ScriptReference"/> objects that define script resources that the control requires.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerable"/> collection of <see cref="T:System.Web.UI.ScriptReference"/> objects.
        /// </returns>
        public override IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            ScriptReference reference = new ScriptReference("BookWidget.Resources.Book.js", "BookWidget");
            return new ScriptReference[] { reference };
        }

        /// <summary>
        /// Initializes the controls.
        /// </summary>
        /// <param name="container">The control container.</param>
        protected override void InitializeControls(GenericContainer container)
        {
        }

        private List<Hashtable> GetImages()
        {
            List<Hashtable> results = new List<Hashtable>();
            var title = this.AlbumTitle;

            // get IQueryable of images from the Standard API.
            var images = LibrariesManager.GetManager().GetImages().Where(x => x.Status == ContentLifecycleStatus.Live);

            // get images from album if set
            if (!string.IsNullOrEmpty(title))
                images.Where((w) => w.Parent.Title == title);

            var filteredImages = images.OrderBy((w) => w.Ordinal);

            foreach (Telerik.Sitefinity.Libraries.Model.Image v in filteredImages)
            {
                Hashtable table = new Hashtable();
                table.Add("Url", v.MediaUrl);
                results.Add(table);
            }

            return results;
        }
    }
}