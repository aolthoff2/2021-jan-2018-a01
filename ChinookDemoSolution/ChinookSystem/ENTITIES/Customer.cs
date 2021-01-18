namespace ChinookSystem.ENTITIES
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    internal partial class Customer
    {
        private string _Company;
        private string _Address;
        private string _City;
        private string _State;
        private string _Country;
        private string _PostalCode;
        private string _Phone;
        private string _Fax;
        private string _Email;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int CustomerId { get; set; }

        [Required(ErrorMessage ="First Name is required.")]
        [StringLength(40, ErrorMessage ="First Name is limited to 40 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name is required.")]
        [StringLength(20, ErrorMessage ="Last Name is limited to 20 characters.")]
        public string LastName { get; set; }

        [StringLength(80)]
        public string Company {
            get { return _Company; }
            set { _Company = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(70)]
        public string Address {
            get { return _Address; }
            set { _Address = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40)]
        public string City {
            get { return _City; }
            set { _City = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40)]
        public string State {
            get { return _State; }
            set { _State = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40)]
        public string Country {
            get { return _Country; }
            set { _Country = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(10)]
        public string PostalCode {
            get { return _PostalCode; }
            set { _PostalCode = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(24)]
        public string Phone {
            get { return _Phone; }
            set { _Phone = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(24)]
        public string Fax {
            get { return _Fax; }
            set { _Fax = string.IsNullOrEmpty(value) ? null : value; }
        }

        [Required]
        [StringLength(60)]
        public string Email {
            get { return _Email; }
            set { _Email = string.IsNullOrEmpty(value) ? null : value; }
        }

        public int? SupportRepId { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
