using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingCeasarCypher
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EncryptionTest()
        {
            string reference = "I love pizza very much! What is your favorite food";
            string expected = "K nqxg rkbbc xgta owej! Yjcv ku aqwt hcxqtkvg hqqf";
            string actual = CeasarCypher.Cypher.Encrypt(reference);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecryptionTest()
        {
            string reference = "K nqxg rkbbc xgta owej! Yjcv ku aqwt hcxqtkvg hqqf";
            string expected = "I love pizza very much! What is your favorite food";
            string actual = CeasarCypher.Cypher.Decrypt(reference);
            Assert.AreEqual(expected, actual);
        }
    }
}
