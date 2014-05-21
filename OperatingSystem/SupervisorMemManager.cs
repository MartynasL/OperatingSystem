using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class SupervisorMemManager
    {
        private VirtualRealMachine.Memory supervisorMemory;
        private bool[] blocks;

        public SupervisorMemManager(VirtualRealMachine.Memory supervisorMemory, int numberOfBlocks)
        {
            this.supervisorMemory = supervisorMemory;
            blocks = new bool[numberOfBlocks];
            for (int i = 0; i < 30; i++)
            {
                blocks[i] = true;
            }
            for(int i = 30; blocks.Length > i; i++)
            {
                blocks[i] = false;
            }
        }

        public int getFreeBlock()
        {
            for (int i = 0; blocks.Length > i; i++)
            {
                if (blocks[i] == false)
                {
                    blocks[i] = true;
                    return i;
                }
            }
            return -1;
        }

        public void freeBlock(int number)
        {
            blocks[number] =false;
        }
    }
}
