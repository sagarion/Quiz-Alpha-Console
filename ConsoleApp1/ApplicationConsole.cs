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
            MenuPrincipale();
        }

        /// <summary>
        /// cette méthode gère la partie applicative de l'affichage du menu principale
        /// 
        /// pour le moment elle n'affiche que le menu et gère la saisie de l'utilsateur
        /// par la suite, elle enclenchera les autres parties applicative.
        /// </summary>
        private static void MenuPrincipale()
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
                        Console.WriteLine("Vous allez à présent accéder à l'interface de création de Quiz");
                        break;
                    case "M":
                        Console.WriteLine("Vous allez à présent accéder à l'interface des Quiz");
                        break;
                    case "R":
                        Console.WriteLine("Vous allez à présent accéder à l'interface de pratique des Quizs");
                        break;
                    case "S":
                        Console.WriteLine("Merci d'avoir choisi cette fonction mais elle n'est pas encore implémenté");
                        break;
                    case "U":
                        Console.WriteLine("Merci d'avoir choisi cette fonction mais elle n'est pas encore implémenté");
                        break;
                    case "Q":
                        Console.WriteLine("Vous allez à présent quitter l'application");
                        break;
                    case "":
                        Console.WriteLine("Erreur aucune saisie : vous devez tapper un des caractère proposés par l'application pour interagir.");
                        invalidResult = true;
                        break;
                    default:
                        Console.WriteLine("Erreur saisie non reconnu : vous devez tapper un des caractères proposés par l'application pour interagir.");
                        invalidResult = true;
                        break;
                }
            }
        }
    }
}
