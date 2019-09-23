namespace IssueTracker.Tests.Issues.Domain.Issues
{
	using System;
	using IssueTracker.Framework.Exceptions;
	using IssueTracker.Issues.Domain.Issue;
	using Xunit;

	public class DescriptionTests
	{
		[Theory]
		[InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit")]
		public void InitDescriptionNormal(string description)
		{
			Assert.NotNull(new Description(description));
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque vel sem fermentum, sagittis " +
		            "nisi ac, pellentesque diam. Praesent diam lectus, mollis ut nibh id, lacinia tincidunt tortor. " +
		            "Duis tristique, felis eu vulputate luctus, quam nunc amet.")]
		public void InitDescriptionCheckBorders(string description)
		{
			Assert.Throws<InvalidEntityException>(() => new Description(description));
		}

		[Theory]
		[InlineData("Test 1", "Test 2")]
		public void DescriptionCheckEqual(string string1, string string2)
		{

			var name1 = new Description(string1);
			var name2 = new Description(string.Copy(string1));
			Assert.Equal(name1, name2);

			name1 = new Description(string1);
			name2 = new Description(string2);
			Assert.NotEqual(name1, name2);
		}
	}
}