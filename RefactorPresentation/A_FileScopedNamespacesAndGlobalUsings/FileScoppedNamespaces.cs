// Requires C# 10

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorPresentation.A_FileScopedNamespacesAndGlobalUsings
{
    internal class FileScoppedNamespaces
    {
        internal FileScoppedNamespaces()
        {
            Init();
        }

        private void Init()
        {
            var listOfSomething = new List<string> { "one", "TWO", "Three" };
            var lowerStrings = listOfSomething.Select(l =>  l.ToLower());
        }

        internal int Number { get; set; }
        internal string Word { get; set; }

        internal async Task DoSomethingAsync()
        {
            await Task.Run(() =>
            {
                // Something
            });
        }
    }
}
