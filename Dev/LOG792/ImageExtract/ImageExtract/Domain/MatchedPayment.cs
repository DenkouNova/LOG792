using System;
using System.Text;
using System.Collections.Generic;


namespace ImageExtract.Domain {
    
    [Serializable]
    public class MatchedPaymentIdentifier
    {
        public virtual int Batch_Seq { get; set; }
        public virtual int Matched_Payment_Seq { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as MatchedPaymentIdentifier;
            if (t == null) return false;
            if (Batch_Seq == t.Batch_Seq
             && Matched_Payment_Seq == t.Matched_Payment_Seq)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ Batch_Seq.GetHashCode();
            hash = (hash * 397) ^ Matched_Payment_Seq.GetHashCode();

            return hash;
        }
        #endregion
    }

    public class MatchedPayment {

        public virtual MatchedPaymentIdentifier MatchedPaymentIdentifier { get; set; }
        public virtual string Matched_Payment_Status { get; set; }

        public virtual CaptureBatch batch { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as MatchedPayment;
			if (t == null) return false;
            return (this.MatchedPaymentIdentifier.Equals(t.MatchedPaymentIdentifier));
        }
        public override int GetHashCode() {
            return this.MatchedPaymentIdentifier.GetHashCode();
        }
        #endregion

        public override string ToString()
        {
            return "Batch_Seq = " + StringTools.TraceString(MatchedPaymentIdentifier.Batch_Seq) +
                ", " + "Matched_Payment_Seq = " + StringTools.TraceString(MatchedPaymentIdentifier.Matched_Payment_Seq) +
                ", " + "Matched_Payment_Status = " + StringTools.TraceString(Matched_Payment_Status +
                "\r\n//\r\n" +
                "Batch_Seq(FK) = " + batch.Batch_Seq + " (capture date " + batch.Capture_Date + ")");
        }
    }
}
