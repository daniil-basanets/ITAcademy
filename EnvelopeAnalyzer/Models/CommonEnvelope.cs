using HelpersLibrary;
using System;

namespace EnvelopeAnalyzer.Models
{
    public abstract class CommonEnvelope
    {
        private CommonEnvelope innerItem;

        public CommonEnvelope InnerItem
        {
            get => innerItem;
            set
            {
                if (IsEnoughSpaceFor(value))
                {
                    innerItem = value;
                }
                else
                {
                    throw new ArgumentException(ErrorCode.InvalidProperty.GetMessage(), "innerItem");
                }
            }
        }

        abstract public float MaxSide();

        abstract public float MinSide();

        abstract public float Square();

        abstract public bool IsEnoughSpaceFor(CommonEnvelope innerEnvelope);
    }
}
