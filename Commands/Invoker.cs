namespace Commands
{
    public class Invoker
    {
        ICommand command;

        public Invoker()
        {
        }

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void DoCommand()
        {
            command.Excecute();
        }
    }
}
