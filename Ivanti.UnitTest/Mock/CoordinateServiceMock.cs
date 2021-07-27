using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Ivanti.UnitTest.Mock
{
	public class CoordinateServiceMock : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[] { };
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
