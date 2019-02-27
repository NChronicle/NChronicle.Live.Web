using NChronicle.Live.Web.Client.Components.Dialogs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NChronicle.Live.Web.Client.Services
{
    interface IDialogService
    {

        IEnumerable<Dialog> RegisteredDialogs { get; }
        event Action<Dialog> OnDialogRegistered;
        event Action<Dialog> OnDialogUnregistered;

        Task RegisterDialogAsync(Dialog model);

        Task UnregisterDialogAsync(Dialog model);

    }
}
