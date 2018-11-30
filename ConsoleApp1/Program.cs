using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;



namespace QuizAlphaV1
{
    class Program
    {
        static void Main(string[] args)
        {
            FlashCard cardTest = new FlashCard("Comment dit-on 'une maison' en allemand ?", "ein Haus");

            Console.WriteLine(" Recto : " + cardTest.GetRectoQuery());

            Console.WriteLine(" Verso : " + cardTest.GetVersoAnswer());

            cardTest.AskQuestionConsole();
            cardTest.AskQuestionConsole();
            cardTest.AskQuestionConsole();
            cardTest.AskQuestionConsole();
            Console.WriteLine("adadafweqwe");
            Console.WriteLine("adadafweqwe");
        }
    }
}
