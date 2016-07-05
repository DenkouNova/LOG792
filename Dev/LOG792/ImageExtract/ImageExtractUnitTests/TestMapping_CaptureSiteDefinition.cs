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
    public class TestMapping_CaptureSiteDefinition
    {
        ICriteria criteria;
        ISession sess = ImageExtract.NHibernateHelper.GetCurrentSession();

        IList<CaptureSiteDefinition> listOfSites;
        CaptureSiteDefinition oneSite;

        [TestInitialize()]
        public void TestInitialize()
        {
            criteria = sess.CreateCriteria<CaptureSiteDefinition>()
                .Add(Restrictions.In("Site_Id", new int[] { 0, 1, 3 }))
                .AddOrder(Order.Asc("Site_Id"));
            listOfSites = criteria.List<CaptureSiteDefinition>();
            oneSite = listOfSites[0];
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            sess.Close();
        }


        [TestMethod]
        public void TestCount() { Assert.AreEqual(listOfSites.Count, 3); }

        [TestMethod]
        public void SiteId() { Assert.AreEqual(oneSite.Site_Id, 0); }

        [TestMethod]
        public void Description() { Assert.AreEqual(oneSite.Description, "Addison, IL"); }


        [TestMethod]
        public void _Ownership_Statements() { Assert.AreEqual(oneSite.Statements.Count, 2); }

    }
}
