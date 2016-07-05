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
    public class TestMapping_ItemPayment
    {
        ICriteria criteria;
        ISession sess = ImageExtract.NHibernateHelper.GetCurrentSession();

        ISet<ItemPayment> setOfPayments;
        ItemPayment onePayment;

        [TestInitialize()]
        public void TestInitialize()
        {
            criteria = sess.CreateCriteria<CaptureBatch>().Add(Restrictions.Eq("Batch_Seq", 256001));
            setOfPayments = criteria.List<CaptureBatch>()[0].ItemPayments;
            onePayment =
                (from x in setOfPayments
                 where x.ItemPaymentIdentifier.Item_Ref == 40
                 select x).ToList()[0];
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            sess.Close();
        }


        [TestMethod]
        public void TestCount() { Assert.AreEqual(setOfPayments.Count, 4); }



        [TestMethod]
        public void BatchSeq() { Assert.AreEqual(onePayment.ItemPaymentIdentifier.Batch_Seq, 256001); }

        [TestMethod]
        public void ItemRef() { Assert.AreEqual(onePayment.ItemPaymentIdentifier.Item_Ref, 40); }



        [TestMethod]
        public void Payment_Amount() { Assert.AreEqual(onePayment.Payment_Amount, (Single)12.25); }

        [TestMethod]
        public void Image_File_Front() { Assert.AreEqual(onePayment.Image_File_Front, "13"); }

        [TestMethod]
        public void Image_File_Rear() { Assert.AreEqual(onePayment.Image_File_Rear, "14"); }

        [TestMethod]
        public void Item_Source() { Assert.AreEqual(onePayment.Item_Source, "1"); }

        [TestMethod]
        public void Item_Status() { Assert.AreEqual(onePayment.Item_Status, "2"); }

        [TestMethod]
        public void Matched_Payment_Seq() { Assert.AreEqual(onePayment.Matched_Payment_Seq, 2); }

        [TestMethod]
        public void Text_1() { Assert.AreEqual(onePayment.Text_1, "DEF"); }

        [TestMethod]
        public void Bank_Account() { Assert.AreEqual(onePayment.Bank_Account, "8989189"); }

        [TestMethod]
        public void Check_No() { Assert.AreEqual(onePayment.Check_No, "56658"); }



        [TestMethod]
        public void _FK_BatchSeq() { Assert.AreEqual(onePayment.batch.Batch_Seq, 256001); }

    }
}
