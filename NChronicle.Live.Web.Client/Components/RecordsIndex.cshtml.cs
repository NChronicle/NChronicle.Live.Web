using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NChronicle.Live.Web.Client.Components.Dialogs;
using NChronicle.Live.Web.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace NChronicle.Live.Web.Client.Components.Behind
{
    public class RecordsIndex : BaseComponent
    {

        [Parameter] public string QueryString { get; private set; }

        protected ElementRef RecordsIndexComponentElement;
        protected Dialog RecordsDetailDialog { get; set; }

        protected ChronicleRecordDto SelectedChronicleRecord { get; set; }
        protected ChronicleRecordDto[] Records;

        [Inject] private HttpClient httpClient { get; set; }

        protected override async Task OnInitAsync()
        {
            await this.Query();
        }

        protected void OnRecordSelect(ChronicleRecordDto selectedRecord)
        {
            Console.WriteLine($"--- Dialog is currently: {RecordsDetailDialog}");
            this.SelectedChronicleRecord = selectedRecord;
            this.StateHasChanged();
            Console.WriteLine($"--- Dialog is currently: {RecordsDetailDialog}");
            this.RecordsDetailDialog.ShowDialog();
        }

        protected void OnDialogClose(Dialog _)
        {
            this.SelectedChronicleRecord = null;
            this.StateHasChanged();
        }

        public async Task Query(string queryString = null, bool scrollIntoView = false)
        {
            this.Records = null;
            this.StateHasChanged();

            if (queryString == null) queryString = this.QueryString;
            if (queryString != null) queryString = HttpUtility.UrlEncode(queryString);
            this.Records = await this.httpClient.GetJsonAsync<ChronicleRecordDto[]>($"api/chroniclerecord" + (queryString != null ? $"?query={queryString}" : ""));
            this.StateHasChanged();
            if (scrollIntoView) _ = JSRuntime.Current.InvokeAsync<object>("ScrollToElement", this.RecordsIndexComponentElement);
        }

    }
}
