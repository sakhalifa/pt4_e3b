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

        private IGenericRepository<ANIMAL> _animalRepository;

        public AnimalController(IGenericRepository<ANIMAL> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public void CreerAnimal(CLIENT client, string nomEspece, string nomRace, string nomAnimal, DateTime dateNaissance, short taille, int poids) 
        {
            _animalRepository.Insert(new ANIMAL
            {
                CLIENT = client,
                NOMESPECE = nomEspece,
                NOMRACE = nomRace,
                NOMANIMAL = nomAnimal,
                DATENAISSANCE = dateNaissance,
                TAILLE = taille,
                POIDS = poids
            });

            _animalRepository.Save();
        }

    }
}
