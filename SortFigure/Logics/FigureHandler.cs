using SortFigure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortFigure.Logics
{
    class FigureHandler
    {
        private List<Figure> figures;

        public Figure this[int index]
        {
            get
            {
                if (index >= figures.Count)
                {
                    return null;
                }
                return figures[index];
            }
            set
            {
                figures[index] = value;
            }
        }

        public FigureHandler()
        {
            figures = new List<Figure>(0);
        }

        public void AddFigure(Figure figure)
        {
            figures.Add(figure);
        }

        public override string ToString()
        {
            figures.Sort();
            StringBuilder builder = new StringBuilder("============= Figures list: ===============\n\r");
            foreach (var figure in figures)
            {
                builder.Append(figure.ToString());
                builder.Append("\n\r");
            }
            return builder.ToString().Trim();
        }
    }
}
