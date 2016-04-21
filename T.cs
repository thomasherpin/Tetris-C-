using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class T : Forme
    {
        public T()
        {
            blocs[0] = new Bloc { X = 5, Y = 21 };
            blocs[1] = new Bloc { X = 4, Y = 20 };
            blocs[2] = new Bloc { X = 5, Y = 20 };
            blocs[3] = new Bloc { X = 6, Y = 20 };
        }

        public override Forme ShallowCopy()
        {
            Forme t = new T();
            t.blocs = this.blocs;
            return t;
        }


        public override void rotation()
        {
            if (blocs[0].Y - blocs[1].Y == 1 && blocs[0].X - blocs[1].X == 1)
            {
                blocs[1].X += 2;
                blocs[2].X += 1;
                blocs[2].Y += 1;
                blocs[3].Y += 2;
            }

            else if (blocs[2].X - blocs[0].X == 1 && blocs[3].X > 1)
            {
                blocs[1].Y += 1;
                blocs[2].X -= 1;
                blocs[2].Y -= 1;
                blocs[3].X -= 2;
                blocs[3].Y -= 1;
            }

            else if (blocs[1].X - blocs[3].X == 2 )
            {
                blocs[1].X -= 2;
                blocs[1].Y += 1;
                blocs[2].X -= 1;
                blocs[2].Y += 1;
                blocs[3].Y -= 1;
            }

            else if(blocs[0].X - blocs[2].X == 1 && blocs[3].X < 8)
            {
                blocs[1].Y -= 2;
                blocs[2].X += 1;
                blocs[2].Y -= 1;
                blocs[3].X += 2;
            }
        }

        public override void RotationInverse()
        {
            if (blocs[2].X - blocs[0].X == 1)
            {
                blocs[1].X -= 2;
                blocs[2].X -= 1;
                blocs[2].Y -= 1;
                blocs[3].Y -= 2;
            }

            else if (blocs[0].X - blocs[1].X == -1)
            {
                blocs[1].Y -= 1;
                blocs[2].X += 1;
                blocs[2].Y += 1;
                blocs[3].X += 2;
                blocs[3].Y += 1;
            }

            else if (blocs[0].X - blocs[2].X == 1)
            {
                blocs[1].X += 2;
                blocs[1].Y -= 1;
                blocs[2].X += 1;
                blocs[2].Y -= 1;
                blocs[3].Y += 1;
            }

            else if (blocs[0].Y - blocs[1].Y == 1 && blocs[0].X - blocs[1].X == 1)
            {
                blocs[1].Y += 2;
                blocs[2].X -= 1;
                blocs[2].Y += 1;
                blocs[3].X -= 2;
            }
        }
    }
}
