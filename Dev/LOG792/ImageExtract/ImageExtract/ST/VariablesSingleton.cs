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

        public static VariablesSingleton GetGlobalVariables()
        {
            if (allVariables == null) allVariables = new VariablesSingleton();
            return allVariables;
        }




        private List<Domain.CaptureBatch> previewBatches;

        private VariablesSingleton()
        {
            previewBatches = new List<Domain.CaptureBatch>();
        }

        public List<Domain.CaptureBatch> PreviewBatches
        {
            get { return previewBatches; }
            set { previewBatches = value; }
        }



    }
}
