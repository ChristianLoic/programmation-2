using System;

namespace lab2BlackJack
{
    class Program
    {

        static void Main(string[] args)
        {
            Random rand = new Random();

            int miseJoueur = 0;
            int scoreJ = 0;
            int scoreA = 0;
            int choix = 0;

            // Joueur
            int jetons = 100;
            int valeurCarteJ1 = 0;
            int valeurCarteJ2 = 0;
            int valeurCarteJ3 = 0;
            int typeCarteJ1 = 0;
            int typeCarteJ2 = 0;
            int typeCarteJ3 = 0;

            // Ordinateur (A)
            int valeurCarteA1 = 0;
            int valeurCarteA2 = 0;
            int valeurCarteA3 = 0;
            int typeCarteA1 = 0;
            int typeCarteA2 = 0;
            
           

            //Convertir le type int en string//
            string getTypeCarte(int typeCarte)
            {
                string typeString = "";

                switch (typeCarte)
                {
                    case 1: typeString = "carreau"; break;
                    case 2: typeString = "pique"; break;
                    case 3: typeString = "trefle"; break;
                    case 4: typeString = "coeur"; break;
                }

                return typeString;
            }
            string getValeurCarte(int valeurCarte)
            {
                string valeurString = "";

                if(valeurCarte==11)
                {
                    valeurString = "As";
                    return valeurString;
                }
                else
                {
                    valeurString =Convert.ToString(valeurCarte);
                    return valeurString;
                }
            }


            //generer main A//
            void genererMainA()
            {
                valeurCarteA1 = rand.Next(1, 14);
                typeCarteA1 = rand.Next(1, 5);

                valeurCarteA2 = rand.Next(1, 14);
                typeCarteA2 = rand.Next(1, 5);

            }    
            //generer main joueur//
           void genererMainJ()
            { 
                valeurCarteJ1 = rand.Next(1, 14);
                typeCarteJ1 = rand.Next(1, 5);

                valeurCarteJ2 = rand.Next(1, 14);
                typeCarteJ2 = rand.Next(1, 5);

            }
            //generer 3eme carte joueur//
            void genererJ3()
            {
                valeurCarteJ3 = rand.Next(1, 14);
                typeCarteJ3 = rand.Next(1, 5);
                
            }

            //afficher 3eme carte joueur//
            void affichercarteJ3()
            {
                genererJ3();
                Console.WriteLine("tu as piocher un :" + getValeurCarte(valeurCarteJ3) + " de " + getTypeCarte(typeCarteJ3));
            }
            //generer 3eme carte adversaire//
            void genererA3()
            {
                valeurCarteA3 = rand.Next(1, 14);
            }

            //afficher une carte de l"adversaire//
           void afficherCarteA()
            {
                genererMainA();
                Console.WriteLine("carte ORDI:" + getValeurCarte(valeurCarteA1) + " de "+ getTypeCarte(typeCarteA1));
            }

            //fonction afficher ma main //
            void afficherMainJ()
            {
                genererMainJ();
                Console.WriteLine("ta main est:");
                Console.WriteLine("carte1:" + getValeurCarte(valeurCarteJ1) + " de " + getTypeCarte(typeCarteJ1));
                Console.WriteLine("carete2:" + getValeurCarte(valeurCarteJ2) + " de " + getTypeCarte(typeCarteJ2));
            }




            //debut jeu
            do
            {
                //le joeur mise une qte//
                Console.WriteLine("combien voulez-vous misez?    (0- "+jetons+" )");
                miseJoueur = Convert.ToInt32(Console.ReadLine());
                if (miseJoueur <= jetons)
                {
                    genererMainA();
                    genererMainJ();
                    afficherCarteA();
                    afficherMainJ();

                    Console.WriteLine("veux-tu: 1-recevoir une nouvelle carte ou 2-arreter ");
                    choix = Convert.ToInt32(Console.ReadLine());
                    if (choix == 1)
                    {
                        genererJ3();
                        affichercarteJ3();
                        scoreJ = valeurCarteJ1 + valeurCarteJ2 + valeurCarteJ3;
                        Console.WriteLine("tu totalises actuellement :" + scoreJ + "points");
                    }
                    else if (choix == 2)
                    {
                        scoreJ = valeurCarteJ2 + valeurCarteJ1;
                        Console.WriteLine("tu totalises actuelement:" + scoreJ + "points");
                    }

                    //le tour de l`ordinateur//

                    scoreA = valeurCarteA1 + valeurCarteA2;
                    if (scoreA < scoreJ && scoreJ <= 21)
                    {
                        genererA3();
                        scoreA = scoreA + valeurCarteA3;
                        Console.WriteLine("l'ordinateur choisit de piocher");
                        Console.WriteLine("score ORDI:" + scoreA); //
                    }
                    else
                    {
                        Console.WriteLine("l'ordi choisit de ne pas piocher ");
                        Console.WriteLine("score ORDI:" + scoreA); //
                    }

                    //determination du gagnant //

                    if (scoreJ > scoreA && scoreJ <= 21)
                    {
                        jetons = jetons + miseJoueur;
                        Console.WriteLine("you won");
                    }
                    else if (scoreJ < scoreA && scoreA > 21)
                    {
                        jetons = jetons + miseJoueur;
                        Console.WriteLine("you won");
                    }
                    else if (scoreA > 21 && scoreJ > 21)
                    {
                        Console.WriteLine("both loosers");
                    }
                    else if (scoreA <= 21 && scoreJ > 21)
                    {
                        jetons = jetons - miseJoueur;
                        Console.WriteLine("looser!");
                    }
                    else if (scoreJ < scoreA && scoreA <= 21)
                    {
                        jetons = jetons - miseJoueur;
                        Console.WriteLine("looser!");
                    }
                }
                else
                {
                    Console.WriteLine("vous n`avez pas assez de jetons ");
                }

                // bilan
                Console.WriteLine("ton solde est de  : " + jetons + "jetons");

            }
            while (jetons > 0);
            Console.WriteLine("TU N'AS PLUS DE JETONS ");
            Console.WriteLine("FIN DE LA PARTIE");

            Console.ReadLine();
























        }











    }

}
