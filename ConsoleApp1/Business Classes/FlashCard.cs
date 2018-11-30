using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAlphaV1
{
    public class FlashCard
    {
        // attributs

        /// <summary>
        /// La question qui est inscrit sur le recto de la carte
        /// </summary>
        private String rectoQuery;

        /// <summary>
        /// la réponse qui est inscrit sur le verso de la carte
        /// </summary>
        private String versoAnswer;

        // Constructor
        public FlashCard(String rectoQuery, String versoAnswer)
        {
            this.SetRectoQuery(rectoQuery);
            this.SetVersoAnswer(versoAnswer);
        }


        // Getter and Setter

        public void SetRectoQuery(String rectoQuery)
        {
            if(this.IsStringValid(rectoQuery))
                this.rectoQuery = rectoQuery;
            else
            {
                this.rectoQuery = "erreur";
            }
        }

        public String GetRectoQuery()
        {
            return this.rectoQuery;
        }

        public void SetVersoAnswer(String versoAnswer)
        {
            if(this.IsStringValid(versoAnswer))
                this.versoAnswer = versoAnswer;
            else
            {
                this.versoAnswer = "erreur";
            }
        }

        public String GetVersoAnswer()
        {
            return this.versoAnswer;
        }

        // methodes

        /// <summary>
        /// Vérifie si la valeur fournit est valide
        /// ( pas null, pas "empty" et pas une suite d'espace
        /// </summary>
        /// <param name="stringTested"> chaîne de caractères vérifiée</param>
        /// <returns>return le résultat du test sous form booléan : chaîne valide : true, chaîne invalide : false </returns>
        public Boolean IsStringValid(String stringTested)
        {
            Boolean result;

            if(String.IsNullOrWhiteSpace(stringTested) || String.IsNullOrEmpty(stringTested))
            {
                result = false;
            }else
            {
                result = true; 
            }

            return result;
        }

        /// <summary>
        /// Vérifie si la carte est dans un état valide et peut être utilisé dans un questionnaire
        /// </summary>
        /// <returns>si la carte est valide : true, si la carte est invalide : false</returns>
        public Boolean IsCardOK()
        {
            if (this.rectoQuery == "erreur" || this.versoAnswer == "erreur")
                return false;
            else
                return true;
        }

        /// <summary>
        /// Cette fonction permet d'interroger un utilisateur concernant cette carte
        /// en utilisant la Console
        /// </summary>
        /// <returns>si la réponse est valide : true, si la réponse est invalide : false</returns>
        public Boolean AskQuestionConsole()
        {
            Boolean result = false;
            String answerGiven = "";

            Console.WriteLine(this.GetRectoQuery());
            Console.Write("votre Réponse : ");
            answerGiven = Console.ReadLine();

            if (answerGiven == this.GetVersoAnswer())
            {
                result = true;
                Console.WriteLine("Cette réponse est correct \n");

            }
            else
            {
                Console.WriteLine("Cette réponse est incorrect, la bonne réponse est : " + this.GetVersoAnswer() + "\n");
            }

            return result;
        }
    }
}
