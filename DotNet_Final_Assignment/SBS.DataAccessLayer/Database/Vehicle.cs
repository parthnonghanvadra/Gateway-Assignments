//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SBS.DataAccessLayer.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            this.Appointments = new HashSet<Appointment>();
        }
    
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public int ManufacturerId { get; set; }
        public string Model { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public long ChassisNumber { get; set; }
        public int CustomerId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
