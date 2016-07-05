using System;
using System.Text;
using System.Collections.Generic;


namespace ImageExtract.Domain {
    
    public class ImageExtractConfig {
        public virtual int ImgExtr_Config_Id { get; set; }
        public virtual string Image_Naming { get; set; }
        public virtual string Encoding_Config_Path { get; set; }
        public virtual string Endorsement_Config_Path { get; set; }

        public virtual StatementDefinition statement { get; set; }

        public virtual ImageExtractArchive imageExtractArchive { get; set; }

        private ISet<ImageExtractCondSet> conditionSets = new HashSet<ImageExtractCondSet>();

        public virtual ISet<ImageExtractCondSet> ConditionSets
        {
            get { return conditionSets; }
            set { conditionSets = value; }
        }

        public override string ToString()
        {
            return "ImgExtr_Config_Id = " + StringTools.TraceString(ImgExtr_Config_Id) +
                ", " + "Image_Naming = " + StringTools.TraceString(Image_Naming) +
                ", " + "Encoding_Config_Path = " + StringTools.TraceString(Encoding_Config_Path) +
                ", " + "Endorsement_Config_Path = " + StringTools.TraceString(Endorsement_Config_Path) +
                "\r\n//\r\n" +
                "Statement_Id = " + StringTools.TraceString(statement.Statement_Id) +
                ", Image_Extract_Archive naming = " + StringTools.TraceString(imageExtractArchive.Archive_Naming) +
                ", number of condition sets = " + ConditionSets.Count;
        }
    }
}
