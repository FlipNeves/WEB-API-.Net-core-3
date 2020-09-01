using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Cliente
    {

        //Dados do Objeto Cliente mapeados para o BadRequest
        [Key]
        public int ID { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(40, ErrorMessage = "O Nome deve ter até 40 caracteres")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(11, ErrorMessage = "O CPF deve conter 11 caracteres. Modelo : xxx xxx xxx xx")]
        [MinLength(11, ErrorMessage = "O CPF deve conter 11 caracteres. Modelo : xxx xxx xxx xx")]
        public string CPF { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(2, ErrorMessage = "As UF contém 2 caracteres")]
        [MinLength(2, ErrorMessage = "As UF contém 2 caracteres")]
        public string UF { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(10, ErrorMessage = "Siga o modelo: dd/mm/yyyy")]
        [MinLength(10, ErrorMessage = "Siga o modelo: dd/mm/yyyy")]
        public string Data { get; set; }



    }
}
