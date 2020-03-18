using HelpersLibrary;
using System;

namespace EnvelopeAnalyzer.Models
{
    abstract class CommonEnvelope
    {
        private CommonEnvelope innerItem;

        public CommonEnvelope InnerItem
        {
            get { return innerItem; }
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
