using System.ComponentModel.DataAnnotations;
namespace jobconnect.Models
{
    public class SearchViewModel
    {
        public List<Job> Jobs { get; set; } = new List<Job>();
        public List<Profession> Professions { get; set; } = new List<Profession>();
        public List<Location> Locations { get; set; } = new List<Location>();
    }

}
