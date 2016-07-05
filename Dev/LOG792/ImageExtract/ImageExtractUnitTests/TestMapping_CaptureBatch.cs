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
    public class TestMapping_CaptureBatch
    {
        ICriteria criteria;
        ISession sess = ImageExtract.NHibernateHelper.GetCurrentSession();
        CaptureBatch oneBatch;

        [TestInitialize()]
        public void TestInitialize()
        {
            criteria = sess.CreateCriteria<CaptureBatch>().Add(Restrictions.Eq("Batch_Seq", 256001));
            oneBatch = criteria.List<CaptureBatch>()[0];
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            sess.Close();
        }



        [TestMethod]
        public void BatchSeq() { Assert.AreEqual(oneBatch.Batch_Seq, 256001); }

        [TestMethod]
        public void CaptureDate() { Assert.AreEqual(oneBatch.Capture_Date, "20160609"); }

        [TestMethod]
        public void CaptureId() { Assert.AreEqual(oneBatch.Capture_Id, 11111111); }

        [TestMethod]
        public void CaptureTypeItem() { Assert.AreEqual(oneBatch.Capture_Type_Item, "2"); }

        [TestMethod]
        public void ClientBatchRefNumber() { Assert.AreEqual(oneBatch.Client_Batch_Ref_Number, "123456"); }

        [TestMethod]
        public void CustomBatchNumber() { Assert.AreEqual(oneBatch.Custom_Batch_Number, 5000); }

        [TestMethod]
        public void ExceptionBatch() { Assert.IsNull(oneBatch.Exception_Batch); }

        [TestMethod]
        public void ReprocessingBatch() { Assert.IsNull(oneBatch.Reprocessing_Batch); }



        [TestMethod]
        public void _FK_StatementId() { Assert.AreEqual(oneBatch.statement.Statement_Id, 1319); }

        [TestMethod]
        public void _Ownership_MatchedPayments() { Assert.AreEqual(oneBatch.MatchedPayments.Count, 4); }

        [TestMethod]
        public void _Ownership_ItemPayments() { Assert.AreEqual(oneBatch.ItemPayments.Count, 4); }

        [TestMethod]
        public void _Ownership_ItemStatements() { Assert.AreEqual(oneBatch.ItemStatements.Count, 5); }




        /*
         *             bool foundBatch = false;
            foreach (CaptureBatch oneBatch in oneStatement.Batches)
            {
                if (oneBatch.Batch_Seq == 256001)
                {
                    foundBatch = true;
                    break;
                }
            }
            Assert.IsTrue(foundBatch);
        */
    }
}
