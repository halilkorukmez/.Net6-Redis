using AutoMapper;

namespace Services.AutoMapper;

public class BaseMappingConfig : Profile
{
    private static IMapper _mapper;
    private BaseMappingConfig(){}

    public static IMapper GetConfig()
    {
        if (_mapper == null)
            _mapper = new MapperConfiguration(c => c.AddProfile(new MappingProfiles())).CreateMapper();
        return _mapper;
    }
}