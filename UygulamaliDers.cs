using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class UygulamaliDers : Ders
    {
        public string LabNo { get; set; }

        public UygulamaliDers() { }
        public UygulamaliDers(string adi, string gun, string saat, string labNo)
            : base(adi, gun, saat)
        {
            LabNo = labNo;
        }

        public override string BilgiVer()
        {
            return base.BilgiVer() + $" (Lab: {LabNo})";
        }
    }


