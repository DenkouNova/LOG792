using System;
using System.Text;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;

using ImageExtract.ST;
using ImageExtract.Domain;

namespace ImageExtractUnitTests
{
    [TestClass]
    public class TestMapping_ImageExtractArchive
    {
        ICriteria criteria;
        ISession sess = ImageExtract.NHibernateHelper.GetCurrentSession();

        ImageExtractArchive oneImageExtractArchive;

        [TestInitialize()]
        public void TestInitialize()
        {
            criteria = sess.CreateCriteria<ImageExtract.Domain.ImageExtractConfig>()
                .Add(Restrictions.Eq("ImgExtr_Config_Id", 1));
            oneImageExtractArchive = criteria.List<ImageExtract.Domain.ImageExtractConfig>()[0].imageExtractArchive;
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            sess.Close();
        }



        [TestMethod]
        public void Archive_Naming() { Assert.AreEqual(oneImageExtractArchive.Archive_Naming, "ImgExtr_($STATEMENT_ID, 8).zip"); }

        [TestMethod]
        public void Archive_Type() { Assert.AreEqual(oneImageExtractArchive.Archive_Type, "zip"); }


        
        [TestMethod]
        public void _FK_ImgExtr_Config_Id() { Assert.AreEqual(oneImageExtractArchive.imageExtractConfig.ImgExtr_Config_Id, 1); }
        
    }
}
