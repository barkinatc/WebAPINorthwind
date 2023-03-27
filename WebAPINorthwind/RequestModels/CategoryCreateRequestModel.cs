using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPINorthwind.RequestModels
{
    // KULLANICI BİR KATEGORİ EKLEMEK İÇİN NASIL BİR VERİ GÖNDERMELİ BUNU TASARLIYORUZ
    public class CategoryCreateRequestModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

    }
}