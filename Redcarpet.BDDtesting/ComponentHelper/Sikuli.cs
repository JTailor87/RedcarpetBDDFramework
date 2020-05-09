using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_UTIL;
using System;

namespace Redcarpet.BDDtesting.ComponentHelper
{
    public static class Sikuli
    {
        public static void SikuliClick(String ImagePath)
        {
            APILauncher Launch = new APILauncher(true);
            Pattern Image = new Pattern(@ImagePath);
            Launch.Start();
            Screen scr = new Screen();
            scr.Wait(Image, 5);
            scr.Click(Image, true);
            Launch.Stop();
        }
        public static void SikuliType(String ImagePath, String text)
        {
            APILauncher Launch = new APILauncher(true);
            Launch.Start();
            Pattern Image = new Pattern(@ImagePath);
            Screen scr = new Screen();
            scr.Wait(Image, 5);
            scr.Type(Image, text, KeyModifier.NONE);
            Launch.Stop();
        }
    }
}
