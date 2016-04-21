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
    abstract class Forme 
    {
        public Bloc[] blocs = new Bloc[4];
        public Bloc[] blocsEssaisRotation = new Bloc[4];
        public  string Couleur { get; set; }
        static string Image { get; set; }

        public void DeplacerAGauche()
        {         

            blocs[0].X += 1;
            blocs[1].X += 1;
            blocs[2].X += 1;
            blocs[3].X += 1;
        }

        public void DeplacerADroite()
        {

            blocs[0].X -= 1;
            blocs[1].X -= 1;
            blocs[2].X -= 1;
            blocs[3].X -= 1;
        }

        public void DeplacerEnBas()
        {
            blocs[0].Y -= 1; 
            blocs[1].Y -= 1;
            blocs[2].Y -= 1;
            blocs[3].Y -= 1;

        }

        // méthode pour cloner un objet, elle sert pour le test de rotation
        abstract public Forme ShallowCopy();
        


        abstract public void rotation();

        abstract public void RotationInverse();
        

    }


}
