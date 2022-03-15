using Microsoft.VisualStudio.TestTools.UnitTesting;
using PT4.Model.dal;

namespace TestProjetVeto
{
    [TestClass]
    public class UnitTest1
    {
        CLIENT clientTest = new CLIENT
        {
            nom = "Test",
            prenom = "Test",
            numero = "Test",
            email = "Test"
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

        [TestMethod]
        public void TestCreerAnimal()
        {
            var req1 = from animal in IAnimalRepository
                       where animal.nomAnimal == animalTest.nomAnimal
                       select animal;

            Assert.AreEqual(req1.Count(), 0); // Test si aucun animal de ce nom dans la base existe d�j�

            CreerAnimal(clientTest, animalTest.nomEspece, animalTest.nomRace, animalTest.nomAnimal, animalTest.dateNaissance, animalTest.taille, animalTest.poids);
            var req2 = from animal in IAnimalRepository
                       where animal.nomAnimal == animal1.nomAnimal
                       select animal;

            Assert.AreEqual(req2.Count(), 1); // Test l'insertion d'un animal dans la base

            foreach (ANIMAL ani in req2)
            {
                Requ�tes.baseMusique.ABONN�S.Remove(ani);
            }
            Requ�tes.baseMusique.SaveChanges();
            _animalRepository.Save();
        }

        [TestMethod]
        public void TestCreerClient()
        {
            var req1 = from client in IClientRepository
                       where client.nom == clientTest.nom
                       select client;

            Assert.AreEqual(req1.Count(), 0); // Test si aucun client dans la base de ce nom existe d�j�

            CreerClient(clientTest.nom, clientTest.prenom, clientTest.numero, clientTest.email);
            var req2 = from client in IClientRepository
                       where client.nomAnimal == clientTest.nomAnimal
                       select client;

            Assert.AreEqual(req2.Count(), 1); // Test l'insertion d'un client dans la base

            foreach (CLIENT cli in req2)
            {
                Requ�tes.baseMusique.ABONN�S.Remove(cli);
            }
            Requ�tes.baseMusique.SaveChanges();
            _animalRepository.Save();
        }

        [TestMethod]
        public void TestCreerRDV()
        {
            var req1 = from rdv in IRendezVousRepository
                       where rdv.dateRdv == rdvTest.dateRdv
                       select rdv;

            Assert.AreEqual(req1.Count(), 0); // Test si aucun rdv dans la base de ce type existe d�j�

            CreerRendezVous(clientTest, rdvTest.dateRdv , rdvTest.raison, rdvTest.finRdv);
            var req2 = from rdv in IRendezVousRepository
                       where rdv.dateRdv == rdvTest.dateRdv
                       select rdv;

            Assert.AreEqual(req2.Count(), 1); // Test l'insertion d'un rendez vous dans la base

            foreach (RENDEZVOUS rdv in req2)
            {
                Requ�tes.baseMusique.ABONN�S.Remove(rdv);
            }
            Requ�tes.baseMusique.SaveChanges();
            _animalRepository.Save();
        }

        [TestMethod]
        public void Test2()
        {

        }




    }
}
