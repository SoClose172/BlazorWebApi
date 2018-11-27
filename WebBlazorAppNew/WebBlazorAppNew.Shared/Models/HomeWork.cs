namespace WebBlazorAppNew.Shared.Models
{
    public class HomeWork
    {
        
        public int Id { get; set; }//Mifort: Поменял на ID

        // [Required]
        public string Name { get; set; }
        //  [Required]

        public int Block { get; set; }
        //  [Required]

        public int Rating { get; set; }
        //  [Required]

        public string Comment { get; set; }
    }
}