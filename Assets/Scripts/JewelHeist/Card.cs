using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jsch.JewelHeist
{
    [System.Serializable]
    public class Card : ICard
    {
        public enum CardType { White, Red, Blue, Green, Yellow }

        public CardType type;
        public int value;

        public void Resolve()
        {
            // do nothing
        }



        public bool Equals(Card other)
        {
            if (other is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != other.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (this.type == other.type) && (this.value == other.value);
        }


        public static bool operator ==(Card lhs, Card rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Card lhs, Card rhs) => !(lhs == rhs);
    }

}
