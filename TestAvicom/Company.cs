using System.ComponentModel;

namespace TestAvicom
{
    /// <summary>
    /// Модель Компании
    /// </summary>
    public class Company : INotifyPropertyChanged
    {

        /// <summary>
        /// Идентификатор Компании
        /// </summary>
        private int id;

        /// <summary>
        /// Название Компании
        /// </summary>
        private string name;

        /// <summary>
        /// Статус контракта Компании
        /// </summary>
        private string contractStatus;

        /// <summary>
        /// Событие при обновлении значений свойств
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public Company()
        {

        }

        /// <summary>
        /// Конструктор для создания новых объектов БД
        /// </summary>
        /// <param name="name">Название Компании</param>
        /// <param name="contractStatus">Статус контракта</param>
        public Company(string name, string contractStatus)
        {
            this.name = name;
            this.contractStatus = contractStatus;
        }
        
        /// <summary>
        /// Задает или возвращает значение идентификатора Компании
        /// </summary>
        public int ID
        {
            get { return id; }
            set
            {
                if (id == 0)
                    id = value;
            }
        }

        /// <summary>
        /// Задает или возвращает название Компании
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Задает или возвращает значение статуса конктракта Компании
        /// </summary>
        public string ContractStatus
        {
            get { return contractStatus; }
            set
            {
                contractStatus = value;
                OnPropertyChanged("ContractStatus");
            }
        }

        /// <summary>
        /// Вызов события
        /// </summary>
        /// <param name="property">Имя свойства</param>
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}