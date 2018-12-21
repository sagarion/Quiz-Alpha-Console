using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizAlphaV1;
namespace UnitTest
{
    [TestClass]
    public class QuizAlphaTest
    {
        /// <summary>
        /// Ce teste détermine si la fonction IsStringValid de la class FlashCard 
        /// est capable de détecter correctement les différents résultats attendus
        /// </summary>
        [TestMethod]
        public void FlashCard_IsStringValid()
        {

            // Données du test

            string ok = "test OK";
            string emptyString = "";
            string nullString = null;
            string spaceString = "       ";

            FlashCard cardTest = new FlashCard("test", "test");

            // Test

            Boolean Result1 = cardTest.IsStringValid(ok);
            Boolean Result2 = cardTest.IsStringValid(emptyString);
            Boolean Result3 = cardTest.IsStringValid(nullString);
            Boolean Result4 = cardTest.IsStringValid(spaceString);

            // Vérification

            Assert.IsTrue(Result1, "Echec du test sur la valeur correct");
            Assert.IsFalse(Result2, "Echec du test sur la valeur vide");
            Assert.IsFalse(Result3, "Echec du test sur la valeur null");
            Assert.IsFalse(Result4, "Echec du test sur la valeur espace");
        }

        /// <summary>
        /// Ce test va déterminer le constructeur réagit correctement à l'introduction de valeur incohérente
        /// </summary>
        [TestMethod]
        public void FlashCard_Constructor()
        {
            // Données du test
            FlashCard cardTestOK = new FlashCard("test", "test");

            FlashCard cardTestEmpty1 = new FlashCard("", "test");
            FlashCard cardTestEmpty2 = new FlashCard("test", "");
            FlashCard cardTestEmpty3 = new FlashCard("", "");

            FlashCard cardTestSpace1 = new FlashCard("     ", "test");
            FlashCard cardTestSpace2 = new FlashCard("test", "    ");
            FlashCard cardTestSpace3 = new FlashCard("        ", "    ");

            FlashCard cardTestNull1 = new FlashCard(null, "test");
            FlashCard cardTestNull2 = new FlashCard("test", null);
            FlashCard cardTestNull3 = new FlashCard(null, null);

            // Test

            Boolean result1 = cardTestOK.IsCardOK();
            Boolean result2 = cardTestEmpty1.IsCardOK() || cardTestEmpty2.IsCardOK() || cardTestEmpty3.IsCardOK();
            Boolean result3 = cardTestSpace1.IsCardOK() || cardTestSpace2.IsCardOK() || cardTestSpace3.IsCardOK();
            Boolean result4 = cardTestNull1.IsCardOK() || cardTestNull2.IsCardOK() || cardTestNull3.IsCardOK();

            // Vérification

            Assert.IsTrue(result1, "Echec du test sur la valeur correct");
            Assert.IsFalse(result2, "Echec du test sur une chaîne de caractères vide");
            Assert.IsFalse(result3, "Echec du test sur une chaîne de caractère remplis d'espace");
            Assert.IsFalse(result4, "Echec du test sur une chaîne de caractère NULL");

        }


        /// <summary>
        /// Ce test va déterminer si l'introduction de valeur incorrecte dans les accesseurs de Flashcard
        /// peut laisser l'objet dans un état incohérent
        /// </summary>
        [TestMethod]
        public void FlashCard_Accessor()
        {
            // Données du test
            FlashCard cardTest = new FlashCard("test", "test");



            // Test
            // controleur état de base OK
            cardTest.RectoQuery = "TestAcessor";
            cardTest.VersoAnswer = "TestAcessor";
            Boolean result1 = cardTest.IsCardOK();

            // test empty string
            cardTest.RectoQuery = "";
            Boolean result2 = cardTest.IsCardOK();

            cardTest.RectoQuery = "TestAcessor";
            cardTest.VersoAnswer = "";
            Boolean result3 = cardTest.IsCardOK();

            cardTest.RectoQuery = "";
            Boolean result4 = cardTest.IsCardOK();

            // test spaced string
            cardTest.RectoQuery = "TestAcessor";
            cardTest.VersoAnswer = "TestAcessor";


            cardTest.RectoQuery = "   ";
            Boolean result5 = cardTest.IsCardOK();

            cardTest.RectoQuery = "TestAcessor";
            cardTest.VersoAnswer = "   ";
            Boolean result6 = cardTest.IsCardOK();

            cardTest.RectoQuery = "   ";
            Boolean result7 = cardTest.IsCardOK();

            // test null string
            cardTest.RectoQuery = "TestAcessor";
            cardTest.VersoAnswer = "TestAcessor";


            cardTest.RectoQuery = null;
            Boolean result8 = cardTest.IsCardOK();

            cardTest.RectoQuery = "TestAcessor";
            cardTest.VersoAnswer = null;
            Boolean result9 = cardTest.IsCardOK();

            cardTest.RectoQuery = null;
            Boolean result10 = cardTest.IsCardOK();

            // Vérification

            Assert.IsTrue(result1, "Echec du test sur la valeur valide initiale");
            Assert.IsFalse(result2 && result3 && result4, "Echec du test sur une chaîne de caractères vide");
            Assert.IsFalse(result5 && result6 && result7, "Echec du test sur une chaîne de caractère remplis d'espace");
            Assert.IsFalse(result8 && result9 && result10, "Echec du test sur une chaîne de caractère NULL");
        }

        /// <summary>
        /// Ce test va déterminer si l'ajout d'une FlashCard à
        /// un Quiz se fait correctement selon que la FlashCard
        /// est valide ou non
        /// </summary>
        [TestMethod]
        public void Quiz_AddCard()
        {
            // Données
            FlashCard cardOK = new FlashCard("test","test");
            Quiz quiz = new Quiz("Quiz de test");

            FlashCard cardTestEmpty1 = new FlashCard("", "test");
            FlashCard cardTestEmpty2 = new FlashCard("test", "");
            FlashCard cardTestEmpty3 = new FlashCard("", "");

            FlashCard cardTestSpace1 = new FlashCard("     ", "test");
            FlashCard cardTestSpace2 = new FlashCard("test", "    ");
            FlashCard cardTestSpace3 = new FlashCard("        ", "    ");

            FlashCard cardTestNull1 = new FlashCard(null, "test");
            FlashCard cardTestNull2 = new FlashCard("test", null);
            FlashCard cardTestNull3 = new FlashCard(null, null);

            FlashCard cardReplica = new FlashCard("test", "test");


            // Test
            quiz.AddCard(cardOK);
            Boolean result1 = quiz.GetCards().Count == 1;

            // empty Cards
            quiz.GetCards().Clear();
            quiz.AddCard(cardTestEmpty1);
            quiz.AddCard(cardTestEmpty2);
            quiz.AddCard(cardTestEmpty3);
            Boolean result2 = quiz.GetCards().Count == 0;
            int temp = quiz.GetCards().Count;

            // spaced Cards
            quiz.GetCards().Clear();
            quiz.AddCard(cardTestSpace1);
            quiz.AddCard(cardTestSpace2);
            quiz.AddCard(cardTestSpace3);
            Boolean result3 = quiz.GetCards().Count == 0;

            // spaced Cards
            quiz.GetCards().Clear();
            quiz.AddCard(cardTestNull1);
            quiz.AddCard(cardTestNull2);
            quiz.AddCard(cardTestNull3);
            Boolean result4 = quiz.GetCards().Count == 0;

            // Verification

            Assert.IsTrue(result1, "Echec du test sur la valeur valide initiale");
            Assert.IsTrue(result2, "Echec du test sur une chaîne de caractères vide");
            Assert.IsTrue(result3, "Echec du test sur une chaîne de caractère remplis d'espace");
            Assert.IsTrue(result4, "Echec du test sur une chaîne de caractère NULL");
        }

        [TestMethod]
        public void IsCardAlreadyIn()
        {
            // Data
            FlashCard cardBase = new FlashCard("test", "test");
            FlashCard cardReplica = new FlashCard("test", "test");
            FlashCard cardOtherReference = cardBase;

            Quiz quizTest = new Quiz("quizTest");

            // Tests

            quizTest.AddCard(cardBase);
            Boolean result1 = (quizTest.GetCards().Count == 1);

            quizTest.AddCard(cardBase);
            Boolean result2 = (quizTest.GetCards().Count == 1);

            quizTest.GetCards().Clear();
            quizTest.AddCard(cardBase);
            quizTest.AddCard(cardReplica);
            Boolean result3 = (quizTest.GetCards().Count == 1);

            quizTest.GetCards().Clear();
            quizTest.AddCard(cardBase);
            quizTest.AddCard(cardOtherReference);
            Boolean result4 = (quizTest.GetCards().Count == 1);

            // Verification

            Assert.IsTrue(result1, "Erreur l'ajout d'une carte à un quiz vide ne fonctionne pas");
            Assert.IsTrue(result2, "Erreur l'ajout d'une carte deux fois au même quiz a été autorisé");
            Assert.IsTrue(result3, "Erreur l'ajout de deux carte différente mais dont les valeurs sont identiques a été autorisé");
            Assert.IsTrue(result4, "Erreur l'ajout d'une copie d'une carte avec une référence différente a été autorisé");

        }
    }
}
