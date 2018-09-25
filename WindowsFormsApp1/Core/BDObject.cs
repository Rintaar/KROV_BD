using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krov.Core
{
    //класс Объекта
    public class BDObject
    {
        //необходимые переменные
        //название объекта
        public string name { get; set; }
        //адрес объекта
        public string address { get; set; }
        //тип выполняемых работ
        public string workstype { get; set; }
        //сроки выполнения работ. интовые, для дальнейшего удобства запихивания в БД
        //аукциона
        public DateTime d_auction { get; set; }
        //по договору
        public DateTime d_contract { get; set; }
        //запланированный
        public DateTime d_planned { get; set; }
        //реальный срок
        public DateTime d_real { get; set; }
        //срок оплаты
        public DateTime d_payment { get; set; }
        //адрес изображения объекта
        public string crew { get; set; }
        //адрес изображения объекта
        public string image { get; set; }
        //login менеджера
        public string manager { get; set; }
        //xml работ
        public string workskind { get; set; }
        public string info { get; set; }

        public string crew_list { get; set; }

        public string part_list { get; set; }

        public string parts { get; set; }


        public BDObject(string nname, string naddress, string nworkstype, DateTime nd_auc, DateTime nd_contract, DateTime nd_planned, DateTime nd_real, DateTime nd_payment, string ncrew, string nimage, string man, string works, string _info, string _crew_list, string _part_list, string _parts)
        {
            name = nname;
            address = naddress;
            workstype = nworkstype;
            d_contract = nd_contract;
            d_planned = nd_planned;
            d_real = nd_real;
            d_payment = nd_payment;
            image = nimage;
            crew = ncrew;
            d_auction = nd_auc;
            manager = man;
            workskind = works;
            info = _info;
            crew_list = _crew_list;
            part_list = _part_list;
            parts = _parts;
        }
        public BDObject(string nname, string naddress, string nworkstype, string ncrew, string nimage)
        {
            name = nname;
            address = naddress;
            workstype = nworkstype;
            image = nimage;
            crew = ncrew;
        }
        public BDObject()
        {
            
        }
    }
   
}
