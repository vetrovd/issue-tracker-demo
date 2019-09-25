namespace IssueTracker.Tests.Issues.Domain.Issues
{
	using IssueTracker.Contexts.Core.Exceptions;
	using IssueTracker.Issues.Domain.Issue;
	using Xunit;

	public class NameTests
	{
		[Theory]
		[InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit")]
		public void InitNameNormal(string name)
		{
			Assert.NotNull(new Name(name));
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas at tristique nunc, sit amet nullam.")]
		public void InitNameCheckBorders(string name)
		{
			Assert.Throws<InvalidEntityException>(() => new Name(name));
		}

		[Theory]
		[InlineData("Test 1", "Test 2")]
		public void NamesCheckEqual(string string1, string string2)
		{
			var name1 = new Name(string1);
			var name2 = new Name(string.Copy(string1));
			Assert.Equal(name1, name2);

			name1 = new Name(string1);
			name2 = new Name(string2);
			Assert.NotEqual(name1, name2);
		}
	}
}