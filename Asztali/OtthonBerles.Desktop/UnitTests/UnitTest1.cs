using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OtthonBerles.Models;

namespace UnitTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void CustomerTest_WithCorrectData()
        {
            Customer correctCustomer = new Customer("1", "fullname", "email", "password");

            Assert.IsTrue(correctCustomer.Id == 1 &&
                            correctCustomer.FullName.Equals("fullname") &&
                            correctCustomer.Email.Equals("email") &&
                            correctCustomer.Password.Equals("password")
                );
        }

        [TestMethod]
        public void CustomerTest_WithEmptyFullName()
        {
            Customer emptyFullNameCustomer = new Customer("1", "", "email", "password");

            Assert.IsTrue(emptyFullNameCustomer.Id == 1 &&
                            emptyFullNameCustomer.FullName.Equals("") &&
                            emptyFullNameCustomer.Email.Equals("email") &&
                            emptyFullNameCustomer.Password.Equals("password")
                );
        }

        [TestMethod]
        public void CustomerTest_WithEmptyEmail()
        {
            Customer emptyEmailCustomer = new Customer("1", "fullname", "", "password");

            Assert.IsTrue(emptyEmailCustomer.Id == 1 &&
                            emptyEmailCustomer.FullName.Equals("fullname") &&
                            emptyEmailCustomer.Email.Equals("") &&
                            emptyEmailCustomer.Password.Equals("password")
                );
        }

        [TestMethod]
        public void CustomerTest_WithEmptyPassword()
        {
            Customer emptyPasswordCustomer = new Customer("1", "fullname", "email", "");

            Assert.IsTrue(emptyPasswordCustomer.Id == 1 &&
                            emptyPasswordCustomer.FullName.Equals("fullname") &&
                            emptyPasswordCustomer.Email.Equals("email") &&
                            emptyPasswordCustomer.Password.Equals("")
                );
        }

        [TestMethod]
        public void CustomerTest_WithNullFullName()
        {
            Customer nullFullNameCustomer = new Customer("1", null, "email", "password");

            Assert.IsTrue(nullFullNameCustomer.Id == 1 &&
                            nullFullNameCustomer.FullName == null &&
                            nullFullNameCustomer.Email.Equals("email") &&
                            nullFullNameCustomer.Password.Equals("password")
                );
        }

        [TestMethod]
        public void CustomerTest_WithNullEmail()
        {
            Customer nullEmailCustomer = new Customer("1", "fullname", null, "password");

            Assert.IsTrue(nullEmailCustomer.Id == 1 &&
                            nullEmailCustomer.FullName.Equals("fullname") &&
                            nullEmailCustomer.Email == null &&
                            nullEmailCustomer.Password.Equals("password")
                );
        }

        [TestMethod]
        public void CustomerTest_WithNullPassword()
        {
            Customer nullPasswordCustomer = new Customer("1", "fullname", "email", null);

            Assert.IsTrue(nullPasswordCustomer.Id == 1 &&
                            nullPasswordCustomer.FullName.Equals("fullname") &&
                            nullPasswordCustomer.Email.Equals("email") &&
                            nullPasswordCustomer.Password == null
                );
        }


        [TestMethod]
        public void AdvertiserTest_WithCorrectData()
        {
            Advertiser correctAdvertiser = new Advertiser("1", "fullname", "email", "password", "companyname");

            Assert.IsTrue(correctAdvertiser.Id == 1 &&
                            correctAdvertiser.FullName.Equals("fullname") &&
                            correctAdvertiser.Email.Equals("email") &&
                            correctAdvertiser.Password.Equals("password") &&
                            correctAdvertiser.CompanyName.Equals("companyname")
                );
        }

        [TestMethod]
        public void AdvertiserTest_WithEmptyFullName()
        {
            Advertiser emptyFullNameAdvertiser = new Advertiser("1", "", "email", "password", "companyname");

            Assert.IsTrue(emptyFullNameAdvertiser.Id == 1 &&
                            emptyFullNameAdvertiser.FullName.Equals("") &&
                            emptyFullNameAdvertiser.Email.Equals("email") &&
                            emptyFullNameAdvertiser.Password.Equals("password") &&
                            emptyFullNameAdvertiser.CompanyName.Equals("companyname")
                );
        }

        [TestMethod]
        public void AdvertiserTest_WithEmptyEmail()
        {
            Advertiser emptyEmailAdvertiser = new Advertiser("1", "fullname", "", "password", "companyname");

            Assert.IsTrue(emptyEmailAdvertiser.Id == 1 &&
                            emptyEmailAdvertiser.FullName.Equals("fullname") &&
                            emptyEmailAdvertiser.Email.Equals("") &&
                            emptyEmailAdvertiser.Password.Equals("password") &&
                            emptyEmailAdvertiser.CompanyName.Equals("companyname")
                );
        }

        [TestMethod]
        public void AdvertiserTest_WithEmptyPassword()
        {
            Advertiser emptyPasswordAdvertiser = new Advertiser("1", "fullname", "email", "", "companyname");

            Assert.IsTrue(emptyPasswordAdvertiser.Id == 1 &&
                            emptyPasswordAdvertiser.FullName.Equals("fullname") &&
                            emptyPasswordAdvertiser.Email.Equals("email") &&
                            emptyPasswordAdvertiser.Password.Equals("") &&
                            emptyPasswordAdvertiser.CompanyName.Equals("companyname")
                );
        }

        [TestMethod]
        public void AdvertiserTest_WithEmptyCompanyName()
        {
            Advertiser emptyCompanyNameAdvertiser = new Advertiser("1", "fullname", "email", "password", "");

            Assert.IsTrue(emptyCompanyNameAdvertiser.Id == 1 &&
                            emptyCompanyNameAdvertiser.FullName.Equals("fullname") &&
                            emptyCompanyNameAdvertiser.Email.Equals("email") &&
                            emptyCompanyNameAdvertiser.Password.Equals("password") &&
                            emptyCompanyNameAdvertiser.CompanyName.Equals("")
                );
        }

        [TestMethod]
        public void AdvertiserTest_WithNullFullName()
        {
            Advertiser nullFullNameAdvertiser = new Advertiser("1", null, "email", "password", "companyname");

            Assert.IsTrue(nullFullNameAdvertiser.Id == 1 &&
                            nullFullNameAdvertiser.FullName == null &&
                            nullFullNameAdvertiser.Email.Equals("email") &&
                            nullFullNameAdvertiser.Password.Equals("password") &&
                            nullFullNameAdvertiser.CompanyName.Equals("companyname")
                );
        }

        [TestMethod]
        public void AdvertiserTest_WithNullEmail()
        {
            Advertiser nullEmailAdvertiser = new Advertiser("1", "fullname", null, "password", "companyname");

            Assert.IsTrue(nullEmailAdvertiser.Id == 1 &&
                            nullEmailAdvertiser.FullName.Equals("fullname") &&
                            nullEmailAdvertiser.Email == null &&
                            nullEmailAdvertiser.Password.Equals("password") &&
                            nullEmailAdvertiser.CompanyName.Equals("companyname")
                );
        }

        [TestMethod]
        public void AdvertiserTest_WithNullPassword()
        {
            Advertiser nullPasswordAdvertiser = new Advertiser("1", "fullname", "email", null, "companyname");

            Assert.IsTrue(nullPasswordAdvertiser.Id == 1 &&
                            nullPasswordAdvertiser.FullName.Equals("fullname") &&
                            nullPasswordAdvertiser.Email.Equals("email") &&
                            nullPasswordAdvertiser.Password == null &&
                            nullPasswordAdvertiser.CompanyName.Equals("companyname")
                );
        }

        [TestMethod]
        public void AdvertiserTest_WithNullCompanyName()
        {
            Advertiser nullCompanyNameAdvertiser = new Advertiser("1", "fullname", "email", "password", null);

            Assert.IsTrue(nullCompanyNameAdvertiser.Id == 1 &&
                            nullCompanyNameAdvertiser.FullName.Equals("fullname") &&
                            nullCompanyNameAdvertiser.Email.Equals("email") &&
                            nullCompanyNameAdvertiser.Password.Equals("password") &&
                            nullCompanyNameAdvertiser.CompanyName == null
                );
        }

        [TestMethod]
        public void PropertyTest_WithCorrectData()
        {
            Property correctProperty = new Property("1", "email", "city", "type", 5, 1000, true, "possibilityOfMoving", "other", new byte[] { 1, 2, 3 });

            Assert.IsTrue(correctProperty.Id == 1 &&
                            correctProperty.Email.Equals("email") &&
                            correctProperty.City.Equals("city") &&
                            correctProperty.Type_.Equals("type") &&
                            correctProperty.RoomNumber == 5 &&
                            correctProperty.Price == 1000 &&
                            correctProperty.IsFurnished &&
                            correctProperty.PossibilityOfMoving.Equals("possibilityOfMoving") &&
                            correctProperty.Other.Equals("other") &&
                            correctProperty.ImageData != null
                );
        }

        [TestMethod]
        public void PropertyTest_WithNullEmail()
        {
            Property nullEmailProperty = new Property("1", null, "city", "type", 5, 1000, true, "possibilityOfMoving", "other", new byte[] { 1, 2, 3 });

            Assert.IsTrue(nullEmailProperty.Id == 1 &&
                            nullEmailProperty.Email == null &&
                            nullEmailProperty.City.Equals("city") &&
                            nullEmailProperty.Type_.Equals("type") &&
                            nullEmailProperty.RoomNumber == 5 &&
                            nullEmailProperty.Price == 1000 &&
                            nullEmailProperty.IsFurnished &&
                            nullEmailProperty.PossibilityOfMoving.Equals("possibilityOfMoving") &&
                            nullEmailProperty.Other.Equals("other") &&
                            nullEmailProperty.ImageData != null
                );
        }

        [TestMethod]
        public void PropertyTest_WithEmptyCity()
        {
            Property emptyCityProperty = new Property("1", "email", "", "type", 5, 1000, true, "possibilityOfMoving", "other", new byte[] { 1, 2, 3 });

            Assert.IsTrue(emptyCityProperty.Id == 1 &&
                            emptyCityProperty.Email.Equals("email") &&
                            emptyCityProperty.City.Equals("") &&
                            emptyCityProperty.Type_.Equals("type") &&
                            emptyCityProperty.RoomNumber == 5 &&
                            emptyCityProperty.Price == 1000 &&
                            emptyCityProperty.IsFurnished &&
                            emptyCityProperty.PossibilityOfMoving.Equals("possibilityOfMoving") &&
                            emptyCityProperty.Other.Equals("other") &&
                            emptyCityProperty.ImageData != null
                );
        }


        [TestMethod]
        public void PropertyTest_WithNegativeRoomNumber()
        {
            Property negativeRoomNumberProperty = new Property("1", "email", "city", "type", -1, 1000, true, "possibilityOfMoving", "other", new byte[] { 1, 2, 3 });

            Assert.IsTrue(negativeRoomNumberProperty.Id == 1 &&
                            negativeRoomNumberProperty.Email.Equals("email") &&
                            negativeRoomNumberProperty.City.Equals("city") &&
                            negativeRoomNumberProperty.Type_.Equals("type") &&
                            negativeRoomNumberProperty.RoomNumber == -1 && 
                            negativeRoomNumberProperty.Price == 1000 &&
                            negativeRoomNumberProperty.IsFurnished &&
                            negativeRoomNumberProperty.PossibilityOfMoving.Equals("possibilityOfMoving") &&
                            negativeRoomNumberProperty.Other.Equals("other") &&
                            negativeRoomNumberProperty.ImageData != null
                );
        }

        [TestMethod]
        public void PropertyTest_WithZeroPrice()
        {
            Property zeroPriceProperty = new Property("1", "email", "city", "type", 5, 0, true, "possibilityOfMoving", "other", new byte[] { 1, 2, 3 });

            Assert.IsTrue(zeroPriceProperty.Id == 1 &&
                            zeroPriceProperty.Email.Equals("email") &&
                            zeroPriceProperty.City.Equals("city") &&
                            zeroPriceProperty.Type_.Equals("type") &&
                            zeroPriceProperty.RoomNumber == 5 &&
                            zeroPriceProperty.Price == 0 && 
                            zeroPriceProperty.IsFurnished &&
                            zeroPriceProperty.PossibilityOfMoving.Equals("possibilityOfMoving") &&
                            zeroPriceProperty.Other.Equals("other") &&
                            zeroPriceProperty.ImageData != null
                );
        }

        [TestMethod]
        public void PropertyTest_WithNullType()
        {
            Property nullTypeProperty = new Property("1", "email", "city", null, 5, 1000, true, "possibilityOfMoving", "other", new byte[] { 1, 2, 3 });

            Assert.IsTrue(nullTypeProperty.Id == 1 &&
                            nullTypeProperty.Email.Equals("email") &&
                            nullTypeProperty.City.Equals("city") &&
                            nullTypeProperty.Type_ == null && // Null type
                            nullTypeProperty.RoomNumber == 5 &&
                            nullTypeProperty.Price == 1000 &&
                            nullTypeProperty.IsFurnished &&
                            nullTypeProperty.PossibilityOfMoving.Equals("possibilityOfMoving") &&
                            nullTypeProperty.Other.Equals("other") &&
                            nullTypeProperty.ImageData != null
                );
        }

        [TestMethod]
        public void PropertyTest_WithEmptyEmail()
        {
            Property emptyEmailProperty = new Property("1", "", "city", "type", 5, 1000, true, "possibilityOfMoving", "other", new byte[] { 1, 2, 3 });

            Assert.IsTrue(emptyEmailProperty.Id == 1 &&
                            emptyEmailProperty.Email.Equals("") && // Empty email
                            emptyEmailProperty.City.Equals("city") &&
                            emptyEmailProperty.Type_.Equals("type") &&
                            emptyEmailProperty.RoomNumber == 5 &&
                            emptyEmailProperty.Price == 1000 &&
                            emptyEmailProperty.IsFurnished &&
                            emptyEmailProperty.PossibilityOfMoving.Equals("possibilityOfMoving") &&
                            emptyEmailProperty.Other.Equals("other") &&
                            emptyEmailProperty.ImageData != null
                );
        }

        [TestMethod]
        public void PropertyTest_WithNegativePrice()
        {
            Property negativePriceProperty = new Property("1", "email", "city", "type", 5, -1000, true, "possibilityOfMoving", "other", new byte[] { 1, 2, 3 });

            Assert.IsTrue(negativePriceProperty.Id == 1 &&
                            negativePriceProperty.Email.Equals("email") &&
                            negativePriceProperty.City.Equals("city") &&
                            negativePriceProperty.Type_.Equals("type") &&
                            negativePriceProperty.RoomNumber == 5 &&
                            negativePriceProperty.Price == -1000 && // Negative price
                            negativePriceProperty.IsFurnished &&
                            negativePriceProperty.PossibilityOfMoving.Equals("possibilityOfMoving") &&
                            negativePriceProperty.Other.Equals("other") &&
                            negativePriceProperty.ImageData != null
                );
        }

        [TestMethod]
        public void PropertyTest_WithNullPossibilityOfMoving()
        {
            Property nullPossibilityOfMovingProperty = new Property("1", "email", "city", "type", 5, 1000, true, null, "other", new byte[] { 1, 2, 3 });

            Assert.IsTrue(nullPossibilityOfMovingProperty.Id == 1 &&
                            nullPossibilityOfMovingProperty.Email.Equals("email") &&
                            nullPossibilityOfMovingProperty.City.Equals("city") &&
                            nullPossibilityOfMovingProperty.Type_.Equals("type") &&
                            nullPossibilityOfMovingProperty.RoomNumber == 5 &&
                            nullPossibilityOfMovingProperty.Price == 1000 &&
                            nullPossibilityOfMovingProperty.IsFurnished &&
                            nullPossibilityOfMovingProperty.PossibilityOfMoving == null && // Null possibility of moving
                            nullPossibilityOfMovingProperty.Other.Equals("other") &&
                            nullPossibilityOfMovingProperty.ImageData != null
                );
        }

        [TestMethod]
        public void PropertyTest_WithEmptyOther()
        {
            Property emptyOtherProperty = new Property("1", "email", "city", "type", 5, 1000, true, "possibilityOfMoving", "", new byte[] { 1, 2, 3 });

            Assert.IsTrue(emptyOtherProperty.Id == 1 &&
                            emptyOtherProperty.Email.Equals("email") &&
                            emptyOtherProperty.City.Equals("city") &&
                            emptyOtherProperty.Type_.Equals("type") &&
                            emptyOtherProperty.RoomNumber == 5 &&
                            emptyOtherProperty.Price == 1000 &&
                            emptyOtherProperty.IsFurnished &&
                            emptyOtherProperty.PossibilityOfMoving.Equals("possibilityOfMoving") &&
                            emptyOtherProperty.Other.Equals("") && // Empty other
                            emptyOtherProperty.ImageData != null
                );
        }

    }
}
