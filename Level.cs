using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Level
    {
        
        public int ScoreADepasser { get; set; }
        public int CoefficientVitesse { get; set; }
        public string Nom { get; set; }
        //constucteur par defaut pour les tests
        public Level() { }

        public Level(string nom, int scoreADepasser, int coefficientVitesse)
        {
            Nom = nom;
            ScoreADepasser = scoreADepasser;
            CoefficientVitesse = coefficientVitesse;
        }
    }
}
