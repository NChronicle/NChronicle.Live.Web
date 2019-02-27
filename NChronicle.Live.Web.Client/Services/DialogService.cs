using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NChronicle.Live.Web.Client.Components.Dialogs;

namespace NChronicle.Live.Web.Client.Services
{
    public class DialogService : IDialogService
    {

        public IEnumerable<Dialog> RegisteredDialogs => this.DialogsList;
        public event Action<Dialog> OnDialogRegistered;
        public event Action<Dialog> OnDialogUnregistered;

        public List<Dialog> DialogsList { get; private set; }

        public DialogService()
        {
            this.DialogsList = new List<Dialog>();
        }

        public async Task RegisterDialogAsync(Dialog dialog)
        {
            this.DialogsList.Add(dialog);
            Console.WriteLine($"Service received registration - currently at {DialogsList.Count} dialogs.");
            await Task.Run(() => {
                Console.WriteLine($"Service notifying event listeners.");
                this.OnDialogRegistered?.Invoke(dialog);
            });
        }

        public async Task UnregisterDialogAsync(Dialog dialog)
        {
            this.DialogsList.RemoveAll(d => d == dialog);
            await Task.Run(() => {
                Console.WriteLine($"Service notifying event listeners.");
                this.OnDialogUnregistered?.Invoke(dialog);
            });

        }

    }
}
