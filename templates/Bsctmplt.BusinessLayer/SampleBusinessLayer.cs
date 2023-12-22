using Bsctmplt.Dto.Sample;
using Bsctmplt.Repository;
using System.ComponentModel.DataAnnotations;

namespace Bsctmplt.BusinessLayer
{
    public class SampleBusinessLayer
    {
        private ISampleRepository _Repository;

        public SampleBusinessLayer(ISampleRepository repository)
        {
            _Repository = repository;
        }

        public int? GetValueById(int id)
        {
            return _Repository.GetSingle(id)?.Value;
        }

        public List<SampleDto> GetAll()
        {
            return _Repository.Fetch()
                .Select(x => new SampleDto
                {
                    Id = x.Id,
                    Value = x.Value
                }).ToList();
        }

        public List<ValidationResult> Create(SampleDto dto)
        {
            var existing = _Repository.GetSingle(x => x.Value == dto.Value);

            if (existing != null)
            {
                return new List<ValidationResult>
                {
                    new ValidationResult("DUPLICATE")
                };
            }

            _Repository.Add(new Entity.Sample
            {
                Value = dto.Value
            });

            return new List<ValidationResult>();
        }

        public List<ValidationResult> Update(SampleDto dto)
        {
            var sample = _Repository.GetSingle(x => x.Id == dto.Id);

            if (sample == null)
            {
                return new List<ValidationResult>
                {
                    new ValidationResult("NOT_FOUND")
                };
            }

            var existing = _Repository.GetSingle(x => x.Value == dto.Value);

            if (existing != null)
            {
                return new List<ValidationResult>
                {
                    new ValidationResult("DUPLICATE")
                };
            }

            sample.Value = dto.Value;

            _Repository.Update(sample);


            return new List<ValidationResult>();
        }

        public List<ValidationResult> Delete(int id)
        {
            var sample = _Repository.GetSingle(x => x.Id == id);

            if (sample == null)
            {
                return new List<ValidationResult>
                {
                    new ValidationResult("NOT_FOUND")
                };
            }

            _Repository.Delete(sample);

            return new List<ValidationResult>();
        }
    }
}

