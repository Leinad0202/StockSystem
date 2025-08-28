using System.IO;
using System.Text.Json;

namespace EstoqueSystem.Utils
{
    public static class Persistencia
    {
        public static void Salvar<T>(T obj, string caminho)
        {
            string json = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminho, json);
        }

        public static T? Carregar<T>(string caminho)
        {
            if (!File.Exists(caminho)) return default;
            string json = File.ReadAllText(caminho);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
