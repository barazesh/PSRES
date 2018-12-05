namespace PSRES.Web.Services
{
    public interface IController
    {
        void ChangeFrequency(int index, byte frequency);
        void ChangeFrequency(byte frequency);

        void Dim(int index, byte dutycycle);
        void Dim(byte dutycycle);





    }
}