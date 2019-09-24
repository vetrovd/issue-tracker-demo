namespace IssueTracker.Issues.Handlers
{
	using AutoMapper;
	using IssueTracker.Issues.Domain.Issue;
	using IssueTracker.Issues.Handlers.CommandsResults;
	using IssueTracker.Issues.Handlers.QueriesResults;

	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Issue, IssueCreatedResult>()
				.ForMember(
					dest => dest.Id,
					opts => opts.MapFrom(source => source.Id))
				.ForMember(
					dest => dest.Name,
					opts => opts.MapFrom(source => source.Name.Value))
				.ForMember(
					dest => dest.Description,
					opts => opts.MapFrom(source => source.Description.Value));


			CreateMap<Issue, GetFullIssueResult>()
				.ForMember(
					dest => dest.Id,
					opts => opts.MapFrom(source => source.Id))
				.ForMember(
					dest => dest.Name,
					opts => opts.MapFrom(source => source.Name.Value))
				.ForMember(
					dest => dest.Description,
					opts => opts.MapFrom(source => source.Description.Value));


			CreateMap<Issue, GetFullIssueResultDynamic>()
				.ForMember(
					dest => dest.Id,
					opts => opts.MapFrom(source => source.Id))
				.ForMember(
					dest => dest.Name,
					opts => opts.MapFrom(source => source.Name.Value))
				.ForMember(
					dest => dest.Description,
					opts => opts.MapFrom(source => source.Description.Value))
				.ForAllMembers(x=> x.ExplicitExpansion());
		}
	}
}