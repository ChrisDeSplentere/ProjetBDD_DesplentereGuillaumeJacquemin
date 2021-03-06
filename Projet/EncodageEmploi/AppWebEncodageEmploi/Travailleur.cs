//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppWebEncodageEmploi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Travailleur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Travailleur()
        {
            this.Emplois = new HashSet<Emploi>();
        }
    
        public decimal ID { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(40, ErrorMessage = "Le nom est trop long (max 40)")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(40, ErrorMessage = "Le prénom est trop long (max 40)")]
        public string Prenom { get; set; }
        
        public string Sexe { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(40, ErrorMessage = "Le nom de rue est trop long (max 40)")]
        public string NomRueDomicile { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(40, ErrorMessage = "Le numéro est trop long (max 10)")]
        public string NumeroRueDomicile { get; set; }

        [Range(0,99999999, ErrorMessage = "Le numéro doit être compris entre 0 et 99 999 999")]
        public Nullable<decimal> NumDossierMedic { get; set; }
        
        public decimal IDDomicile { get; set; }

        public string NomPrenomId
        {
            get { return Prenom + " " + Nom + " (ID = " + ID + ")"; }
        }
        public int displayID
        {
            get { return (int)ID; }
        }
        public string displayNumDossierMedic
        {
            get { return NumDossierMedic.ToString(); }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emploi> Emplois { get; set; }
        public virtual Localite Localite { get; set; }
    }
}
