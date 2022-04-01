using PT4.Model.dal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PT4.Controllers
{

    public class AnimalController
    {
        private IGenericRepository<ANIMAL> _animalRepository;
        private IGenericRepository<HISTORIQUEMALADIE> _histoMaladieRepo;


        public AnimalController(IGenericRepository<ANIMAL> animalRepository, IGenericRepository<HISTORIQUEMALADIE> histoMaladieRepo)
        {
            _animalRepository = animalRepository;
            _histoMaladieRepo = histoMaladieRepo;
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

        public void AddSickness(ANIMAL a, MALADIE m, DateTime date)
        {
            var tt = a.HISTORIQUEMALADIE.Where(h => h.DATEDEBUT == date);
            if (tt.Count() > 0)
            {
                throw new ArgumentException("ERREUR! On ne peut avoir 2 historiques qui ont la même date de début!");
            }
            var histo = new HISTORIQUEMALADIE() { DATEDEBUT = date };
            //Verif pas de histo avec la MEME date de début, le même ANIMAL pour 1 maladie
            tt = a.HISTORIQUEMALADIE.Where((h) => h.DATEDEBUT == date).Intersect(m.HISTORIQUEMALADIE.Where((h) => h.DATEDEBUT == date));

            if (tt.Count() > 0)
            {
                throw new ArgumentException("ERREUR! La maladie a déjà été déclarée");
            }
            histo.MALADIE.Add(m);
            histo.ANIMAL.Add(a);

            a.HISTORIQUEMALADIE.Add(histo);
            _animalRepository.Update(a);
            _animalRepository.Save();

        }

    }
}
