﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prefeitura.SysCras.Web.ViewModels
{
    public class CargoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(2, ErrorMessage = "O campo {0} deve conter entre {2} e  {1} caracteres.")]
        public string TituloCargo { get; set; }

        [DisplayName("Setor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid SrtorId { get; set; }

        public IEnumerable<ColaboradorViewModel> Colaboradores { get; set; }
    }
}
