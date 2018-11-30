using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace QuizAlphaV1
{
    class Program
    {
        static void Main(string[] args)
        {
            // création des carte de test
            FlashCard cardTest1 = new FlashCard("Comment dit-on 'une maison' en allemand ?", "ein Haus");

            FlashCard cardTest2 = new FlashCard("Comment dit-on 'la botte' en allemand ?", "die Stiefel");

            FlashCard cardTest3 = new FlashCard("Comment dit-on 'un bateau' en allemand ?", "ein Boat");

            FlashCard cardTest4 = new FlashCard("Comment dit-on 'le chien' en allemand ?", "der Hound");

            // Ajouts des cartes au quiz de test
            Quiz quizTest = new Quiz("Allemand Test");
            quizTest.AddCard(cardTest1);
            quizTest.AddCard(cardTest2);
            quizTest.AddCard(cardTest3);
            quizTest.AddCard(cardTest4);

            //test
            quizTest.startQuizConsole();

        }
    }
}
