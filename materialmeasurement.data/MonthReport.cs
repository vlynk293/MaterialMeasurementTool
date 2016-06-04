//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaterialMeasurement.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class MonthReport
    {
        public long ID { get; set; }
        public long MaterialId { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public double RemainQuantity { get; set; }
        public double ImportQuantity { get; set; }
        public double ExportQuantity { get; set; }
        public string WeightUnit { get; set; }
        public System.DateTime ReportDate { get; set; }
        public string ParcelCode { get; set; }
    
        public virtual Material Material { get; set; }
    }
}