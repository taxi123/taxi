using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taxi
{
    class State
    {
        private int number;
        private String description;

        public int getNumber() { return this.number; }
        public String getDescription() { return this.description; }

        public State(int number, String description)
        {
            this.number = number;
            this.description = description;
        }
    }
}
