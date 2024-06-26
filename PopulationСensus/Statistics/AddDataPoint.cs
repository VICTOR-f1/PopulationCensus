using PopulationСensus.Domain.Entities;

namespace PopulationCensus.Statistics
{
    public class AddDataPoint
    {
        private List<UserAnswer> userAnswer;
        private List<User> user;
        private List<Address> addresses;
        public AddDataPoint(List<UserAnswer> userAnswer, List<User> user, List<Address> addresses)
        {
            this.userAnswer = userAnswer;
            this.user = user;
            this.addresses = addresses;
        }
        private List<DataPoint> CreateListNumberPeoplePassed(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Январь", 0),
                new DataPoint("Февраль", 0),
                new DataPoint("Март", 0),
                new DataPoint("Апрель", 0),
                new DataPoint("Май", 0),
                new DataPoint("Июнь", 0),
                new DataPoint("Июль", 0),
                new DataPoint("Август", 0),
                new DataPoint("Сентабрь", 0),
                new DataPoint("Октябрь", 0),
                new DataPoint("Ноябрь", 0),
                new DataPoint("Декабрь", 0)
            };
            return dataPoints;
        }
        public List<DataPoint> NumberPeoplePassed(List<DataPoint> dataPoints)
        {
            dataPoints = CreateListNumberPeoplePassed(dataPoints);

            foreach (var item in userAnswer)
            {
                int month = item.Date.Month;
                dataPoints[month - 1].Y++;

            }
            return dataPoints;
        }
        public List<DataPoint> RegisteredButNotPass(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Прошли перепись", 0),
                new DataPoint("Только зарегистрировались", 0),
            };

            foreach (var item in user)
            {
                if (item.UserAnswerId != null)
                    dataPoints[0].Y++;
                else
                    dataPoints[1].Y++;
            }
            return dataPoints;
        }
      
        public List<DataPoint> Nationality(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Русский", 0),
                new DataPoint("Украинец", 0),
                new DataPoint("Казах", 0),
                new DataPoint("Таджик", 0),
                new DataPoint("Киргиз", 0)
            };

            foreach (var item in userAnswer)
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    if (item.Nationality == dataPoints[i].Label)
                    {
                        dataPoints[i].Y++;
                        break;
                    }
                }
            }
            dataPoints[0].Label = "Русских";
            dataPoints[1].Label = "Украинецев";
            dataPoints[2].Label = "Казахов";
            dataPoints[3].Label = "Таджиков";
            dataPoints[4].Label = "Киргизов";

            dataPoints = dataPoints.OrderBy(x => x.Y).ToList();
            return dataPoints;
        }
    
        public List<DataPoint> Education(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Общее", 0),
                new DataPoint("Средне профессиональное", -1),
                new DataPoint("Высшеее", -1),
                new DataPoint("Без образования", 2),
            };

            foreach (var item in userAnswer)
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    if (item.Education == dataPoints[i].Label)
                    {
                        dataPoints[i].Y++;
                        break;
                    }
                }
            }
            dataPoints = dataPoints.OrderBy(x => x.Y).ToList();
            return dataPoints;
        }
        public List<DataPoint> Gender(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Количество женщин", 0),
                new DataPoint("Количество мужчин", 0),
            };

            foreach (var item in userAnswer)
            {
                if (item.Gender == true)
                    dataPoints[0].Y++;
                else
                    dataPoints[1].Y++;
            }
            return dataPoints;
        }
        public List<DataPoint> MaritalStatus(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("В зарегистрированном браке", 0),
                new DataPoint("В незарегистрированном супружеском союзе", 0),
                new DataPoint("Офицально разведён(а)", 0),
                new DataPoint("Разошёлся(лась)", 0),
                new DataPoint("Вдовец вдова", 0),
                new DataPoint("Никогда не состоял(а) в браке, супружеском союзе", 0),
            };

            foreach (var item in userAnswer)
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    if (item.MaritalStatus == dataPoints[i].Label)
                    {
                        dataPoints[i].Y++;
                        break;
                    }
                }
            }
            dataPoints = dataPoints.OrderByDescending(x => x.Y).ToList();
            return dataPoints;
        }
        public List<DataPoint> State(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Академический", 0),
                new DataPoint("Верх-Исетский", 0),
                new DataPoint("Железнодорожный", 0),
                new DataPoint("Кировский", 0),
                new DataPoint("Ленинский", 0),
                new DataPoint("Октябрьский", 0),
                new DataPoint("Орджоникидзевский", 0),
                new DataPoint("Чкаловский", 0),

            };

            foreach (var item in addresses)
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {

                    if (item.State == dataPoints[i].Label)
                    {
                        dataPoints[i].Y++;
                        break;
                    }

                }
            }
            dataPoints = dataPoints.OrderByDescending(x => x.Y).ToList();
            return dataPoints;
        }
        public List<DataPoint> GettingEducation(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Не получаю образование", 0),
                new DataPoint("Основные профессиональные программы", 0),
                new DataPoint("Дополнительные образовательные программы", 0),
                new DataPoint("Программы общего образования", 0),
            };

            foreach (var item in userAnswer)
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {

                    if (item.GettingEducation == dataPoints[i].Label)
                    {
                        dataPoints[i].Y++;
                        break;
                    }

                }
            }
            dataPoints = dataPoints.OrderByDescending(x => x.Y).ToList();
            return dataPoints;
        }
        public List<DataPoint> SourcesOfLiveliHood(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Не имею источник средств к существованию", 0),
                new DataPoint("Заработная плата", 0),
                new DataPoint("Предпринимательский доход, самозанятость", 0),
                new DataPoint("Производство товаров для собственного использования", 0),
                new DataPoint("Сдача в аренду имущества", 0),
                new DataPoint("Доход от патентов, авторских прав", 0),
                new DataPoint("Сбережения, дивиденды, проценты, ссуды, реализация капитала", 0),
                new DataPoint("Пенсия (кроме пенсии по инвалидности)", 0),
                new DataPoint("Пенсия по инвалидности", 0),
                new DataPoint("Стипендия", 0),
                new DataPoint("Пособие по безработице", 0),
                new DataPoint("Другие пособия и выппаты от организаций, государства", 0),
                new DataPoint("Льготы, компенсации, субсидии, выигрыши", 0),
                new DataPoint("Обеспечение со стороны других лиц, иждивение иной источник", 0),
                new DataPoint("Иной источник", 0),
            };

            foreach (var item in userAnswer)
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {

                    if (item.SourcesOfLiveliHood == dataPoints[i].Label)
                    {
                        dataPoints[i].Y++;
                        break;
                    }

                }
            }
            dataPoints = dataPoints.OrderByDescending(x => x.Y).ToList();
            dataPoints[0].Label = "Не имею источник...";
            dataPoints[2].Label = "Предпринимательский доход...";
            dataPoints[3].Label = "Производство товаров...";
            dataPoints[8].Label = "Сбережения, дивиденды...";
            return dataPoints;
        }
        public List<DataPoint> WhoWereMainJob(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Работающий по найму", 0),
                new DataPoint("Владелец (совладелец) собственного предприятия (дела)", 0),
                new DataPoint("Индивидуальный предприниматель", 0),
                new DataPoint("Самозанятый", 0),
                new DataPoint("Помогающий на семейном предприятии", 0),
                new DataPoint("Иное", 0)
            };

            foreach (var item in userAnswer)
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    if (item.WhoWereMainJob == dataPoints[i].Label)
                    {
                        dataPoints[i].Y++;
                        break;
                    }
                }
            }
            dataPoints = dataPoints.OrderByDescending(x => x.Y).ToList();
            return dataPoints;
        }

        public List<DataPoint> TypeOfDwelling(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Индивидуальный дом", 0),
                new DataPoint("Общежитие", 0),
                new DataPoint("Отдельная квартира", 0),
                new DataPoint("Гостиница", 0),
                new DataPoint("Коммунальная квартира", 0),
                new DataPoint("Другое жилище", 0),
                new DataPoint("Бездомныйе", 0)
            };

            foreach (var item in userAnswer)
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    if (item.TypeOfDwelling == dataPoints[i].Label)
                    {
                        dataPoints[i].Y++;
                        break;
                    }
                }
            }
            dataPoints = dataPoints.OrderByDescending(x => x.Y).ToList();
            return dataPoints;
        }
        public List<DataPoint> Heating(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Централизованное", 0),
                new DataPoint("От индивидуальных установок, котлов", 0),
                new DataPoint("Печное", 0),
            };

            foreach (var item in userAnswer)
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    if (item.Heating == dataPoints[i].Label)
                    {
                        dataPoints[i].Y++;
                        break;
                    }
                }
            }
            dataPoints = dataPoints.OrderByDescending(x => x.Y).ToList();
            return dataPoints;
        }
        public List<DataPoint> WaterSupply(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Централизонаннам система холодного водоснабжения", 0),
                new DataPoint("Индивидуальная система водоснабжения", 0),
                new DataPoint("Водоснабжение вне жилица, колонка", 0),
                new DataPoint("Колодец, скважина или другой источник водоснабжения", 0),
            };

            foreach (var item in userAnswer)
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    if (item.WaterSupply == dataPoints[i].Label)
                    {
                        dataPoints[i].Y++;
                        break;
                    }
                }
            }
            dataPoints = dataPoints.OrderByDescending(x => x.Y).ToList();
            return dataPoints;
        }
        public List<DataPoint> HotWaterSupply(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Централизованное", 0),
                new DataPoint("От индивидуальных водонагревателей", 0),
                new DataPoint("Горячее водоснабжение отсутствует", 0),
            };

            foreach (var item in userAnswer)
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    if (item.HotWaterSupply == dataPoints[i].Label)
                    {
                        dataPoints[i].Y++;
                        break;
                    }
                }
            }
            dataPoints = dataPoints.OrderByDescending(x => x.Y).ToList();
            return dataPoints;
        }
        public List<DataPoint> WaterDisposalSewerage(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Централизованная система", 0),
                new DataPoint("Индивидуальная система (включая септик)", 0),
                new DataPoint("Через систему труб выгребные ямы и т.п.", 0),
                new DataPoint("Водоотведение (канализация) отсутствует", 0)
            };

            foreach (var item in userAnswer)
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    if (item.WaterDisposalSewerage == dataPoints[i].Label)
                    {
                        dataPoints[i].Y++;
                        break;
                    }
                }
            }
            dataPoints = dataPoints.OrderByDescending(x => x.Y).ToList();
            return dataPoints;
        }
        public List<DataPoint> DisposalOfHouseholdWaste(List<DataPoint> dataPoints)
        {
            dataPoints = new List<DataPoint>
            {
                new DataPoint("Мусоропровод", 0),
                new DataPoint("Мусоросборники вне дома", 0),
                new DataPoint("Сбор мусора спецмашиной", 0),
                new DataPoint("Выброс мусора в ямы, на кучи и т.п.", 0)
            };

            foreach (var item in userAnswer)
            {
                for (int i = 0; i < dataPoints.Count; i++)
                {
                    if (item.DisposalOfHouseholdWaste == dataPoints[i].Label)
                    {
                        dataPoints[i].Y++;
                        break;
                    }
                }
            }
            dataPoints = dataPoints.OrderByDescending(x => x.Y).ToList();
            return dataPoints;
        }
    }
}
