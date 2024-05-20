using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodenBox
{
    public static class InformationAboutBox
    {
        public static List<ValueBox> ValueBox = new List<ValueBox>();
        public static List<ValueBoxForReport> ValueBoxForReport = new List<ValueBoxForReport>();
        public static List<ForReport> ForReport = new List<ForReport>();
    }
    public class ValueBox
    {
        public double TypeBox { get; set; }

        public string cap { get; set; } // размер крышкы
        public string masscap { get; set; } //масса крышки
        public string before { get; set; } //торцевой щит размер
        public string massbefore { get; set; } //торцевой щит масса
        public string side { get; set; } //боковой щит размер 
        public string massside { get; set; } //боковой щит масса 
        public string around1 { get; set; } //планка пояса - верхняя
        public string massaround1 { get; set; } //планка пояса - верхняя
        public string around2 { get; set; } //планка пояса - боковая
        public string massaround2 { get; set; } //планка пояса - боковая
        public string front1 { get; set; } //планка торцевого щита - вертикальная
        public string massfront1 { get; set; } //планка торцевого щита - вертикальная
        public string front2 { get; set; } //планка торцевого щита - горизонтальная
        public string massfront2 { get; set; } //планка торцевого щита - горизонтальная
        public double colNails { get; set; } // количество гвоздей
        public double lengthTape { get; set; } // длина мет ленты
    }

    public class ValueBoxForReport
    {
        public double col_cap { get; set; }
        public double w_cap { get; set; }
        public double col_side { get; set; }
        public double w_side { get; set; }
        public double heightBoard { get; set; }
        public double lenghtBox { get; set; }
        public double gap { get; set; }

    }

    public class ForReport
    {
        public string massNails { get; set; }
        public string nameNails { get; set; }
        public string nameTape { get; set; }
        public string lenghtTape { get; set; }

        public string gostNails { get; set; }
        public string gostTape { get; set; }
        public string gostWood { get; set; }
        public string wood { get; set; }

    }

    }
