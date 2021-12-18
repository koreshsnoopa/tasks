using System;
using System.Collections.Generic;

namespace exceptions_task
{
    static class ExtensionClass
    {
        public static void AddAuto(this List<Transport> transports, Transport transport)
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

        public static void UpdateAuto(this List<Transport> transports, int id, Transport newAuto)
        {
            bool isDone = false;

            for (int i = 0; i < transports.Count; i++)
            {
                if (transports[i].Id == id)
                {
                    transports.Remove(transports[i]);
                    transports.AddAuto(newAuto);
                    isDone = true;
                }
            }

            if (!isDone)
            {
                throw new UpdateAutoException("There is no auto with such ID to update!");
            }
        }

        public static void RemoveAuto(this List<Transport> transports, int id)
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

        public static List<Transport> GetAutoByParameter(this List<Transport> transports, string parameter, string value)
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
    }
}
