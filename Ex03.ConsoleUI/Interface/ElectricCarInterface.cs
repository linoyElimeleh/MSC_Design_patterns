using GarageLogic;

namespace ConsoleUI.Actions
{
    class ElectricCarInterface
    {
        public static void electricCarQuestions(Vehicle i_TheVehicle)
        {
            CarInterface.carQuestions(i_TheVehicle);
            ElectricInterface.electricQuestions(i_TheVehicle);
        }

    }
}
