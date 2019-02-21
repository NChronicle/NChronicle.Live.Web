using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NChronicle.Live.Web.Client.Services
{

    public interface IStyleSheetService
    {

        event Action<string[]> OnStyleSheetsRegistered;

        IEnumerable<string> RegisteredStyleSheets { get; }

        void RegisterStyleSheet(params string[] styleSheets);

    }

}
