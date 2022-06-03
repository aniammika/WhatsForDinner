using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsForDinner.Model;

namespace WhatsForDinner.Data
{
    public interface IDinnerDataProvider
    {
        List<Dinner> LoadDinners();
        void SaveDinner(Dinner dinner);
        void AddDinner(Dinner dinner);
        void RemoveDinner(Dinner dinner);
        IEnumerable<Cusine> LoadCusines();
    }
}
