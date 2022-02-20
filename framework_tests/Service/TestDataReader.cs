using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace framework_tests
{
    public class TestDataReader
    {
        public static async Task<ComputerEngineForm> GetForm(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                ComputerEngineForm form = await JsonSerializer.DeserializeAsync<ComputerEngineForm>(fs);
                return form;
            }
        }
    }
}
