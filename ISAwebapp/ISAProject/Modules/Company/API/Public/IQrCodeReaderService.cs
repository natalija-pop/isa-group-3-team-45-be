namespace ISAProject.Modules.Company.API.Public
{
    public interface IQrCodeReaderService
    {
        long ReadQrCode(Stream stream);
    }
}
