using System.ComponentModel.DataAnnotations;


namespace testeef.Models 
{
    public class Category
    {
        [Key]
        public int id {get;set;}
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60,ErrorMessage="Este campo devee conter entre  3a 60 caracteres")]
        [MinLength(3,ErrorMessage = "Este campo deve conter entre 23 e 60 caracateres")]
        public string Title {get; set;}
    }
}