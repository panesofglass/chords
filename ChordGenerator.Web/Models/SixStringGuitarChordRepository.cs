using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Music;

namespace ChordGenerator.Web.Models
{
    public class SixStringGuitarChordRepository : IChordRepository
    {
        private static TInstrument standardGuitar = new TInstrument(19, // Including nut
            new[]
            {  // Treble side
               new TNote(Music.ChordGenerator.ENat, 2),
               new TNote(Music.ChordGenerator.BNat, 2),
               new TNote(Music.ChordGenerator.GNat, 1),
               new TNote(Music.ChordGenerator.DNat, 1),
               new TNote(Music.ChordGenerator.ANat, 1),
               new TNote(Music.ChordGenerator.ENat, 0),
               // Bass side
            });

        private readonly Dictionary<string, TNote[]> _chords;

        public SixStringGuitarChordRepository()
        {
            _chords = new Dictionary<string, TNote[]>
            {
                { "CMaj", Music.ChordGenerator.chordOf(new TNote(Music.ChordGenerator.CNat, 1), Music.ChordGenerator.major) },
                { "DMaj", Music.ChordGenerator.chordOf(new TNote(Music.ChordGenerator.DNat, 1), Music.ChordGenerator.major) },
                { "DMin", Music.ChordGenerator.chordOf(new TNote(Music.ChordGenerator.DNat, 1), Music.ChordGenerator.minor) },
                { "D7", Music.ChordGenerator.chordOf(new TNote(Music.ChordGenerator.DNat, 1), Music.ChordGenerator.seventh) },
                { "DMaj7", Music.ChordGenerator.chordOf(new TNote(Music.ChordGenerator.DNat, 1), Music.ChordGenerator.majorSeventh) },
                { "EMaj", Music.ChordGenerator.chordOf(new TNote(Music.ChordGenerator.ENat, 0), Music.ChordGenerator.major) },
                { "EMin", Music.ChordGenerator.chordOf(new TNote(Music.ChordGenerator.ENat, 0), Music.ChordGenerator.minor) },
                { "AMaj", Music.ChordGenerator.chordOf(new TNote(Music.ChordGenerator.ANat, 1), Music.ChordGenerator.major) },
                { "AMin", Music.ChordGenerator.chordOf(new TNote(Music.ChordGenerator.ANat, 1), Music.ChordGenerator.minor) },
                { "ADim", Music.ChordGenerator.chordOf(new TNote(Music.ChordGenerator.ANat, 1), Music.ChordGenerator.diminished) },
            };
        }

        public IEnumerable<string> GetKeys()
        {
            return _chords.Keys;
        }

        public IEnumerable<TFrettedNote> Get(string chordName)
        {
            if (chordName == null)
                throw new ArgumentNullException(chordName);
            if (_chords.ContainsKey(chordName))
                return Music.ChordGenerator.findShape(standardGuitar, 0, 3, _chords[chordName]);
            return null;
        }

        public void Add(string chordName, TNote[] chord)
        {
            if (chordName == null)
                throw new ArgumentNullException(chordName);
            _chords[chordName] = chord;
        }

        public void Remove(string chordName)
        {
            if (chordName == null)
                throw new ArgumentNullException(chordName);
            if (_chords.ContainsKey(chordName))
                _chords.Remove(chordName);
        }
    }
}
