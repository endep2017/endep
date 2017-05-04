using System.Web;
using System.Web.Optimization;

namespace endep
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            //// preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));


            //**************  PLANTILLA *****************

            //********** CSS *******************

            // <!-- Bootstrap -->
            bundles.Add(new StyleBundle("~/Content/BootstrapCSS").Include(
                      "~/vendors/bootstrap/dist/css/bootstrap.min.css"));

            // <!-- Font Awesome -->
            bundles.Add(new StyleBundle("~/Content/AwesomeCSS").Include(                    
                     "~/vendors/font-awesome/css/font-awesome.min.css"));

            // <!-- NProgress -->
            bundles.Add(new StyleBundle("~/Content/NProgressCSS").Include(                 
                     "~/vendors/nprogress/nprogress.css"));

            // <!-- iCheck -->
            bundles.Add(new StyleBundle("~/Content/iCheckCSS").Include(                    
                     "~/vendors/iCheck/skins/flat/green.css"));

            //<!-- bootstrap-wysiwyg -->
            bundles.Add(new StyleBundle("~/Content/bootstrapwysiwygCSS").Include(
                     "~/vendors/google-code-prettify/bin/prettify.min.css"));
            
            //<!-- Select2 -->
            bundles.Add(new StyleBundle("~/Content/Select2CSS").Include(
                    "~/vendors/select2/dist/css/select2.min.css"));
            
            // < !--Switchery-- >
            bundles.Add(new StyleBundle("~/Content/SwitcheryCSS").Include(
                    "~/vendors/switchery/dist/switchery.min.css"));
            
            // <!-- starrr -->
            bundles.Add(new StyleBundle("~/Content/starrrCSS").Include(
                   "~/vendors/starrr/dist/starrr.css"));
            
            //<!-- bootstrap-daterangepicker -->
            bundles.Add(new StyleBundle("~/Content/bootstrapDaterangepickerCSS").Include(
                   "~/vendors/bootstrap-daterangepicker/daterangepicker.css"));
            
            //<!-- Custom Theme Style -->
            bundles.Add(new StyleBundle("~/Content/CustomCSS").Include(
                  "~/build/css/custom.min.css"));

            // <!-- Animate.css -->
            bundles.Add(new StyleBundle("~/Content/AnimateCSS").Include(
                 "~/vendors/animate.css/animate.min.css")); 


               //********** SCRIPTS *******************


               //jQuery
               bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/vendors/jquery/dist/jquery.min.js"));


            // <!-- Bootstrap -->
            bundles.Add(new ScriptBundle("~/bundles/BootstrapJS").Include(
                     "~/vendors/bootstrap/dist/js/bootstrap.min.js"));

            //<!-- FastClick -->
            bundles.Add(new ScriptBundle("~/bundles/FastClickJS").Include(
                     "~/vendors/fastclick/lib/fastclick.js"));

            //<!-- NProgress -->
            bundles.Add(new ScriptBundle("~/bundles/NProgressJS").Include(
                     "~/vendors/nprogress/nprogress.js"));

            //<!-- bootstrap-progressbar -->
            bundles.Add(new ScriptBundle("~/bundles/bootstrapProgressbarJS").Include(
                     "~/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js"));

            //< !--iCheck-- >
            bundles.Add(new ScriptBundle("~/bundles/iCheckJS").Include(
                    "~/vendors/iCheck/icheck.min.js"));

            //<!-- bootstrap-daterangepicker -->
            bundles.Add(new ScriptBundle("~/bundles/bootstrapDaterangepickerJS").Include(
                    "~/vendors/moment/min/moment.min.js",
                    "~/vendors/bootstrap-daterangepicker/daterangepicker.js"));

            //<!-- bootstrap-wysiwyg -->
            bundles.Add(new ScriptBundle("~/bundles/bootstrapWysiwygJS").Include(
                    "~/vendors/bootstrap-wysiwyg/js/bootstrap-wysiwyg.min.js",
                    "~/vendors/jquery.hotkeys/jquery.hotkeys.js",
                    "~/vendors/google-code-prettify/src/prettify.js"));

            //<!-- jQuery Tags Input -->
            bundles.Add(new ScriptBundle("~/bundles/tagsinputJS").Include(
                   "~/vendors/jquery.tagsinput/src/jquery.tagsinput.js"));

            // <!-- Switchery -->
            bundles.Add(new ScriptBundle("~/bundles/SwitcheryJS").Include(
                 "~/vendors/switchery/dist/switchery.min.js"));

            //< !--Select2-- >
            bundles.Add(new ScriptBundle("~/bundles/Select2JS").Include(
                "~/vendors/select2/dist/js/select2.full.min.js"));

            //<!-- Parsley -->
            bundles.Add(new ScriptBundle("~/bundles/ParsleyJS").Include(
                "~/vendors/parsleyjs/dist/parsley.min.js"));

            //< !--Autosize-- >
            bundles.Add(new ScriptBundle("~/bundles/AutosizeJS").Include(
                "~/vendors/autosize/dist/autosize.min.js"));

            //< !--jQuery autocomplete-- >
            bundles.Add(new ScriptBundle("~/bundles/autocompleteJS").Include(
               "~/vendors/devbridge-autocomplete/dist/jquery.autocomplete.min.js"));

            // <!-- starrr -->
            bundles.Add(new ScriptBundle("~/bundles/starrrJS").Include(
              "~/vendors/starrr/dist/starrr.js"));

            //< !--Custom Theme Scripts -->
            bundles.Add(new ScriptBundle("~/bundles/customJS").Include(
              "~/build/js/custom.min.js"));

            // < !--Chart.js-- >
            bundles.Add(new ScriptBundle("~/bundles/ChartJS").Include(
              "~/vendors/Chart.js/dist/Chart.min.js"));

            //<!-- jQuery Sparklines -->
            bundles.Add(new ScriptBundle("~/bundles/SparklinesJS").Include(
              "~/vendors/jquery-sparkline/dist/jquery.sparkline.min.js"));

            //  <!-- Flot -->
            bundles.Add(new ScriptBundle("~/bundles/FlotJS").Include(
              "~/vendors/Flot/jquery.flot.js",
              "~/vendors/Flot/jquery.flot.pie.js",
              "~/vendors/Flot/jquery.flot.time.js",
              "~/vendors/Flot/jquery.flot.stack.js",
              "~/vendors/Flot/jquery.flot.resize.js"));

            //<!-- Flot plugins -->
            bundles.Add(new ScriptBundle("~/bundles/FlotPluginsJS").Include(
              "~/vendors/flot.orderbars/js/jquery.flot.orderBars.js",
              "~/vendors/flot-spline/js/jquery.flot.spline.min.js",
              "~/vendors/flot.curvedlines/curvedLines.js"));

            // <!-- DateJS -->
            bundles.Add(new ScriptBundle("~/bundles/DateJS").Include(
              "~/vendors/DateJS/build/date.js"));
            
        }
    }
}
