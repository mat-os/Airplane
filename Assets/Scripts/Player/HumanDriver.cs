
    public class HumanDriver : IDriver
    {
        private Airplane airplane;
        public void Control(Airplane _airplane)
        {
            airplane = _airplane;
        }
    }
