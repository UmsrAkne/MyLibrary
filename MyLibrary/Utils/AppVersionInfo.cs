using System.Reflection;
using System.Text.RegularExpressions;
using Prism.Mvvm;

namespace MyLibrary.Utils
{
    public class AppVersionInfo : BindableBase
    {
        public AppVersionInfo()
        {
            var projectName = Assembly.GetExecutingAssembly().GetName().Name ?? string.Empty;
            ProjectName = Regex.Replace(projectName, "([a-z])([A-Z])", "$1 $2");
        }

        public string Title => GetAppNameWithVersion();

        private string ProjectName { get; }

        public string GetAppNameWithVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var infoVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
            return !string.IsNullOrWhiteSpace(infoVersion)
                ? $"{ProjectName} ver:{infoVersion}"
                : $"{ProjectName} (version unknown)";
        }
    }
}