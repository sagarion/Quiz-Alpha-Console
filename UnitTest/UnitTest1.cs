using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizAlphaV1;
namespace UnitTest
{
    [TestClass]
    public class QuizAlphaTest
    {

        [TestMethod]
        public void IsStringValid()
        {
            // Donnée du test

            string ok = "test OK";
            string emptyString = "";
            string nullString = null;
            string spaceString = "       ";

            FlashCard cardTest = new FlashCard("test","test");

            // Test

            Boolean Result1 = cardTest.IsStringValid(ok);
            Boolean Result2 = cardTest.IsStringValid(emptyString);
            Boolean Result3 = cardTest.IsStringValid(nullString);
            Boolean Result4 = cardTest.IsStringValid(spaceString);

            // Vérification

            Assert.IsTrue(Result1,"Echec du test sur la valeur correct");
            Assert.IsFalse(Result2, "Echec du test sur la valeur vide");
            Assert.IsFalse(Result3, "Echec du test sur la valeur null");
            Assert.IsFalse(Result4, "Echec du test sur la valeur espace");
        }
    }
}
