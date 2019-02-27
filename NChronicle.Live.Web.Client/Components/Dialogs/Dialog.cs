using Microsoft.AspNetCore.Components;
using NChronicle.Live.Web.Client.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NChronicle.Live.Web.Client.Components.Dialogs
{
    public class Dialog : BaseComponent, IDisposable
    {

        [Parameter] public string Title { get; private set; }
        [Parameter] public RenderFragment ChildContent { get; private set; }
        [Parameter] public Dictionary<string, Action> Buttons { get; private set; }
        [Parameter] public bool Closable { get; private set; }
        [Parameter] public bool Modal { get; private set; }
        [Parameter] public bool Show { get; private set; }
        [Parameter] public string ContentClass { get; private set; }

        public event Action<Dialog> OnDialogUpdated;

        [Inject] private IDialogService dialogService { get; set; }

        protected override async Task OnInitAsync() =>
            await this.dialogService.RegisterDialogAsync(this);

        protected override async Task OnParametersSetAsync() =>
            await Task.Run(() => this.OnDialogUpdated?.Invoke(this));

        public void ShowDialog() => this.Show = true;

        public void HideDialog() => this.Show = false;

        #region IDisposable Support
        private bool disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.dialogService.UnregisterDialogAsync(this);
                    GC.SuppressFinalize(this);
                }

                disposed = true;
            }
        }

        ~Dialog() => Dispose(false);

        // This code added to correctly implement the disposable pattern.
        public void Dispose() => Dispose(true);
        #endregion

    }
}
