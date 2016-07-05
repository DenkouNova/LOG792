using System;
using System.Text;
using System.Collections.Generic;


namespace ImageExtract.Domain {

    [Serializable]
    public class ItemStatementIdentifier
    {
        public virtual int Batch_Seq { get; set; }
        public virtual int Item_Ref { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as ItemStatementIdentifier;
            if (t == null) return false;
            if (Batch_Seq == t.Batch_Seq
             && Item_Ref == t.Item_Ref)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ Batch_Seq.GetHashCode();
            hash = (hash * 397) ^ Item_Ref.GetHashCode();

            return hash;
        }
        #endregion
    }

    public class ItemStatement {

        public virtual ItemStatementIdentifier ItemStatementIdentifier { get; set; }

        public virtual float? Amount_Due { get; set; }
        public virtual float? Amount_Paid { get; set; }
        public virtual int? Chadd_Status { get; set; }
        public virtual string Image_File_Front { get; set; }
        public virtual string Image_File_Rear { get; set; }
        public virtual string Item_Source { get; set; }
        public virtual string Item_Status { get; set; }
        public virtual int Matched_Payment_Seq { get; set; }
        public virtual string Text_1 { get; set; }
        public virtual string Transaction_Reference { get; set; }

        public virtual CaptureBatch batch { get; set; }

        public override string ToString()
        {
            return "Batch_Seq = " + StringTools.TraceString(ItemStatementIdentifier.Batch_Seq) +
                ", " + "Item_Ref = " + StringTools.TraceString(ItemStatementIdentifier.Item_Ref) +
                ", " + "Amount_Due = " + StringTools.TraceString(Amount_Due) +
                ", " + "Amount_Paid = " + StringTools.TraceString(Amount_Paid) +
                ", " + "Chadd_Status = " + StringTools.TraceString(Chadd_Status) +
                ", " + "Image_File_Front = " + StringTools.TraceString(Image_File_Front) +
                ", " + "Image_File_Rear = " + StringTools.TraceString(Image_File_Rear) +
                ", " + "Item_Source = " + StringTools.TraceString(Item_Source) +
                ", " + "Item_Status = " + StringTools.TraceString(Item_Status) +
                ", " + "Matched_Payment_Seq = " + StringTools.TraceString(Matched_Payment_Seq) +
                ", " + "Text_1 = " + StringTools.TraceString(Text_1) +
                ", " + "Transaction_Reference = " + StringTools.TraceString(Transaction_Reference) +
                "\r\n//\r\n" +
                "Batch_Seq(FK) = " + batch.Batch_Seq + " (capture date " + batch.Capture_Date + ")";
        }
    }
}
