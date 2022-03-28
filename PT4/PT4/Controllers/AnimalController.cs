using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT4.Model.dal;

namespace PT4.Controllers
{
    
    public class AnimalController
    {
        public delegate void OnChangedAnimal(IEnumerable<ANIMAL> animals);
        private IGenericRepository<ANIMAL> _animalRepository;

        

        public AnimalController(IGenericRepository<ANIMAL> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public void CreerAnimal(CLIENT client, string nomEspece, string nomRace, string nomAnimal, DateTime dateNaissance, short taille, int poids) 
        {
            ANIMAL newAnimal = new ANIMAL
            {
                CLIENT = client,
                NOMESPECE = nomEspece,
                NOMRACE = nomRace,
                NOMANIMAL = nomAnimal,
                DATENAISSANCE = dateNaissance,
                TAILLE = taille,
                POIDS = poids
            };
            _animalRepository.Insert(newAnimal);

            _animalRepository.Save();
            List<ANIMAL> animalsChanged = new List<ANIMAL>();
            animalsChanged.Add(newAnimal);
            //OnChangedAnimal.Invoke(animalsChanged);
        }

        /// <summary>
        /// Find all animals in the database
        /// </summary>
        public IQueryable<ANIMAL> FindAll()
        {
            return _animalRepository.FindAll();
        }
    }
}
