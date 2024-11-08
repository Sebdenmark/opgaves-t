using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace dag_4_objekt
{
    //objekt cat 
    public class Cat : Animal
    {
        private string soundFilePath = @"C:\Users\Sebastian Nielsen\Documents\GitHub\opgaves-t\dag 5 objekt\cat.wav";
        public Cat(string name) : base(name) { }
        //the sound that will overwrite the Abstrakt method
        public override void MakeSound()
        {
            Console.WriteLine("Meau");
            // display the sound 
            try
            {
                //play the sound and wait for it to be done 
                using (SoundPlayer player = new SoundPlayer(soundFilePath))
                {
                    player.PlaySync(); 
                }
            }
            //here i have add a debugger so if there is an error we will know 
            catch (Exception ex)
            {
                Console.WriteLine($"could not display sound: {ex.Message}");
            }
        }
    }
}
