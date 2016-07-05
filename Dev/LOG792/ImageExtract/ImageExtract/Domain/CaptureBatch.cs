using System;
using System.Text;
using System.Collections.Generic;

namespace ImageExtract.Domain {
    
    public class CaptureBatch {

        public virtual int Batch_Seq { get; set; }

        public virtual string Capture_Date { get; set; }
        public virtual int? Capture_Id { get; set; }
        public virtual string Capture_Type_Item { get; set; }
        public virtual string Client_Batch_Ref_Number { get; set; }
        public virtual int? Custom_Batch_Number { get; set; }
        public virtual int? Exception_Batch { get; set; }
        public virtual int? Reprocessing_Batch { get; set; }

        public virtual StatementDefinition statement { get; set; }

        private ISet<MatchedPayment> matchedPayments = new HashSet<MatchedPayment>();
        public virtual ISet<MatchedPayment> MatchedPayments
        {
            get { return matchedPayments; }
            set { matchedPayments = value; }
        }

        private ISet<ItemPayment> itemPayments = new HashSet<ItemPayment>();
        public virtual ISet<ItemPayment> ItemPayments
        {
            get { return itemPayments; }
            set { itemPayments = value; }
        }

        private ISet<ItemStatement> itemStatements = new HashSet<ItemStatement>();
        public virtual ISet<ItemStatement> ItemStatements
        {
            get { return itemStatements; }
            set { itemStatements = value; }
        }

        public override string ToString()
        {
            return "Batch_Seq = " + StringTools.TraceString(Batch_Seq) +
                ", " + "Capture_Date = " + StringTools.TraceString(Capture_Date) +
                ", " + "Capture_Id = " + StringTools.TraceString(Capture_Id) +
                ", " + "Capture_Type_Item = " + StringTools.TraceString(Capture_Type_Item) +
                ", " + "Client_Batch_Ref_Number = " + StringTools.TraceString(Client_Batch_Ref_Number) +
                ", " + "Custom_Batch_Number = " + StringTools.TraceString(Custom_Batch_Number) +
                ", " + "Exception_Batch = " + StringTools.TraceString(Exception_Batch) +
                ", " + "Reprocessing_Batch = " + StringTools.TraceString(Reprocessing_Batch) +
                "\r\n//\r\n" + 
                "Statement_Id = " + StringTools.TraceString(statement.Statement_Id) +
                ", " + "MatchedPayments.Count = " + MatchedPayments.Count +
                ", " + "ItemPayments.Count = " + ItemPayments.Count +
                ", " + "ItemStatements.Count = " + ItemStatements.Count;
        }



    }
}
