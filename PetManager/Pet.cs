using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetManager {
    public class Pet {
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime Birthday
        {
            get;
            set;
        }
        public int Age { get; set; }
        public Pet() { }
        public Pet(int day, int month, int year)
        {
            var date = new DateTime(year: year, month: month, day: day);
            Birthday = date;
            CheckYear(date);
            Age = CalculateAge(date);
        }

        private void CheckYear(DateTime dt)
        {
            var yearNow = DateTime.Now.Year;
            var petYear = Birthday.Year;
            if (petYear > yearNow) throw new Exception("Entered year is in the future..");
        }

        private int CalculateAge(DateTime date)
        {
            var petyears = date.Year;
            var now = DateTime.Now.Year;
            return now - petyears;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

       
        public override bool Equals(object obj)
        {
            if (!(obj is Pet))
            {
                return object.Equals(obj, this);
            }
            var pet = (Pet)obj;
            return Birthday.Equals(pet.Birthday) && string.Equals(this.Name, pet.Name) &&
                   string.Equals(this.Breed, pet.Breed);
        }
    }
}
