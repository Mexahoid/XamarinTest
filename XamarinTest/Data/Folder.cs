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
        private event Action<Folder> Notify;

        public bool Checked
        {
            get => _checked;
            set
            {
                if(_checked != value)
                    Notify?.Invoke(this);
                _checked = value;
            }
        }

        private int checkedCount;
        private bool _checked;

        public Folder(string folderName, Action<Folder> notifier)
        {
            Notify += notifier;
            FolderName = folderName;
            checkedCount = 0;
            sounds = new List<Sound>();
        }

        public void FillSounds(List<string> names)
        {
            foreach (string name in names)
            {
                sounds.Add(new Sound(name, SoundCheckHandler));
            }
        }

        private void SoundCheckHandler(bool check)
        {
            if (check)
            {
                checkedCount++;
                Checked = true;
            }
            else
            {
                checkedCount--;
                if(checkedCount == 0)
                    Checked = false;
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