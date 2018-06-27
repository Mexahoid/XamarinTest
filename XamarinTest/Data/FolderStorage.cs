using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;

namespace XamarinTest.Data
{
    public class FolderStorage
    {
        private static FolderStorage _instance;
        private readonly List<Folder> folders;
        private event Action<int> Notify;

        private FolderStorage()
        {
            folders = new List<Folder>();
            FillRandom();
        }

        private void FillRandom()
        {
            for (int i = 0; i < 40; i++)
            {
                folders.Add(new Folder($"Папка {i + 1}", NotifyStorage));

                List<string> sounds = new List<string>();
                for (int j = 0; j < 20; j++)
                {
                    sounds.Add($"Звук { i * j}");
                }
                folders[folders.Count - 1].FillSounds(sounds);
            }
        }

        private void NotifyStorage(Folder target)
        {
            Notify?.Invoke(folders.IndexOf(target));
        }

        public void SetNotifier(Action<int> notifier)
        {
            Notify += notifier;
        }

        public static FolderStorage GetInstance()
        {
            return _instance ?? (_instance = new FolderStorage());
        }

        public Folder this[int index] => folders[index];

        public void AddFolder(string name, List<string> sounds)
        {
            var fld = new Folder(name, NotifyStorage);
            fld.FillSounds(sounds);
            folders.Add(fld);
        }

        public int GetFolderCount()
        {
            return folders.Count;
        }

        public int GetFolderSoundsCount(string folderName)
        {
            Folder fld = (from folder in folders
                          where folder.FolderName == folderName
                          select folder).FirstOrDefault();
            return fld?.GetSoundsCount() ?? -1;
        }

        public List<string> GetFolderNames()
        {
            return (from folder in folders
                    select folder.FolderName).ToList();
        }

        public List<string> GetFolderSoundsNames(string folderName)
        {
            Folder fld = (from folder in folders
                          where folder.FolderName == folderName
                          select folder).FirstOrDefault();
            return fld?.GetSoundsNames();
        }
    }
}