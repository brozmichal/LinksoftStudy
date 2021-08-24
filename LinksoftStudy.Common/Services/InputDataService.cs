using LinksoftStudy.Common.Interfaces;
using LinksoftStudy.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LinksoftStudy.Common.Services
{
    public class InputDataService : IInputDataService
    {
        public InputDataService()
        {

        }

        public IEnumerable<ContactModel> ProcessContent(string content)
        {
            var pairs = content.Split("\n");
            List<ContactModel> inputDataModels = new List<ContactModel>();
            foreach (var pair in pairs)
            {
                var inputItem = ProcessPair(pair);
                if (inputItem == null)
                {
                    continue;
                }

                inputDataModels.Add(inputItem);
            }

            return inputDataModels;
        }

        public IEnumerable<ContactModel> ProcessInputFile(string path)
        {
            var reader = new StreamReader(path);

            string line;
            List<ContactModel> inputDataModels = new List<ContactModel>();

            while ((line = reader.ReadLine()) != null)
            {
                var inputItem = ProcessPair(line);
                if (inputItem == null)
                {
                    continue;
                }

                inputDataModels.Add(inputItem);
            }

            return inputDataModels;
        }

        private ContactModel ProcessPair(string pairString)
        {
            var splitString = pairString.Split(' ');
            var filteredLine = splitString.Where(item => !string.IsNullOrWhiteSpace(item)).ToList();
            if (filteredLine.Count != 2)
            {
                // log inconsistent line
                return null;
            }

            return new ContactModel()
            {
                ContactPrimary = filteredLine[0],
                ContactSecondary = filteredLine[1]
            };
        }
    }
}
