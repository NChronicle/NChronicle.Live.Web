using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace NChronicle.Live.Web.Client.Components.Behind
{

    public class App : BaseComponent
    {

        protected string QueryString;
        protected ElementRef SearchBoxElement;
        protected RecordsIndex RecordsIndexComponent;

        protected override async Task OnAfterRenderAsync()
        {
            await JSRuntime.Current.InvokeAsync<object>("OnKeyUpFocusElement", 190, this.SearchBoxElement);
            await JSRuntime.Current.InvokeAsync<object>("FocusElement", this.SearchBoxElement);
        }

        protected async Task OnKeyUp(UIKeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await this.RecordsIndexComponent.Query(this.QueryString, true);
            }
        }

    }

}
