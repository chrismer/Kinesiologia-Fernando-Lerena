using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Convierte fotos de perfil entre archivo, bytes (columna usuario.foto) e Image.
    /// </summary>
    public static class FotoHelper
    {
        /// <summary>Lado máximo en píxeles. Una foto de celular pasa de varios MB a unos 20 KB.</summary>
        public const int LadoMaximo = 256;

        /// <summary>
        /// Lee una imagen del disco, la achica para que el lado mayor sea LadoMaximo
        /// y la devuelve como JPEG. Lanza excepción si el archivo no es una imagen.
        /// </summary>
        public static byte[] DesdeArchivo(string ruta)
        {
            using var original = Image.FromFile(ruta);

            var escala = Math.Min(1.0, (double)LadoMaximo / Math.Max(original.Width, original.Height));
            var ancho = Math.Max(1, (int)Math.Round(original.Width * escala));
            var alto = Math.Max(1, (int)Math.Round(original.Height * escala));

            using var chica = new Bitmap(ancho, alto);
            using (var g = Graphics.FromImage(chica))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White); // PNG con transparencia: fondo blanco en el JPEG
                g.DrawImage(original, 0, 0, ancho, alto);
            }

            using var ms = new MemoryStream();
            chica.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        /// <summary>
        /// Devuelve una Image independiente del stream (se puede asignar a un PictureBox).
        /// Null si no hay bytes o están corruptos.
        /// </summary>
        public static Image? ABitmap(byte[]? foto)
        {
            if (foto is null || foto.Length == 0)
                return null;

            try
            {
                using var ms = new MemoryStream(foto);
                using var img = Image.FromStream(ms);
                return new Bitmap(img);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
}
