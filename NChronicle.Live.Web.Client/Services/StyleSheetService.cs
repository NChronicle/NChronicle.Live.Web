using System;
using System.Collections.Generic;

namespace NChronicle.Live.Web.Client.Services
{

    public class StyleSheetService : IStyleSheetService
    {

        public IEnumerable<string> RegisteredStyleSheets => this.StyleSheetsHashSet;
        public event Action<string[]> OnStyleSheetsRegistered;

        private HashSet<string> StyleSheetsHashSet;

        public StyleSheetService()
        {
            this.StyleSheetsHashSet = new HashSet<string>();
        }

        public void RegisterStyleSheet(params string[] styleSheets)
        {
            var anyAdded = false;
            foreach (var styleSheet in styleSheets)
            {
                anyAdded = this.StyleSheetsHashSet.Add(styleSheet) || anyAdded;
            }
            if (anyAdded)
            {
                this.OnStyleSheetsRegistered?.Invoke(styleSheets);
            }
        }

    }

}
