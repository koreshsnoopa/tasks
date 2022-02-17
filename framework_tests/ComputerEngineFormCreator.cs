namespace framework_tests
{
    public class ComputerEngineFormCreator
    {
        const int NUMBER_OF_INSTANCES = 4;
        const string SOFTWARE = "Free";
        const string VM_CLASS = "Regular";
        const string INSTANCE_TYPE = "n1-standard-8";
        const int NUMBER_OF_GPUS = 1;
        const string GPU_TYPE = "NVIDIA Tesla V100";
        const string LOCAL_SSD = "2x375 Gb";
        const string DATACENTER_LOCATION = "Frankfurt (europe-west3)";
        const string COMMITED_USAGE = "1 Year";

        public static ComputerEngineForm WithCredentialsFromProperty()
        {
            return new ComputerEngineForm(NUMBER_OF_INSTANCES, SOFTWARE, VM_CLASS, INSTANCE_TYPE, NUMBER_OF_GPUS,
                GPU_TYPE, LOCAL_SSD, DATACENTER_LOCATION, COMMITED_USAGE);
        }
    }
}
