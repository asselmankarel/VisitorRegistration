using System;
using VisitorRegistrationLibrary.Models;
using System.Collections.Generic;
using System.IO;

namespace VisitorRegistrationLibrary.DataAccess
{
    public static class CsvConnectorProcessor
    {
        public static List<CompanyModel> LoadCompanies(string filePath)
        {
            List<CompanyModel> output = new List<CompanyModel>();
            IEnumerable<string> FileContent;
            FileContent = File.ReadLines(filePath);

            foreach(string line in FileContent)
            {
                string[] lineArr = line.Split(',');
                CompanyModel model = new CompanyModel();
                int.TryParse(lineArr[0], out int id);
                model.Id = id;
                model.Name = lineArr[1];
                output.Add(model);
            }

            return output;

        }
    }
}
