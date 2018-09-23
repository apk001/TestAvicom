using System.ComponentModel;

namespace TestAvicom
{
    public class Company : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string contractStatus;

        public event PropertyChangedEventHandler PropertyChanged;

        public Company()
        {

        }

        public Company(string name, string contractStatus)
        {
            this.name = name;
            this.contractStatus = contractStatus;
        }
        
        public int ID
        {
            get { return id; }
            set
            {
                if (id == 0)
                    id = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string ContractStatus
        {
            get { return contractStatus; }
            set
            {
                contractStatus = value;
                OnPropertyChanged("ContractStatus");
            }
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}