using System.Collections.Generic;
using System.Reflection;

namespace MvvmFramework
{
    public static class AssemblySource
    {
        /// <summary>
        /// The singleton instance of the AssemblySource used by the framework.
        /// </summary>
        public static readonly List<Assembly> Instance = new List<Assembly>();
    }
}