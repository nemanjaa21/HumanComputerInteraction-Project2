using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NetworkService.ViewModel
{
    public class NetworkEntitiesViewModel : BindableBase
    {
        public static ObservableCollection<Entitie> Entiteti { get; set; }
        public static ICollectionView PrikazEntiteta { get; set; }
        public static List<Model.Type> Tipovi { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand FilterCommand { get; set; }
        public MyICommand HelpCommand { get; set; }
        bool toolTipsBool;

        public bool ToolTipsBool
        {
            get => toolTipsBool;
            set
            {
                toolTipsBool = value;
                MainWindowViewModel.UseToolTips = value;
                OnPropertyChanged("ToolTipsBool");
            }
        }

        Entitie noviEntitet = new Entitie();
        public Entitie NoviEntitet
        {
            get => noviEntitet;
            set
            {
                noviEntitet = value;
                OnPropertyChanged("NoviEntitet");
            }
        }

        Entitie izabran;
        public Entitie Izabran
        {
            get => izabran;
            set
            {
                izabran = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        bool filterL;
        public bool FilterL
        {
            get => filterL;
            set
            {
                if (filterL != value)
                {
                    filterL = value;
                    OnPropertyChanged("FilterL");
                    FilterCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private bool filterM;
        public bool FilterM
        {
            get => filterM;
            set
            {
                if (filterM != value)
                {
                    filterM = value;
                    OnPropertyChanged("FilterM");
                    FilterCommand.RaiseCanExecuteChanged();
                }
            }
        }

        int filterID;
        public int FilterID
        {
            get => filterID;
            set
            {
                filterID = value;
                OnPropertyChanged("FilterID");
                FilterCommand.RaiseCanExecuteChanged();
            }
        }

        string filterIDGreska;
        public string FilterIDGreska
        {
            get => filterIDGreska;
            set
            {
                filterIDGreska = value;
                OnPropertyChanged("FilterIDGreska");
            }
        }

        Model.Type filterTip;
        public Model.Type FilterTip
        {
            get => filterTip;
            set 
            {

                filterTip = value;
                OnPropertyChanged("Tip");
                FilterCommand.RaiseCanExecuteChanged();
            
            }
        
        
        }
        public NetworkEntitiesViewModel()
        {
            if (Entiteti == null)
                Entiteti = new ObservableCollection<Entitie>();
            PrikazEntiteta = CollectionViewSource.GetDefaultView(Entiteti);
            Tipovi = new List<Model.Type> { new Model.Type("iA"), new Model.Type("iB") };

            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            FilterCommand = new MyICommand(OnFilter, CanFilter);
            HelpCommand = new MyICommand(OnHelp);
            FilterID = 1;
            NoviEntitet.Id = 1;
            HelpText = saveHelp;
            ToolTipsBool = MainWindowViewModel.UseToolTips;
        }
        string helpText;
        static string saveHelp = "";
        public string HelpText
        {
            get => helpText;
            set
            {
                helpText = value;
                saveHelp = value;
                OnPropertyChanged("HelpText");
                HelpCommand.RaiseCanExecuteChanged();
            }
        }

        private void OnHelp()
        {
           if (HelpText == string.Empty)
            {
                HelpText = "U koliko vam je potrebna pomoć,prečice su sledeće:" + "\nCTRL+D -> Dodavanje entiteta u listu\nCTRL+TAB -> pomeranje" +
                   " između prozora\nCTRL+F -> Filtracija sa zadatim parametrima\nCTRL+H -> Help \n" +
                    "Za dodavanje novog entiteta potrebno je uneti jedinstveni id, naziv i izabrati " +
                  "kog je tipa entitet. Nakon toga pritisak na dugme \"Add\" ili gestikulacijom CTRL+D " +
                    "se doda u listu entiteta.\nOznačavanjem entiteta u listi i pritiskom na \"Delete\" se ukloni " +
                   "entitet iz liste.\nFiltracija je moguća na 3 načina: samo po tipu, samo po id-u i po tipu i id-u.\n" +
                   "Nakon izabranih parametara filtraciju je moguće pokrenuti na dugme \"Filter\" ili " +
                   "gestikulacijom CTRL+F";
                //HelpText = "BILJANCICA JE DIIIIIIVNAAAA";
            }
            else
            {
               HelpText = string.Empty;
            }
        }

        bool IDLM => FilterIDCheck() && (FilterL || FilterM);
        private bool CanFilter()
        {
            return IDLM || FilterTip != null;
        }

        private void OnFilter()
        {
            if (FilterTip != null)
                PrikazEntiteta.Filter = FilterWithType;
            else
                PrikazEntiteta.Filter = FilterWithoutType;
        }

        private bool FilterWithType(object obj)
        {
            Entitie e = obj as Entitie;
            if (IDLM)
                return (FilterL ? e.Id < FilterID : e.Id > FilterID) && FilterTip.Name == e.Type.Name;
            else
                return FilterTip.Name == e.Type.Name;
        }

        private bool FilterWithoutType(object obj)
        {
            Entitie e = obj as Entitie;
            return FilterL ? e.Id < FilterID : e.Id > FilterID;
        }

        private bool CanDelete()
        {
            return Izabran != null;
        }

        private void OnDelete()
        {    
            NetworkDisplayViewModel.RemoveFromList(Izabran);
            Entiteti.Remove(Izabran);
        }

        private void OnAdd()
        {
            NoviEntitet.Validate();
            if (NoviEntitet.IsValid)
            {
                if (ExistsID(NoviEntitet.Id))
                {
                    NoviEntitet.ValidationErrors["Id"] = "ID exists in list";
                    return;
                }
                Entiteti.Add(new Entitie(NoviEntitet));
                NetworkDisplayViewModel.EntitetList.Add(new Entitie(NoviEntitet));
                
                NoviEntitet.Id++;
            }
        }

        bool ExistsID(int id)
        {
            foreach (Entitie e in Entiteti)
                if (e.Id == id)
                    return true;
            return false;
        }

        bool FilterIDCheck()
        {
            if (FilterID > 0)
                FilterIDGreska = "";
            else
                FilterIDGreska = "ID must be more then 0 and must be number";
            return FilterID > 0;
        }
    }
}
