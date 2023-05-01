namespace SlotMachine.Interfaces
{
    public interface ISlotMachineService
    {
        bool CheckForWinningLine(string firstSlot, string secondSlot, string thirdSlot);
    }
}
