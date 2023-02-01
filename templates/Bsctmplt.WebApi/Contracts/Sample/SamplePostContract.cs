using System;
using Bsctmplt.Dto.Sample;

namespace Bsctmplt.WebApi.Contracts.Sample
{
	public class SamplePostContract
	{
        public int Value { get; set; }

        public static explicit operator SampleDto(SamplePostContract contract)
        {
            return new SampleDto
            {
                Value = contract.Value
            };
        }
    }
}

