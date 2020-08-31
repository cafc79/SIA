using BOCAR.SACI.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Collections.Generic;

namespace Test_Business
{
    
    
    /// <summary>
    ///This is a test class for BuzonManagerTest and is intended
    ///to contain all BuzonManagerTest Unit Tests
    ///</summary>
	[TestClass()]
	public class BuzonManagerTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for BuzonManager Constructor
		///</summary>
		[TestMethod()]
		public void BuzonManagerConstructorTest()
		{
			BuzonManager target = new BuzonManager();
			Assert.Inconclusive("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for DeleteConfigBuzon
		///</summary>
		[TestMethod()]
		public void DeleteConfigBuzonTest()
		{
			BuzonManager target = new BuzonManager(); // TODO: Initialize to an appropriate value
			int iConfiguracion = 0; // TODO: Initialize to an appropriate value
			target.DeleteConfigBuzon(iConfiguracion);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for GetMessages
		///</summary>
		[TestMethod()]
		public void GetMessagesTest()
		{
			BuzonManager target = new BuzonManager(); // TODO: Initialize to an appropriate value
			DataTable expected = null; // TODO: Initialize to an appropriate value
			DataTable actual;
			actual = target.GetMessages();
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for InsertConfigBuzon
		///</summary>
		[TestMethod()]
		public void InsertConfigBuzonTest()
		{
			BuzonManager target = new BuzonManager(); // TODO: Initialize to an appropriate value
			int iModulo = 0; // TODO: Initialize to an appropriate value
			List<string> lstEtapas = null; // TODO: Initialize to an appropriate value
			List<byte> lstAreas = null; // TODO: Initialize to an appropriate value
			List<byte> lstUsuarios = null; // TODO: Initialize to an appropriate value
			target.InsertConfigBuzon(iModulo, lstEtapas, lstAreas, lstUsuarios);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for ReviewMessage
		///</summary>
		[TestMethod()]
		public void ReviewMessageTest()
		{
			BuzonManager target = new BuzonManager(); // TODO: Initialize to an appropriate value
			int iMensaje = 0; // TODO: Initialize to an appropriate value
			int iUsuario = 0; // TODO: Initialize to an appropriate value
			target.ReviewMessage(iMensaje, iUsuario);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for SendMail_SMTP
		///</summary>
		[TestMethod()]
		public void SendMail_SMTPTest()
		{
			BuzonManager target = new BuzonManager(); // TODO: Initialize to an appropriate value
			List<string> sendTo = null; // TODO: Initialize to an appropriate value
			string mensaje = string.Empty; // TODO: Initialize to an appropriate value
			string asunto = string.Empty; // TODO: Initialize to an appropriate value
			target.SendMail_SMTP(sendTo, mensaje, asunto);
			Assert.Inconclusive("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for PasswordMail
		///</summary>
		[TestMethod()]
		[DeploymentItem("BOCAR.SACI.Business.dll")]
		public void PasswordMailTest()
		{
			string expected = string.Empty; // TODO: Initialize to an appropriate value
			string actual;
			BuzonManager_Accessor.PasswordMail = expected;
			actual = BuzonManager_Accessor.PasswordMail;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Sender
		///</summary>
		[TestMethod()]
		[DeploymentItem("BOCAR.SACI.Business.dll")]
		public void SenderTest()
		{
			string expected = string.Empty; // TODO: Initialize to an appropriate value
			string actual;
			BuzonManager_Accessor.Sender = expected;
			actual = BuzonManager_Accessor.Sender;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ServerPort
		///</summary>
		[TestMethod()]
		[DeploymentItem("BOCAR.SACI.Business.dll")]
		public void ServerPortTest()
		{
			int expected = 0; // TODO: Initialize to an appropriate value
			int actual;
			BuzonManager_Accessor.ServerPort = expected;
			actual = BuzonManager_Accessor.ServerPort;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for SmtpIp
		///</summary>
		[TestMethod()]
		[DeploymentItem("BOCAR.SACI.Business.dll")]
		public void SmtpIpTest()
		{
			string expected = string.Empty; // TODO: Initialize to an appropriate value
			string actual;
			BuzonManager_Accessor.SmtpIp = expected;
			actual = BuzonManager_Accessor.SmtpIp;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for UserMail
		///</summary>
		[TestMethod()]
		[DeploymentItem("BOCAR.SACI.Business.dll")]
		public void UserMailTest()
		{
			string expected = string.Empty; // TODO: Initialize to an appropriate value
			string actual;
			BuzonManager_Accessor.UserMail = expected;
			actual = BuzonManager_Accessor.UserMail;
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
