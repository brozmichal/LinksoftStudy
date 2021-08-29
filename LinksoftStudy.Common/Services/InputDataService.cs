using LinksoftStudy.Common.Interfaces;
using LinksoftStudy.Common.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinksoftStudy.Common.Services
{
    public class InputDataService : IInputDataService
    {
        public InputDataService()
        {

        }

        public IEnumerable<IContactModel> ProcessContent(string content)
        {
            var pairs = content.Split("\n");
            var inputDataModels = new List<ContactModel>();
            foreach (var pair in pairs)
            {
                var inputItem = this.ProcessPair(pair);
                if (inputItem == null)
                {
                    continue;
                }

                inputDataModels.Add((ContactModel)inputItem);
            }

            return inputDataModels;
        }

        public IEnumerable<IContactModel> ProcessInputFile(string path)
        {
            var reader = new StreamReader(path);

            string line;
            var inputDataModels = new List<ContactModel>();

            while ((line = reader.ReadLine()) != null)
            {
                var inputItem = this.ProcessPair(line);
                if (inputItem == null)
                {
                    continue;
                }

                inputDataModels.Add((ContactModel)inputItem);
            }

            return inputDataModels;
        }

        private IContactModel ProcessPair(string pairString)
        {
            var splitString = pairString.Split(null);
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
