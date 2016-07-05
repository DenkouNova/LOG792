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
    public class TestMapping_MatchedPayment
    {
        ICriteria criteria;
        ISession sess = ImageExtract.NHibernateHelper.GetCurrentSession();

        ISet<MatchedPayment> setOfMatchedPayments;
        MatchedPayment oneMatchedPayment;

        [TestInitialize()]
        public void TestInitialize()
        {
            criteria = sess.CreateCriteria<CaptureBatch>().Add(Restrictions.Eq("Batch_Seq", 256001));
            setOfMatchedPayments = criteria.List<CaptureBatch>()[0].MatchedPayments;
            oneMatchedPayment =
                (from x in setOfMatchedPayments
                where x.MatchedPaymentIdentifier.Matched_Payment_Seq == 1
                select x).ToList()[0];
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            sess.Close();
        }



        [TestMethod]
        public void TestCount() { Assert.AreEqual(setOfMatchedPayments.Count, 4); }



        [TestMethod]
        public void MatchedPaymentSeq() { Assert.AreEqual(oneMatchedPayment.MatchedPaymentIdentifier.Matched_Payment_Seq, 1); }

        [TestMethod]
        public void MatchedPaymentStatus() { Assert.AreEqual(oneMatchedPayment.Matched_Payment_Status, "1"); }



        [TestMethod]
        public void _FK_BatchSeq() { Assert.AreEqual(oneMatchedPayment.batch.Batch_Seq, 256001); }

    }
}
