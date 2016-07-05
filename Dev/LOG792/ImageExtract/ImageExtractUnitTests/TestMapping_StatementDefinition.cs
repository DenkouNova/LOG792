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
    public class TestMapping_StatementDefinition
    {
        ICriteria criteria;
        ISession sess = ImageExtract.NHibernateHelper.GetCurrentSession();

        IList<StatementDefinition> listOfStatements;
        StatementDefinition oneStatement;

        [TestInitialize()]
        public void TestInitialize()
        {
            criteria = sess.CreateCriteria<StatementDefinition>()
                .Add(Restrictions.In("Statement_Id", new int[] { 1319, 4331, 4366 }))
                .AddOrder(Order.Asc("Statement_Id"));
            listOfStatements = criteria.List<StatementDefinition>();
            oneStatement = listOfStatements[0];
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            sess.Close();
        }



        [TestMethod]
        public void TestCount() { Assert.AreEqual(listOfStatements.Count, 3); }



        [TestMethod]
        public void StatementId() { Assert.AreEqual(oneStatement.Statement_Id, 1319); }

        [TestMethod]
        public void Description() { Assert.AreEqual(oneStatement.Description, "CTLK"); }



        [TestMethod]
        public void _FK_HomeSite() { Assert.AreEqual(oneStatement.site.Site_Id, 3); }

        [TestMethod]
        public void _Ownership_Batches() {
            bool foundBatch = false;
            foreach (CaptureBatch oneBatch in oneStatement.Batches)
            {
                if (oneBatch.Batch_Seq == 256001)
                {
                    foundBatch = true;
                    break;
                }
            }
            Assert.IsTrue(foundBatch);
        }
    }
}
