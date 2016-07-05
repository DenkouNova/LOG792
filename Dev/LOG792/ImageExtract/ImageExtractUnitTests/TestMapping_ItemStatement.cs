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
    public class TestMapping_ItemStatement
    {
        ICriteria criteria;
        ISession sess = ImageExtract.NHibernateHelper.GetCurrentSession();

        ISet<ItemStatement> setOfStatements;
        ItemStatement oneStatement;

        [TestInitialize()]
        public void TestInitialize()
        {
            criteria = sess.CreateCriteria<CaptureBatch>().Add(Restrictions.Eq("Batch_Seq", 256001));
            setOfStatements = criteria.List<CaptureBatch>()[0].ItemStatements;
            oneStatement =
                (from x in setOfStatements
                 where x.ItemStatementIdentifier.Item_Ref == 50
                 select x).ToList()[0];
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            sess.Close();
        }
         

        [TestMethod]
        public void TestCount() { Assert.AreEqual(setOfStatements.Count, 5); }


        [TestMethod]
        public void Batchseq() { Assert.AreEqual(oneStatement.ItemStatementIdentifier.Batch_Seq, 256001); }

        [TestMethod]
        public void ItemRef() { Assert.AreEqual(oneStatement.ItemStatementIdentifier.Item_Ref, 50); }



        [TestMethod]
        public void AmountDue() { Assert.AreEqual(oneStatement.Amount_Due, (Single)10.0); }

        [TestMethod]
        public void AmountPaid() { Assert.AreEqual(oneStatement.Amount_Paid, (Single)55.55); }

        [TestMethod]
        public void ChaddStatus() { Assert.AreEqual(oneStatement.Chadd_Status, 0); }

        [TestMethod]
        public void ImageFileFront() { Assert.AreEqual(oneStatement.Image_File_Front, "5"); }

        [TestMethod]
        public void ImageFileRear() { Assert.AreEqual(oneStatement.Image_File_Rear, "6"); }

        [TestMethod]
        public void ItemSource() { Assert.AreEqual(oneStatement.Item_Source, "1"); }

        [TestMethod]
        public void ItemStatus() { Assert.AreEqual(oneStatement.Item_Status, "1"); }

        [TestMethod]
        public void MatchedPaymentSeq() { Assert.AreEqual(oneStatement.Matched_Payment_Seq, 3); }

        [TestMethod]
        public void Text_1() { Assert.IsNull(oneStatement.Text_1); }

        [TestMethod]
        public void TransactionReference() { Assert.AreEqual(oneStatement.Transaction_Reference, "52589729"); }


        [TestMethod]
        public void _FK_BatchSeq() { Assert.AreEqual(oneStatement.batch.Batch_Seq, 256001); }

    }
}
