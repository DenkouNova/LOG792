using System;
using System.Text;
using System.Collections.Generic;


namespace ImageExtract.Domain {
    
    public class ImageExtractCondition {
        public virtual int Condition_Id { get; set; }
        public virtual string Description { get; set; }
        public virtual string Where_Clause { get; set; }

        private ISet<ImageExtractCondCategory> imageExtractConditionCategories =
            new HashSet<ImageExtractCondCategory>();
        public virtual ISet<ImageExtractCondCategory> ImageExtractConditionCategories
        {
            get { return imageExtractConditionCategories; }
            set { imageExtractConditionCategories = value; }
        }

        private ISet<ImageExtractCondSet> imageExtractConditionSets =
            new HashSet<ImageExtractCondSet>();
        public virtual ISet<ImageExtractCondSet> ImageExtractConditionSets
        {
            get { return imageExtractConditionSets; }
            set { imageExtractConditionSets = value; }
        }

        public override string ToString()
        {
            return "Condition_Id = " + StringTools.TraceString(Condition_Id) +
                ", " + "Description = " + StringTools.TraceString(Description) +
                ", " + "Where_Clause = " + StringTools.TraceString(Where_Clause) +
                "\r\n//\r\n" +
                "imageExtractConditionCategories.Count = " + imageExtractConditionCategories.Count +
                ", " + "imageExtractConditionSets = " + imageExtractConditionSets.Count
                ;
        }
    }
}
