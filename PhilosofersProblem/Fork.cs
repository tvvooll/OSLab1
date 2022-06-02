using System;
using System.Collections.Generic;
using System.Text;

namespace PhilosofersProblem
{
    class Fork
    {
        public bool IsFree { get; set; } = true;
        public int TakerId { get; set; } = -1;

        public virtual bool Take(int takerId)
        {
            if (!IsFree)
                return false;

            IsFree = false;
            TakerId = takerId;
            return true;
        }

        public virtual void Release()
        {
            IsFree = true;
            TakerId = -1;
        }
    }
}
