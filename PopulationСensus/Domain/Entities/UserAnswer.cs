using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace PopulationСensus.Domain.Entities
{
    public class UserAnswer : Entity
    {
        public User User { get; set; }
        //пол
        public bool Gender { get; set; }
        //количество рожденных детей
        public byte? NumberChildrenBorn { get; set; }
        //год рождения первого ребёнка
        public short? YearBirthFirstChild { get; set; }
        //место рождения
        [StringLength(70)]
        public string PlaceBirth { get; set; } = null!;
        //жили ли вы в других странах
        public bool LivedOtherCountries { get; set; }
        //где вы жили до прибытия(возвращение) в РФ
        [StringLength(70)]
        public string? WhereLiveBeforeArriving { get; set; } = null!;
        //год прибытия(возвращение) в РФ
        public short? YearArrival { get; set; }
        // говорите по русски?
        public bool SpeakRussian { get; set; }
        //используете его в повсденевной жизни?
        public bool UseRussianInConversation { get; set; }
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
        //есть учённая степень
        public bool HaveDegree { get; set; }
        //умеете писать и читать 
        public bool CanReadAndWrite { get; set; }
        // состояние в браке
        [StringLength(70)]
        public string MaritalStatus { get; set; } = null!;

		// Дата
		public DateTime Date { get; set; }
	}
}
