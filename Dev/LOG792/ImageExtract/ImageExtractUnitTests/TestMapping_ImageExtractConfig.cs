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
    public class TestMapping_ImageExtractConfig
    {
        ICriteria criteria;
        ISession sess = ImageExtract.NHibernateHelper.GetCurrentSession();

        IList<ImageExtractConfig> listOfImageExtracts;
        ImageExtractConfig oneImageExtract;

        [TestInitialize()]
        public void TestInitialize()
        {
            criteria = sess.CreateCriteria<ImageExtractConfig>()
                .Add(Restrictions.Eq("ImgExtr_Config_Id", 1));
            listOfImageExtracts = criteria.List<ImageExtractConfig>();
            oneImageExtract = listOfImageExtracts[0];
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            sess.Close();
        }



        [TestMethod]
        public void TestCount() { Assert.AreEqual(listOfImageExtracts.Count, 1); }



        [TestMethod]
        public void ImageExtractId() { Assert.AreEqual(oneImageExtract.ImgExtr_Config_Id, 1); }

        [TestMethod]
        public void Description() { Assert.AreEqual(oneImageExtract.Image_Naming, "abc"); }

        [TestMethod]
        public void Encoding_Config_Path() { Assert.AreEqual(oneImageExtract.Encoding_Config_Path, "def"); }

        [TestMethod]
        public void Endorsement_Config_Path() { Assert.AreEqual(oneImageExtract.Endorsement_Config_Path, "ghi"); }



        [TestMethod]
        public void _FK_StatementId() { Assert.AreEqual(oneImageExtract.statement.Statement_Id, 1319); }

        /*
        [TestMethod]
        public void _Ownership_Archives() { Assert.AreEqual(oneImageExtract.imageExtractArchive.Archive_Naming, "ImgExtr_($STATEMENT_ID, 8).zip"); }
        */
    }
}
