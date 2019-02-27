using Microsoft.AspNetCore.Components;
using NChronicle.Live.Web.Client.Services;

namespace NChronicle.Live.Web.Client.Components
{
    public class BaseComponent : ComponentBase
    {

        [Inject] private IStyleSheetService styleSheetService { get; set; }

        protected object RegisterStyleSheet(params string[] styleSheets) {
            styleSheetService.RegisterStyleSheet(styleSheets);
            return null;
        }

    }
}
