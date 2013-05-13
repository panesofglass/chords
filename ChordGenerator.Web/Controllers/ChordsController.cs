using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChordGenerator.Web.Models;
using Music;

namespace ChordGenerator.Web.Controllers
{
    public class ChordsController : ApiController
    {
        private readonly IChordRepository _repository;

        public ChordsController()
            : this(new SixStringGuitarChordRepository())
        {
        }

        public ChordsController(IChordRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            _repository = repository;
        }

        public IEnumerable<string> GetAll()
        {
            return _repository.GetKeys();
        }

        public IEnumerable<TFrettedNote> Get(string id)
        {
            return _repository.Get(id);
        }
    }
}
