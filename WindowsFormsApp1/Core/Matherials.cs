using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Core
{
    public class Matherials
    {
        public string code { get; set; }
        public string name { get; set; }
        public string mat_measure { get; set; }
        public string mat_price { get; set; }
        public string measure { get; set; }
        public string mat_for_one { get; set; }
        public string full_price { get; set; }
        public string work_price { get; set; }
        public string measure_name { get; set; }
        public Matherials()
        { }
        public Matherials(string _code, string _name, string _mat_measure, string _mat_price, string _measure, string _mat_for_one, string _full_price, string mes_name)
        {
            code = _code;
            name = _name;
            mat_measure = _mat_measure;
            mat_price = _mat_price;
            measure = _measure;
            mat_for_one = _mat_for_one;
            full_price = _full_price;
            measure_name = mes_name;
        }
        //public Matherials(string _code, string _name, string _mat_measure, string _mat_price, string _measure, string _mat_for_one, string _full_price, string _work_price)
        //{
        //    code = _code;
        //    name = _name;
        //    mat_measure = _mat_measure;
        //    mat_price = _mat_price;
        //    measure = _measure;
        //    mat_for_one = _mat_for_one;
        //    full_price = _full_price;
        //    work_price = _work_price;
        //}
    }
}
