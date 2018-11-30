using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    class Quiz
    {
        /// <summary>
        /// Titre du questionnaire
        /// </summary>
        private String title;

        /// <summary>
        /// FlashCard dans le questionnaire
        /// </summary>
        private List<FlashCard> cards;

        //Constructeur
        public Quiz(String title)
        {
            this.SetTitle(title);
            this.cards = new List<FlashCard>();
        }

        // Getter Setter

        public String GetTitle()
        {
            return title;
        }

        public void SetTitle(String title)
        {
            this.title = title;
        }

        public List<FlashCard> GetCards()
        {
            return this.cards;
        }


        // methodes

        /// <summary>
        /// Ajoute une nouvelle Flashcard à celles listées par le quiz
        /// </summary>
        /// <param name="card"> carte à ajouté</param>
        public void AddCard(FlashCard card)
        {
            // vérifie que la carte est valide avant de l'ajouter
            if (card.IsCardOK())
                cards.Add(card);
            else
                // ne fait rien pour le moment
               ;
        }
        
        public void startQuizConsole()
        {
            int countCorrectAnswers = 0;
            int countQuestions = 0;
            Boolean result = false;

            Console.WriteLine("Début du test : " + title);
            foreach (FlashCard card in cards)
            {
                if(card.IsCardOK())
                {
                    countQuestions += 1;
                    result = card.AskQuestionConsole();

                    if (result == true)
                        countCorrectAnswers += 1;
                }
                
            }

            Console.WriteLine("\n Résultat du quiz : ");
            Console.WriteLine(countCorrectAnswers + "/" + countQuestions + " corrects answers !");
        }
    }
}
