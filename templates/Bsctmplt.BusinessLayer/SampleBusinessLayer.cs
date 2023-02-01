using System;
using System.ComponentModel.DataAnnotations;
using Bsctmplt.Dto.Sample;
using Bsctmplt.EntityFrameworkCore;
using Humanizer;

namespace Bsctmplt.BusinessLayer
{
	public class SampleBusinessLayer
    {
		private BsctmpltDbContext _Context;

        public SampleBusinessLayer(BsctmpltDbContext dbContext)
		{
			_Context = dbContext;
		}

        public int? GetValueById(int id)
        {
            return _Context.Samples.SingleOrDefault(x => x.Id == id)?.Value;
        }

        public List<int> GetValues()
        {
            return _Context.Samples.Select(x => x.Value).ToList();
        }

        public List<ValidationResult> Create(SampleDto dto)
        {
            var existing = _Context.Samples.SingleOrDefault(x => x.Value == dto.Value);

            if(existing != null)
            {
                return new List<ValidationResult>
                {
                    new ValidationResult("DUPLICATE")
                };
            }

            _Context.Samples.Add(new Entity.Sample
            {
                Value = dto.Value
            });

            _Context.SaveChanges();

            return new List<ValidationResult>();
        }

        public List<ValidationResult> Update(SampleDto dto)
        {
            var sample = _Context.Samples.SingleOrDefault(x => x.Id == dto.Id);

            if (sample == null)
            {
                return new List<ValidationResult>
                {
                    new ValidationResult("NOT_FOUND")
                };
            }

            var existing = _Context.Samples.SingleOrDefault(x => x.Value == dto.Value);

            if (existing != null)
            {
                return new List<ValidationResult>
                {
                    new ValidationResult("DUPLICATE")
                };
            }

            sample.Value = dto.Value;

            _Context.Samples.Update(sample);

            _Context.SaveChanges();


            return new List<ValidationResult>();
        }

        public List<ValidationResult> Delete(int id)
        {
            var sample = _Context.Samples.SingleOrDefault(x => x.Id == id);

            if (sample == null)
            {
                return new List<ValidationResult>
                {
                    new ValidationResult("NOT_FOUND")
                };
            }

            _Context.Samples.Remove(sample);

            _Context.SaveChanges();

            return new List<ValidationResult>();
        }
    }
}

