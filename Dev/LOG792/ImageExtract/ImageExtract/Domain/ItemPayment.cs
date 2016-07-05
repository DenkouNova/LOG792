using System;
using System.Text;
using System.Collections.Generic;

namespace ImageExtract.Domain {

    [Serializable]
    public class ItemPaymentIdentifier
    {
        public virtual int Batch_Seq { get; set; }
        public virtual int Item_Ref { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as ItemPaymentIdentifier;
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

    public class ItemPayment {

        public virtual ItemPaymentIdentifier ItemPaymentIdentifier { get; set; }

        public virtual float? Payment_Amount { get; set; }
        public virtual string Image_File_Front { get; set; }
        public virtual string Image_File_Rear { get; set; }
        public virtual string Item_Source { get; set; }
        public virtual string Item_Status { get; set; }
        public virtual int Matched_Payment_Seq { get; set; }
        public virtual string Text_1 { get; set; }
        public virtual string Bank_Account { get; set; }
        public virtual string Check_No { get; set; }

        public virtual CaptureBatch batch { get; set; }

        public override string ToString()
        {
            return "Batch_Seq = " + StringTools.TraceString(ItemPaymentIdentifier.Batch_Seq) +
                ", " + "Item_Ref = " + StringTools.TraceString(ItemPaymentIdentifier.Item_Ref) +
                ", " + "Payment_Amount = " + StringTools.TraceString(Payment_Amount) +
                ", " + "Image_File_Front = " + StringTools.TraceString(Image_File_Front) +
                ", " + "Image_File_Rear = " + StringTools.TraceString(Image_File_Rear) +
                ", " + "Item_Source = " + StringTools.TraceString(Item_Source) +
                ", " + "Item_Status = " + StringTools.TraceString(Item_Status) +
                ", " + "Matched_Payment_Seq = " + StringTools.TraceString(Matched_Payment_Seq) +
                ", " + "Text_1 = " + StringTools.TraceString(Text_1) +
                ", " + "Bank_Account = " + StringTools.TraceString(Bank_Account) +
                ", " + "Check_No = " + StringTools.TraceString(Check_No) +
                "\r\n//\r\n" +
                "Batch_Seq(FK) = " + batch.Batch_Seq + " (capture date " + batch.Capture_Date + ")";
        }
    }
}
