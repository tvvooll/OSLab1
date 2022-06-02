using System.Collections.Generic;
using System.Linq;

namespace PhilosofersProblem
{
    class ManagedFork : Fork
    {
        static Manager manager = new Manager();

        public override bool Take(int takerId)
        {
            lock (manager)
            {
                if (!IsFree || !manager.CanTake(takerId, this))
                    return false;
                IsFree = false;
                TakerId = takerId;
            }
            return true;
        }

        public ManagedFork()
        {
            manager.Forks.Add(this);
        }

        class Manager
        {
            public List<ManagedFork> Forks = new List<ManagedFork>();

            public bool CanTake(int taker, ManagedFork fork)
            {
                return Forks.Select(x => x.TakerId)
                            .Where(x => x != taker)
                            .Distinct()
                            .Count() != Forks.Count;
            }
        }
    }
}
