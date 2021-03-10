using Microsoft.VisualStudio.TestTools.UnitTesting;
using NicolaiHansenEksamen.GUILayer;
using System;

namespace NicolaiHansenEksamenTest
{
    [TestClass]
    public class DatabaseHandlerTest
    {
        [TestMethod]
        public void insertPlayerDataTest()
        {
            //Arrange
            TestClass testclass = new TestClass();
            string name = "Nicolai Hansen";
            string smnName = "Phreakkie";
            string rank = "Gold 5";
            int phnNmb = 22536194;
            string turnType = "5v5";

            //Act
            string exMessage = "1";
            try
            {

            testclass.testMetode(name, smnName, rank, phnNmb, turnType);
            }
            catch(Exception ex)
            {
                exMessage = ex.ToString();
            }
            //Assert
            Assert.AreEqual(exMessage, "0x80131904");
        }
    }
}
