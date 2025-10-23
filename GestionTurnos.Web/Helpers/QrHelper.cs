using QRCoder;

namespace GestionTurnos.Web.Helpers
{
    public static class QRHelper
    {
        public static string GenerarQRParaAfiliado(int id)
        {
            string url = $"https://localhost:32771/afiliado/detalle/{id}";

            var qrGenerator = new QRCodeGenerator();
            var qrData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var pngQr = new PngByteQRCode(qrData);

            byte[] qrBytes = pngQr.GetGraphic(20);
            return "data:image/png;base64," + Convert.ToBase64String(qrBytes);
        }
    }
}
