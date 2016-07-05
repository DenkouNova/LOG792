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
    public class TestMapping_ImageExtractCondSet
    {
        ICriteria criteria;
        ISession sess = ImageExtract.NHibernateHelper.GetCurrentSession();

        IList<ImageExtractCondSet> listOfItems;
        ImageExtractCondSet oneItem;

        [TestInitialize()]
        public void TestInitialize()
        {
            criteria = sess.CreateCriteria<ImageExtractCondSet>()
                .Add(Restrictions.Eq("Cond_Set_Id", 1));
            listOfItems = criteria.List<ImageExtractCondSet>();
            oneItem = listOfItems[0];
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            sess.Close();
        }



        [TestMethod]
        public void CondSetId() { Assert.AreEqual(oneItem.Cond_Set_Id, 1); }



        [TestMethod]
        public void _Association_Conditions() { Assert.AreEqual(oneItem.ImageExtractConditions.Count, 2); }


        [TestMethod]
        public void _Association_ImgExtrConfigs() { Assert.AreEqual(oneItem.ImageExtractConfigs.Count, 1); }

    }
}
