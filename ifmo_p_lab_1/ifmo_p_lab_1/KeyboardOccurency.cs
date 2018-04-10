using System;

namespace Petar.IFMO.sem_2.programming.lab_1
    {
    class KeyboardOccurency
        {
        internal Int32 index;
        internal Int32 count;
        internal Boolean foundInAnnotation;

        public KeyboardOccurency(Int32 index, Int32 count, Boolean foundInAnnotation)
            {
            this.index = index;
            this.count = count;
            this.foundInAnnotation = foundInAnnotation;
            }
        }
    }
