using System;
using System.Diagnostics.CodeAnalysis;

namespace SortFigure.Models
{
    abstract class Figure : IComparable<Figure>
    {
        public string Name { get; set; }
        public abstract float Square { get; }
        public abstract float Perimeter { get; }

        public int CompareTo([AllowNull] Figure other)
        {
            return Square.CompareTo(other.Square);
        }

        public abstract override string ToString();
    }
}
