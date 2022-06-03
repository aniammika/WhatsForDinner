using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WhatsForDinner.Model;
using WhatsForDinner.Resources;

namespace WhatsForDinner.Data
{
    public class DinnerDataProvider: IDinnerDataProvider
    {
        public List<Dinner> LoadDinners()
        {
            List<Dinner> dinners = new List<Dinner>();
            var loadedDinners = File.ReadAllText(Constants.dataFilePath);
            dinners = JsonSerializer.Deserialize<List<Dinner>>(loadedDinners);
            return dinners;
        }

        public void SaveDinner(Dinner dinner)
        {
            List<Dinner> dinners = new List<Dinner>();
            var loadedDinners = File.ReadAllText(Constants.dataFilePath);
            dinners = JsonSerializer.Deserialize<List<Dinner>>(loadedDinners);
            dinners.RemoveAt(dinner.Id);
            dinners.Add(dinner);
            string dinnersJson = JsonSerializer.Serialize(dinners);
            File.WriteAllText(Constants.dataFilePath, dinnersJson);

        }
        public void AddDinner(Dinner dinner)
        {
            List<Dinner> dinners = new List<Dinner>();
            var loadedDinners = File.ReadAllText(Constants.dataFilePath);
            dinners = JsonSerializer.Deserialize<List<Dinner>>(loadedDinners);
            dinners.Add(dinner);
            string dinnersJson = JsonSerializer.Serialize(dinners);
            File.WriteAllText(Constants.dataFilePath, dinnersJson);
        }
        public void RemoveDinner(Dinner dinner)
        {
            List<Dinner> dinners = new List<Dinner>();
            var loadedDinners = File.ReadAllText(Constants.dataFilePath);
            dinners = JsonSerializer.Deserialize<List<Dinner>>(loadedDinners);
            dinners.RemoveAt(dinner.Id);
            string dinnersJson = JsonSerializer.Serialize(dinners);
            File.WriteAllText(Constants.dataFilePath, dinnersJson);
        }

        public IEnumerable<Cusine> LoadCusines()
        {
            return new List<Cusine>
            {
                new Cusine {Id = 1, CusineName = "Polska"},
                new Cusine {Id = 2, CusineName = "Włoska"},
                new Cusine {Id = 3, CusineName = "Francuska"},
                new Cusine {Id = 4, CusineName = "Meksykańska"},
                new Cusine {Id = 5, CusineName = "Japońska"},
                new Cusine {Id = 6, CusineName = "Tajska/Wietnamska"},
                new Cusine {Id = 7, CusineName = "Wegetariańska"},
                new Cusine {Id = 8, CusineName = "Pozostałe"}
            };
        }
    }
}
