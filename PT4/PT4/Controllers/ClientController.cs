using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PT4.Model;
using PT4.Model.dal;

namespace PT4.Controllers
{
    public class ClientController
    {
        private IGenericRepository<CLIENT> _clientRepository;
        private IGenericRepository<RENDEZVOUS> _rendezVousRepository;

        /// <summary>
        /// Constructor of the ClientController object
        /// </summary>
        /// <param name="clientRepository">The entity repository of the customers</param>
        public ClientController(IGenericRepository<CLIENT> clientRepository, IGenericRepository<RENDEZVOUS> rendezVousRepository)
        {
            _clientRepository = clientRepository;
            _rendezVousRepository = rendezVousRepository;
        }

        public void SubscribeDeleteCustomers(OnDelete<CLIENT> onDelete)
        {
            _clientRepository.SubscribeDelete(onDelete);
        }

        public void SubscribeCustomers(OnChanged<CLIENT> onChanged)
        {
            _clientRepository.Subscribe(onChanged);
        }

        public void UnSubscribeCustomers(OnChanged<CLIENT> onChanged)
        {
            _clientRepository.UnSubscribe(onChanged);
        }

        public void UnSubscribeCustomers(OnDelete<CLIENT> onDelete)
        {
            _clientRepository.UnSubscribeDelete(onDelete);
        }

        /// <summary>
        /// Creates a customer
        /// </summary>
        /// <param name="nom">Their last name</param>
        /// <param name="prenom">Their first name</param>
        /// <param name="numero">Their phone number (can be null)</param>
        /// <param name="email">Their email (can't be null)</param>
        public void CreerClient(string nom, string prenom, string numero, string email)
        {
            CLIENT client = _clientRepository.FindWhere(c => c.EMAIL == email).FirstOrDefault();
            if (client != null)
            {
                throw new ArgumentException("ERREUR! Cette adresse mail est déjà utilisée!");

            }
            _clientRepository.Insert(new CLIENT
            {
                EMAIL = email,
                NUMERO = numero,
                PRENOMCLIENT = prenom,
                NOMCLIENT = nom
            });

            _clientRepository.Save();

        }

        public IQueryable<CLIENT> ListCustomers()
        {
            return _clientRepository.FindAll();
        }



        public void CreerRendezVous(CLIENT client, DateTime dateRdv, string raison, DateTime finRdv)
        {

            IEnumerable<RENDEZVOUS> jourRdv = _rendezVousRepository.FindWhere(j => j.DATEHEURERDV.Day == dateRdv.Day);
            foreach (RENDEZVOUS rdv in jourRdv)
            {
                TimeSpan durée = rdv.HEUREFINRDV - rdv.DATEHEURERDV;
                if ((dateRdv >= rdv.DATEHEURERDV && dateRdv <= rdv.HEUREFINRDV)
                  || (finRdv >= rdv.DATEHEURERDV && finRdv <= rdv.HEUREFINRDV))
                {
                    throw new Exception("Cet horaire n'est pas disponible.");
                }
            }
            _rendezVousRepository.Insert(new RENDEZVOUS
            {
                CLIENT = client,
                DATEHEURERDV = dateRdv,
                RAISON = raison,
                HEUREFINRDV = finRdv
            });

            _rendezVousRepository.Save();
        }

        public void RemoveByEmail(string email)
        {
            CLIENT c = this.FindByEmail(email);
            if (c is null)
            {
                throw new ArgumentException($"ERREUR! Il n'y a pas de client avec l'email {email}");
            }
            _clientRepository.Delete(c);
            _clientRepository.Save();
        }

        public CLIENT FindByEmail(string email)
        {
            return _clientRepository.FindWhere((cc) => cc.EMAIL == email).FirstOrDefault();
        }
        public Expression<Func<CLIENT, bool>> CreateCriteriasFromForm(RechercheClient rC)
        {
            Expression<Func<CLIENT, bool>> finalExpr = (p) => true;
            TableLayoutPanel table = rC.tableLayoutPanel1;



            //To ensure the order of combinations, I have to first go through all the rows
            for (int i = 0; i < table.RowCount; i++)
            {
                //If we are not at the line where we can insert a new criteria
                if (!(table.GetControlFromPosition(0, i) is Button))
                {
                    string criteria = null;
                    if (table.GetControlFromPosition(1, i) is ComboBox criteriaCb)
                    {
                        criteria = (string)criteriaCb.SelectedItem;
                    }
                    CriteriaCombinationType? combinationType = null;
                    if (table.GetControlFromPosition(0, i) is ComboBox combinationCb)
                    {
                        combinationType = CriteriaCombinationTypeHelper.FromString((string)(combinationCb.SelectedItem));
                    }
                    CriteriaCheckType? checkType = null;
                    if (table.GetControlFromPosition(2, i) is ComboBox checkCb)
                    {
                        checkType = CriteriaCheckTypeHelper.FromString((string)(checkCb.SelectedItem));
                    }

                    object checkObj = null;
                    if (table.GetControlFromPosition(3, i) is TextBox tb)
                    {
                        checkObj = tb.Text;
                    }
                    else if (table.GetControlFromPosition(3, i) is NumericUpDown nud)
                    {
                        checkObj = nud.Value;
                    }
                    switch (criteria)
                    {
                        case "Nom":
                            Utils.CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new StringCriteria((string)checkObj), (c) => c.NOMCLIENT);
                            break;
                        case "Prenom":
                            Utils.CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new StringCriteria((string)checkObj), (c) => c.PRENOMCLIENT);
                            break;
                        case "Email":
                            Utils.CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new StringCriteria((string)checkObj), (c) => c.EMAIL);
                            break;
                        case "Nombre d'animaux":
                            Utils.CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new DecimalCriteria((decimal)checkObj, checkType.Value), (c) => c.NumberOfAnimals);
                            break;
                        case "Nombre de RDV dans le mois":
                            Utils.CreateCriteriaCheckFunc(ref finalExpr, combinationType, () => new DecimalCriteria((decimal)checkObj, checkType.Value), (c) => c.AppointmentOfTheMonth.Count());
                            break;
                    }
                }
            }
            return finalExpr;
        }

    }
}
