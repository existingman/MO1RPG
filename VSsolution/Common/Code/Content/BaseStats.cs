using System;
using System.Collections.Generic;
using MO1.Definitions.Items;
using System.IO;
using MO1.Tech;

namespace MO1.Content
{
    public struct MatStat
    {
        public Dictionary<DammageType, float> Resistances;
        public Dictionary<DammageType, float> DamageModifier;
        public float Luminosity;
        public float Hue;
        public float Saturation;
        public int BaseRef;

        public MatStat(float slashingModifier, float piercingModifier, float bluntModifier, float slashingResistance, float piercingResistance, float bluntResistance, float h, float s, float l, string baseName)
        {
            Resistances = new Dictionary<DammageType, float>()
            {
                {DammageType.Blunt, bluntModifier},
                {DammageType.Pierce, piercingModifier},
                {DammageType.Slash, slashingModifier}
            };

            DamageModifier = new Dictionary<DammageType, float>()
            {
                {DammageType.Blunt, bluntResistance},
                {DammageType.Pierce, piercingResistance},
                {DammageType.Slash, slashingResistance}
            };
            Hue = h;
            Saturation = s;
            Luminosity = l;
            BaseRef = BaseStats.MatBaseIndicies[baseName];
        }
    }



    public static class BaseStats
    {
        public static TripleDict<MatStat> MatStats;

        public static Dictionary<string, int> MatBaseIndicies;

        public static void Init()
        {
            MatBaseIndicies = new Dictionary<string, int>();
            string dir = Path.Combine(Data.BaseDir, "images");
            dir = Path.Combine(dir, "equipment");
            var subfolders = System.IO.Directory.GetDirectories(dir);
            int counter = 0;
            foreach(string sub in subfolders)
            {
                MatBaseIndicies.Add(Path.GetFileName(sub), counter);
                counter++;
            }


            MatStats = new TripleDict<MatStat>();
            dir = Path.Combine(Data.BaseDir, "stats");
            string filename = Path.Combine(dir, "Materials.csv");
            if (File.Exists(filename))
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(filename);
                file.ReadLine();
                while ((line = file.ReadLine()) != null)
                {
                    string[] vals = line.Split(new string[] { "," }, StringSplitOptions.None);
                    MatStat matstat = new MatStat(float.Parse(vals[1]), float.Parse(vals[2]), float.Parse(vals[3]), float.Parse(vals[4]), float.Parse(vals[5]), float.Parse(vals[6]), float.Parse(vals[7]), float.Parse(vals[8]), float.Parse(vals[9]), vals[10]);
                    MatStats.Add(vals[0], matstat);
                }

                file.Close();
            }

        }

    }
}
