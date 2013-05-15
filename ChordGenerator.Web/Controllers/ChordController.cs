using System;
using System.Collections.Generic;
using System.Net.Http;
using ChordGenerator.Web.Models;
using Music;
using Newtonsoft.Json;
using WebApiContrib.Formatting.CollectionJson;

namespace ChordGenerator.Web.Controllers
{
    public class ChordController : CollectionJsonController<Chord, string>
    {
        private readonly IChordRepository _repository;

        public ChordController()
            : this(new SixStringGuitarChordRepository(), new ChordDocumentWriter(), new ChordDocumentReader())
        {
        }

        public ChordController(IChordRepository repository,
            ICollectionJsonDocumentWriter<Chord> writer,
            ICollectionJsonDocumentReader<Chord> reader)
            : base(writer, reader)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            _repository = repository;
        }

        protected override IEnumerable<Chord> Read(HttpResponseMessage response)
        {
            return _repository.GetAll();
        }

        protected override Chord Read(string id, HttpResponseMessage response)
        {
            return _repository.Get(id);
        }
    }

    public class ChordDocumentReader : ICollectionJsonDocumentReader<Chord>
    {
        public Chord Read(WriteDocument document)
        {
            var template = document.Template;
            var name = template.Data.GetDataByName("name").Value;
            var frettedNote = JsonConvert.DeserializeObject<IEnumerable<TFrettedNote>>(template.Data.GetDataByName("frettedNote").Value);
            return new Chord(name, frettedNote);
        }
    }

    public class ChordDocumentWriter : ICollectionJsonDocumentWriter<Chord>
    {
        public ReadDocument Write(IEnumerable<Chord> chords)
        {
            var document = new ReadDocument();
            var collection = document.Collection;
            collection.Version = "1.0";
            collection.Href = new Uri("http://example.org/chords");
            collection.Links.Add(new Link { Rel = "feed", Href = new Uri("http://example.org/chords/feed") });

            foreach (var chord in chords)
            {
                var item = new Item { Href = new Uri("http://example.org/chords/" + chord.Name) };
                item.Data.Add(new Data { Name = "name", Value = chord.Name, Prompt = "Name" });
                item.Data.Add(new Data { Name = "frettedNote", Value = JsonConvert.SerializeObject(chord.FrettedNote), Prompt = "Fretted Note" });
                collection.Items.Add(item);
            }

            var query = new Query { Rel = "search", Href = new Uri("http://example.org/chords/search"), Prompt = "Search" };
            query.Data.Add(new Data { Name = "name" });
            collection.Queries.Add(query);

            var data = collection.Template.Data;
            data.Add(new Data { Name = "name", Prompt = "Name" });

            return document;
        }
    }
}
