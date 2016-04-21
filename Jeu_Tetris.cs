using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Jeu_Tetris
    {
        public struct etatBloc
        {
            public int? Id { get; set; } // garde en memoire a quel objet appartient le bloc
            public string Couleur { get; set; }

        }

        public bool GameOver { get; set; }
        List<Forme> formes = new List<Forme>();
        int Id = 0;
        public int Score { get; set; } = 0;

        //Création des niveaux

        #region Level
        Level level1 = new Level("Level 1",0, 1);
        Level level2 = new Level("Level 2", 5000, 2);
        Level level3 = new Level("Level 3", 10000, 3);
        Level level4 = new Level("Level 4", 20000, 4);
        List<Level> levels = new List<Level>();


        #endregion
        public List<string> ListeCouleur = new List<string> { "#3399ff", "#6C7F59", "#7E680B", "#FDD016", "#3A9649", "#47ce8e", "#8b7b8b", "#7b68ee", "#8b7e66", "#20b2aa","#1F6357","#f070de", "#d60a0a","#AED9BB", "#344138" };


        // je n'arrive pas a remplir la liste dans la classe donc je fais dans une methode
        public void RemplirListeNiveau()
        {
            levels.Add(level1);
            levels.Add(level2);
            levels.Add(level3);
            levels.Add(level4);
        }

        public Level getLevel()
        {
            Level levelActuel = new Level();
            for(int i = levels.Count()- 1; i >= 0; i--)
            {
                if(Score >= levels[i].ScoreADepasser)
                {
                    levelActuel = levels[i];
                    return levelActuel;
                }

            }

            return levelActuel;
        }
        public etatBloc[,] grilleTetris;

        public Jeu_Tetris()
        {
            grilleTetris = new etatBloc[10, 24];

        }

        public Forme InitialiserForme()
        {

            #region Les formes

            Forme carre = new Carree();
            Forme l = new L();
            Forme linverse = new LInverse();
            Forme ligne = new Ligne();
            Forme marche = new Marche();
            Forme marcheInverse = new MarcheInverse();
            Forme t = new T();



            formes.Clear();
            Forme formeAleatoire;
            formes.Add(carre);
            formes.Add(l);
            formes.Add(linverse);
            formes.Add(ligne);
            formes.Add(marche);
            formes.Add(marcheInverse);
            formes.Add(t);
            #endregion

            Random geneAleatoire = new Random();
            int nombregenere = geneAleatoire.Next(0, formes.Count);
            int couleurgenere = geneAleatoire.Next(0, ListeCouleur.Count);
            formeAleatoire = formes[nombregenere];
            formeAleatoire.Couleur = ListeCouleur[couleurgenere];
            return formeAleatoire;
        }


        public void initGrille()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 24 ; j++)
                {
                    grilleTetris[i, j].Id = null;  // aucun objet est present dans la grille au depart
                    grilleTetris[i, j].Couleur = null;
                }
            }
        }

        #region Collision
        //test les cases disponible vertical
        public bool CollisionVertical(Bloc[] blocs)
        {
            bool collision = false;

            for (int i = 0; i < blocs.Count(); i++)
                if (blocs[i].Y == 0 || grilleTetris[blocs[i].X, blocs[i].Y - 1].Id != null)
                {
                    if (blocs[i].Y > 19)
                    {
                        GameOver = true;
                    }
                    collision = true;
                    Score += 10;
                    return collision;
                }

            return collision;
        }


        //test les cases disponible horizontal
        public bool CollisionHorizontalGauche(Bloc[] blocs)
        {
            bool collision = false;

            for (int i = 0; i < blocs.Count(); i++)
                if (blocs[i].X == 9 || grilleTetris[blocs[i].X + 1, blocs[i].Y].Id != null)
                {
                    collision = true;
                    return collision;
                }

            return collision;
        }

        public bool CollisionHorizontalDroite(Bloc[] blocs)
        {
            bool collision = false;

            for (int i = 0; i < blocs.Count(); i++)
                if (blocs[i].X == 0 || grilleTetris[blocs[i].X - 1, blocs[i].Y].Id != null)
                {
                    collision = true;
                    return collision;
                }

            return collision;
        }
        #endregion


        public etatBloc[,] getGrille()
        {
            return grilleTetris;
        }


        public void remplirGrille(Forme forme)
        {
            for (int i = 0; i < forme.blocs.Count(); i++)
            {
                grilleTetris[forme.blocs[i].X, forme.blocs[i].Y].Id = Id;
                grilleTetris[forme.blocs[i].X, forme.blocs[i].Y].Couleur = forme.Couleur;

            }
        }

        public void VerifLigneComplete()
        {
            for (int r = 0; r < 20; r++)
            {
                int compteur = 0;
                for (int c = 0; c < 10; c++)
                {
                    if (grilleTetris[c, r].Id != null)
                    {
                        compteur += 1;
                    }
                }
                if (compteur == 10)
                {
                    Score += 1000;
                    for (int row = r; row < 20; row++)
                    {
                        for (int c = 0; c < 10; c++)
                        {
                            grilleTetris[c, row] = grilleTetris[c, row + 1];
                        }                  
                    }
                    r -= 1;

                }

            }
        }

        public void Rotation(Forme forme)
        {
            //sert a vérifié la disponibilité des cases apres rotation

            forme.rotation();
            bool collision = false;
            for (int i = 0; i < forme.blocs.Count() && collision == false; i++)
            {
                if (grilleTetris[forme.blocs[i].X, forme.blocs[i].Y].Id != null)
                {
                    forme.RotationInverse();
                    collision = true;
                }

            }
        }
    }
}

