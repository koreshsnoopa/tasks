using System.Collections.Generic;

namespace exceptions_task
{
    public class AutoPark
    {
        private List<Transport> transports = new List<Transport>();

        public AutoPark()
        {
        }

        public void AddAuto(Transport transport)
        {
            foreach (var tr in transports)
            {
                if (tr.Id == transport.Id)
                {
                    throw new AddException("Can't add two autos with identical IDs!");
                }
            }

            transports.Add(transport);
        }
        public void UpdateAuto(int id, Transport newAuto)
        {
            bool isDone = false;

            for (int i = 0; i < transports.Count; i++)
            {
                if (transports[i].Id == id)
                {
                    transports.Remove(transports[i]);
                    transports.Add(newAuto);
                    isDone = true;
                }
            }

            if (!isDone)
            {
                throw new UpdateAutoException("There is no auto with such ID to update!");
            }
        }

        public void RemoveAuto(int id)
        {
            bool isDone = false;
            for (int i = 0; i < transports.Count; i++)
            {
                if (transports[i].Id == id)
                {
                    transports.Remove(transports[i]);
                    isDone = true;
                }
            }

            if (!isDone)
            {
                throw new RemoveAutoException("There is no auto with such ID to remove!");
            }
        }

        public List<Transport> GetAutoByParameter(string parameter, string value)
        {
            List<Transport> autosWithParamAndVal = new List<Transport>();
            foreach (var tr in transports)
            {
                if (tr.ToString().Contains($"{parameter}:\n{value}"))
                {
                    autosWithParamAndVal.Add(tr);
                }
            }

            if (autosWithParamAndVal.Count == 0)
            {
                throw new GetAutoByParameterException("There is no auto with such parameter or value!");
            }

            return autosWithParamAndVal;
        }

        public List<Transport> GetTransportsList()
        {
            return transports;
        }

    }
}
