using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MIS333KProject.Models
{
    public enum StkType { Ordinary, ETF, Futures, Mutual_Fund, Index_Fund }
    public class Stock
    {
        [Display(Name = "Ticker Symbol")]
        public string TickerSymbol { get; set; }

        [Required(ErrorMessage = "Stock type is required.")]
        [EnumDataType(typeof(StkType))]
        [Display(Name = "Stock Type")]
        public StkType StockType { get; set; }

        [Required(ErrorMessage = "Stock Name is required.")]
        [Display(Name = "Stock Name")]
        public string StockName { get; set; }

        [Display(Name = "Stock Price")]
        public Decimal StockPrice { get; set; }

        [Display(Name = "Stock Fee")]
        public Decimal StockFee { get; set; }
    }
}