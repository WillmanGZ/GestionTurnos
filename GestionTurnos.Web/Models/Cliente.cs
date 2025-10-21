using System.ComponentModel.DataAnnotations;


namespace GestionTurnos.Web.Models
{
    //public class Cliente
    //{
    //    public int Id { get; set; } // EF lo toma como clave primaria por convención
    //    public string Nombre { get; set; } // Los demas tipos de atributos los traduce a tipos SQL como varchar, integer, etc.
    //}

    public class Cliente
    {
        [Key] // Automaticamente lo hace autoincremental
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] Esto lo hace autoincremental pero manualmente
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(255, ErrorMessage = "El nombre solo puede contener 255 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage ="Formato de correo inválido")]
        public string Correo { get; set; }

        // Si no se crea el constructor, EF crea automaticamente un constructor vacio
    }
}
