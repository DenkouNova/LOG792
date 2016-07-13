using System;
using System.Text;
using System.Collections.Generic;

namespace ImageExtract.Domain {
    
    public class CaptureBatchSummary {

        public virtual int Batch_Seq { get; set; }

        public virtual int? Tot_Num_Payments { get; set; }
        public virtual int? Tot_Num_Statements { get; set; }
        public virtual int? Tot_Num_Envelops { get; set; }

        public virtual CaptureBatch captureBatch { get; set; }

        public override string ToString()
        {
            return "Batch_Seq = " + StringTools.TraceString(Batch_Seq) +
                ", " + "Tot_Num_Payments = " + StringTools.TraceString(Tot_Num_Payments) +
                ", " + "Tot_Num_Statements = " + StringTools.TraceString(Tot_Num_Statements) +
                ", " + "Tot_Num_Envelops = " + StringTools.TraceString(Tot_Num_Envelops) +
                "\r\n//\r\n" +
                "Capture_Batch.Batch_Seq = " + StringTools.TraceString(captureBatch.Batch_Seq);
        }

    }
}
