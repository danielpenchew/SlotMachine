using SlotMachine.Interfaces;

namespace SlotMachine.Services
{
    public class SlotMachineService : ISlotMachineService
    {
        private const string ASTERISK = "*";

        public bool CheckForWinningLine(string firstSlot, string secondSlot, string thirdSlot)
        {
            // * A A or A * A or A A *
            if ((firstSlot == ASTERISK && secondSlot == thirdSlot)
                        || (secondSlot == ASTERISK && firstSlot == thirdSlot)
                        || (thirdSlot == ASTERISK && firstSlot == secondSlot))
            {
                return true;
            }
            // A A A
            else if (firstSlot == secondSlot && secondSlot == thirdSlot)
            {
                return true;
            }
            // * * A or * A * or A * *
            else if (firstSlot == ASTERISK && secondSlot == ASTERISK && thirdSlot != ASTERISK
                        || firstSlot == ASTERISK && secondSlot != ASTERISK && thirdSlot == ASTERISK
                        || (firstSlot != ASTERISK && secondSlot == ASTERISK && thirdSlot == ASTERISK))
            {
                return true;
            }
            // A B P or * A B or A A B
            return false;
        }
    }
}
