// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "ChordGenerator.fs"
open Music
open Music.ChordGenerator

// Examples:

// Ordinary 6-string with EADGBE tuning:
let standardGuitar = new TInstrument(
                            19, // Including nut
                            [|  // Treble side
                                {label=ENat; octave=2}
                                {label=BNat; octave=2}
                                {label=GNat; octave=1}
                                {label=DNat; octave=1}
                                {label=ANat; octave=1}
                                {label=ENat; octave=0}
                                // Bass side
                            |]
                          )

let droppedDGuitar = new TInstrument(
                            19, // Including nut
                            [|  // Treble side
                                {label=ENat; octave=2}
                                {label=BNat; octave=2}
                                {label=GNat; octave=1}
                                {label=DNat; octave=1}
                                {label=ANat; octave=1}
                                {label=DNat; octave=0}
                                // Bass side
                            |]
                          )

let celticGuitar =  new TInstrument(
                            19, // Including nut
                            [|  // Treble side
                                {label=DNat; octave=2}
                                {label=ANat; octave=2}
                                {label=GNat; octave=1}
                                {label=DNat; octave=1}
                                {label=ANat; octave=1}
                                {label=DNat; octave=0}
                                // Bass side
                            |]
                          )

// This is the first and last time I shall have involvement with 'progressive Metal'.
// Seven stringed guitar used by 'TesseracT' - no, really: http://en.wikipedia.org/wiki/DADGAD
let tesseractGuitar =  new TInstrument(
                                19, // Including nut
                                [|  // Treble side
                                    {label=EFlat; octave=2}
                                    {label=BFlat; octave=2}
                                    {label=GFlat; octave=1}
                                    {label=EFlat; octave=1}
                                    {label=BFlat; octave=1}
                                    {label=FNat; octave=0}
                                    {label=BFlat; octave=0}
                                    // Bass side
                                |]
                              )

let plectrumBanjo =  new TInstrument(
                            23, // Including nut
                            [|  // Treble side
                                {label=DNat; octave=1}
                                {label=BNat; octave=0}
                                {label=GNat; octave=0}
                                {label=CNat; octave=0}
                                // Bass side
                            |]
                          )

// Some chords to play:
let CMaj = chordOf {label=CNat; octave=1} major
let DMaj = chordOf {label=DNat; octave=1} major
let DMin = chordOf {label=DNat; octave=1} minor
let D7 = chordOf {label=DNat; octave=1} seventh
let DMaj7 = chordOf {label=DNat; octave=1} majorSeventh
let EMaj = chordOf {label=ENat; octave=0} major
let EMin = chordOf {label=ENat; octave=0} minor
let AMaj = chordOf {label=ANat; octave=1} major
let AMin = chordOf {label=ANat; octave=1} minor
let ADim = chordOf {label=ANat; octave=1} diminished

// Generate fingerings for a standard guitar
findShape standardGuitar 0 3 CMaj |> printShape "C Major" |> printfn "%s"
findShape standardGuitar 0 3 EMaj |> printShape "E Major" |> printfn "%s"
findShape standardGuitar 0 3 EMin |> printShape "E Minor" |> printfn "%s"
findShape standardGuitar 0 3 AMaj |> printShape "A Major" |> printfn "%s"
findShape standardGuitar 0 3 AMin |> printShape "A Minor" |> printfn "%s"
findShape standardGuitar 0 3 ADim |> printShape "A Dim" |> printfn "%s"
findShape standardGuitar 0 3 DMaj |> printShape "D Major" |> printfn "%s"
findShape standardGuitar 0 3 DMin |> printShape "D Minor" |> printfn "%s"
findShape standardGuitar 0 3 D7 |> printShape "D seventh" |> printfn "%s"
findShape standardGuitar 0 3 DMaj7 |> printShape "D major seventh" |> printfn "%s"

// Some lower D-chords for the dropped D guitar and Celtic guitars:
let DMajLow = chordOf {label=DNat; octave=0} major
let DMinLow = chordOf {label=DNat; octave=0} minor
let D7Low = chordOf {label=DNat; octave=0} seventh
let DMaj7Low = chordOf {label=DNat; octave=0} majorSeventh

// Generate fingerings for a dropped-D guitar
findShape droppedDGuitar 0 3 CMaj |> printShape "C Major" |> printfn "%s"
findShape droppedDGuitar 0 3 EMaj |> printShape "E Major" |> printfn "%s"
findShape droppedDGuitar 0 3 EMin |> printShape "E Minor" |> printfn "%s"
findShape droppedDGuitar 0 3 AMaj |> printShape "A Major" |> printfn "%s"
findShape droppedDGuitar 0 3 AMin |> printShape "A Minor" |> printfn "%s"
findShape droppedDGuitar 0 3 ADim |> printShape "A Dim" |> printfn "%s"
findShape droppedDGuitar 0 3 DMajLow |> printShape "D Major (low)" |> printfn "%s"
findShape droppedDGuitar 0 3 DMinLow |> printShape "D Minor (low)" |> printfn "%s"
findShape droppedDGuitar 0 3 D7Low |> printShape "D seventh (low)" |> printfn "%s"
findShape droppedDGuitar 0 3 DMaj7Low |> printShape "D major seventh (low)" |> printfn "%s"

// Generate fingerings for a Celtic guitar
findShape celticGuitar 0 3 CMaj |> printShape "C Major" |> printfn "%s"
findShape celticGuitar 0 3 EMaj |> printShape "E Major" |> printfn "%s"
findShape celticGuitar 0 3 EMin |> printShape "E Minor" |> printfn "%s"
findShape celticGuitar 0 3 AMaj |> printShape "A Major" |> printfn "%s"
findShape celticGuitar 0 3 AMin |> printShape "A Minor" |> printfn "%s"
findShape celticGuitar 0 3 ADim |> printShape "A Dim" |> printfn "%s"
// Needs a bit more of a stretch to get an F#
findShape celticGuitar 0 4 DMajLow |> printShape "D Major (low)" |> printfn "%s" 
findShape celticGuitar 0 3 DMinLow |> printShape "D Minor (low)" |> printfn "%s"
findShape celticGuitar 0 3 D7Low |> printShape "D seventh (low)" |> printfn "%s"
findShape celticGuitar 0 3 DMaj7Low |> printShape "D major seventh (low)" |> printfn "%s"

// Generate fingerings for a TesseracT's guitar
findShape tesseractGuitar 0 3 CMaj |> printShape "C Major" |> printfn "%s"
findShape tesseractGuitar 0 3 EMaj |> printShape "E Major" |> printfn "%s"
findShape tesseractGuitar 0 3 EMin |> printShape "E Minor" |> printfn "%s"
findShape tesseractGuitar 0 3 AMaj |> printShape "A Major" |> printfn "%s"
findShape tesseractGuitar 0 3 AMin |> printShape "A Minor" |> printfn "%s"

// We have to go up the neck a bit to find some Ds - and even then these are
// probably unplayable at the moment:
findShape tesseractGuitar 4 7 ADim |> printShape "A Dim" |> printfn "%s"
findShape tesseractGuitar 4 7 DMaj |> printShape "D Major" |> printfn "%s"
findShape tesseractGuitar 4 7 DMin |> printShape "D Minor" |> printfn "%s"
findShape tesseractGuitar 4 7 D7 |> printShape "D seventh" |> printfn "%s"
findShape tesseractGuitar 4 7 DMaj7 |> printShape "D major seventh" |> printfn "%s"

// Generate fingerings for a plectrum banjo
findShape plectrumBanjo 0 3 CMaj |> printShape "C Major" |> printfn "%s"

// Up the neck a bit for Es - I don't have a banjo to check these are playable!
findShape plectrumBanjo 1 4 EMaj |> printShape "E Major" |> printfn "%s"
findShape plectrumBanjo 1 4 EMin |> printShape "E Minor" |> printfn "%s"

findShape plectrumBanjo 0 3 AMaj |> printShape "A Major" |> printfn "%s"
findShape plectrumBanjo 0 3 AMin |> printShape "A Minor" |> printfn "%s"
findShape plectrumBanjo 0 3 ADim |> printShape "A Dim" |> printfn "%s"
findShape plectrumBanjo 0 3 DMaj |> printShape "D Major" |> printfn "%s"
findShape plectrumBanjo 0 3 DMin |> printShape "D Minor" |> printfn "%s"
findShape plectrumBanjo 0 3 D7 |> printShape "D seventh" |> printfn "%s"
findShape plectrumBanjo 0 3 DMaj7 |> printShape "D major seventh" |> printfn "%s"

// Example output for the first standard guitar line:
//  C Major
//  String 1 fret 0
//  String 2 fret 1
//  String 3 fret 0
//  String 4 fret 2
//  String 5 fret 3

// Example output for the final banjo line:
//  D major seventh
//  String 1 fret 0
//  String 2 fret 2
//  String 3 fret 2
//  String 4 fret 2