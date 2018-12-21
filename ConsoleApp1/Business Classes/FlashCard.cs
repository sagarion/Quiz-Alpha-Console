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
        /// La réponse qui est inscrit sur le verso de la carte
        /// </summary>
        private String versoAnswer;

        /// <summary>
        /// L'attribut qui permet de déterminer l'état actuelle de la flashCard
        /// </summary>
        private bool cardOk = true;

        // Constructor
        public FlashCard(String rectoQuery, String versoAnswer)
        {
            this.RectoQuery = rectoQuery;
            this.VersoAnswer = versoAnswer;
        }


        // Getter and Setter
        public string RectoQuery
        {
            get
            {
                return this.rectoQuery;
            }

            set
            {
                if (this.IsStringValid(value))
                    this.rectoQuery = value;
                else
                {
                    this.rectoQuery = "";
                }
                this.CheckCard();
            }
        }

        public string VersoAnswer
        {
            get
            {
                return this.versoAnswer;
            }

            set
            {
                if (this.IsStringValid(value))
                    this.versoAnswer = value;
                else
                {
                    this.versoAnswer = "";
                }
                this.CheckCard();
            }
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
        /// Cette fonction a pour but mettre à jour l'état de la FlashCard
        /// </summary>
        public void CheckCard()
        {
            if (this.IsStringValid(this.RectoQuery) && this.IsStringValid(this.VersoAnswer))
                cardOk = true;
            else
                cardOk = false;
        }

        /// <summary>
        /// Vérifie si la carte est dans un état valide et peut être utilisé dans un questionnaire
        /// </summary>
        /// <returns>si la carte est valide : true, si la carte est invalide : false</returns>
        public Boolean IsCardOK()
        {
            return this.cardOk;
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

            Console.WriteLine(this.RectoQuery);
            Console.Write("votre Réponse : ");
            answerGiven = Console.ReadLine();

            if (answerGiven == this.VersoAnswer)
            {
                result = true;
                Console.WriteLine("Cette réponse est correct \n");

            }
            else
            {
                Console.WriteLine("Cette réponse est incorrect, la bonne réponse est : " + this.VersoAnswer + "\n");
            }

            return result;
        }

        /// <summary>
        /// fonction déterminant si une carte mise en paramètre est identique (même donnée)
        /// à la carte courrante
        /// </summary>
        /// <param name="card"> FlashCard devant être comparé</param>
        /// <returns> Renvoie true si elles sont identique sion false</returns>
        public Boolean IsIdentical(FlashCard card)
        {
            Boolean result = false; ;

            if (card.RectoQuery == this.RectoQuery && card.VersoAnswer == this.VersoAnswer)
                result = true;

            return result;
        }
    }
}
