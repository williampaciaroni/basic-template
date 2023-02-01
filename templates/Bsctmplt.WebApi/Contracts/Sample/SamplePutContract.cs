using System;
using Bsctmplt.Dto.Sample;

namespace Bsctmplt.WebApi.Contracts.Sample
{
	public class SamplePutContract
    {
		public int Id { get; set; }
		public int Value { get; set; }

		public static explicit operator SampleDto (SamplePutContract contract)
		{
			return new SampleDto
			{
				Id = contract.Id,
				Value = contract.Value
			};
		}
	}
}

