using System;
using System.Text;
using System.Collections.Generic;


namespace ImageExtract.Domain {
    
    public class ImageExtractCondSet {
        public virtual int Cond_Set_Id { get; set; }

        private ISet<ImageExtractCondition> imageExtractConditions = new HashSet<ImageExtractCondition>();
        public virtual ISet<ImageExtractCondition> ImageExtractConditions
        {
            get { return imageExtractConditions; }
            set { imageExtractConditions = value; }
        }

        private ISet<ImageExtractConfig> imageExtractConfigs = new HashSet<ImageExtractConfig>();
        public virtual ISet<ImageExtractConfig> ImageExtractConfigs
        {
            get { return imageExtractConfigs; }
            set { imageExtractConfigs = value; }
        }

        public override string ToString()
        {
            return "Cond_Set_Id = " + StringTools.TraceString(Cond_Set_Id) +
                "\r\n//\r\n" +
                //"Image Extract Image Naming = " + StringTools.TraceString(imageExtract.Image_Naming)
                "ImageExtractConditions.Count = " + ImageExtractConditions.Count +
                ", ImageExtractConfigs.Count = " + ImageExtractConfigs.Count
                ;
        }
    }
}
