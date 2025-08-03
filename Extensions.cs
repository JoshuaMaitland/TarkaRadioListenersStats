using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TarkaRadioListenersStats
{
    public static class Extensions
    {
        // Code below from: https://stackoverflow.com/a/41971082/10746214
        public static string GetAssemblyDescription(this Assembly assembly)
        {
            return assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
                .OfType<AssemblyDescriptionAttribute>().SingleOrDefault()?.Description;
        }
    }
}
