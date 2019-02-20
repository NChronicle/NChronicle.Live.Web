using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.Concurrent;
using NChronicle.Core.Model;
using NChronicle.Core.Interfaces;
using NChronicle.Live.Web.Shared;
using System.Threading;
using System;
using System.Linq;

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
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-2), Level = ChronicleLevel.Info, Message = "System.IO.IOException: Kieran you broke it again! Could not read asset because Asset Store wasn't running!", Tags = new List<string>() { "something", "another", "even-more-component" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-6), Level = ChronicleLevel.Success, Message = "NChronicle.Logging.LoggingException: This exception is a random exception just for sake of testing logging, infact... it doesn't exist, this is just a hardcoded string in the controller!" });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-2).AddHours(-1), Level = ChronicleLevel.Critical, Message = "Doggo.Catto.Loggo.MeowsomException: We need more cats in the house, there isn't enough cat litter smell and cat hair embedded in the furniture!", Tags = new List<string>() { "something", "another", "even-more-component", "dog", "cat", "final-fantasy-xiv", "chronicle record testing again" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-4), Level = ChronicleLevel.Info, Message = "System.IO.IOException: Kieran you broke it again! Could not read asset because Asset Store wasn't running!", Tags = new List<string>() { "something", "another", "even-more-component" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-1), Level = ChronicleLevel.Success, Message = "NChronicle.Logging.LoggingException: This exception is a random exception just for sake of testing logging, infact... it doesn't exist, this is just a hardcoded string in the controller!", Tags = new List<string>() { "something", "even-more-component", "chronicle record testing again", "dog", "cat", "final-fantasy-xiv" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-2).AddHours(-23), Level = ChronicleLevel.Critical, Message = "Doggo.Catto.Loggo.MeowsomException: We need more cats in the house, there isn't enough cat litter smell and cat hair embedded in the furniture!", Tags = new List<string>() { "final-fantasy-xiv", "chronicle record testing again" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-8), Level = ChronicleLevel.Info, Message = "System.IO.IOException: Kieran you broke it again! Could not read asset because Asset Store wasn't running!", Tags = new List<string>() { "something", "another", "even-more-component" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-3), Level = ChronicleLevel.Success, Message = "NChronicle.Logging.LoggingException: This exception is a random exception just for sake of testing logging, infact... it doesn't exist, this is just a hardcoded string in the controller!" });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-2).AddHours(-8), Level = ChronicleLevel.Critical, Message = "Doggo.Catto.Loggo.MeowsomException: We need more cats in the house, there isn't enough cat litter smell and cat hair embedded in the furniture!", Tags = new List<string>() { "something", "another", "even-more-component", "dog", "cat", "final-fantasy-xiv", "chronicle record testing again" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-1), Level = ChronicleLevel.Info, Message = "System.IO.IOException: Kieran you broke it again! Could not read asset because Asset Store wasn't running!", Tags = new List<string>() { "something", "another", "even-more-component" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-9), Level = ChronicleLevel.Success, Message = "NChronicle.Logging.LoggingException: This exception is a random exception just for sake of testing logging, infact... it doesn't exist, this is just a hardcoded string in the controller!", Tags = new List<string>() { "something", "even-more-component", "chronicle record testing again", "dog", "cat", "final-fantasy-xiv" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-2).AddHours(-12), Level = ChronicleLevel.Critical, Message = "Doggo.Catto.Loggo.MeowsomException: We need more cats in the house, there isn't enough cat litter smell and cat hair embedded in the furniture!", Tags = new List<string>() { "final-fantasy-xiv", "chronicle record testing again" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-14), Level = ChronicleLevel.Info, Message = "System.IO.IOException: Kieran you broke it again! Could not read asset because Asset Store wasn't running!", Tags = new List<string>() { "something", "another", "even-more-component" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-3), Level = ChronicleLevel.Success, Message = "NChronicle.Logging.LoggingException: This exception is a random exception just for sake of testing logging, infact... it doesn't exist, this is just a hardcoded string in the controller!" });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-2).AddHours(-1), Level = ChronicleLevel.Critical, Message = "Doggo.Catto.Loggo.MeowsomException: We need more cats in the house, there isn't enough cat litter smell and cat hair embedded in the furniture!", Tags = new List<string>() { "something", "another", "even-more-component", "dog", "cat", "final-fantasy-xiv", "chronicle record testing again" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-13), Level = ChronicleLevel.Info, Message = "System.IO.IOException: Kieran you broke it again! Could not read asset because Asset Store wasn't running!", Tags = new List<string>() { "something", "another", "even-more-component" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-7), Level = ChronicleLevel.Success, Message = "NChronicle.Logging.LoggingException: This exception is a random exception just for sake of testing logging, infact... it doesn't exist, this is just a hardcoded string in the controller!", Tags = new List<string>() { "something", "even-more-component", "chronicle record testing again", "dog", "cat", "final-fantasy-xiv" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-1).AddHours(-2), Level = ChronicleLevel.Critical, Message = "Doggo.Catto.Loggo.MeowsomException: We need more cats in the house, there isn't enough cat litter smell and cat hair embedded in the furniture!", Tags = new List<string>() { "final-fantasy-xiv", "chronicle record testing again" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-9), Level = ChronicleLevel.Info, Message = "System.IO.IOException: Kieran you broke it again! Could not read asset because Asset Store wasn't running!", Tags = new List<string>() { "something", "another", "even-more-component" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-6), Level = ChronicleLevel.Success, Message = "NChronicle.Logging.LoggingException: This exception is a random exception just for sake of testing logging, infact... it doesn't exist, this is just a hardcoded string in the controller!" });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-8).AddHours(-3), Level = ChronicleLevel.Critical, Message = "Doggo.Catto.Loggo.MeowsomException: We need more cats in the house, there isn't enough cat litter smell and cat hair embedded in the furniture!", Tags = new List<string>() { "something", "another", "even-more-component", "dog", "cat", "final-fantasy-xiv", "chronicle record testing again" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-9), Level = ChronicleLevel.Info, Message = "System.IO.IOException: Kieran you broke it again! Could not read asset because Asset Store wasn't running!", Tags = new List<string>() { "something", "another", "even-more-component" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-4), Level = ChronicleLevel.Success, Message = "NChronicle.Logging.LoggingException: This exception is a random exception just for sake of testing logging, infact... it doesn't exist, this is just a hardcoded string in the controller!", Tags = new List<string>() { "something", "even-more-component", "chronicle record testing again", "dog", "cat", "final-fantasy-xiv" } });
            this._records.Add(new ChronicleRecordDto() { Time = DateTime.Now.AddDays(-15).AddHours(-1), Level = ChronicleLevel.Critical, Message = "Doggo.Catto.Loggo.MeowsomException: We need more cats in the house, there isn't enough cat litter smell and cat hair embedded in the furniture!", Tags = new List<string>() { "final-fantasy-xiv", "chronicle record testing again" } });
        }


        [HttpGet]
        public IEnumerable<ChronicleRecordDto> GetAll()
        {
            this._chronicle.Info("Received call to fetch all records.");
            return this._records.OrderBy(r => r.Time);
        }
    }

}
