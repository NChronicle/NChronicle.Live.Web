using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.Concurrent;
using NChronicle.Core.Model;
using NChronicle.Core.Interfaces;
using NChronicle.Live.Web.Shared;
using System.Threading;
using System;

namespace NChronicle.Live.Web.Server.Controllers
{

    [Route("api/chroniclerecord")]
    public class ChronicleRecordController : Controller
    {

        private IChronicle _chronicle;
        private ConcurrentBag<ChronicleRecordDto> _records;

        public ChronicleRecordController(IChronicle chronicle)
        {
            this._chronicle = chronicle;
            this._records = new ConcurrentBag<ChronicleRecordDto>();
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now, Level = ChronicleLevel.Info, Message = "Hello World!" });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddHours(-6), Level = ChronicleLevel.Success, Message = "Yeeey!" });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-2).AddHours(-1), Level = ChronicleLevel.Critical, Message = "Oops!" });
        }


        [HttpGet]
        public IEnumerable<ChronicleRecordDto> GetAll()
        {
            this._chronicle.Info("Received call to fetch all records.");
            return this._records;
        }
    }

}
