namespace ChinookSystem.ENTITIES
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    internal partial class Employee
    {
        private string _Title;
        private string _Address;
        private string _City;
        private string _State;
        private string _Country;
        private string _PostalCode;
        private string _Phone;
        private string _Fax;
        private string _Email;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Customers = new HashSet<Customer>();
            Employees1 = new HashSet<Employee>();
        }

        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="Last Name is required.")]
        [StringLength(20, ErrorMessage ="Last Name is limited to 20 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(20, ErrorMessage ="First Name is limited to 20 characters.")]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage = "Title is limited to 30 characters.")]
        public string Title
        {
            get { return _Title; }
            set { _Title = string.IsNullOrEmpty(value) ? null : value; }
        }

        public int? ReportsTo { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }

        [StringLength(70, ErrorMessage ="Address is limited to 70 characters.")]
        public string Address {
            get { return _Address; }
            set { _Address = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40, ErrorMessage ="City is limited to 40 characters.")]
        public string City {
            get { return _City; }
            set { _City = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40, ErrorMessage = "State is limited to 40 characters.")]
        public string State {
            get { return _State; }
            set { _State = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40, ErrorMessage = "Country is limited to 40 characters.")]
        public string Country {
            get { return _Country; }
            set { _Country = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(10, ErrorMessage = "Postal Code is limited to 10 characters.")]
        public string PostalCode {
            get { return _PostalCode; }
            set { _PostalCode = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(24, ErrorMessage = "Phone is limited to 24 characters.")]
        public string Phone {
            get { return _Phone; }
            set { _Phone = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(24, ErrorMessage = "Fax is limited to 24 characters.")]
        public string Fax {
            get { return _Fax; }
            set { _Fax = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(60, ErrorMessage = "Email is limited to 60 characters.")]
        public string Email {
            get { return _Email; }
            set { _Email = string.IsNullOrEmpty(value) ? null : value; }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees1 { get; set; }

        public virtual Employee Employee1 { get; set; }
    }
}
