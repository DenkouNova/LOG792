using System;
using System.Text;
using System.Collections.Generic;


namespace ImageExtract.Domain {
    
    public class CaptureSiteDefinition {
        public virtual int Site_Id { get; set; }
        public virtual string Description { get; set; }

        private ISet<StatementDefinition> statements = new HashSet<StatementDefinition>();

        public virtual ISet<StatementDefinition> Statements
        {
            get { return statements; }
            set { statements = value; }
        }

        public override string ToString()
        {
            return "Site_Id = " + StringTools.TraceString(Site_Id) +
                ", " + "Description = " + StringTools.TraceString(Description) +
                "\r\n//\r\n" +
                "Statements.Count = " + Statements.Count;
        }

        

    } 
}
