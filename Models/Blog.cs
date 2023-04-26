namespace BlogSemedo.Models
{
    public class Blog
    {
        public Artigo Principal { get; set; }
        public Artigo DestaqueUm { get; set; }
        public Artigo DestaqueDois { get; set; }
        
        public List<Artigo> Artigos { get; set; }
    }
}
