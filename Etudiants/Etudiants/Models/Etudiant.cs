using Microsoft.AspNetCore.Identity;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Etudiants.Models
{
    //public partial class Etudiant
    //{
    //    public int Id { get; set; }
    //    public string Nom { get; set; }
    //    public string Prenom { get; set; }
    //    public string Cin { get; set; }
    //    public string Adresse { get; set; }
    //}
    public partial class Etudiant : IdentityUser
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CIN { get; set; }
        public string Adresse { get; set; }
    }
}
