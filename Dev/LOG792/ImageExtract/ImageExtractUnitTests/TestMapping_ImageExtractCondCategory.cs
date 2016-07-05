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
    public class TestMapping_ImageExtractCondCategory
    {
        ICriteria criteria;
        ISession sess = ImageExtract.NHibernateHelper.GetCurrentSession();

        IList<ImageExtractCondCategory> listOfItems;
        ImageExtractCondCategory oneItem;

        [TestInitialize()]
        public void TestInitialize()
        {
            criteria = sess.CreateCriteria<ImageExtractCondCategory>()
                .Add(Restrictions.Eq("Cond_Category_Id", 1));
            listOfItems = criteria.List<ImageExtractCondCategory>();
            oneItem = listOfItems[0];
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            sess.Close();
        }



        [TestMethod]
        public void CondCategoryId() { Assert.AreEqual(oneItem.Cond_Category_Id, 1); }

        [TestMethod]
        public void CondDescription() { Assert.AreEqual(oneItem.Description, "Batch type"); }


        [TestMethod]
        public void _Association_Conditions() { Assert.AreEqual(oneItem.ImageExtractConditions.Count, 3); }

    }
}
