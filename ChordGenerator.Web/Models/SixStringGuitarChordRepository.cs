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

        private readonly List<Chord> _chords;

        public SixStringGuitarChordRepository()
        {
            _chords = new List<Chord>();

            var data = new Dictionary<string, TNote[]>
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
            
            foreach (var entry in data)
                Add(entry.Key, entry.Value);
        }

        public IEnumerable<Chord> GetAll()
        {
            return _chords;
        }

        public Chord Get(string chordName)
        {
            if (chordName == null)
                throw new ArgumentNullException(chordName);

            return _chords.SingleOrDefault(x => x.Name.Equals(chordName, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(string chordName, TNote[] chord)
        {
            if (chordName == null)
                throw new ArgumentNullException(chordName);

            _chords.Add(new Chord(chordName, Music.ChordGenerator.findShape(standardGuitar, 0, 3, chord)));
        }

        public void Remove(string chordName)
        {
            if (chordName == null)
                throw new ArgumentNullException(chordName);

            var chord = _chords.SingleOrDefault(x => x.Name.Equals(chordName, StringComparison.OrdinalIgnoreCase));
            if (chord != null)
                _chords.Remove(chord);
        }
    }
}
