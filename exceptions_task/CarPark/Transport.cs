namespace exceptions_task
{
    public abstract class Transport
    {
        public Transmission transmission;
        public Chassis chassis;
        public Engine engine;
        public int Id { get; private set; }

        public Transport(Transmission transmission, Chassis chassis, Engine engine, int Id)
        {
            this.transmission = transmission;
            this.chassis = chassis;
            this.engine = engine;

            if (Id <= 0)
            {
                throw new InitializationException("Id must be more then 0!");
            }
            else
            {
                this.Id = Id;
            }
        }

        public override string ToString()
        {
            return $"\nID:\n{Id}";
        }

    }
}
