using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinTest.Data
{
    public class Folder
    {
        public string FolderName { get; }
        private readonly List<Sound> sounds;
        public bool Checked { get; set; }

        public Folder(string folderName)
        {
            FolderName = folderName;
            sounds = new List<Sound>();
        }

        public void FillSounds(List<string> names)
        {
            foreach (string name in names)
            {
                sounds.Add(new Sound(name));
            }
        }

        public List<string> GetSoundsNames()
        {
            return (from sound in sounds
                select sound.Name).ToList();
        }

        public int GetSoundsCount()
        {
            return sounds.Count;
        }

        public Sound this[int index] => sounds[index];
    }
}