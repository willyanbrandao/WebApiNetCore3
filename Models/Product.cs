using System.ComponentModel.DataAnnotations;

namespace testeef.Models 
{
    public class Product
    {
        [Key]
        public int id {get;set;}
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60,ErrorMessage="Este campo devee conter entre  3a 60 caracteres")]
        [MinLength(3,ErrorMessage = "Este campo deve conter entre 3 e 60 caracateres")]
        public string Title {get; set;}

        [MaxLength(1024,ErrorMessage = "Este campo deve conter no máximo 1024 caraacteres")]
        public string Description {get;set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Prince{get;set;}

        [Required(ErrorMessage = "Este campo é obrigatório ")]
        [Range(1,int.MaxValue, ErrorMessage = "Categoria Inválida")]
        public int CategoryId {get;set;}
        public Category Catergory {get;set;}


    }
}