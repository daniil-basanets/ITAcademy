using EnvelopeAnalyzer.Models;
using System;

namespace EnvelopeAnalyzer.Implementation
{
    public class Rectangular : CommonEnvelope
    {
        #region Private Members

        //private const float eps = 0.0001f;
        private readonly float width;
        private readonly float height;

        #endregion

        public Rectangular(float width, float height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Negative width or height!");
            }
            this.width = width;
            this.height = height;
        }

        public override bool IsEnoughSpaceFor(CommonEnvelope innerEnvelope)
        {
            return innerEnvelope.MaxSide() <= MaxSide()
                && innerEnvelope.MinSide() <= MinSide();
        }

        public override float Square()
        {
            return width * height;
        }

        public override float MaxSide()
        {
            return width > height ? width : height;
        }

        public override float MinSide()
        {
            return width > height ? height : width;
        }
    }
}
