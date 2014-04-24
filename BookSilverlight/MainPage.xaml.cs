using System;
using System.Windows.Browser;
using System.Windows.Controls;

namespace BookSilverlight
{
    /// <summary>
    /// The user control that is used to load the book widget.
    /// </summary>
    public partial class MainPage : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Sets the book properties
        /// </summary>
        /// <param name="props">The collection of book propeties and their values</param>
        [ScriptableMember]
        public void SetBookProperties(dynamic props)
        {
            try
            {
                this.book.HardPages = Enum.Parse(typeof(Telerik.Windows.Controls.HardPages), props.hardPages, true);
                this.book.FirstPagePosition = Enum.Parse(typeof(Telerik.Windows.Controls.PagePosition), props.firstPagePosition, true);
                this.book.PageFlipMode = Enum.Parse(typeof(Telerik.Windows.Controls.PageFlipMode), props.pageFlipMode, true);
                this.book.RightPageIndex = Convert.ToInt32(props.rightPageIndex.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets the item.
        /// </summary>
        /// <param name="url">The URL of the image.</param>
        [ScriptableMember]
        public void SetItem(string url)
        {
            this.book.Items.Add(url);
        }
    }
}
