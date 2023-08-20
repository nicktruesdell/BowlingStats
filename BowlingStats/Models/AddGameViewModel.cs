using Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BowlingStats.Models
{
    public class AddGameViewModel
    {
        private string _dateString = "";

        public IEnumerable<SelectListItem>? Players { get; set; }
        public int GameId { get; set; }
        public DateTime Date 
        { 
            get => DateTime.Parse(_dateString); 
            set => _dateString = value.ToShortDateString(); 
        }
        public int Number { get; set; }
        public string Notes { get; set; }
        public IList<AddScoreViewModel> Scores { get; set; }

        public AddGameViewModel()
        {
            Scores = new List<AddScoreViewModel>();
        }
    }
}
