using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PT4;
using PT4.Model.dal;
using PT4.Controllers;
using System.Linq;

namespace TestProjetVeto
{
    [TestClass]
    public class TestAnimal
    {

        private IGenericRepository<ANIMAL> _animalRepo;
        private IGenericRepository<CLIENT> _clientRepo;
        private AnimalController _animalController;

        CLIENT clientTest = new CLIENT
        {
            NOMCLIENT = "Test",
            PRENOMCLIENT = "Test",
            NUMERO = "Test",
            EMAIL = "Test"
        };

        ANIMAL animalTest = new ANIMAL
        {
            client = clientTest,
            nomEspece = "chat",
            nomRace = "tigre",
            nomAnimal = "Test",
            dateNaissance = 10 / 03 / 2009,
            taille = 18,
            poids = 7
        };

        RENDEZVOUS rdvTest = new RENDEZVOUS
        {
            client = clientTest,
            dateRdv = 10/03/2050 10:00:00,
            raison = "Mon chat ne veut plus manger",
            finRdv = 10/03/2050 10:30:00
        });

        [TestInitialize]
        public void TestInitialize()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<PT4_PLANNIMAUX_S4p2B_JKVBLBEntities>()
                    .AddSingleton<IGenericRepository<ANIMAL>, AnimalRepository>()
                    .AddSingleton<IGenericRepository<CLIENT>, ClientRepository>()
                    .AddSingleton<AnimalController>()
                    .AddSingleton<ClientController>()
            ;
            services.AddSingleton(services);

            using(ServiceProvider provider = services.BuildServiceProvider())
            {
                _animalRepo = provider.GetRequiredService<IGenericRepository<ANIMAL>>();
                _clientRepo = provider.GetRequiredService<IGenericRepository<CLIENT>>();
                _animalController = provider.GetRequiredService<AnimalController>();
            }
        }

        [TestMethod]
        public void TestCreerAnimal()
        {
            var req1 = from animal in _animalRepo.FindAll()
                       where animal.NOMANIMAL == animalTest.NOMANIMAL
                       select animal;

            var testFindWhere = _animalRepo.FindWhere((a) => a.NOMANIMAL == animalTest.NOMANIMAL);

            Assert.AreEqual(req1.Count(), 0); // Test si aucun animal de ce nom dans la base existe déjà

            _animalController.CreerAnimal(clientTest, animalTest.nomEspece, animalTest.nomRace, animalTest.nomAnimal, animalTest.dateNaissance, animalTest.taille, animalTest.poids);
            var req2 = from animal in IAnimalRepository
                       where animal.nomAnimal == animal1.nomAnimal
                       select animal;

            Assert.AreEqual(req2.Count(), 1); // Test l'insertion d'un animal dans la base

            

            foreach (ANIMAL ani in req2)
            {
                _animalRepo.Delete(ani.IDANIMAL);
            }
            _animalRepo.Save();
        }

        [TestMethod]
        public void TestCreerClient()
        {
            var req1 = from client in IClientRepository
                       where client.nom == clientTest.nom
                       select client;

            Assert.AreEqual(req1.Count(), 0); // Test si aucun client dans la base de ce nom existe déjà

            CreerClient(clientTest.nom, clientTest.prenom, clientTest.numero, clientTest.email);
            var req2 = from client in IClientRepository
                       where client.nomAnimal == clientTest.nomAnimal
                       select client;

            Assert.AreEqual(req2.Count(), 1); // Test l'insertion d'un client dans la base

            foreach (CLIENT cli in req2)
            {
                Requêtes.baseMusique.ABONNÉS.Remove(cli);
            }
            Requêtes.baseMusique.SaveChanges();
            _animalRepository.Save();
        }

        [TestMethod]
        public void TestCreerRDV()
        {
            var req1 = from rdv in IRendezVousRepository
                       where rdv.dateRdv == rdvTest.dateRdv
                       select rdv;

            Assert.AreEqual(req1.Count(), 0); // Test si aucun rdv dans la base de ce type existe déjà

            CreerRendezVous(clientTest, rdvTest.dateRdv , rdvTest.raison, rdvTest.finRdv);
            var req2 = from rdv in IRendezVousRepository
                       where rdv.dateRdv == rdvTest.dateRdv
                       select rdv;

            Assert.AreEqual(req2.Count(), 1); // Test l'insertion d'un rendez vous dans la base

            foreach (RENDEZVOUS rdv in req2)
            {
                Requêtes.baseMusique.ABONNÉS.Remove(rdv);
            }
            Requêtes.baseMusique.SaveChanges();
            _animalRepository.Save();
        }

        [TestMethod]
        public void Test2()
        {

        }




    }
}
