using System.ComponentModel.DataAnnotations;

namespace GestionTurnos.Web.Data.Entities
{
    public class Afiliado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre solo puede tener maximo 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El documento es obligatorio")]
        [MaxLength(15, ErrorMessage = "El documento solo puede tener maximo 15 caracteres")]
         public string Documento { get; set; }

        [Required(ErrorMessage = "El sexo es obligatorio")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [MaxLength(20, ErrorMessage = "El teléfono solo puede tener maximo 15 caracteres")]
        [MinLength(10, ErrorMessage = "El teléfono debe tener minimo 10 caracteres")]
        public string Telefono { get; set; }

        public string FotoUrl { get; set; } = string.Empty;
    }
}
