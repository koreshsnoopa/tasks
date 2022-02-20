using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace framework_tests
{
    public class ComputerEngineForm
    {
        [JsonProperty(PropertyName = "NumberOfInstances")]
        public int NumberOfInstances { get; set; }
        public string SoftWare { get; set; }
        public string VMClass { get; set; }
        public string InstanceType { get; set; }
        public int NumberOfGPUs { get; set; }
        public string GPUType { get; set; }

        public static explicit operator ComputerEngineForm(Task<ComputerEngineForm> v)
        {
            throw new NotImplementedException();
        }

        public string LocalSSD { get; set; }
        public string DatacenterLocation { get; set; }
        public string CommitedUsage { get; set; }

        public ComputerEngineForm()
        { }

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
