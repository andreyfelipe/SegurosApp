using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegurosApp.Models
{
    public class Seguro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O número da apólice é obrigatório.")]
        [StringLength(30)]
        [Display(Name = "Número da Apólice")]
        public string NumeroApolice { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo é obrigatório.")]
        [Display(Name = "Tipo de Seguro")]
        public String Tipo { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public String Status { get; set; } = string.Empty;

        [Required(ErrorMessage = "O valor do prêmio é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Prêmio Mensal (R$)")]
        public decimal PremioMensal { get; set; }

        [Required(ErrorMessage = "O valor segurado é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Valor Segurado (R$)")]
        public decimal ValorSegurado { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Início da Vigência")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de vencimento é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fim da Vigência")]
        public DateTime DataVencimento { get; set; }

        [StringLength(500)]
        [Display(Name = "Observações")]
        public string Observacoes { get; set; } = string.Empty;

        [Required(ErrorMessage = "A seguradora é obrigatória.")]
        [Display(Name = "Seguradora")]
        public int SeguradoraId { get; set; }
        public Seguradora? Seguradora { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatório.")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

    }
}
