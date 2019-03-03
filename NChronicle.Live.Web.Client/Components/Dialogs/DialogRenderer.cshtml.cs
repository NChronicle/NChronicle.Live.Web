using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace NChronicle.Live.Web.Client.Components.Dialogs.Behind
{
    public class DialogRenderer : BaseComponent
    {

        [Parameter]
        public Dialog Dialog { get; private set; }

        protected bool Closing { get; set; }
        protected ElementRef CloseButton { get; set; }

        protected override void OnInit()
        {
            this.Dialog.OnDialogUpdated += d => this.StateHasChanged();
            this.Dialog.OnDialogShow += d => JSRuntime.Current.InvokeAsync<object>("TakeFocus", this.CloseButton);
            this.Dialog.OnDialogHide += d => JSRuntime.Current.InvokeAsync<object>("RestoreFocus");
        }

        protected void OnUnfocus()
        {
            if (this.Dialog.Closable && this.Dialog.UnfocusClosable)
            {
                this.OnClose();
            }
        }

        protected void OnClose()
        {
            this.Closing = true;
            Task.Delay(500).ContinueWith(t => {
                this.Dialog.HideDialog();
                this.Closing = false;
                this.StateHasChanged();
            });
        }

    }
}
