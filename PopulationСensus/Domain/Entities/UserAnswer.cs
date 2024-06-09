using System.ComponentModel.DataAnnotations;

namespace PopulationСensus.Domain.Entities
{
    public class UserAnswer : Entity
    {
        //пол
        public bool Gender { get; set; }

        //количество рожденных детей
        public byte? NumberChildrenBorn { get; set; }


        //место рождения
        [StringLength(70)]
        public string PlaceBirth { get; set; } = null!;

        //ваше родной язык
        [StringLength(30)]
        public string NativeLanguage { get; set; } = null!;

        //гражданство
        [StringLength(70)]
        public string Citizenship { get; set; } = null!;

        //национальность
        [StringLength(30)]
        public string Nationality { get; set; } = null!;

        //образование
        [StringLength(25)]
        public string Education { get; set; } = null!;

        // состояние в браке
        [StringLength(70)]
        public string MaritalStatus { get; set; } = null!;

        // количество людей живущих в домохозайстве
        public short? CountPeopleLivingHousehold { get; set; } 

        // Тип жилища
        [StringLength(30)]
        public string TypeOfDwelling { get; set; } = null!;

        // Получаете ли образование
        [StringLength(90)]
        public string GettingEducation { get; set; } = null!;

        // ОСНОВНОЙ источник средств к существованию
        [StringLength(90)]
        public string SourcesOfLiveliHood { get; set; } = null!;

        // Имели ли Вы какую-либо оплачиваемую работу или доходное занятие с 24 по 30 сентября 2020 года?
        public bool HaveWorkedRecently { get; set; } 

        // 19 Кем Вы являлись на основной работе?
        [StringLength(90)]
        public string WhoWereMainJob { get; set; } = null!;
        // Отопление
        [StringLength(80)]
        public string Heating { get; set; } = null!;

        // Водоснабжение
        [StringLength(60)]
        public string WaterSupply { get; set; } = null!;

        // Горячие водоснабжение
        [StringLength(60)]
        public string HotWaterSupply { get; set; } = null!;

        // Водоотведение(канализация)
        [StringLength(60)]
        public string WaterDisposalSewerage { get; set; } = null!;

        // Удаление бытовых отходов
        [StringLength(60)]
        public string DisposalOfHouseholdWaste { get; set; } = null!;

        // Дата
        public DateTime Date { get; set; }

        public List<User> User { get; set; } = null!;


    }
}
