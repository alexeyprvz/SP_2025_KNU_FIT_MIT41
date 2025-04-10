using System;
using System.Collections.Generic;

namespace Lab5_6
{
    public class Copybook
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public bool IsInUse { get; set; }
        public List<string> Notes { get; set; }

        public Copybook()
        {
            Title = "Новий зошит";
            PageCount = 96;
            IsInUse = false;
            Notes = new List<string> { "Порожній" };
        }

        public Copybook(string title, int pageCount, bool isInUse, List<string> notes)
        {
            Title = title;
            PageCount = pageCount;
            IsInUse = isInUse;
            Notes = notes;
        }

        public void AddNote(string note)
        {
            Notes.Add(note);
        }

        public void ClearNotes()
        {
            Notes.Clear();
        }

        public string GetSummary()
        {
            return $"{Title}, сторінок: {PageCount}, активний: {IsInUse}, нотаток: {Notes.Count}";
        }
    }
}
