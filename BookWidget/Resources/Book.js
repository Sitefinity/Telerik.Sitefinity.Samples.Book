Type.registerNamespace('BookWidget');

BookWidget.Book = function (element) {
    BookWidget.Book.initializeBase(this, [element]);

    this._imagesCollection = null;
    this._properties = null;
    this._silverlightBookObject = null;

}
BookWidget.Book.prototype = {
    // ------------------------------------------------------------------------ 
    // initialization and clean-up 
    // ------------------------------------------------------------------------ 
    initialize: function () {
        BookWidget.Book.callBaseMethod(this, 'initialize');
        Sys.Application.add_load(Function.createDelegate(this, this._onLoad));

        var BookObject = this.get_silverlightBookObject();
        BookObject.onLoad = Function.createDelegate(this, this.pluginLoaded);
        BookObject.onError = Function.createDelegate(this, this.onSilverlightError);
    },
    dispose: function () {
        BookWidget.Book.callBaseMethod(this, 'dispose');
    },
    // ------------------------------------------------------------------------ 
    // public functions 
    // ------------------------------------------------------------------------ 
    pluginLoaded: function (sender, args) {
        var imagesArr = Sys.Serialization.JavaScriptSerializer.deserialize(this.get_imagesCollection());
        slCtl = sender.getHost();
        for (var idx = 0; idx < imagesArr.length; idx++) {
            slCtl.Content.mainPage.SetItem(imagesArr[idx]['Url']);
        }
        slCtl.Content.mainPage.SetBookProperties(Sys.Serialization.JavaScriptSerializer.deserialize(this.get_properties()));
    },

    onSilverlightError: function (sender, args) {
        var appSource = "";
        if (sender != null && sender != 0) {
            appSource = sender.getHost().Source;
        }

        var errorType = args.ErrorType;
        var iErrorCode = args.ErrorCode;

        if (errorType == "ImageError" || errorType == "MediaError") {
            return;
        }

        var errMsg = "Unhandled Error in Silverlight Application " + appSource + "\n";

        errMsg += "Code: " + iErrorCode + "    \n";
        errMsg += "Category: " + errorType + "       \n";
        errMsg += "Message: " + args.ErrorMessage + "     \n";

        if (errorType == "ParserError") {
            errMsg += "File: " + args.xamlFile + "     \n";
            errMsg += "Line: " + args.lineNumber + "     \n";
            errMsg += "Position: " + args.charPosition + "     \n";
        }
        else if (errorType == "RuntimeError") {
            if (args.lineNumber != 0) {
                errMsg += "Line: " + args.lineNumber + "     \n";
                errMsg += "Position: " + args.charPosition + "     \n";
            }
            errMsg += "MethodName: " + args.methodName + "     \n";
        }

        throw new Error(errMsg);
    },

    // ------------------------------------------------------------------------ 
    // private functions 
    // ------------------------------------------------------------------------ 
    _onLoad: function (sender, args) {

    },


    // ------------------------------------------------------------------------ 
    // property accessors 
    // ------------------------------------------------------------------------
    get_imagesCollection: function () {
        return this._imagesCollection;
    },
    set_imagesCollection: function (value) {
        if (this._imagesCollection !== value) {
            this._imagesCollection = value;
            this.raisePropertyChanged('imagesCollection');
        }
    },
    get_properties: function () {
        return this._properties;
    },
    set_properties: function (value) {
        if (this._properties !== value) {
            this._properties = value;
            this.raisePropertyChanged('properties');
        }
    },
    get_silverlightBookObject: function () {
        return this._silverlightBookObject;
    },
    set_silverlightBookObject: function (value) {
        if (this._silverlightBookObject !== value) {
            this._silverlightBookObject = value;
            this.raisePropertyChanged('silverlightBookObject');
        }
    }
}

BookWidget.Book.registerClass('BookWidget.Book', Sys.UI.Control);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();