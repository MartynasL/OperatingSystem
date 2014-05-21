using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class RAMManager
    {
        private VirtualRealMachine.Memory memory;
        private bool[] blocks;

        public RAMManager(VirtualRealMachine.Memory memory, int numberOfBlocks)
        {
            this.memory = memory;
            blocks = new bool[numberOfBlocks];
            for(int i = 0; blocks.Length > i; i++)
            {
                blocks[i] = false;
            }
        }

        private int getFreeBlockNumber()
        {
            for (int i = 0; blocks.Length > i; i++)
            {
                if (blocks[i] == false)
                {
                    return i;
                }
            }
            return -1;
        }

        public VirtualRealMachine.MemoryBlock getPageTable(ref VirtualRealMachine.Word PRValue)
        {
            VirtualRealMachine.MemoryBlock pageTable;

            int freeBlockNr = getFreeBlockNumber();

            if (freeBlockNr == -1)
            {
                return null;
            }
            else
            {
                pageTable = memory.getBlock(freeBlockNr);
                string freeBlockNrStr = freeBlockNr.ToString();
                PRValue = new VirtualRealMachine.Word(freeBlockNrStr);
                blocks[freeBlockNr] = true;

                for (int i = 0; i < 10; i++)
                {
                    int freeBlNumber = getFreeBlockNumber();
                    string freeBlStr = freeBlNumber.ToString();
                    pageTable.setBlockWord(i, new VirtualRealMachine.Word(freeBlStr));
                    blocks[freeBlockNr] = true;
                }
                return pageTable;
            }
        }

        public void freeBlocks(VirtualRealMachine.MemoryBlock pageTable, VirtualRealMachine.Word PRValue)
        {
            for (int i = 0; 10 > i; i++)
            {
                blocks[pageTable.getBlockWord(i).toInt()] = false;
            }

            blocks[PRValue.toInt()] = false;
        }
    }
}
