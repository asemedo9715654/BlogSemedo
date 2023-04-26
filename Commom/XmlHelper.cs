using System.Text;
using System.Xml.Serialization;

namespace BlogSemedo.Commom
{
    public class XmlHelper
    {
        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
        private static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                var stringwriter = new Utf8StringWriter();
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
            catch (Exception exception)
            {
                return "Erro: " + exception.Message;//caso não conseguir serializar
            }
        }

        /// <summary>
        /// Tranforma uma string XML em tipo de objecto que foi passado como parametro
        /// </summary>
        /// <typeparam name = "T" ></ typeparam >
        /// < param name="xmlText">string xml</param>
        /// <returns>Retorna o Objecto</returns>
        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch

            {
                throw new Exception("Não foi possível desserializar.");
            }
        }

    }
}
