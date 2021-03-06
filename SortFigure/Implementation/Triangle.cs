﻿using HelpersLibrary;
using SortFigure.Interfaces;
using System;

namespace SortFigure.Implementation
{
    public class Triangle : Figure
    {
        private float sideA;
        private float sideB;
        private float sideC;

        public float SideA
        {
            get => sideA;
            set
            {
                if (Validator.IsValidTriangle(value, SideB, SideC))
                {
                    sideA = value;
                }
            }
        }

        public float SideB
        {
            get => sideB;
            set
            {
                if (Validator.IsValidTriangle(SideA, value, SideC))
                {
                    sideB = value;
                }
            }
        }

        public float SideC
        {
            get => sideC;
            set
            {
                if (Validator.IsValidTriangle(SideA, SideB, value))
                {
                    sideC = value;
                }
            }
        }

        public override float Square => GetSquare();

        public override float Perimeter => sideA + sideB + sideC;

        private float GetSquare()
        {
            var halphPerimeter = (sideA + sideB + sideC) / 2.0;
            return (float)Math.Sqrt(halphPerimeter * (halphPerimeter - sideA) * (halphPerimeter - sideB) * (halphPerimeter - sideC));
        }

        public Triangle(float sideA, float sideB, float sideC, string name)
        {
            if (!Validator.IsValidTriangle(sideA, sideB, sideC))
            {
                throw new ArgumentException(ErrorCode.IncorrectTriangle.GetMessage());
            }

            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("[Triangle {0}]: {1:0.00} сm", Name, Square);
        }
    }
}
