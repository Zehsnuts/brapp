using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class HourDateDay : MonoBehaviour {

    public Text hour, date, weekDay;

    private enum monthName
    {
        Janeiro, Fevereiro,Março, Abril, Maio, Junho, Julho, Agosto, Setembro, Outubro, Novembro, Dezembro
    }

 	void Start () 
	{
        var today = System.DateTime.Now;

        date.text = today.ToString("dd")+" de " + MonthNumberToName(today.ToString("MM")) + " de " + today.ToString("yyyy");

        weekDay.text = WeekDaysTranslated(today.DayOfWeek.ToString());
    }

    string  MonthNumberToName(string month)
    {
        switch (month)
        {
            case "01":
               return monthName.Janeiro.ToString();
            case "02":
                return monthName.Fevereiro.ToString();
            case "03":
                return monthName.Março.ToString();
            case "04":
                return monthName.Abril.ToString();
            case "05":
                return monthName.Maio.ToString();
            case "06":
                return monthName.Junho.ToString();
            case "07":
                return monthName.Julho.ToString();
            case "08":
                return monthName.Agosto.ToString();
            case "09":
                return monthName.Setembro.ToString();
            case "10":
                return monthName.Outubro.ToString();
            case "11":
                return monthName.Novembro.ToString();
            case "12":
                return monthName.Dezembro.ToString();
            default:
                return "";
        }
    }

    string WeekDaysTranslated(string weekD)
    {
        string day = "";

        switch (weekD)
        {
            case "Monday":
                day = "Segunda-Feira";
                break;
            case "Tuesday":
                day = "Terça-Feira";
                break;
            case "Wednesday":
                day = "Quarta-Feira";
                break;
            case "Thursday":
                day = "Quinta-Feira";
                break;
            case "Friday":
                day = "Sexta-Feira";
                break;
            case "Saturday":
                day = "Sábado";
                break;
            case "Sunday":
                day = "Domingo";
                break;
            default:
                break;
        }



        return day;
    }
	
	void Update ()
	{
        var today = System.DateTime.Now;
        hour.text = today.ToString("HH:mm");
	}
}
