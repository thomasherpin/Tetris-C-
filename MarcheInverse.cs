using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class MarcheInverse: Forme
    {
        public MarcheInverse()
        {
            blocs[0] = new Bloc { X = 5, Y = 20 };
            blocs[1] = new Bloc { X = 4, Y = 20 };
            blocs[2] = new Bloc { X = 4, Y = 21 };
            blocs[3] = new Bloc { X = 3, Y = 21 };
        }
        public override Forme ShallowCopy()
        {
            Forme marcheI = new MarcheInverse();
            marcheI.blocs = this.blocs;
            return marcheI;
        }

        public override void rotation()
        {
            if(blocs[0].X - blocs[3].X == 2)
            {
                blocs[0].X -= 1;
                blocs[1].Y += 1;
                blocs[2].X += 1;
                blocs[3].X += 2;
                blocs[3].Y += 1;
            }
            else if (blocs[3].Y - blocs[0].Y == 2 && blocs[3].X > 1)
            {
                blocs[0].X += 1;
                blocs[1].Y -= 1;
                blocs[2].X -= 1;
                blocs[3].X -= 2;
                blocs[3].Y -= 1;
            }
        }

        public override void RotationInverse()
        {
            if (blocs[3].Y - blocs[0].Y == 2)
            {
                blocs[0].X += 1;
                blocs[1].Y -= 1;
                blocs[2].X -= 1;
                blocs[3].X -= 2;
                blocs[3].Y -= 1;
            }
            else if(blocs[0].X - blocs[3].X == 2)
            {
                blocs[0].X -= 1;
                blocs[1].Y += 1;
                blocs[2].X += 1;
                blocs[3].X += 2;
                blocs[3].Y += 1;
            }
        }
    }
}
