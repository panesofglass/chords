﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Music;

namespace ChordGenerator.Web.Models
{
    public interface IChordRepository
    {
        IEnumerable<string> GetKeys();
        IEnumerable<TFrettedNote> Get(string chordName);
        void Add(string chordName, TNote[] chord);
        void Remove(string chordName);
    }
}
