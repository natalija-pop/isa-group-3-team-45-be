using ISAProject.Modules.Company.API.Public;
namespace ISAProject.Modules.Company.Core.UseCases;

public class QrCodeReaderService: IQrCodeReaderService
{
    public long ReadQrCode(Stream stream)
    {
        var qrCodeReadings = IronBarCode.BarcodeReader.Read(stream);
        if (qrCodeReadings == null || !qrCodeReadings.Any())
        {
            throw new ArgumentException("Exception! No valid QR code found in the provided stream.");
        }

        foreach (var qrCodeReading in qrCodeReadings)
        {
            var qrCodeReadingText = qrCodeReading.Text;
            if (qrCodeReadingText.StartsWith("AppointmentEAN"))
            {
                var appointmentEAN = qrCodeReadingText.Split("\n")[0].Split(":")[1].Trim();
                return long.Parse(appointmentEAN);
            }
        }
        return 0;
    }
}