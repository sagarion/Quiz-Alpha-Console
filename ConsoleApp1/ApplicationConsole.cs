using QuizAlphaV1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ApplicationConsole
    {
        public static void QuizAlphaConsole()
        {
            MenuPrincipaleApp();
        }

        /// <summary>
        /// cette méthode gère la partie applicative de l'affichage du menu principale
        /// 
        /// pour le moment elle n'affiche que le menu et gère la saisie de l'utilsateur
        /// par la suite, elle enclenchera les autres parties applicative.
        /// </summary>
        private static void MenuPrincipaleApp()
        {
            Console.WriteLine("\n------------------------------");

            Console.WriteLine("Menu Principale de Quiz Alpha");

            Console.WriteLine("--> C : Créer un quiz ");
            if(true)
                Console.WriteLine("--> M : Modifier un quiz ");
            if(true)
                Console.WriteLine("--> R : Répondre à un quiz ");
            Console.WriteLine("--> S : consulter Statistiques générales ");
            Console.WriteLine("--> U : modifier les informations Utilisateur ");
            Console.WriteLine("--> Q : Quitter l'application ");
            Console.WriteLine("\n------------------------------");

            bool invalidResult = true;
            string read = "";

            while (invalidResult)
            {
                Console.WriteLine("\n Que souhaitez vous faire ? : ");
                read = Console.ReadLine();

                invalidResult = false;

                switch (read)
                {
                    case "C":
                        Console.WriteLine("Vous allez à présent accéder à l'interface de création de Quiz.");
                        CreateQuizApp();
                        break;
                    case "M":
                        Console.WriteLine("Vous allez à présent accéder à l'interface des Quiz.(non implementer");
                        MenuPrincipaleApp();
                        break;
                    case "R":
                        Console.WriteLine("Vous allez à présent accéder à l'interface de pratique des Quizs.");
                        MenuPrincipaleApp();
                        break;
                    case "S":
                        Console.WriteLine("Merci d'avoir choisi cette fonction mais elle n'est pas encore implémenté.");
                        MenuPrincipaleApp();
                        break;
                    case "U":
                        Console.WriteLine("Merci d'avoir choisi cette fonction mais elle n'est pas encore implémenté.");
                        MenuPrincipaleApp();
                        break;
                    case "Q":
                        Console.WriteLine("Vous allez à présent quitter l'application.");
                        break;
                    case "":
                        Console.WriteLine("Erreur aucune saisie : vous devez tapper un des caractère proposés par l'application pour interagir.");
                        invalidResult = true;
                        MenuPrincipaleApp();
                        break;
                    default:
                        Console.WriteLine("Erreur saisie non reconnu : vous devez tapper un des caractères proposés par l'application pour interagir.");
                        invalidResult = true;
                        MenuPrincipaleApp();
                        break;
                }
            }
        }

        private static string AskUserQuizTitle()
        {
            string quizName;
            bool resultInvalid = true;

            do
            {
                Console.WriteLine("\n------------------------------");
                Console.WriteLine("Comment voulez-vous nommer le quiz ?");
                quizName = Console.ReadLine();

                if (quizName == "")
                    Console.WriteLine("Erreur aucune saisie : Veuillez saisir un nom pour le quiz !");
                else
                    resultInvalid = false;

            } while (resultInvalid);

            return quizName;
        }

        /// <summary>
        /// Partie gérant la création d'un nouveau Quiz.
        /// </summary>
        private static void CreateQuizApp()
        {
            string quizName = AskUserQuizTitle();

            Quiz newQuiz = new Quiz(quizName);

            Console.WriteLine("le numero du Quiz qui a été créer est le {0} !", newQuiz.GetId());
            UpdateQuizApp(newQuiz);
        }

        /// <summary>
        /// Partie gérant la manipulation dun quiz Existant.
        /// Suite à la cération d'un nouveau Quiz on arrive ici.
        /// </summary>
        /// <param name="quiz"></param>
        public static void UpdateQuizApp(Quiz quiz)
        {
            Console.WriteLine("\n------------------------------");
            Console.WriteLine("Gestion du Quiz \"{0}\" numero : {1}",quiz.GetTitle(),quiz.GetId());
            Console.WriteLine("Ce quiz comporte {0} carte de question. \n", quiz.GetCards().Count());
            Console.WriteLine("--> A : Afficher toutes les informations du Quiz ");
            Console.WriteLine("--> R : Renommer le quiz. ");
            Console.WriteLine("--> G : Gestion des cartes du quiz ");
            Console.WriteLine("--> Q : Quitter la gestion du quiz ");
            Console.WriteLine("");
            Console.WriteLine("\n------------------------------");

            bool invalidResult = true;
            string read = "";

            while (invalidResult)
            {
                Console.Write("\n Que souhaitez vous faire ? : ");
                read = Console.ReadLine();

                invalidResult = false;

                switch (read)
                {
                    // Afficher les informations du quiz
                    case "A":
                        // implemented but not fully tested
                        Console.WriteLine(quiz.ToString());

                        UpdateQuizApp(quiz);
                        break;
                    // Renommer le quiz
                    case "R":
                        RenameQuiz(quiz);
                        UpdateQuizApp(quiz);
                        break;
                    // Gérer les cartes du quiz
                    case "G":
                        // not implemented
                        UpdateQuizApp(quiz);
                        break;
                    // quitter la gestion de quiz
                    case "Q":
                        Console.WriteLine("Retour au menu Principale");
                        MenuPrincipaleApp();
                        break;
                    case "":
                        Console.WriteLine("Erreur aucune saisie : vous devez tapper un des caractère proposés par l'application pour interagir.");
                        invalidResult = true;
                        MenuPrincipaleApp();
                        break;
                    default:
                        Console.WriteLine("Erreur saisie non reconnu : vous devez tapper un des caractères proposés par l'application pour interagir.");
                        invalidResult = true;
                        MenuPrincipaleApp();
                        break;
                }
            }
        }

        public static void RenameQuiz(Quiz quiz)
        {
            Console.WriteLine("Le quiz {0} a pour titre actuelle \"{1}\"", quiz.GetId(), quiz.GetTitle());
            quiz.SetTitle(AskUserQuizTitle());
        }


    }
}
