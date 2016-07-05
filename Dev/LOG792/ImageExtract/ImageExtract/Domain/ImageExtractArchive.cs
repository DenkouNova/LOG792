using System;
using System.Text;
using System.Collections.Generic;


namespace ImageExtract.Domain {
    
    public class ImageExtractArchive {
        public virtual int ImgExtr_Config_Id { get; set; }
        public virtual string Archive_Naming { get; set; }
        public virtual string Archive_Type { get; set; }

        public virtual ImageExtractConfig imageExtractConfig { get; set; }

        public override string ToString()
        {
            return "ImgExtr_Config_Id = " + StringTools.TraceString(ImgExtr_Config_Id) +
                ", " + "Archive_Naming = " + StringTools.TraceString(Archive_Naming) +
                ", " + "Archive_Type = " + StringTools.TraceString(Archive_Type) +
                "\r\n//\r\n" +
                "Image Extract Image Naming = " + StringTools.TraceString(imageExtractConfig.Image_Naming)
                ;
        }
    }
}
