using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class L : Forme
    {
        public L ()
        {
            blocs[0] = new Bloc { X = 4, Y = 21 };
            blocs[1] = new Bloc { X = 4, Y = 22 };
            blocs[2] = new Bloc { X = 4, Y = 20 };
            blocs[3] = new Bloc { X = 5, Y = 20 };
        }

        public override Forme ShallowCopy()
        {
            Forme l = new L();
            l.blocs = this.blocs;
            return l;
        }

        public override void rotation()
        {
            if (blocs[1].Y - blocs[0].Y == 1 && blocs[1].X  > 0)
            {
                blocs[0].Y -= 1;
                blocs[1].X -= 1;
                blocs[1].Y -= 2;
                blocs[2].X += 1;
                blocs[3].Y += 1;

            }

            else if (blocs[1].X - blocs[0].X == -1 && blocs[3].X + 1 > 0)
            {
                blocs[0].Y += 1;
                blocs[1].X += 1;
                blocs[2].X -= 1;
                blocs[2].Y += 2;
                blocs[3].X -= 2;
                blocs[3].Y += 1;
            }

            else if (blocs[1].Y - blocs[0].Y == -1 && blocs[1].X +1 < 10)
            {
                blocs[1].X += 1;
                blocs[1].Y += 1;
                blocs[2].X -= 1;
                blocs[2].Y -= 1;
                blocs[3].Y -= 2;

            }

            else if (blocs[1].X - blocs[0].X == 1)
            {
                blocs[1].X -= 1;
                blocs[1].Y += 1;
                blocs[2].X += 1;
                blocs[2].Y -= 1;
                blocs[3].X += 2;
            }
        }

        public override void RotationInverse()
        {
            if (blocs[1].X - blocs[0].X == -1)
            {
                blocs[0].Y += 1;
                blocs[1].X += 1;
                blocs[1].Y += 2;
                blocs[2].X -= 1;
                blocs[3].Y -= 1;

            }

            else if ( blocs[1].Y - blocs[0].Y == -1)
            {
                blocs[0].Y -= 1;
                blocs[1].X -= 1;
                blocs[2].X += 1;
                blocs[2].Y -= 2;
                blocs[3].X += 2;
                blocs[3].Y -= 1;
            }

            else if (blocs[1].X - blocs[0].X == 1)
            {
                blocs[1].X -= 1;
                blocs[1].Y -= 1;
                blocs[2].X += 1;
                blocs[2].Y += 1;
                blocs[3].Y += 2;

            }

            else if (blocs[1].Y - blocs[0].Y == 1)
            {
                blocs[1].X += 1;
                blocs[1].Y -= 1;
                blocs[2].X -= 1;
                blocs[2].Y += 1;
                blocs[3].X -= 2;
            }
        }
    }
}
