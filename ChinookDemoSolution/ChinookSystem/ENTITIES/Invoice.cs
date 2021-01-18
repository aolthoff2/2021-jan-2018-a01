namespace ChinookSystem.ENTITIES
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    internal partial class Invoice
    {
        private string _BillingAddress;
        private string _BillingCity;
        private string _BillingState;
        private string _BillingCountry;
        private string _BillingPostalCode;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
        }

        public int InvoiceId { get; set; }

        public int CustomerId { get; set; }

        public DateTime InvoiceDate { get; set; }

        [StringLength(70, ErrorMessage = "Billing Address is limited to 70 characters.")]
        public string BillingAddress
        {
            get { return _BillingAddress; }
            set { _BillingAddress = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40, ErrorMessage = "Billing City is limited to 40 characters.")]
        public string BillingCity {
            get { return _BillingCity; }
            set { _BillingCity = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40, ErrorMessage = "Billing State is limited to 40 characters.")]
        public string BillingState {
            get { return _BillingState; }
            set { _BillingState = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40, ErrorMessage = "Billing Country is limited to 40 characters.")]
        public string BillingCountry {
            get { return _BillingCountry; }
            set { _BillingCountry = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(10, ErrorMessage = "Billing Postal Code is limited to 10 characters.")]
        public string BillingPostalCode {
            get { return _BillingPostalCode; }
            set { _BillingPostalCode = string.IsNullOrEmpty(value) ? null : value; }
        }

        [Column(TypeName = "numeric")]
        public decimal Total { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
