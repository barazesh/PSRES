using PSRESLogic;

namespace PSRES.Web.Services
{
    public class SystemControl:IController
    {
        public void ChangeFrequency(int index, byte frequency)
        {
            //change one lamp's switching frequency

        }

        public void ChangeFrequency(byte frequency){
            //change all lamps switching frequency at once
        }

        public void Dim(int index, byte dutycycle){
            //change one lamp's duty cycle
        }

        public void Dim(byte dutycycle){
            //change all lamps duty cycle at once
        }
    }
}