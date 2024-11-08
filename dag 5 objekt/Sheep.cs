using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dag_4_objekt
{
    // Objekt sheep
    public class Sheep : Animal
    {
        private string soundFilePath = @"C:\Users\Sebastian Nielsen\Documents\GitHub\opgaves-t\dag 5 objekt\sheep.wav";

        public Sheep(string name) : base(name) { }

        // this is the sound tha overrides the abstrakt method 
        public override void MakeSound()
        {
            Console.WriteLine("Baaaah"); 

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
