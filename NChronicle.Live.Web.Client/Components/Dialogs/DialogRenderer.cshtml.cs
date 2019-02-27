using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace NChronicle.Live.Web.Client.Components.Dialogs.Behind
{
    public class DialogRenderer : BaseComponent
    {

        [Parameter]
        public Dialog Dialog { get; private set; }

        protected override void OnInit()
        {
            this.Dialog.OnDialogUpdated += (dialog) => this.StateHasChanged();
        }
        protected void OnClose()
        {
            this.Dialog.HideDialog();
        }

    }
}
