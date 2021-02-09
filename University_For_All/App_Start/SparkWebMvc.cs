using System.Web.Mvc;
using Spark;
using Spark.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(University_For_All.App_Start.SparkWebMvc), "Start")]

namespace University_For_All.App_Start {
    public static class SparkWebMvc {
        public static void Start() {
            var settings = new SparkSettings();
            settings.SetAutomaticEncoding(true); 

            // Note: you can change the list of namespace and assembly
            // references in Views\Shared\_global.spark
            SparkEngineStarter.RegisterViewEngine(settings);
        }
    }
}
