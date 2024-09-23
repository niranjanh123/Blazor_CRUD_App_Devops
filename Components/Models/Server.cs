using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Components.Models
{
    public class Server
    {
        public Server()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2);
            status = randomNumber == 0 ? false : true;
        }

        public int ID { get; set; }
        public bool status { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Location { get; set; }
    }
}
