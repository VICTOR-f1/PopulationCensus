using PopulationСensus.Domain.Entities;

namespace PopulationCensus.Statistics
{
    public class AddDataPoint
    {
        //private List<UserAnswer> userAnswer;
        //private List<User> user;
        //private List<Address> addresses;
        //public AddDataPoint(List<UserAnswer> userAnswer, List<User> user, List<Address> addresses)
        //{
        //    this.userAnswer = userAnswer;
        //    this.user = user;
        //    this.addresses = addresses;
        //}
        //private List<DataPoint> CreateListNumberPeoplePassed(List<DataPoint> dataPoints)
        //{
        //    dataPoints = new List<DataPoint>
        //    {
        //        new DataPoint("Январь", 0),
        //        new DataPoint("Февраль", 0),
        //        new DataPoint("Март", 0),
        //        new DataPoint("Апрель", 0),
        //        new DataPoint("Май", 0),
        //        new DataPoint("Июнь", 0),
        //        new DataPoint("Июль", 0),
        //        new DataPoint("Август", 0),
        //        new DataPoint("Сентабрь", 0),
        //        new DataPoint("Октябрь", 0),
        //        new DataPoint("Ноябрь", 0),
        //        new DataPoint("Декабрь", 0)
        //    };
        //    return dataPoints;
        //}
        //public List<DataPoint> NumberPeoplePassed(List<DataPoint> dataPoints)
        //{
        //    dataPoints = CreateListNumberPeoplePassed(dataPoints);

        //    foreach (var item in userAnswer)
        //    {
        //        int month = item.Date.Month;
        //        dataPoints[month - 1].Y++;

        //    }
        //    return dataPoints;
        //}
        //public List<DataPoint> RegisteredButNotPass(List<DataPoint> dataPoints)
        //{
        //    dataPoints = new List<DataPoint>
        //    {
        //        new DataPoint("Прошли перепись", 0),
        //        new DataPoint("Только зарегистрировались", 0),
        //    };

        //    foreach (var item in user)
        //    {
        //        if (item.UserAnswerId != null)
        //            dataPoints[0].Y++;
        //        else
        //            dataPoints[1].Y++;
        //    }
        //    return dataPoints;
        //}
        //public List<DataPoint> CanWriteAndRead(List<DataPoint> dataPoints)
        //{
        //    dataPoints = new List<DataPoint>
        //    {
        //        new DataPoint("Умеют читать и писать", 0),
        //        new DataPoint("Не умеют читать и писать", 0),
        //    };

        //    foreach (var item in userAnswer)
        //    {
        //        if (item.CanReadAndWrite == true)
        //            dataPoints[0].Y++;
        //        else
        //            dataPoints[1].Y++;
        //    }
        //    return dataPoints;
        //}
        //public List<DataPoint> HaveDegree(List<DataPoint> dataPoints)
        //{
        //    dataPoints = new List<DataPoint>
        //    {
        //        new DataPoint("Имеют учённую степень", 0),
        //        new DataPoint("Не имеют учённую степень", 0),
        //    };

        //    foreach (var item in userAnswer)
        //    {
        //        if (item.HaveDegree == true)
        //            dataPoints[0].Y++;
        //        else
        //            dataPoints[1].Y++;
        //    }
        //    return dataPoints;
        //}
        //public List<DataPoint> Nationality(List<DataPoint> dataPoints)
        //{
        //    dataPoints = new List<DataPoint>
        //    {
        //        new DataPoint("Русский", 0),
        //        new DataPoint("Украинец", 0),
        //        new DataPoint("Казах", 0),
        //        new DataPoint("Таджик", 0),
        //        new DataPoint("Киргиз", 0)
        //    };

        //    foreach (var item in userAnswer)
        //    {
        //        for (int i = 0; i < dataPoints.Count; i++)
        //        {
        //            if (item.Nationality == dataPoints[i].Label)
        //            {
        //                dataPoints[i].Y++;
        //                break;
        //            }
        //        }
        //    }
        //    dataPoints[0].Label = "Русских";
        //    dataPoints[1].Label = "Украинецев";
        //    dataPoints[2].Label = "Казахов";
        //    dataPoints[3].Label = "Таджиков";
        //    dataPoints[4].Label = "Киргизов";

        //    dataPoints = dataPoints.OrderBy(x => x.Y).ToList();
        //    return dataPoints;
        //}
        //public List<DataPoint> LivedOtherCountries(List<DataPoint> dataPoints)
        //{
        //    dataPoints = new List<DataPoint>
        //    {
        //        new DataPoint("Количество людей которые жили в других странах более года", 0),
        //        new DataPoint("Количество людей которые не жили в других странах более года", 0),
        //    };

        //    foreach (var item in userAnswer)
        //    {
        //        if (item.LivedOtherCountries == true)
        //            dataPoints[0].Y++;
        //        else
        //            dataPoints[1].Y++;
        //    }
        //    return dataPoints;
        //}
        //public List<DataPoint> WhereLiveBeforeArriving(List<DataPoint> dataPoints)
        //{
        //    dataPoints = new List<DataPoint>
        //    {
        //        new DataPoint("Таджикистан", 0),
        //        new DataPoint("Киргизия", 0),
        //        new DataPoint("Азербайджан", 0),
        //        new DataPoint("Украина", 0),
        //        new DataPoint("Казахстан", 0)
        //    };

        //    foreach (var item in userAnswer)
        //    {
        //        for (int i = 0; i < dataPoints.Count; i++)
        //        {
        //            if (item.WhereLiveBeforeArriving == dataPoints[i].Label)
        //            {
        //                dataPoints[i].Y++;
        //                break;
        //            }
        //        }
        //    }
        //    dataPoints[0].Label = "Таджикистане";
        //    dataPoints[1].Label = "Киргизиее";
        //    dataPoints[2].Label = "Азербайджан";
        //    dataPoints[3].Label = "Украине";
        //    dataPoints[4].Label = "Казахстане";
        //    dataPoints = dataPoints.OrderBy(x => x.Y).ToList();
        //    return dataPoints;
        //}
        //public List<DataPoint> Education(List<DataPoint> dataPoints)
        //{
        //    dataPoints = new List<DataPoint>
        //    {
        //        new DataPoint("Общее", 0),
        //        new DataPoint("Средне профессиональное", -1),
        //        new DataPoint("Высшеее", -1),
        //        new DataPoint("Без образования", 2),
        //    };

        //    foreach (var item in userAnswer)
        //    {
        //        for (int i = 0; i < dataPoints.Count; i++)
        //        {
        //            if (item.Education == dataPoints[i].Label)
        //            {
        //                dataPoints[i].Y++;
        //                break;
        //            }
        //        }
        //    }
        //    return dataPoints;
        //}
        //public List<DataPoint> Gender(List<DataPoint> dataPoints)
        //{
        //    dataPoints = new List<DataPoint>
        //    {
        //        new DataPoint("Количество женщин", 0),
        //        new DataPoint("Количество мужчин", 0),
        //    };

        //    foreach (var item in userAnswer)
        //    {
        //        if (item.Gender == true)
        //            dataPoints[0].Y++;
        //        else
        //            dataPoints[1].Y++;
        //    }
        //    return dataPoints;
        //}
        //public List<DataPoint> MaritalStatus(List<DataPoint> dataPoints)
        //{
        //    dataPoints = new List<DataPoint>
        //    {
        //        new DataPoint("В зарегистрированном браке", 0),
        //        new DataPoint("В незарегистрированном супружеском союзе", 0),
        //        new DataPoint("Офицально разведён(а)", 0),
        //        new DataPoint("Разошёлся(лась)", 0),
        //        new DataPoint("Вдовец вдова", 0),
        //        new DataPoint("Никогда не состоял(а) в браке, супружеском союзе", 0),
        //    };

        //    foreach (var item in userAnswer)
        //    {
        //        for (int i = 0; i < dataPoints.Count; i++)
        //        {
        //            if (item.MaritalStatus == dataPoints[i].Label)
        //            {
        //                dataPoints[i].Y++;
        //                break;
        //            }
        //        }
        //    }
        //    dataPoints = dataPoints.OrderByDescending(x => x.Y).ToList();
        //    return dataPoints;
        //}
        //public List<DataPoint> State(List<DataPoint> dataPoints)
        //{
        //    dataPoints = new List<DataPoint>
        //    {
        //        new DataPoint("Академический", 0),
        //        new DataPoint("Верх-Исетский", 0),
        //        new DataPoint("Железнодорожный", 0),
        //        new DataPoint("Кировский", 0),
        //        new DataPoint("Ленинский", 0),
        //        new DataPoint("Октябрьский", 0),
        //        new DataPoint("Орджоникидзевский", 0),
        //        new DataPoint("Чкаловский", 0),

        //    };

        //    foreach (var item in addresses)
        //    {
        //        for (int i = 0; i < dataPoints.Count; i++)
        //        {

        //            if (item.State == dataPoints[i].Label)
        //            {
        //                dataPoints[i].Y++;
        //                break;
        //            }

        //        }
        //    }
        //    dataPoints = dataPoints.OrderByDescending(x=>x.Y).ToList();
        //    return dataPoints;
        //}
    }
}
