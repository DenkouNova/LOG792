using System;
using System.Text;
using System.Collections.Generic;


namespace ImageExtract.Domain {
    
    public class ImageExtractCondCategory {
        public virtual int Cond_Category_Id { get; set; }
        public virtual string Description { get; set; }

        private ISet<ImageExtractCondition> imageExtractConditions = new HashSet<ImageExtractCondition>();
        public virtual ISet<ImageExtractCondition> ImageExtractConditions
        {
            get { return imageExtractConditions; }
            set { imageExtractConditions = value; }
        }

        public override string ToString()
        {
            return "Condition_Category_Id = " + StringTools.TraceString(Cond_Category_Id) +
                ", " + "Description = " + StringTools.TraceString(Description) +
                "\r\n//\r\n" +
                "ImageExtractConditions.Count = " + ImageExtractConditions.Count
                ;
        }
    }
}
