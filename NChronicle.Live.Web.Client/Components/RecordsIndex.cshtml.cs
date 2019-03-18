using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NChronicle.Core.Model;
using NChronicle.Live.Web.Client.Components.Dialogs;
using NChronicle.Live.Web.Shared;
using System;
using System.Collections.Generic;
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
        protected IDictionary<ChronicleLevel, (byte R, byte G, byte B)> LevelColors;

        [Inject] private HttpClient httpClient { get; set; }

        public RecordsIndex()
        {
            this.LevelColors = new Dictionary<ChronicleLevel, (byte R, byte G, byte B)>
            {
                { ChronicleLevel.Critical, (120, 0, 0) },
                { ChronicleLevel.Warning, (90, 90, 0) },
                { ChronicleLevel.Success, (0, 120, 0) },
                { ChronicleLevel.Info, (120, 120, 120) },
                { ChronicleLevel.Debug, (60, 60, 60) }
            };
        }

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

        protected (byte R, byte G, byte B) GetLevelColor(ChronicleLevel level) => LevelColors.ContainsKey(level) ? LevelColors[level] : ((byte) 0, (byte) 0, (byte) 0);

    }
}
