using System;
using System.Collections.Generic;


namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _rand;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _rand = new Random();
            _words = new List<Word>();

            var tokens = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var t in tokens)
                 _words.Add(new Word(t));
        }
        public string GetDisplayText()
        {
            var parts = _words.Select(w => w.GetDisplayText());
            return $"{_reference.GetDisplayText()} - {string.Join(" ", parts)}";
        }

        public void HideRandomWords(int Count)
        {
            var candidates = _words.Where(w => w.HasLetters() && !w.IsHidden()).ToList();
            if (candidates.Count == 0) return;

            Count = Math.Min(Count, candidates.Count);
            for (int i = 0; i < Count; i++)
            {
                int idx = _rand.Next(candidates.Count);
                candidates[idx].Hide();
                candidates.RemoveAt(idx);
            }
        }
        public bool IsFullyHidden()
        {
            return _words.Where(w => w.HasLetters()).All(w => w.IsHidden());
        }
        public void Reset()
        {
            foreach (var w in _words) w.Reveal();
        }
    }
}