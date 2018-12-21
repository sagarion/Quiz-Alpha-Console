using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAlphaV1
{
    public class Quiz
    {
        /// <summary>
        /// compteur pour la généation d'identifiant
        /// </summary>
        private static int idCounter = 1;

        /// <summary>
        /// identificateur unique à chaque objet de la classe ( dans les limites de int
        /// </summary>
        private int id;

        /// <summary>
        /// Titre du questionnaire
        /// </summary>
        private String title;

        /// <summary>
        /// FlashCard dans le questionnaire
        /// </summary>
        private List<FlashCard> cards;

        private static Random generator = new Random();

        //Constructeur
        public Quiz(String title)
        {
            this.SetTitle(title);
            this.cards = new List<FlashCard>();

            this.id = idCounter;
            idCounter += 1;
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

        public int getId()
        {
            return id;
        }


        // methodes

        /// <summary>
        /// Ajoute une nouvelle Flashcard à celles listées par le quiz
        /// </summary>
        /// <param name="card"> carte à ajouté</param>
        public void AddCard(FlashCard card)
        {
            // vérifie que la carte est valide avant de l'ajouter
            if (card.IsCardOK() && !this.IsCardAlreadyIn(card))
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
                if (card.IsCardOK())
                {
                    countQuestions += 1;
                    result = card.AskQuestionConsole();

                    if (result == true)
                        countCorrectAnswers += 1;
                }

            }

            Console.WriteLine("\n Résultat du quiz : ");
            Console.WriteLine(" " + countCorrectAnswers + "/" + countQuestions + " réponse(s) correcte(s) !");
        }

        public Boolean IsCardAlreadyIn(FlashCard Card)
        {
            Boolean result = false;

            int compteur = 0;

            while (!result && compteur < this.GetCards().Count())
            {
                if (this.GetCards().ElementAt(compteur).IsIdentical(Card))
                    return true;

                compteur += 1;
            }

            return result;
        }

        public void Shuffle()
        {
            if (this.GetCards().Count() > 1)
            {
                int permutations = generator.Next(this.GetCards().Count(), this.GetCards().Count() * 10);

                int index1;
                int index2;

                FlashCard temp;

                for (int i = 0; i < permutations; i++)
                {
                    index1 = generator.Next(0, this.GetCards().Count());
                    index2 = generator.Next(0, this.GetCards().Count());

                    temp = this.GetCards().ElementAt(index1);
                    this.GetCards()[index1] = this.GetCards().ElementAt(index2);
                    this.GetCards()[index2] = temp;

                    Console.WriteLine("\n\n--- new list ---");

                    foreach (FlashCard card in this.GetCards())
                    {
                        Console.WriteLine(card.RectoQuery + " : " + card.VersoAnswer);

                    }
                }
            }
        }
    }
}
