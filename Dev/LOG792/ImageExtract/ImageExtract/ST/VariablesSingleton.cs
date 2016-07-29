using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;

using ImageExtract.ST;
using ImageExtract.Domain;

namespace ImageExtract.ST
{
    public class VariablesSingleton
    {
        private static VariablesSingleton allVariables = null;

        public static VariablesSingleton GetInstance()
        {
            if (allVariables == null) allVariables = new VariablesSingleton();
            return allVariables;
        }

        private VariablesSingleton()
        {
            previewBatches = new List<Domain.CaptureBatch>();
        }




        private List<Domain.CaptureBatch> previewBatches;

        public List<Domain.CaptureBatch> PreviewBatches
        {
            get { return previewBatches; }
            set { previewBatches = value; }
        }

        // Ordinateur à la maison
        // public string ImagePath = @"D:\Cossins\Documents\ETS\LOG792\Images";

        // Ordinateur à l'école
        public string ImagePath = @"J:\LOG792\Images";



    }
}
