using System;
namespace framework_tests
{
    public class ComputerEngineForm
    {
        public int NumberOfInstances { get; private set; }
        public string SoftWare { get; private set; }
        public string VMClass { get; private set; }
        public string InstanceType { get; private set; }
        public int NumberOfGPUs { get; private set; }
        public string GPUType { get; private set; }
        public string LocalSSD { get; private set; }
        public string DatacenterLocation { get; private set; }
        public string CommitedUsage { get; private set; }

        public ComputerEngineForm(int NumberOfInstances, string SoftWare, string VMClass, string InstanceType,
            int NumberOfGPUs, string GPUType, string LocalSSD, string DatacenterLocation, string CommitedUsage)
        {
            if (string.IsNullOrEmpty(SoftWare) || string.IsNullOrEmpty(VMClass) || string.IsNullOrEmpty(InstanceType)
                || string.IsNullOrEmpty(GPUType) || string.IsNullOrEmpty(LocalSSD) || string.IsNullOrEmpty(DatacenterLocation)
                || string.IsNullOrEmpty(CommitedUsage))
            {
                throw new ArgumentException("Field is empty!");
            }

            this.NumberOfInstances = NumberOfInstances;
            this.SoftWare = SoftWare;
            this.VMClass = VMClass;
            this.InstanceType = InstanceType;
            this.NumberOfGPUs = NumberOfGPUs;
            this.GPUType = GPUType;
            this.LocalSSD = LocalSSD;
            this.DatacenterLocation = DatacenterLocation;
            this.CommitedUsage = CommitedUsage;
        }
    }
}
