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
using ImageExtract.ObserverPattern;

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
            observableBatchList = new MyObservable();
        }

        private HashSet<Domain.ImageExtractCondition> conditionsInIncludeBox = new HashSet<Domain.ImageExtractCondition>();
        private HashSet<Domain.ImageExtractCondition> conditionsInUnusedBox = new HashSet<Domain.ImageExtractCondition>();
        private HashSet<Domain.ImageExtractCondition> conditionsInExcludeBox = new HashSet<Domain.ImageExtractCondition>();

        public HashSet<Domain.ImageExtractCondition> ConditionsInIncludeBox
        {
            get { return conditionsInIncludeBox; }
            set { conditionsInIncludeBox = value; }
        }

        public HashSet<Domain.ImageExtractCondition> ConditionsInExcludeBox
        {
            get { return conditionsInExcludeBox; }
            set { conditionsInExcludeBox = value; }
        }

        public HashSet<Domain.ImageExtractCondition> ConditionsInUnusedBox
        {
            get { return conditionsInUnusedBox; }
            set { conditionsInUnusedBox = value; }
        }



        public MyObservable observableBatchList;

        



        private IList<Domain.CaptureBatch> previewBatches = new List<Domain.CaptureBatch>();

        public IList<Domain.CaptureBatch> PreviewBatches
        {
            get { return previewBatches; }
            set { previewBatches = value; }
        }



        // Ordinateur à la maison
        public string ImagePath = @"D:\Cossins\Documents\ETS\LOG792\Images";

        // Ordinateur à l'école
        // public string ImagePath = @"J:\LOG792\Images";



    }
}
