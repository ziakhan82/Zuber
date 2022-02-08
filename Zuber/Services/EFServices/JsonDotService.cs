using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Zuber.Models;
using Zuber.Services.Interfaces;

namespace Zuber.Services.EFServices
{

    //for transfering dot data
    public class JsonDotService
    {
        const string FileName = @".\wwwroot\data\Dots.Json";
        IDotService database;
        private List<Dot> tempList { get; set; }

        public JsonDotService(IDotService d)
        {
            database = d;
            UpdateJson();
        }
        public void UpdateJson()
        {
            tempList = database.GetAllDots();
            WriteToJson(tempList, FileName);
        }
        //public List<Dot> ReadJsonDots(string JsonFileName)
        //{
        //    string jsonString = File.ReadAllText(JsonFileName);

        //    return JsonConvert.DeserializeObject<List<Dot>>(jsonString);
        //}
        public void WriteToJson(List<Dot> Dots, string JsonFileName)
        {
            string output = JsonConvert.SerializeObject(Dots, Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }
    }
}
