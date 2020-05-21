using System.ComponentModel.DataAnnotations;

namespace API_StarWars.Models
{
    public class Jedi
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public int Idade { get; set; }
        public string Sabre { get; set; }
    }
}