using System;
using System.Text;
using System.Collections.Generic;


namespace ImageExtract.Domain {
    
    public class StatementDefinition {
        public virtual int Statement_Id { get; set; }
        public virtual string Description { get; set; }

        public virtual CaptureSiteDefinition site { get; set; }

        private ISet<CaptureBatch> batches = new HashSet<CaptureBatch>();
        public virtual ISet<CaptureBatch> Batches
        {
            get { return batches; }
            set { batches = value; }
        }

        public override string ToString()
        {
            return "Statement_Id = " + StringTools.TraceString(Statement_Id) +
                ", " + "Description = " + StringTools.TraceString(Description) +
                "\r\n//\r\n" +
                "Home_Site = " + StringTools.TraceString(site.Site_Id) +
                ", Batches.Count = " + Batches.Count;
        }

    }
}
