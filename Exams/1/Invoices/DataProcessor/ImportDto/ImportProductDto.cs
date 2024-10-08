﻿using Invoices.Data.Models.Enums;
using Invoices.Data.Models;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(9)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(5.00, 1000.00)]
        public decimal Price { get; set; }

        [Required]
        [EnumDataType(typeof(CategoryType))]
        public CategoryType CategoryType { get; set; }

        public int[] Clients { get; set; }
    }
}
