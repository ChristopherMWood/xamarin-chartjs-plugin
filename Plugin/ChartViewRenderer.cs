//using System;

//namespace Plugin
//{[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
//namespace CustomRenderer.iOS
//    {
//        public class ChartViewRenderer : WkWebViewRenderer, IWKScriptMessageHandler
//        {
//            const string JavaScriptFunction = "function invokeCSharpAction(data){window.webkit.messageHandlers.invokeAction.postMessage(data);}";
//            WKUserContentController userController;

//            public ChartViewRenderer() : this(new WKWebViewConfiguration())
//            {
//            }

//            public ChartViewRenderer(WKWebViewConfiguration config) : base(config)
//            {
//                userController = config.UserContentController;
//                var script = new WKUserScript(new NSString(JavaScriptFunction), WKUserScriptInjectionTime.AtDocumentEnd, false);
//                userController.AddUserScript(script);
//                userController.AddScriptMessageHandler(this, "invokeAction");
//            }

//            protected override void OnElementChanged(VisualElementChangedEventArgs e)
//            {
//                base.OnElementChanged(e);

//                if (e.OldElement != null)
//                {
//                    userController.RemoveAllUserScripts();
//                    userController.RemoveScriptMessageHandler("invokeAction");
//                    HybridWebView hybridWebView = e.OldElement as HybridWebView;
//                    hybridWebView.Cleanup();
//                }

//                if (e.NewElement != null)
//                {
//                    string filename = Path.Combine(NSBundle.MainBundle.BundlePath, $"Content/{((HybridWebView)Element).Uri}");
//                    LoadRequest(new NSUrlRequest(new NSUrl(filename, false)));
//                }
//            }

//            public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
//            {
//                ((HybridWebView)Element).InvokeAction(message.Body.ToString());
//            }

//            protected override void Dispose(bool disposing)
//            {
//                if (disposing)
//                {
//                    ((HybridWebView)Element).Cleanup();
//                }
//                base.Dispose(disposing);
//            }
//        }
//    }
//}




//[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
//namespace CustomRenderer.Droid
//{
//    public class ChartViewRenderer : WebViewRenderer
//    {
//        const string JavascriptFunction = "function invokeCSharpAction(data){jsBridge.invokeAction(data);}";
//        Context _context;

//        public ChartViewRenderer(Context context) : base(context)
//        {
//            _context = context;
//        }

//        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
//        {
//            base.OnElementChanged(e);

//            if (e.OldElement != null)
//            {
//                Control.RemoveJavascriptInterface("jsBridge");
//                ((HybridWebView)Element).Cleanup();
//            }
//            if (e.NewElement != null)
//            {
//                Control.SetWebViewClient(new JavascriptWebViewClient(this, $"javascript: {JavascriptFunction}"));
//                Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");
//                Control.LoadUrl($"file:///android_asset/Content/{((HybridWebView)Element).Uri}");
//            }
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                ((HybridWebView)Element).Cleanup();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}