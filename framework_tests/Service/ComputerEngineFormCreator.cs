using System;

namespace framework_tests
{
    public class ComputerEngineFormCreator
    {
        public static ComputerEngineForm WithCredentialsFromProperty()
        {
            if (Environment.GetEnvironmentVariable("enviroment").Equals("dev"))
            {
                return TestDataReader.GetForm("/Users/marialukasova/Projects/epam_tasks/framework_tests/DevConfig.json").Result;
            }
            else if (Environment.GetEnvironmentVariable("enviroment").Equals("qa"))
            {
                return TestDataReader.GetForm("/Users/marialukasova/Projects/epam_tasks/framework_tests/QAConfig.json").Result;
            }

            return null;
        }
    }
}
