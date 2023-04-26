using System.Xml.Serialization;

namespace BlogSemedo.Models
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Artigo));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Artigo)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "Artigo")]
    public class Artigo
    {

        [XmlElement(ElementName = "DataArtigo")]
        public string DataArtigo { get; set; }

        [XmlElement(ElementName = "Autor")]
        public string Autor { get; set; }

        [XmlElement(ElementName = "Titulo")]
        public string Titulo { get; set; }

        [XmlElement(ElementName = "Imagem")]
        public string Imagem { get; set; }

        [XmlElement(ElementName = "Resumo")]
        public string Resumo { get; set; }

        [XmlElement(ElementName = "CorpoArtigo")]
        public string CorpoArtigo { get; set; }
    }




}
