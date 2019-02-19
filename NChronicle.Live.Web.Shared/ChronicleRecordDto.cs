using NChronicle.Core.Model;
using System;

namespace NChronicle.Live.Web.Shared
{
    public class ChronicleRecordDto : ChronicleRecord
    {

        public ChronicleRecordDto() : base(ChronicleLevel.Info) { }

        public DateTime Time;

    }
}
