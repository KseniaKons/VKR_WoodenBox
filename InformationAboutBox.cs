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
        public string cap { get; set; } 
        public string masscap { get; set; } 
        public string before { get; set; } 
        public string massbefore { get; set; } 
        public string side { get; set; }  
        public string massside { get; set; } 
        public string around1 { get; set; } 
        public string massaround1 { get; set; } 
        public string around2 { get; set; } 
        public string massaround2 { get; set; } 
        public string front1 { get; set; } 
        public string massfront1 { get; set; } 
        public string front2 { get; set; }
        public string massfront2 { get; set; } 
        public double colNails { get; set; } 
        public double lengthTape { get; set; }
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
