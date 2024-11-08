using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace dag_4_objekt
{
    //objekt dog 
    public class Dog : Animal
    {
        private string soundFilePath = @"C:\Users\Sebastian Nielsen\Documents\GitHub\opgaves-t\dag 5 objekt\dog.wav";
        public Dog(string name) : base(name) { }

        //the sound that will override the Abstrakt method
        public override void MakeSound()
        {
            Console.WriteLine("Vow");
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
