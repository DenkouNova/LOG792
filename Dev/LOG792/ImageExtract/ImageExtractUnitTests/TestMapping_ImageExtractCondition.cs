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
    public class TestMapping_ImageExtractCondition
    {
        ICriteria criteria;
        ISession sess = ImageExtract.NHibernateHelper.GetCurrentSession();

        IList<ImageExtractCondition> listOfItems;
        ImageExtractCondition oneItem;

        [TestInitialize()]
        public void TestInitialize()
        {
            criteria = sess.CreateCriteria<ImageExtractCondition>()
                .Add(Restrictions.Eq("Condition_Id", 1));
            listOfItems = criteria.List<ImageExtractCondition>();
            oneItem = listOfItems[0];
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            sess.Close();
        }



        [TestMethod]
        public void TestCount() { Assert.AreEqual(listOfItems.Count, 1); }



        [TestMethod]
        public void Condition_Id() { Assert.AreEqual(oneItem.Condition_Id, 1); }

        [TestMethod]
        public void Description() { Assert.AreEqual(oneItem.Description, "Multiples"); }

        [TestMethod]
        public void Where_Clause() { Assert.AreEqual(oneItem.Where_Clause, "Capture_Batch.Capture_Type_Item = 1"); }


        [TestMethod]
        public void _Association_Categories() { Assert.AreEqual(oneItem.ImageExtractConditionCategories.Count, 1); }

        [TestMethod]
        public void _Association_Categories2() {
            Assert.AreEqual(oneItem.ImageExtractConditionCategories.ToArray<ImageExtractCondCategory>()[0].Description, "Batch type");
        }

        [TestMethod]
        public void _Association_Sets() { Assert.AreEqual(oneItem.ImageExtractConditionSets.Count, 1); }

    }
}
