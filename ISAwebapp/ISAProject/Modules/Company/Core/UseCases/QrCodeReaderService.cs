using ISAProject.Modules.Company.API.Public;
namespace ISAProject.Modules.Company.Core.UseCases;

public class QrCodeReaderService: IQrCodeReaderService
{
    public long ReadQrCode(string filePath)
    {
        var qrCodeReadings = IronBarCode.BarcodeReader.Read(filePath);
        if (qrCodeReadings == null) throw new ArgumentException("Exception! Invalid file path!");
        foreach (var qrCoreReading in qrCodeReadings)
        {
            var qrCodeReadingText = qrCoreReading.Text;
            if (qrCodeReadingText.StartsWith("AppointmentEAN"))
            {
                var appointmentEAN = qrCodeReadingText.Split("\n")[0].Split(":")[1].Trim();
                return long.Parse(appointmentEAN);
            }
        }
        return 0;
    }
}