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

        public void SubscribeAnimal(OnChanged<ANIMAL> onChanged)
        {
            _animalRepository.Subscribe(onChanged);
        }

        public void SubscribeDeleteAnimal(OnDelete<ANIMAL> onDelete)
        {
            _animalRepository.SubscribeDelete(onDelete);
        }

        public void UnSubscribeAnimal(OnChanged<ANIMAL> onChanged)
        {
            _animalRepository.UnSubscribe(onChanged);
        }

        public void UnSubscribeDeleteAnimal(OnDelete<ANIMAL> onDelete)
        {
            _animalRepository.UnSubscribeDelete(onDelete);
        }

        public void CreerAnimal(CLIENT client, string nomEspece, string nomRace, string nomAnimal, DateTime dateNaissance, short taille, decimal poids) 
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
        }

        public void ModifierAnimal(ANIMAL animal, CLIENT client, string nomEspece, string nomRace, string nomAnimal, DateTime dateNaissance, short taille, decimal poids)
        {
            animal.CLIENT = client;
            animal.NOMESPECE = nomEspece;
            animal.NOMRACE = nomRace;
            animal.NOMANIMAL = nomAnimal;
            animal.DATENAISSANCE = dateNaissance;
            animal.TAILLE = taille;
            animal.POIDS = poids;

            _animalRepository.Update(animal);
            _animalRepository.Save();
        }

        public IQueryable<ANIMAL> AllAnimalsOfCustomer(CLIENT c)
        {
            return _animalRepository.FindWhere((a) => a.CLIENT.IDCLIENT == c.IDCLIENT);
        }

        public ANIMAL AnimalByID(int id)
        {
            return _animalRepository.FindById(id);
        }

        public void DeleteAnimal(ANIMAL a)
        {
            _animalRepository.Delete(a);
            _animalRepository.Save();
        }
    }
}
